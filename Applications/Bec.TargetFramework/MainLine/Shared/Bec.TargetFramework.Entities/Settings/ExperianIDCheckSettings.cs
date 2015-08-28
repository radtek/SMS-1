
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Settings;
using System;
using System.Runtime.CompilerServices;

namespace Bec.TargetFramework.Entities.Settings
{
	public class ExperianIDCheckSettings : ISettings
	{
        public int BankWizardAbsoluteTimeout { get; set; }

        public string BankWizardLanguage
        {
            get;
            set;
        }

		public string UserName
		{
			get;
			set;
		}

		public string Password
		{
			get;
			set;
		}

		public string ProductCode
		{
			get;
			set;
		}

        public string CertificatePath
        {
            get;
            set;
        }

        public string CertificatePassword
        {
            get;
            set;
        }

        public string WASPServiceUrl
        {
            get;
            set;
        }

        public string ApplicationName
        {
            get;
            set;
        }

        public string BWAServiceUrl
        {
            get;
            set;
        }
	}
}