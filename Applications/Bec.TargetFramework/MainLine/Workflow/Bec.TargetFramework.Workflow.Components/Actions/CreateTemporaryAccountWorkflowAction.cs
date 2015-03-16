using Autofac;
using Bec.TargetFramework.Entities.DTO.Workflow;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Workflow.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Workflow.Helpers;
using BrockAllen.MembershipReboot;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Framework.Configuration;
using Bec.TargetFramework.SB.Infrastructure.EventSource;
using EnsureThat;

namespace Bec.TargetFramework.Workflow.Components.Actions
{
    class CreateTemporaryAccountWorkflowAction : WorkflowActionBase
    {
        public override bool PerformExecuteCommands()
        {
            try
            {
                //var m_UserLogic = IocContainerBase.IocContainer.Resolve<IUserLogic>();
                //var dataLogic = IocContainerBase.IocContainer.Resolve<IDataLogic>();
                //var commonSettings = IocContainerBase.IocContainer.Resolve<CommonSettings>();

                //var tempAccountDto = base.GetData<TemporaryAccountDTO>(this.Data, WorkflowDataEnum.TemporaryAccountData.GetStringValue());

                //UserAccount tempAccount = null;
                //Guid? uaoId = null;

                ////Check if account exists otherwise create
                //if (!m_UserLogic.DoesUserExist(tempAccountDto.TemporaryUserId, true))
                //{
                //    // generate new password using required standard
                //    string newPassword = Bec.TargetFramework.Security.RandomPasswordGenerator.Generate(10);

                //    tempAccount = m_UserLogic.CreateTemporaryAccount(tempAccountDto.EmailAddress, newPassword, true,
                //        tempAccountDto.TemporaryUserId);

                //    tempAccountDto.Password = newPassword;
                //}
                //else
                //{
                //    tempAccount = m_UserLogic.GetUserAccount(tempAccountDto.TemporaryUserId);
                //}

                //// add user to temp organisation if not existing
                //if (!m_UserLogic.DoesTemporaryUserBelongToTempOrganisation(tempAccount.ID))
                //    uaoId = m_UserLogic.AddUserToTemporaryOrganisation(tempAccount.ID);
                //else
                //    uaoId = m_UserLogic.GetTemporaryUAO(tempAccountDto.TemporaryUserId).UserAccountOrganisationID;

                //Ensure.That(uaoId).IsNotNull();

                //tempAccountDto.UserAccountOrganisationID = uaoId.Value;
                //tempAccountDto.UserName = tempAccount.Username;
                //tempAccountDto.AccountExpiry = DateTime.Now.AddDays(commonSettings.UserAccountExpiryInDays);

                //// send event for creation sending whole dictionary
                //if (
                //        !EventPublisher.PublishEvent(dataLogic, TFEventEnum.TemporaryAccountCreatedEvent.GetStringValue(), "CreateTemporaryAccountWorkflowAction", tempAccount.ID.ToString(),
                //            new object[] {JsonHelper.SerializeData( new WorkflowDictionaryDTO{WorkflowDictionary = this.Data })}))
                //{
                //    //TBD
                //}

                return true;
            }
            catch (Exception ex)
            {
                this.AddWorkflowError(ex);
                return false;
            }
        }
    }
}
