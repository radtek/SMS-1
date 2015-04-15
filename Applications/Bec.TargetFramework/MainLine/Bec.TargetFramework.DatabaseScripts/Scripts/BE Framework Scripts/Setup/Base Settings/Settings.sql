/* Data for the 'public.Setting' table  (Records 1 - 46) */

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (1, E'CommonSettings.LogDebugDatabase', E'True', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (2, E'CommonSettings.LogTraceDatabase', E'True', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (3, E'WorkflowSettings.LogWorkflowTaskSchedulerCommands', E'True', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (4, E'PaymentSettings.AdditionalFee', E'0', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (5, E'PaymentSettings.AdditionalFeePercentage', E'0', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (6, E'PaymentSettings.EnableCardSaving', E'False', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (7, E'PaymentSettings.EnableRecurringPayments', E'False', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (8, E'PaymentSettings.PaymentURL', E'https://test.ipg-online.com/ipgapi/services/order.wsdl', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (9, E'PaymentSettings.GatewayID', E'AE7819-05', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (10, E'PaymentSettings.HMAC', E'Vcuo8yPVj09ZAzOy3AL3WxBe0yx24dcP', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (11, E'PaymentSettings.KeyID', E'WS1120540206._.1', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (12, E'PaymentSettings.Password', E'ep6n9VhEeh', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (13, E'PaymentSettings.UseSandbox', E'False', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (14, E'PaymentSettings.TransactionMode', E'1', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (15, E'WorkflowSettings.EnableWorkflowTrace', E'True', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (16, E'WorkflowSettings.GapBetweenProcessingTasksMilliseconds', E'10000', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (17, E'CommonSettings.PersonalOrganisationType', E'2044', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (18, E'CommonSettings.EnableTrace', E'True', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (19, E'PaymentSettings.KeySerialNumber', E'5B11', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (20, E'ExperianIDCheckSettings.UserName', E'beconsult_uat', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (21, E'ExperianIDCheckSettings.Password', E'Itsvctr3#', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (22, E'ExperianIDCheckSettings.ProductCode', E'ProveID_KYC', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (23, E'ExperianIDCheckSettings.CertificatePath', E'BEConsultingltdUAT.p12', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (24, E'ExperianIDCheckSettings.CertificatePassword', E'Psme09499', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (25, E'ExperianIDCheckSettings.WASPServiceUrl', E'https://secure.authenticator.uat.uk.experian.com/WASPAuthenticator/TokenService.asmx', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (26, E'ExperianIDCheckSettings.ApplicationName', E'STS', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (27, E'ExperianIDCheckSettings.BWAServiceUrl', E'https://uat.bankwizardondemand.uk.experian.com/absolute/server/bankwizardservice_v1_1.asmx', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (31, E'CommonSettings.IconFilePath', E'~/Content/resources/images/icons/', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (32, E'CommonSettings.ServerUrl', E'http://localhost:22468/', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (33, E'CommonSettings.ServerFolderName', E'/Bec.TargetFramework.Web.UI/', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (35, E'CommonSettings.PrimaryEmailAddressOfTFFramework', E'applications@beconsultancy.co.uk', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (37, E'ServerLogoImageFileNameWithExtension', E'SMSLogo.jpg', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (38, E'CommonSettings.ServerLogoImageFileNameWithExtension', E'SMSLogoSmall.png', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (39, E'CommonSettings.ServerNotificationImageContentUrlFolder', E'Content/resources/images/STS/', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (41, E'CommonSettings.LoginActionRoute', E'STSLogin/Login', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (43, E'CommonSettings.NotificationFromEmailAddress', E'applications@beconsultancy.co.uk', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (44, E'CommonSettings.UserAccountExpiryInDays', E'21', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (45, E'CommonSettings.PrimaryUserIDFromBecAdministrationNotifications', E'b60de4d4-6109-11e4-864b-27436fc41ccb', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (46, E'CommonSettings.ServerChangePasswordActionRoute', E'STSLogin/ChangePassword/Index', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (47, E'CommonSettings.TimeSinceLastNotificationOfSameTypeWasSent', E'180', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (48, E'CommonSettings.Environment', E'DEV', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (49, E'LRSettings.Environment', E'DEV', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (50, E'LRSettings.LRUserName', E'1', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (51, E'LRSettings.LRPassword', E'1', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (52, E'LRSettings.LRCertificateSerialNumber', E'1', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (53, E'LRSettings.LRBindingConfigurationName', E'1', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (54, E'CommonSettings.ProductName', E'BEC Software', True, False);

INSERT INTO public."Setting" ("Id", "Name", "Value", "IsActive", "IsDeleted")
VALUES (55, E'CommonSettings.PublicWebsiteUrl', E'http://www.becsoftware.co.uk', True, False);