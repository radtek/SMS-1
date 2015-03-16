using Autofac;
using Bec.TargetFramework.Entities.DTO.Workflow;
using Bec.TargetFramework.Workflow.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using BrockAllen.MembershipReboot;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Extensions;
using System.Collections.Concurrent;
using Bec.TargetFramework.Workflow.Interfaces;
namespace Bec.TargetFramework.Workflow.Components.Actions
{
    class CreatePermanentLoginWorkflowAction : WorkflowActionBase
    {
        public override bool PerformExecuteCommands()
        {

                //if (DataContains(WorkflowDataEnum.PermanentAccountData.GetStringValue()))
                //{
                //    var m_UserLogic = IocContainerBase.IocContainer.Resolve<IUserLogic>();
                //    UserAccountService uaService = IocContainerBase.IocContainer.Resolve<UserAccountService>();
                //    var registrationDto = base.GetData<RegistrationDTO>(this.Data,
                //       WorkflowDataEnum.RegistrationData.GetStringValue());
                //    var data = base.GetData<PermanentAccountDTO>(this.Data,
                //       WorkflowDataEnum.PermanentAccountData.GetStringValue());
                //    TemporaryAccountDTO tempData = base.GetData<TemporaryAccountDTO>(this.Data,
                //        WorkflowDataEnum.TemporaryAccountData.GetStringValue());
                //    BrockAllen.MembershipReboot.UserAccount tempAccount = m_UserLogic.GetUserAccount(tempData.TemporaryUserId);

                //    BrockAllen.MembershipReboot.UserAccount permanentAcc = null; ;
                //    List<UserAccountDTO> account = m_UserLogic.GetUserAccountByEmail(data.EmailAddress, true);

                //    bool userAccountExists = (account.Count > 0);

                //    if (!userAccountExists)
                //    {
                //        // create account
                //        permanentAcc = m_UserLogic.CreateAccount(data.UserName, data.Password, data.EmailAddress, false,
                //            data.UserID);

                //        // set security questions if for some reason others already exist
                //        if (permanentAcc.PasswordResetSecrets.Count > 0)
                //        {
                //            foreach (var secret in permanentAcc.PasswordResetSecrets)
                //                uaService.RemovePasswordResetSecret(permanentAcc.ID, secret.PasswordResetSecretID);
                //        }
                //        uaService.AddPasswordResetSecret(permanentAcc.ID, data.Password, data.Question1, data.Answer1);
                //        uaService.AddPasswordResetSecret(permanentAcc.ID, data.Password, data.Question2, data.Answer2);
                //    }

                //    //Create Contact

                //    var PermanentAccountContact = new ContactDTO();

                //    // create colp contact if not existing
                //    if (!m_UserLogic.ContactExists(data.UserID))
                //    {
                //        PermanentAccountContact.ContactName = registrationDto.COFirstName + " " + registrationDto.COLastName;
                //        PermanentAccountContact.FirstName = registrationDto.COFirstName;
                //        PermanentAccountContact.LastName = registrationDto.COLastName;
                //        PermanentAccountContact.EmailAddress1 = registrationDto.COEmail;
                //        PermanentAccountContact.ParentID = data.UserID;
                //        PermanentAccountContact.IsPrimaryContact = true;

                //        m_UserLogic.CreateContact(PermanentAccountContact);
                //    }

                //    Guid? userID = null;

                //    if (userAccountExists)
                //        userID = account.First().ID;
                //    else
                //        userID = permanentAcc.ID;


                //    if (!m_UserLogic.DoesPermanentUserHavePersonalOrganisation(userID.Value))
                //       {
                //            try
                //            {
                //                var uaoID = m_UserLogic.CreateAndAddUserToPersonalOrganisation(userID.Value);

                //                tempData.UserAccountOrganisationID = uaoID.GetValueOrDefault(Guid.Empty);

                //                m_UserLogic.LockUserTemporaryAccount(tempAccount.ID);
                //            }
                //            catch (Exception ex)
                //            {
                //                actionCompleted = false;

                //                AddWorkflowError(ex);
                //                throw;
                //            }
                //        }



            return true;
        }
    }
}
