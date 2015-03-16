
using Bec.TargetFramework.Workflow.Test.FirstDataTransactionService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Bec.TargetFramework.Workflow.Test.Objects
{
    public class Merchant
{
    private readonly string _gatewayId;
    private readonly string _password;
    private readonly string _keyId;
    private readonly string _hmac;
    private readonly bool _isDemo;

    private const string ProdUrl = "https://api.globalgatewaye4.firstdata.com/transaction/v12";
    private const string TestUrl = "https://api.demo.globalgatewaye4.firstdata.com/transaction/v12";


    public Merchant(string gatewayId, string password, string hmac, string keyId, bool isDemo = true)
    {
        _gatewayId = gatewayId;
        _password = password;
        _hmac = hmac;
        _keyId = keyId;
        _isDemo = isDemo;
    }

    public MerchantResponse Charge(int orderId, string cardHoldersName, string cardNumber, decimal amount, 
        int expirationMonth, int expirationYear, int ccv, string address, string city, string state, string zip)
    {            
        var client = new ServiceSoapClient(new BasicHttpBinding(BasicHttpSecurityMode.Transport), 
            new EndpointAddress(_isDemo ? TestUrl : ProdUrl));                                           
        client.ChannelFactory.Endpoint.Behaviors.Add(new HmacHeaderBehaivour(_hmac,_keyId));            

        TransactionResult result = client.SendAndCommit(new Transaction
                                                {                                                                        
                                                    ExactID = _gatewayId,
                                                    Password = _password,
                                                    Transaction_Type = "00",                                                                        
                                                    Card_Number = cardNumber,
                                                    CardHoldersName = cardHoldersName,                                                                                                                                                
                                                    DollarAmount = amount.ToString("F"),
                                                    Expiry_Date = string.Format("{0:D2}{1}",expirationMonth,expirationYear),
                                                    Customer_Ref = orderId.ToString(),
                                                    VerificationStr1 = string.Format("{0}|{1}|{2}|{3}|US",address,zip,city,state),
                                                    VerificationStr2 = ccv.ToString()
                                                });
        var response = new MerchantResponse
                        {
                            IsTransactionApproved = result.Transaction_Approved,
                            IsError = result.Transaction_Error
                        };
        if (!result.Transaction_Approved && !result.Transaction_Error)
        {
            response.Message = string.Format("Error {0}: {1}", result.Bank_Resp_Code, result.Bank_Message);
        }
        if (!result.Transaction_Approved && result.Transaction_Error)
        {
            response.Message = string.Format("Error {0}: {1}",result.EXact_Resp_Code,result.EXact_Message);
        }
        if (result.Transaction_Approved)
        {
            response.Message = result.Authorization_Num;
        }
        return response;
    }               

    class HmacHeaderBehaivour: IEndpointBehavior
    {
        private readonly string _hmac;
        private readonly string _keyId;

        public HmacHeaderBehaivour(string hmac, string keyId)
        {
            _hmac = hmac;
            _keyId = keyId;
        }

        public void Validate(ServiceEndpoint endpoint)
        {                
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {                
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {                
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new HmacHeaderInspector(_hmac,_keyId));                                
        }
    }      
         

    class HmacHeaderInspector: IClientMessageInspector
    {
        private readonly string _hmac;
        private readonly string _keyId;

        public HmacHeaderInspector(string hmac,string keyId)
        {
            _hmac = hmac;
            _keyId = keyId;
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {                                                                
            MessageBuffer buffer = request.CreateBufferedCopy(Int32.MaxValue);
            request = buffer.CreateMessage();
            Message msg = buffer.CreateMessage();                
            ASCIIEncoding encoder = new ASCIIEncoding();
                
            var sb = new StringBuilder();
            var xmlWriter = XmlWriter.Create(sb, new XmlWriterSettings
                                                    {
                                                    OmitXmlDeclaration  = true
                                                    });
            var writer = XmlDictionaryWriter.CreateDictionaryWriter(xmlWriter);
            msg.WriteStartEnvelope(writer);
            msg.WriteStartBody(writer);
            msg.WriteBodyContents(writer);                                
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndElement();
            writer.Flush();

            string body = sb.ToString().Replace(" />","/>");

            byte[] xmlByte = encoder.GetBytes(body);
            SHA1CryptoServiceProvider sha1Crypto = new SHA1CryptoServiceProvider();
            string hash = BitConverter.ToString(sha1Crypto.ComputeHash(xmlByte)).Replace("-", "");
            string hashedContent = hash.ToLower();

            //assign values to hashing and header variables
            string time = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ");
            string hashData = "POST\ntext/xml; charset=utf-8\n" + hashedContent + "\n" + time + "\n/transaction/v12";
            //hmac sha1 hash with key + hash_data
            HMAC hmacSha1 = new HMACSHA1(Encoding.UTF8.GetBytes(_hmac)); //key
            byte[] hmacData = hmacSha1.ComputeHash(Encoding.UTF8.GetBytes(hashData)); //data
            //base64 encode on hmac_data
            string base64Hash = Convert.ToBase64String(hmacData);

            HttpRequestMessageProperty httpRequestMessage;
            object httpRequestMessageObject;

            if (request.Properties.TryGetValue(HttpRequestMessageProperty.Name, out httpRequestMessageObject))
            {
                httpRequestMessage = httpRequestMessageObject as HttpRequestMessageProperty;
                httpRequestMessage.Headers["X-GGe4-Content-SHA1"] = hashedContent;
                httpRequestMessage.Headers["X-GGe4-Date"] = time;
                httpRequestMessage.Headers["Authorization"] = "GGE4_API " + _keyId + ":" + base64Hash;
            }
            else
            {
                httpRequestMessage = new HttpRequestMessageProperty();
                httpRequestMessage.Headers["X-GGe4-Content-SHA1"] = hashedContent;
                httpRequestMessage.Headers["X-GGe4-Date"] = time;                    
                httpRequestMessage.Headers["Authorization"] = "GGE4_API " + _keyId + ":" + base64Hash;
                request.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMessage);
            }                
            return null;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {                
        }
    }
}

public class MerchantResponse
{
    public bool IsTransactionApproved { get; set; }
    public bool IsError { get; set; }
    public string Message { get; set; }
}
}
