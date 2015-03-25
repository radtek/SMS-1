
using System.Collections.Generic;
using Bec.TargetFramework.Analysis.Entities;
using Bec.TargetFramework.Infrastructure.Serilog.Helpers;
using EnsureThat;
using System;
using System.Linq;
using System.Diagnostics;
using Bec.TargetFramework.Data.Analysis;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Analysis.Interfaces;
using Bec.TargetFramework.Analysis.Infrastructure;
using Bec.TargetFramework.Analysis;

// The command line that was used to created Bec.TargetFramework.Analysis.Interfaces/Batch.cs is:
// Xsd2Code.exe schema.xsd Bec.TargetFramework.Analysis.Interfaces Batch.cs /dc /sc /xa /ap /pl Net35 /if- /dbg
// To download xsd2Code, see http://xsd2code.codeplex.com/
using ServiceStack.Text;

namespace Bec.TargetFramework.Analysis
{
    public class MortgageApplicationLogic : LogicBase, IMortgageApplicationLogic, IDisposable
    {
        private System.Collections.Generic.List<ErrorDetail> m_businessErrors;
        public MortgageApplicationLogic(ILogger logger, ICacheProvider cacheProvider):
            base(logger, cacheProvider)
        {
        }

        

        public SearchDetail ProcessMortgageApplication(SearchDetail request)
        {
            Logger.Trace("in ProcessMortgageApplication");

            try
            {
                Logger.Trace("in try");    

                m_businessErrors = new List<ErrorDetail>();

                Logger.Trace("Validate(request);");

                if (request != null)
                {
                    string json = JsonHelper.SerializeData(request);
                    Logger.Trace("application Json: " + json);
                }

                // Check if the request is valid or not.
                Validate(request);

                Logger.Trace("if (IsValid)");
                
                // Only save the new application if it is valid
                if (IsValid)
                {
                    Logger.Trace("Save(request);");
                    Save(request);
                }

                Logger.Trace("out try");
            }
            catch (Exception ex)
            {
                // Catch all errors condition just in case. This will append the error with call stack.
                string message = ex.FlattenException();
                Logger.Error(ex, message, null);
                Logger.Trace("Error: " + message);
                m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR101, Message = GetErrorMessage(ErrorEnum.ERR101) + message });                
            }

            Logger.Trace("BuildResponse(request);");

            return BuildResponse(request);
        }

        private SearchDetail BuildResponse(SearchDetail request)
        {
            Ensure.That(request).IsNotNull();

            Logger.Trace("in BuildResponse");

            var response = new SearchDetail();

            try
            {
                
                response.LastUpdated = DateTime.Now;

                Logger.Trace("in try");

                // Guard against a null request
                if (request != null)
                {
                    Logger.Trace("setting attributes");

                    // Tag the response with the keys so that it can be matched by the client
                    response.Lender = request.Lender;
                    response.Domain = request.Domain;
                    response.MortgageApplicationNumber = request.MortgageApplicationNumber;
                }

                // Set the HasError flag to indicate if we have any errors
                response.HasError = m_businessErrors.Count > 0;
                Logger.Trace("response.HasError: " + response.HasError);

                // If we have errors, add them to the business errors section so the client has useful information as to the reason it fails
                if (response.HasError)
                {
                    response.BusinessErrors = new List<ErrorDetail>();
                    for (int i = 0; i < m_businessErrors.Count; i++)
                    {
                        Logger.Trace(String.Format("Error: {0}, {1}", m_businessErrors[i].Code, m_businessErrors[i].Message));
                        response.BusinessErrors.Add(new ErrorDetail() { Code = m_businessErrors[i].Code, Message = m_businessErrors[i].Message });
                    }
                }

                Logger.Trace("out try");
            }
            catch (Exception ex)
            {
                ex.Data.Add("request",request);

                Logger.Error(ex, "Bec.TargetFramework.AnalysisService BuildResponse");

                m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR101, Message = GetErrorMessage(ErrorEnum.ERR101) + ex.FlattenException() });                
            }

            Logger.Trace("response Json: " + response.Dump());

            Logger.Trace("out BuildResponse");

            return response;
        }

        private bool Save(SearchDetail request)
        {
            Logger.Trace("in Save");

            Ensure.That(request).IsNotNull();

            bool saveSucces = false;

            using (var scope = new UnitOfWorkScope<TargetFrameworkAnalysisEntities>(UnitOfWorkScopePurpose.Writing, Logger, true))
            {
                Logger.Trace("if (ApplicationExists(request, scope))");

                if (ApplicationExists(request, scope))
                {
                    Logger.Trace("Update(request, scope);");
                    Update(request, scope);
                }
                else
                {
                    Logger.Trace("Insert(request, scope);");
                    Insert(request, scope);
                }

                // Do the actual save to DB
                Logger.Trace("scope.Save();");
                saveSucces = scope.Save();
            }

            Logger.Trace("out Save");

            return saveSucces;
        }

        private bool ApplicationExists(SearchDetail request, UnitOfWorkScope<TargetFrameworkAnalysisEntities> scope)
        {
            // Check if this application already exists in the DB
            string searchReferenceKey = GetSearchReferenceKey(request);
            return scope.DbContext.AnalysisInputMortgageApplicationDetails.Any(
                            s => s.SearchReferenceKey.Equals(searchReferenceKey)
                            && s.IsActive
                            && !s.IsDeleted);
        }

        private void Update(SearchDetail request, UnitOfWorkScope<TargetFrameworkAnalysisEntities> scope)
        {
            Logger.Trace("in Save_Update");

            string searchReferenceKey = GetSearchReferenceKey(request);

            Logger.Trace("searchReferenceKey: " + searchReferenceKey);

            // Find the mortgage application detail row, to get the ID
            var analysisInputMortgageApplicationDetailDto =
                    AnalysisInputMortgageApplicationDetailConverter.ToDto(
                        scope.DbContext.AnalysisInputMortgageApplicationDetails.Single(
                            s => s.SearchReferenceKey.Equals(searchReferenceKey)
                            && s.IsActive
                            && !s.IsDeleted));

            Logger.Trace("AnalysisInputMortgageApplicationDetailDto is null: " + (analysisInputMortgageApplicationDetailDto == null).ToString());

            // Use the ID to find the mortgage application row
            var analysisInputMortgageApplicationDto =
                    AnalysisInputMortgageApplicationConverter.ToDto(
                        scope.DbContext.AnalysisInputMortgageApplications.Single(
                            s => s.AnalysisInputMortgageApplicationID == analysisInputMortgageApplicationDetailDto.AnalysisInputMortgageApplicationID));

            Logger.Trace("AnalysisInputMortgageApplicationDto is null: " + (analysisInputMortgageApplicationDetailDto == null).ToString());

            // Update the fields
            analysisInputMortgageApplicationDto.ModifiedOn = DateTime.Now;

            Logger.Trace("AnalysisInputMortgageApplicationDto.ApplicationData = JsonHelper.SerializeData(request);");
            analysisInputMortgageApplicationDto.InputData = JsonHelper.SerializeData(request);
            
            // Update the scope
            Logger.Trace("var AnalysisInputMortgageApplicationRepo = scope.GetGenericRepository<AnalysisInputMortgageApplication, Guid>();");
            var analysisInputMortgageApplicationRepo = scope.GetGenericRepository<AnalysisInputMortgageApplication, Guid>();
            var analysisInputMortgageApplication = AnalysisInputMortgageApplicationConverter.ToEntity(analysisInputMortgageApplicationDto);
            analysisInputMortgageApplicationRepo.Update(analysisInputMortgageApplication);

            Logger.Trace("out Update");
        }

        private void Insert(SearchDetail request, UnitOfWorkScope<TargetFrameworkAnalysisEntities> scope)
        {
            Logger.Trace("in Insert");

            // Create the mortgage application row
            var analysisInputMortgageApplicationDto = new AnalysisInputMortgageApplicationDTO();
            analysisInputMortgageApplicationDto.CreatedOn = DateTime.Now;

            Logger.Trace("AnalysisInputMortgageApplicationDto.ApplicationData = JsonHelper.SerializeData(request);");
            analysisInputMortgageApplicationDto.InputData = JsonHelper.SerializeData(request);

            // load default schema for this type of request
            var defaultSchema =
                scope.DbContext.AnalysisInputSchemata.Single(
                    s => s.Name.Equals("Default Mortgage Application from SIRA"));

            analysisInputMortgageApplicationDto.AnalysisInputSchemaID = defaultSchema.AnalysisInputSchemaID; // Test schema entry, use this for now.
            analysisInputMortgageApplicationDto.AnalysisInputSchemaVersionNumber = defaultSchema.AnalysisInputSchemaVersionNumber; // Test schema entry, use this for now.
            analysisInputMortgageApplicationDto.IsActive = true;
            analysisInputMortgageApplicationDto.IsDeleted = false;

            // Update the scope
            Logger.Trace("var AnalysisInputMortgageApplicationRepo = scope.GetGenericRepository<AnalysisInputMortgageApplication, Guid>();");
            var analysisInputMortgageApplicationRepo = scope.GetGenericRepository<AnalysisInputMortgageApplication, Guid>();
            var analysisInputMortgageApplication = AnalysisInputMortgageApplicationConverter.ToEntity(analysisInputMortgageApplicationDto);
            analysisInputMortgageApplicationRepo.Add(analysisInputMortgageApplication);

            // Also create the mortgage application detail row too
            Logger.Trace("AnalysisInputMortgageApplicationDetailDTO AnalysisInputMortgageApplicationDetailDto = new AnalysisInputMortgageApplicationDetailDTO();");
            var analysisInputMortgageApplicationDetailDto = new AnalysisInputMortgageApplicationDetailDTO();
            analysisInputMortgageApplicationDetailDto.AnalysisInputMortgageApplicationID = analysisInputMortgageApplication.AnalysisInputMortgageApplicationID;
            analysisInputMortgageApplicationDetailDto.Lender = request.Lender;
            analysisInputMortgageApplicationDetailDto.Domain = request.Domain;
            analysisInputMortgageApplicationDetailDto.MortgageApplicationNumber = request.MortgageApplicationNumber;
            analysisInputMortgageApplicationDetailDto.SearchReferenceKey = GetSearchReferenceKey(request);
            analysisInputMortgageApplicationDetailDto.IsActive = true;
            analysisInputMortgageApplicationDetailDto.IsDeleted = false;

            // Update the scope
            Logger.Trace("var AnalysisInputMortgageApplicationDetailRepo = scope.GetGenericRepository<AnalysisInputMortgageApplicationDetail, Guid>();");
            var analysisInputMortgageApplicationDetailRepo = scope.GetGenericRepository<AnalysisInputMortgageApplicationDetail, Guid>();
            var analysisInputMortgageApplicationDetail = AnalysisInputMortgageApplicationDetailConverter.ToEntity(analysisInputMortgageApplicationDetailDto);
            analysisInputMortgageApplicationDetailRepo.Add(analysisInputMortgageApplicationDetail);

            Logger.Trace("out Insert");
        }

        private string GetSearchReferenceKey(SearchDetail request)
        {
            // What uniquely identifies the application is a combination of the lender, domain and mortgage application number
            return string.Join("|", request.Lender, request.Domain, request.MortgageApplicationNumber);
        }

        private void Validate(SearchDetail request)
        {
            Logger.Trace("in Validate");

            if (request == null)
            {
                Logger.Trace("request is null");
                m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR011, Message = GetErrorMessage(ErrorEnum.ERR011) });
                return;
            }

            ValidateAttributes(request);
            ValidateTransaction(request);
            ValidateParties(request);

            Logger.Trace("out Validate");
        }

        private void ValidateParties(SearchDetail request)
        {
            Logger.Trace("in ValidateParties");

            if (!request.HasPartyType(PartyTypeEnum.BUY))
            {
                Logger.Trace("ERR007");
                m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR007, Message = GetErrorMessage(ErrorEnum.ERR007) });
            }
            else
            {
                if (!request.HasBuyerName())
                {
                    Logger.Trace("ERR008");
                    m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR008, Message = GetErrorMessage(ErrorEnum.ERR008) });
                }

                if (!request.HasBuyerAddress())
                {
                    Logger.Trace("ERR009");
                    m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR009, Message = GetErrorMessage(ErrorEnum.ERR009) });
                }
            }

            Logger.Trace("out ValidateParties");
        }

        private void ValidateTransaction(SearchDetail request)
        {
            Logger.Trace("in ValidateTransaction");

            if (request.Transaction == null)
            {
                Logger.Trace("ERR010");
                m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR010, Message = GetErrorMessage(ErrorEnum.ERR010) });
            }
            else
                if (!request.Transaction.HasAddress())
                {
                    Logger.Trace("ERR006");
                    m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR006, Message = GetErrorMessage(ErrorEnum.ERR006) });
                }

            Logger.Trace("out ValidateTransaction");
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
                //case ErrorEnum.ERR012:
                //    return "Mortgage application number is not recognized";
                //case ErrorEnum.ERR013:
                //    return "XML Validation Error";
                case ErrorEnum.ERR101:
                    return "Error encountered: ";
                default:
                    return "undefined error";
            }
        }

        private void ValidateAttributes(SearchDetail request)
        {
            Logger.Trace("in ValidateAttributes");

            if (string.IsNullOrEmpty(request.Lender))
            {
                Logger.Trace("ERR001");
                m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR001, Message = GetErrorMessage(ErrorEnum.ERR001) });
            }
            else
                if (!request.IsLenderValid())
                {
                    Logger.Trace("ERR004");
                    m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR004, Message = GetErrorMessage(ErrorEnum.ERR004) });
                }

            if (string.IsNullOrEmpty(request.Domain))
            {
                Logger.Trace("ERR002");
                m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR002, Message = GetErrorMessage(ErrorEnum.ERR002) });
            }
            else
                if (!request.IsDomainValid())
                {
                    Logger.Trace("ERR005");
                    m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR005, Message = GetErrorMessage(ErrorEnum.ERR005) });
                }

            if (string.IsNullOrEmpty(request.MortgageApplicationNumber))
            {
                Logger.Trace("ERR003");
                m_businessErrors.Add(new ErrorDetail() { Code = ErrorEnum.ERR003, Message = GetErrorMessage(ErrorEnum.ERR003) });
            }

            Logger.Trace("out ValidateAttributes");
        }

        private bool IsValid
        {
            get { return m_businessErrors.Count == 0; }
        }

        public void Dispose()
        {
            m_businessErrors = null;
        }
    }
}
