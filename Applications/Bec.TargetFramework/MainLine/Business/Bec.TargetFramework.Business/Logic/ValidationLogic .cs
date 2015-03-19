using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Data.Repositories;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Security;

using Omu.ValueInjecter;
using Bec.TargetFramework.Entities.Injections;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using System.IO;
using System.Reflection;
using Bec.TargetFramework.Business.Logic.Helper;

namespace Bec.TargetFramework.Business.Logic
{
    using Bec.TargetFramework.Aop.Aspects;
    using System.Net;
    using EnsureThat;
   
    [Trace(TraceExceptionsOnly = true)]
    public class ValidationLogic : LogicBase, IValidationLogic
    {
        public string _strSearch;
        public string _strSearchUrl;
        public ValidationLogic(ILogger logger, ICacheProvider cacheProvider)
            : base(logger, cacheProvider)
        {
        }


        #region SRA Validation public methods

        public EmployeeDTO GetEmployeeById(string strSRAID)
        {

            var sraUserDetails = ScrapScreen(SRAValidationEnum.PesonLookupBySRAId, strSRAID);
            int indexPerson = sraUserDetails.IndexOf("/person/", 0);
            if (indexPerson > 0)
            {

                var PersonIndexs = new List<int>();
                PersonIndexs.Add(indexPerson);
                return GetEmployeeList(sraUserDetails, PersonIndexs).First();

            }
            return null;

        }


        public CompanyDTO GetCompanyDetailsByName(string strCopmanyName)
        {
            CompanyDTO Company = null;

            var strCompanyData = ScrapScreen(SRAValidationEnum.FirmLookupByName, strCopmanyName);

            int indexCompany = strCompanyData.IndexOf("/office/", 0);

            if (indexCompany > 0)
            {
                var companyIndexs = new List<int>();
                companyIndexs.Add(indexCompany);
                return GetCompaniesList(strCompanyData, companyIndexs).First();
            }

            return Company;
        }


        public bool IsInvalidBranch(string strBranchSraId, string strCompanyName, string strPostCode)
        {

            //var sraUserDetails = ScrapScreen(SRAValidationEnum.FirmLookupBySRAId, strBranchSraId.Trim());
            //var indexes = AllIndexesOf(sraUserDetails, "/office/");
            //var companies = GetCompaniesList(sraUserDetails, indexes);
            //bool result = false;
            //if (companies.Count > 0)
            //{
            //    string[] tradingNames = companies.First().TradingName.Split(',');
            //    if (companies.First().Address.ToLower().Replace(" ", "").Contains(strPostCode.ToLower().Trim().Replace(" ", "")))
            //    {
            //        if (WebUtility.HtmlDecode(companies.First().Name.ToLower()).Trim().Equals(strCompanyName.ToLower().Trim()))
            //            result = true;
            //        else
            //            foreach (string tradingName in tradingNames)
            //                if (WebUtility.HtmlDecode(tradingName.ToLower()).Trim().Equals(strCompanyName.ToLower().Trim()))
            //                    result = true;
            //    }
            //}


            return false;
        }

        public bool IsInvalidEmployee(string strSraId, string strLastName, string strCompanyName, bool IsColp)
        {
            bool result = false;
            //var employee = GetEmployeeById(strSraId.Trim());

            //if (employee != null)
            //{
            //    var company = GetCompanyDetailsByName(employee.CompanyName);
            //    string[] tradingNames = company.TradingName.Split(',');
            //    if (!IsColp)
            //    {

            //        if (WebUtility.HtmlDecode(employee.Name).ToLower().Contains(strLastName.ToLower().Trim()))
            //            result = true;
            //    }
            //    else
            //    {
            //        if (WebUtility.HtmlDecode(employee.Name).ToLower().Contains(strLastName.ToLower().Trim()) && (employee.IsCOLP == IsColp))
            //            result = true;

            //    }
            //    if (result)
            //    {
            //        result = false;
            //        if (WebUtility.HtmlDecode(employee.CompanyName).ToLower().Trim().Equals(strCompanyName.Trim().ToLower()))
            //            result = true;
            //        else
            //            foreach (string tradingName in tradingNames)
            //                if (WebUtility.HtmlDecode(tradingName.ToLower()).Trim().Equals(strCompanyName.ToLower().Trim()))
            //                    result = true;
            //    }
            //}
            return !result;
        }

        #endregion

        #region SRA Validation Private methods



        private string BuildSearchURL(SRAValidationEnum lookupType, string strSearchString)
        {


            string url = "http://solicitors.lawsociety.org.uk/search/results?Type=1&IncludeNlsp=True&Pro=True";
            if (lookupType == SRAValidationEnum.PesonLookupBySRAId)
                return String.Format("{0}&SraId={1}", url, strSearchString);
            if (lookupType == SRAValidationEnum.FirmLookupByName)
                return String.Format("http://solicitors.lawsociety.org.uk/search/results?Type=0&IncludeNlsp=True&Pro=True&Name={0}", strSearchString);
            if (lookupType == SRAValidationEnum.FirmLookupBySRAId)
                return String.Format("http://solicitors.lawsociety.org.uk/search/results?Type=0&IncludeNlsp=True&Pro=True&SraId={0}", strSearchString);
            else
                return String.Format("{0}&Name={1}", url, strSearchString);


        }

        private string ScrapeUrl(string url)
        {
            // Create a request for the URL. 
            WebRequest request = WebRequest.Create(url);
            // If required by the server, set the credentials.
            request.Credentials = CredentialCache.DefaultCredentials;
            // Get the response.
            WebResponse response = request.GetResponse();
            // Display the status.
            Console.WriteLine(((HttpWebResponse)response).StatusDescription);
            // Get the stream containing content returned by the server.
            Stream dataStream = response.GetResponseStream();
            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream);
            // Read the content.
            string responseFromServer = reader.ReadToEnd();

            reader.Close();
            response.Close();

            return responseFromServer;
        }


        private string ScrapScreen(SRAValidationEnum searchId, string searchString)
        {
            _strSearchUrl = BuildSearchURL(searchId, searchString);
            return ScrapeUrl(_strSearchUrl);
        }

        private List<int> AllIndexesOf(string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");
            List<int> indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }

        private List<EmployeeDTO> GetEmployeeList(string employeesContent, List<int> employeesIndexes)
        {
            var Employees = new List<EmployeeDTO>();

            string employee = "";

            var officesIndexes = AllIndexesOf(employeesContent, "/office/");

            string companyName = "";


            employeesIndexes.ForEach(eItem =>
            {


                officesIndexes.ForEach(office =>
                {
                    string compantNamesubbed = employeesContent.Substring(office);

                    int endOfURLCompanyName = compantNamesubbed.IndexOf('>');
                    int endOfTextCompnayName = compantNamesubbed.IndexOf('<');
                    // string _url = compantNamesubbed.Substring(0, (endOfURLCompanyName - 1));
                    companyName = compantNamesubbed.Substring((endOfURLCompanyName + 1), (endOfTextCompnayName - endOfURLCompanyName) - 1);
                });


                string subbed = employeesContent.Substring(eItem);

                // find next occurance of  '>'
                int endOfURL = subbed.IndexOf('>');
                int endOfText = subbed.IndexOf('<');
                string url = subbed.Substring(0, (endOfURL - 1));
                string EmpolyeeName = subbed.Substring((endOfURL + 1), (endOfText - endOfURL) - 1);
                string sraID;


                // Employee by Id
                string employeeContent = ScrapeUrl("http://solicitors.lawsociety.org.uk" + url);


                int sraIndex = employeeContent.IndexOf("SRA ID:</dt>");
                int sraEndIndex = employeeContent.IndexOf("</dd>");
                string sraId = "";
                bool IsSraRegistored = false;
                if (sraIndex > 0)
                {
                    string sraString = employeeContent.Substring(sraIndex);

                    //sraId = sraString.Replace("SRA ID:</dt> <dd>", "").Substring(0, 6).Trim();
                    int i = sraEndIndex - sraIndex;
                    sraId = employeeContent.Substring(sraIndex + 17, (sraEndIndex - sraIndex) - 17).Trim();
                    IsSraRegistored = true;
                }

                //  Is Employee  a COLP
                int sraRegulatedIndex = employeeContent.IndexOf("Roles at this organisation</dt>");
                bool ColpRegistored = false;
                if (sraRegulatedIndex > 0)
                {
                    string colpRegulatedString = employeeContent.Substring(sraRegulatedIndex);
                    int sraRegulatedEndIndex = colpRegulatedString.IndexOf("</ul></dd>");
                    ColpRegistored = colpRegulatedString.Contains(">Compliance Officer for Legal Practice</li>");
                }

                Employees.Add(new EmployeeDTO { Name = EmpolyeeName, SraNumber = sraId, IsCOLP = ColpRegistored, Url = url, IsSraRegistered = IsSraRegistored, CompanyName = companyName });


            });

            return Employees;
        }


        private List<CompanyDTO> GetCompaniesList(string employeesContent, List<int> indexes)
        {
            var companies = new List<CompanyDTO>();
            //string companyName = "";
            //indexes.ForEach(item =>
            //{
            //    string subbed = employeesContent.Substring(item);

            //    // find next occurance of  '>'
            //    int endOfURL = subbed.IndexOf('>');
            //    int endOfText = subbed.IndexOf('<');

            //    string url = subbed.Substring(0, (endOfURL - 1));

            //    // get company name
            //    companyName = subbed.Substring((endOfURL + 1), (endOfText - endOfURL) - 1);

            //    string boo = "";

            //    var companyFullDetails = ScrapeUrl("http://solicitors.lawsociety.org.uk/" + url);

            //    StringBuilder tradName = new StringBuilder();

            //    tradName.Append("id=");
            //    tradName.Append('"');
            //    tradName.Append("trading-names");

            //    int TradeNameStartIndex = companyFullDetails.IndexOf(tradName.ToString());
            //    int TradeNameEndIndex = companyFullDetails.IndexOf("</header>");
            //    string strTradingName = "";
            //    if (TradeNameStartIndex > 0)
            //    {
            //        var tempstubb = companyFullDetails.Substring(TradeNameStartIndex, TradeNameEndIndex);
            //        int i = tempstubb.IndexOf('>');
            //        var subbCompanyName = tempstubb.Substring(i);
            //        int TradeNamePStartIndex = subbCompanyName.IndexOf("<p>");
            //        int TradeNamePSEndIndex = subbCompanyName.IndexOf("</p>");
            //        var tempDataForPtag = subbCompanyName.Substring(TradeNamePStartIndex + 9, TradeNamePSEndIndex);
            //        int index = tempDataForPtag.IndexOf('<');

            //        strTradingName = subbCompanyName.Substring(TradeNamePStartIndex + 9, index);


            //    }


            //    companies.Add(new CompanyDTO { Name = companyName, Url = url, TradingName = strTradingName.Trim() });
            //});

            //// get company sra numbers
            //companies.ForEach(item =>
            //{
            //    string companyContent = ScrapeUrl("http://solicitors.lawsociety.org.uk" + item.Url);

            //    int indexSraNumber = companyContent.IndexOf("<dt>SRA ID:</dt>");

            //    /// sra number
            //    if (indexSraNumber != -1)
            //    {
            //        string subbed = companyContent.Substring(indexSraNumber);

            //        int endOfURL = subbed.IndexOf("<dd>");
            //        int endOfText = subbed.IndexOf("</dd>");

            //        string sraNumber = subbed.Substring(endOfURL + 4, ((endOfText) - endOfURL) - 4);

            //        item.SraNumber = sraNumber;
            //    }

            //    // address
            //    int indexAddress = companyContent.IndexOf("Address:");

            //    if (indexAddress != -1)
            //    {
            //        string subbed = companyContent.Substring(indexAddress);

            //        int endOfURL = subbed.IndexOf("<dd class=\"feature\">");
            //        int endOfText = subbed.IndexOf("</dd>");

            //        string address = subbed.Substring(endOfURL + 22, ((endOfText) - endOfURL) - 4).Replace("<br/>", "").Replace("</dd>", "").Trim();

            //        item.Address = address;
            //    }

            //});


            return companies;
        }

        #endregion

        #region RegistrationValidation Methods

        public RegistrationValidationErrorDTO DuplicateComplianceOfficer(string CORegulator, string CORegulatorNumber, string COFirmName, string COFirmTradingName, string COLastName = null, string COEmail = null)
        {
            Ensure.That(CORegulator);
            Ensure.That(CORegulatorNumber);
            Ensure.That(COFirmName);

            RegistrationValidationErrorDTO validation = new RegistrationValidationErrorDTO() {HasError=false};

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var userDetailQuery =
                    scope.DbContext.VUserRoleRegulatorDetails.Where(s => s.IsActive && !s.IsDeleted);

                var data = userDetailQuery.Where(x => x.Regulator.Equals(CORegulator) && x.RegulatorNumber.Equals(CORegulatorNumber) && x.UserRole.Equals("Compliance Officer") && (x.CompanyName.Trim().Replace(" ", "").Equals(COFirmName.Trim().Replace(" ", ""))
                                                                                                                                                                     || x.TradingName.Trim().Replace(" ", "").Equals(COFirmName.Trim().Replace(" ", ""))
                                                                                                                                                                     || x.CompanyName.Trim().Replace(" ", "").Equals(COFirmTradingName.Trim().Replace(" ", ""))
                                                                                                                                                                     || x.TradingName.Trim().Replace(" ", "").Equals(COFirmTradingName.Trim().Replace(" ", "")))).ToList();

                if (data.Count > 0)
                {
                    var userDetails = VUserRoleRegulatorDetailConverter.ToDto(data.First());

                    validation.HasError = true;
                    validation.ExistingFirmRegisteredName = userDetails.CompanyName;
                    validation.ExistingCOFirstName = userDetails.FirstName;
                    validation.ExistingCOLastName = userDetails.LastName;
                    validation.ExistingCOEmail = userDetails.Email;
                }

            }
            /*test code begins
            validation.HasError = true;
            validation.ExistingFirmRegisteredName = "Renier Gillies";
            validation.ExistingCOFirstName = "TUFN";
            validation.ExistingCOLastName = "TULN";
            validation.ExistingCOEmail = "TUEmail";
            /*test code ends*/
            return validation;
        }

        public RegistrationValidationErrorDTO DuplicateCompany(string FirmRegulator, string BranchRegulatorNumber, string FirmName, string FirmTradingName, string COLastName = null, string COEmail = null)
        {
            Ensure.That(FirmRegulator);
            Ensure.That(BranchRegulatorNumber);
            Ensure.That(FirmName);
            Ensure.That(FirmTradingName);

            RegistrationValidationErrorDTO validation = new RegistrationValidationErrorDTO() { HasError = false };

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var userDetailQuery = scope.DbContext.VOrganisationComplianceOfficers.Where(s => s.IsActive && !s.IsDeleted);

                var data = userDetailQuery.Where(x => x.CompanyName.Equals(FirmName) && x.TradingName.Equals(FirmTradingName) && x.BranchRegulator.Equals(FirmRegulator)
                                                    && x.BranchRegulatorNumber.Equals(BranchRegulatorNumber)).ToList();

                if (data.Count > 0)
                {
                    var organisationCO = VOrganisationComplianceOfficerConverter.ToDto(data.First());

                    validation.HasError = true;
                    validation.ExistingFirmRegisteredName = organisationCO.CompanyName;
                    validation.ExistingCOFirstName = organisationCO.COFirstName;
                    validation.ExistingCOLastName = organisationCO.COLastName;
                    validation.ExistingCOEmail = organisationCO.COEmail;
                }

            }
            /*test code begins
            validation.HasError = true;
            validation.ExistingFirmRegisteredName = "T C Test";
            validation.ExistingCOFirstName = "MTUFN";
            validation.ExistingCOLastName = "MTULN";
            validation.ExistingCOEmail = "MTUEmail";
            /*test code ends*/
            return validation;
        }

        public RegistrationValidationErrorDTO COwithAnotherFirm(string CORegulator, string CORegulatorNumber, string COFirmName, string COFirmTradingName, string COLastName, string COEmail = null)
        {
            Ensure.That(CORegulator);
            Ensure.That(CORegulatorNumber);
            Ensure.That(COFirmName);
            Ensure.That(COLastName);

            RegistrationValidationErrorDTO validation = new RegistrationValidationErrorDTO() { HasError = false };

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var userDetailQuery =
                    scope.DbContext.VUserRoleRegulatorDetails.Where(s => s.IsActive && !s.IsDeleted);

                var data = userDetailQuery.Where(x => x.Regulator.Equals(CORegulator) && x.RegulatorNumber.Equals(CORegulatorNumber) && x.LastName.Equals(COLastName) && x.UserRole.Equals("Compliance Officer") && !(x.CompanyName.Trim().Replace(" ", "").Equals(COFirmName.Trim().Replace(" ", ""))
                                                                                                                                          || x.TradingName.Trim().Replace(" ", "").Equals(COFirmName.Trim().Replace(" ", ""))
                                                                                                                                          || x.CompanyName.Trim().Replace(" ", "").Equals(COFirmTradingName.Trim().Replace(" ", ""))
                                                                                                                                          || x.TradingName.Trim().Replace(" ", "").Equals(COFirmTradingName.Trim().Replace(" ", "")))).ToList();

                if (data.Count > 0)
                {
                    var userDetails = VUserRoleRegulatorDetailConverter.ToDto(data.First());

                    validation.HasError = true;
                    validation.ExistingFirmRegisteredName = userDetails.CompanyName;
                    validation.ExistingCOFirstName = userDetails.FirstName;
                    validation.ExistingCOLastName = userDetails.LastName;
                    validation.ExistingCOEmail = userDetails.Email;
                }

            }
            /*test code begins
            validation.HasError = true;
            validation.ExistingFirmRegisteredName = "R G Socilitiors";
            validation.ExistingCOFirstName = "UFN";
            validation.ExistingCOLastName = "ULN";
            validation.ExistingCOEmail = "UEmail";
            /*test code ends*/

            return validation;
        }

        #endregion

    }

       


}
