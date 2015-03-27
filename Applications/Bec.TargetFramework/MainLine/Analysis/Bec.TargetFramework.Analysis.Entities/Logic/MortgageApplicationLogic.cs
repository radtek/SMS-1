using EnsureThat;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using Bec.TargetFramework.Data.Analysis;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Analysis.Interfaces;
using Bec.TargetFramework.Analysis.Infrastructure;

// The command line that was used to created Bec.TargetFramework.Analysis.Interfaces/Batch.cs is:
// Xsd2Code.exe schema.xsd Bec.TargetFramework.Analysis.Interfaces Batch.cs /dc /sc /xa /ap /pl Net35 /if- /dbg
// To download xsd2Code, see http://xsd2code.codeplex.com/

namespace Bec.TargetFramework.Analysis
{
    public class MortgageApplicationLogic : LogicBase, IMortgageApplicationLogic, IDisposable
    {
        private List<ErrorDetail> m_businessErrors;
        private EventLog m_eventLog;
        private TargetFrameworkAnalysisEntities m_DbContext;

        public MortgageApplicationLogic(ILogger logger, ICacheProvider cacheProvider):
            this(logger, cacheProvider, new TargetFrameworkAnalysisEntities())
        {
        }

        public MortgageApplicationLogic(ILogger logger, ICacheProvider cacheProvider, TargetFrameworkAnalysisEntities dbContext)
            : base(logger, cacheProvider)
        {
            m_DbContext = dbContext;

            m_eventLog = new EventLog();
            m_eventLog.Source = "Bec.TargetFramework.Analysis";
            m_eventLog.Log = "Application";
            m_eventLog.EnableRaisingEvents = true;
        }

        public SearchDetail ProcessMortgageApplication(SearchDetail request)
        {
            m_eventLog.WriteEntry("in ProcessMortgageApplication");

            try
            {
                m_eventLog.WriteEntry("in try");    

                m_businessErrors = new List<ErrorDetail>();

                m_eventLog.WriteEntry("Validate(request);");

                if (request != null)
                {
                    string json = JsonHelper.SerializeData(request);
                    m_eventLog.WriteEntry("application Json: " + json);
                }

                // Check if the request is valid or not.
                Validate(request);

                m_eventLog.WriteEntry("if (IsValid)");
                
                // Only save the new application if it is valid
                if (IsValid)
                {
                    m_eventLog.WriteEntry("Save(request);");
                    Save(request);
                }

                m_eventLog.WriteEntry("out try");
            }
            catch (Exception ex)
            {
                // Catch all errors condition just in case. This will append the error with call stack.
                string message = ex.FlattenException();
                Logger.Error(ex, message, null);
                m_eventLog.WriteEntry("Error: " + message);
                m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR101, Message = GetErrorMessage(ErrorEnum.ERR101) + message });                
            }

            m_eventLog.WriteEntry("BuildResponse(request);");

            return BuildResponse(request);
        }

        private SearchDetail BuildResponse(SearchDetail request)
        {
            m_eventLog.WriteEntry("in BuildResponse");

            var response = new SearchDetail();
            response.LastUpdated = DateTime.Now;

            try
            {
                m_eventLog.WriteEntry("in try");

                // Guard against a null request
                if (request != null)
                {
                    m_eventLog.WriteEntry("setting attributes");

                    // Tag the response with the keys so that it can be matched by the client
                    response.Lender = request.Lender;
                    response.Domain = request.Domain;
                    response.MortgageApplicationNumber = request.MortgageApplicationNumber;
                }

                // Set the HasError flag to indicate if we have any errors
                response.HasError = m_businessErrors.Count > 0;
                m_eventLog.WriteEntry("response.HasError: " + response.HasError);

                // If we have errors, add them to the business errors section so the client has useful information as to the reason it fails
                if (response.HasError)
                {
                    response.BusinessErrors = new List<ErrorDetail>();
                    for (int i = 0; i < m_businessErrors.Count; i++)
                    {
                        m_eventLog.WriteEntry(String.Format("Error: {0}, {1}", m_businessErrors[i].Code, m_businessErrors[i].Message));
                        response.BusinessErrors.Add(new ErrorDetail() { Code = m_businessErrors[i].Code, Message = m_businessErrors[i].Message });
                    }
                }

                m_eventLog.WriteEntry("out try");
            }
            catch (Exception ex)
            {
                // Catch all errors condition just in case. This will append the error with call stack.
                string message = ex.FlattenException();
                Logger.Error(ex, message, null);
                m_eventLog.WriteEntry("Error: " + message);
                m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR101, Message = GetErrorMessage(ErrorEnum.ERR101) + message });                
            }

            // Comment this line when deploying - it is added for testing purposes, to validate we actually called the remote wcf service
            //response.MortgageApplicationNumber = System.Environment.MachineName;

            string json = JsonHelper.SerializeData(response);
            m_eventLog.WriteEntry("response Json: " + json);

            m_eventLog.WriteEntry("out BuildResponse");

            return response;
        }

        private bool Save(SearchDetail request)
        {
            m_eventLog.WriteEntry("in Save");

            Ensure.That(request).IsNotNull();

            m_eventLog.WriteEntry("using (var scope = new UnitOfWorkScope<BecTargetFrameworkAnalysisEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))");

            using (var scope = new UnitOfWorkScope<TargetFrameworkAnalysisEntities>(m_DbContext, UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                m_eventLog.WriteEntry("if (ApplicationExists(request, scope))");

                if (ApplicationExists(request, scope))
                {
                    m_eventLog.WriteEntry("Save_Update(request, scope);");
                    Save_Update(request, scope);
                }
                else
                {
                    m_eventLog.WriteEntry("Save_New(request, scope);");
                    Save_New(request, scope);
                }

                // Do the actual save to DB
                m_eventLog.WriteEntry("scope.Save();");
                scope.Save();
            }

            m_eventLog.WriteEntry("out Save");

            return true;
        }

        private bool ApplicationExists(SearchDetail request, UnitOfWorkScope<TargetFrameworkAnalysisEntities> scope)
        {
            // Check if this application already exists in the DB
            string searchReferenceKey = GetSearchReferenceKey(request);
            return scope.DbContext.AnalysisMortgageApplicationDetails.Any(
                            s => s.SearchReferenceKey.Equals(searchReferenceKey)
                            && s.IsActive
                            && !s.IsDeleted);
        }

        private void Save_Update(SearchDetail request, UnitOfWorkScope<TargetFrameworkAnalysisEntities> scope)
        {
            m_eventLog.WriteEntry("in Save_Update");

            string searchReferenceKey = GetSearchReferenceKey(request);

            m_eventLog.WriteEntry("searchReferenceKey: " + searchReferenceKey);

            // Find the mortgage application detail row, to get the ID
            AnalysisMortgageApplicationDetailDTO analysisMortgageApplicationDetailDto =
                    AnalysisMortgageApplicationDetailConverter.ToDto(
                        scope.DbContext.AnalysisMortgageApplicationDetails.Single(
                            s => s.SearchReferenceKey.Equals(searchReferenceKey)
                            && s.IsActive
                            && !s.IsDeleted));

            m_eventLog.WriteEntry("analysisMortgageApplicationDetailDto is null: " + (analysisMortgageApplicationDetailDto == null).ToString());

            // Use the ID to find the mortgage application row
            AnalysisMortgageApplicationDTO analysisMortgageApplicationDto =
                    AnalysisMortgageApplicationConverter.ToDto(
                        scope.DbContext.AnalysisMortgageApplications.Single(
                            s => s.AnalysisMortgageApplicationID == analysisMortgageApplicationDetailDto.AnalysisMortgageApplicationID));

            m_eventLog.WriteEntry("analysisMortgageApplicationDto is null: " + (analysisMortgageApplicationDetailDto == null).ToString());

            // Update the fields
            analysisMortgageApplicationDto.LastUpdated = DateTime.Now;

            m_eventLog.WriteEntry("analysisMortgageApplicationDto.ApplicationData = JsonHelper.SerializeData(request);");
            analysisMortgageApplicationDto.ApplicationData = JsonHelper.SerializeData(request);
            
            // Update the scope
            m_eventLog.WriteEntry("var analysisMortgageApplicationRepo = scope.GetGenericRepository<AnalysisMortgageApplication, Guid>();");
            var analysisMortgageApplicationRepo = scope.GetGenericRepository<AnalysisMortgageApplication, Guid>();
            AnalysisMortgageApplication analysisMortgageApplication = AnalysisMortgageApplicationConverter.ToEntity(analysisMortgageApplicationDto);
            analysisMortgageApplicationRepo.Update(analysisMortgageApplication);

            m_eventLog.WriteEntry("out Save_Update");
        }

        private void Save_New(SearchDetail request, UnitOfWorkScope<TargetFrameworkAnalysisEntities> scope)
        {
            m_eventLog.WriteEntry("in Save_New");

            // Create the mortgage application row
            AnalysisMortgageApplicationDTO analysisMortgageApplicationDto = new AnalysisMortgageApplicationDTO();
            analysisMortgageApplicationDto.LastUpdated = DateTime.Now;

            m_eventLog.WriteEntry("analysisMortgageApplicationDto.ApplicationData = JsonHelper.SerializeData(request);");
            analysisMortgageApplicationDto.ApplicationData = JsonHelper.SerializeData(request);
            
            analysisMortgageApplicationDto.SchemaID = Guid.Parse("8967ae42-97fa-11e4-9023-e7ad5fae5a2c"); // Test schema entry, use this for now.
            analysisMortgageApplicationDto.SchemaVersionNumber = 0; // Test schema entry, use this for now.
            analysisMortgageApplicationDto.IsActive = true;
            analysisMortgageApplicationDto.IsDeleted = false;

            // Update the scope
            m_eventLog.WriteEntry("var analysisMortgageApplicationRepo = scope.GetGenericRepository<AnalysisMortgageApplication, Guid>();");
            var analysisMortgageApplicationRepo = scope.GetGenericRepository<AnalysisMortgageApplication, Guid>();
            AnalysisMortgageApplication analysisMortgageApplication = AnalysisMortgageApplicationConverter.ToEntity(analysisMortgageApplicationDto);
            analysisMortgageApplicationRepo.Add(analysisMortgageApplication);

            // Also create the mortgage application detail row too
            m_eventLog.WriteEntry("AnalysisMortgageApplicationDetailDTO analysisMortgageApplicationDetailDto = new AnalysisMortgageApplicationDetailDTO();");
            AnalysisMortgageApplicationDetailDTO analysisMortgageApplicationDetailDto = new AnalysisMortgageApplicationDetailDTO();
            analysisMortgageApplicationDetailDto.AnalysisMortgageApplicationID = analysisMortgageApplication.AnalysisMortgageApplicationID;
            analysisMortgageApplicationDetailDto.Lender = request.Lender;
            analysisMortgageApplicationDetailDto.Domain = request.Domain;
            analysisMortgageApplicationDetailDto.MortgageApplicationNumber = request.MortgageApplicationNumber;
            analysisMortgageApplicationDetailDto.SearchReferenceKey = GetSearchReferenceKey(request);
            analysisMortgageApplicationDetailDto.IsActive = true;
            analysisMortgageApplicationDetailDto.IsDeleted = false;

            // Update the scope
            m_eventLog.WriteEntry("var analysisMortgageApplicationDetailRepo = scope.GetGenericRepository<AnalysisMortgageApplicationDetail, Guid>();");
            var analysisMortgageApplicationDetailRepo = scope.GetGenericRepository<AnalysisMortgageApplicationDetail, Guid>();
            AnalysisMortgageApplicationDetail analysisMortgageApplicationDetail = AnalysisMortgageApplicationDetailConverter.ToEntity(analysisMortgageApplicationDetailDto);
            analysisMortgageApplicationDetailRepo.Add(analysisMortgageApplicationDetail);

            m_eventLog.WriteEntry("out Save_New");
        }

        private string GetSearchReferenceKey(SearchDetail request)
        {
            // What uniquely identifies the application is a combination of the lender, domain and mortgage application number
            return string.Join("|", request.Lender, request.Domain, request.MortgageApplicationNumber);
        }

        private void Validate(SearchDetail request)
        {
            m_eventLog.WriteEntry("in Validate");

            if (request == null)
            {
                m_eventLog.WriteEntry("request is null");
                m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR011, Message = GetErrorMessage(ErrorEnum.ERR011) });
                return;
            }

            Validate_Attributes(request);
            Validate_Transaction(request);
            Validate_Parties(request);

            m_eventLog.WriteEntry("out Validate");
        }

        private void Validate_Parties(SearchDetail request)
        {
            m_eventLog.WriteEntry("in Validate_Parties");

            if (!request.HasPartyType(PartyTypeEnum.BUY))
            {
                m_eventLog.WriteEntry("ERR007");
                m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR007, Message = GetErrorMessage(ErrorEnum.ERR007) });
            }
            else
            {
                if (!request.HasBuyerName())
                {
                    m_eventLog.WriteEntry("ERR008");
                    m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR008, Message = GetErrorMessage(ErrorEnum.ERR008) });
                }

                if (!request.HasBuyerAddress())
                {
                    m_eventLog.WriteEntry("ERR009");
                    m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR009, Message = GetErrorMessage(ErrorEnum.ERR009) });
                }
            }

            m_eventLog.WriteEntry("out Validate_Parties");
        }

        private void Validate_Transaction(SearchDetail request)
        {
            m_eventLog.WriteEntry("in Validate_Transaction");

            if (request.Transaction == null)
            {
                m_eventLog.WriteEntry("ERR010");
                m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR010, Message = GetErrorMessage(ErrorEnum.ERR010) });
            }
            else
                if (!request.Transaction.HasAddress())
                {
                    m_eventLog.WriteEntry("ERR006");
                    m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR006, Message = GetErrorMessage(ErrorEnum.ERR006) });
                }

            m_eventLog.WriteEntry("out Validate_Transaction");
        }

        private string GetErrorMessage(ErrorEnum code)
        {
            switch (code)
            {
                case ErrorEnum.ERR001:
                    return "Lender not supplied in request";
                case ErrorEnum.ERR002:
                    return "Domain not supplied in request";
                case ErrorEnum.ERR003:
                    return "Mortgage application number not supplied in request";
                case ErrorEnum.ERR004:
                    return "Lender supplied is not recognised";
                case ErrorEnum.ERR005:
                    return "Domain supplied is not recognised";
                case ErrorEnum.ERR006:
                    return "Transaction address not supplied in request";
                case ErrorEnum.ERR007:
                    return "Buyer not supplied in request";
                case ErrorEnum.ERR008:
                    return "Buyer name not supplied in request";
                case ErrorEnum.ERR009:
                    return "Buyer address not supplied in request";
                case ErrorEnum.ERR010:
                    return "Transaction section not supplied in request";
                case ErrorEnum.ERR011:
                    return "Request is a null value";
                case ErrorEnum.ERR012:
                    return "Mortgage application number is not recognized";
                case ErrorEnum.ERR013:
                    return "XML Validation Error";
                case ErrorEnum.ERR101:
                    return "Error encountered: ";
                default:
                    return "undefined error";
            }
        }

        private void Validate_Attributes(SearchDetail request)
        {
            m_eventLog.WriteEntry("in Validate_Attributes");

            if (string.IsNullOrEmpty(request.Lender))
            {
                m_eventLog.WriteEntry("ERR001");
                m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR001, Message = GetErrorMessage(ErrorEnum.ERR001) });
            }
            else
                if (!request.IsLenderValid())
                {
                    m_eventLog.WriteEntry("ERR004");
                    m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR004, Message = GetErrorMessage(ErrorEnum.ERR004) });
                }

            if (string.IsNullOrEmpty(request.Domain))
            {
                m_eventLog.WriteEntry("ERR002");
                m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR002, Message = GetErrorMessage(ErrorEnum.ERR002) });
            }
            else
                if (!request.IsDomainValid())
                {
                    m_eventLog.WriteEntry("ERR005");
                    m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR005, Message = GetErrorMessage(ErrorEnum.ERR005) });
                }

            if (string.IsNullOrEmpty(request.MortgageApplicationNumber))
            {
                m_eventLog.WriteEntry("ERR003");
                m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR003, Message = GetErrorMessage(ErrorEnum.ERR003) });
            }

            m_eventLog.WriteEntry("out Validate_Attributes");
        }

        private bool IsValid
        {
            get { return m_businessErrors.Count == 0; }
        }

        public void Dispose()
        {
            m_businessErrors = null;
            m_eventLog = null;
        }
    }
}
