//Bec.TargetFramework.Entities

//using Fabrik.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web.Services.Protocols;
using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Business.BWAService;
using Bec.TargetFramework.Business.BWATokenService;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Experian;
using Bec.TargetFramework.Entities.Settings;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
using EnsureThat;
using ServiceStack.Text;

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class ExperianBWALogic : LogicBase, IExperianBWALogic
    {
        private readonly ExperianIDCheckSettings idSettings;

        public ExperianBWALogic(ILogger logger, ICacheProvider cacheProvider,
            ExperianIDCheckSettings idcheckSettings)
            : base(logger, cacheProvider)
        {
            idSettings = idcheckSettings;
        }

        private void InitialiseBWAHostedService(BankWizard_v1_1_SOAPBinding service,string secureToken)
        {
            service.Url = idSettings.BWAServiceUrl;

            // set timeout
            service.Timeout = idSettings.BankWizardAbsoluteTimeout;

            // 3. To access the SoapContext see the files provided in Service\src. 
            // The first argument in the WASPToken constructor comes from a successful WASP authentication request.
            service.RequestSoapContext.Security.Tokens.Add(new WASPTokenLogic(secureToken));
            service.RequestSoapContext.Security.MustUnderstand = false;
        }

        private List<Tuple<string, string, string>> m_ErrorCodes = new List<Tuple<string, string, string>>();

        public string PerformExperianBankWizardAbsoluteQuery(BWARequestDTO searchRequest)
        {
            ExperianHelper.EnsureExperianSettingsAreValid(idSettings,"Experian BWA Error");

            var secureToken = ExperianHelper.CreateASecureToken(idSettings);

            var response = string.Empty;

            if (secureToken != null)
            {
                var verifyRequest = new VerifyRequest();
                verifyRequest.language = idSettings.BankWizardLanguage;

                // 1.1 Account information includes sort code, account number, check context, account setup date, account type and customer account type.
                verifyRequest.accountInformation = CreateVerifyAccountObject(searchRequest);

                // 1.2 Personal information includes first name, surname,date of birth, address and owner type.
                if (searchRequest.IsCommericalBankAccount)
                    verifyRequest.companyInformation = CreateCompanyRequestObject(searchRequest);
                else
                    verifyRequest.personalInformation = CreatePersonalRequestObject(searchRequest);

                // 2. Create a new service proxy. Change the hostedServiceURL to the URL supplied by Experian.
                try
                {
                    using (var hostedService = new BankWizard_v1_1_SOAPBinding())
                    {
                        InitialiseBWAHostedService(hostedService, secureToken);

                        VerifyResponse verifyResponse = hostedService.Verify(verifyRequest);
                        if (verifyResponse != null)
                        {
                            /// 5. How to check to see if there were any error conditions.
                            if (verifyResponse.conditions != null)
                            {
                                if (
                                    !verifyResponse.conditions.ToList()
                                        .Exists(c => c.severity == ConditionSeverity.error))
                                {
                                    //Return verification status
                                    response = verifyResponse.accountInformation.accountVerificationStatus.ToString();
                                    string jsonResponse = JsonSerializer.SerializeToString(verifyResponse);
                                    return jsonResponse;
                                }
                                else
                                {
                                    StringBuilder errorResponse = new StringBuilder();

                                    verifyResponse.conditions.Where(c => c.severity == ConditionSeverity.error)
                                        .ToList()
                                        .ForEach(c =>
                                        {
                                            m_ErrorCodes.Add(new Tuple<string, string, string>(c.code, c.Value,
                                                c.severity.ToString()));
                                        });

                                    throw new Exception("Experian BWA Error:" + errorResponse.ToString());
                                }
                            }
                        }
                        else
                            throw new Exception("Experian BWA Error: Response object not found");
                    }
                }
                catch (Exception ex)
                {
                    if (!ex.Message.Contains("Experian BWA Error"))
                    {
                        var soapEx = ex as SoapException;

                        if (soapEx != null)
                            m_ErrorCodes.Add(new Tuple<string, string, string>(soapEx.Code.ToString(),
                                soapEx.Detail.InnerText, ""));
                    }

                    Exception e = new ArgumentException("Experian BWA Error", ex);

                    // dump errors into exception
                    if (m_ErrorCodes.Count > 0)
                        e.Data.Add("ErrorCodes", m_ErrorCodes.Dump());

                    // dump request into exception
                    e.Data.Add("Request", searchRequest.Dump());

                    // log exception
                    Logger.Error(new TargetFrameworkLogDTO
                    {
                        Exception = e
                    });

                    throw ex;
                }
            }

            if(response != string.Empty)
                return JsonSerializer.SerializeToString(response);
            else
            {
                throw new Exception("Experian BWA Error: response is empty");
            }
        }

        private VerifyAccountRequestType CreateVerifyAccountObject(BWARequestDTO request)
        {
            var vart = new VerifyAccountRequestType
            {
                sortCode = request.SortCode,
                accountNumber = request.AccountNumber,
                rollNumber = request.RollNumber,
                checkContext = CheckContextType.DirectCredit,
                accountVerification = new VerifyBankAccountRequestType
                {
                    accountSetupDate = new AccountDateType
                    {
                        year = request.AccountSetupDate.Year.ToString(),
                        month = request.AccountSetupDate.Month.ToString(),
                        day = request.AccountSetupDate.Day.ToString()
                    },
                    accountTypeInformation = new AccountTypeInformation
                    {
                        accountType = AccountType.Current,
                        customerAccountType = CustomerAccountType.Business
                    }
                }
            };

            return vart;
        }

        private VerifyCompanyRequestType CreateCompanyRequestObject(BWARequestDTO request)
        {
            var companyInformation = new VerifyCompanyRequestType
            {
                companyName = request.CompanyName,
                companyType = CompanyType.L,
                registrationNumber = request.RegNumber,
                address = new Address
                {
                    deliveryPoint = new[]
                            {
                                new DeliveryPoint
                                {
                                    deliveryType = DeliveryPointType.houseName,
                                    Value = request.HouseName
                                }
                            },
                    postalPoint = new[]
                            {
                                new PostalPoint
                                {
                                    postalType = PostalPointType.street,
                                    Value = request.Street
                                },
                                new PostalPoint
                                {
                                    postalType = PostalPointType.postcode,
                                    Value = request.Postcode
                                }
                            }
                },
                proprietor = new PersonalDetails
                {
                    firstName = request.ForeName,
                    surname = request.SurName,
                    dob = request.DOB,
                    dobSpecified = true
                }
            };

            return companyInformation;
        }

        private VerifyPersonalRequestType CreatePersonalRequestObject(BWARequestDTO request)
        {
            var personalInformation = new VerifyPersonalRequestType
            {
                personal = new PersonalDetails
                {
                    firstName = request.ForeName,
                    surname = request.SurName,
                    dob = request.DOB,
                    dobSpecified = true
                },
                address = new Address
                {
                    deliveryPoint = new[]
                            {
                                new DeliveryPoint
                                {
                                    deliveryType = DeliveryPointType.houseNumber,
                                    Value = request.HouseNumber
                                }
                            },
                    postalPoint = new[]
                            {
                                new PostalPoint
                                {
                                    postalType = PostalPointType.street,
                                    Value = request.Street
                                },
                                new PostalPoint
                                {
                                    postalType = PostalPointType.postcode,
                                    Value = request.Postcode
                                }
                            }
                },
                ownerType = OwnerType.Single,
                ownerTypeSpecified = true
            };

            return personalInformation;
        }

        
    }
}