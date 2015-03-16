using Autofac.Integration.Mvc;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.UI.Web.Base;
using Fabrik.Common;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Autofac;
using FluentValidation.Results;


namespace Bec.TargetFramework.Entities.Validators
{
    public class BaseValidator<T> : AbstractValidator<T>
    {
        private AutofacDependencyResolver m_IocContainer;
        private FieldDetailsAndValidationsContainerDTO m_FieldDetailsAndValidations;

        public FieldDetailsAndValidationsContainerDTO FieldDetailsAndValidations
        {
            get { return m_FieldDetailsAndValidations; }
            set { m_FieldDetailsAndValidations = value; }
        }
        private Dictionary<string,List<Tuple<string,Func<bool>>>> m_InterfacePanelValidations;

        public string GetInterfacePanelValidationMessage(string ipName,string validationName)
        {
            var IocContainer = DependencyResolver.Current as AutofacDependencyResolver;

            var FieldDetailsAndValidations = IocContainer.ApplicationContainer.Resolve<FieldDetailsAndValidationsContainerDTO>();
            
            var validationData =  FieldDetailsAndValidations.GetInterfacePanelValidationMessage(ipName,validationName);

            return (validationData.OverrideValidationIsHTML.HasValue ? validationData.OverrideValidationIsHTML.Value : false) ? validationData.OverrideValidationMessageHTML : validationData.OverrideValidationMessage;
           
        }


        public BaseValidator()
        {
            //m_IocContainer = DependencyResolver.Current as AutofacDependencyResolver;

            //m_FieldDetailsAndValidations = m_IocContainer.ApplicationContainer.Resolve<FieldDetailsAndValidationsContainerDTO>();

            //m_InterfacePanelValidations = new Dictionary<string, List<Tuple<string, Func< bool>>>>();
        }

        public void AddValidationActionToIPValidationList(string ipName,string validationName,Func<bool> validation)
        {
            List<Tuple<string,Func<bool>>> validationList = null;

            if (m_InterfacePanelValidations.ContainsKey(ipName))
                validationList = m_InterfacePanelValidations[ipName];
            else
                validationList = new List<Tuple<string, Func<bool>>>();

            var validationData = FieldDetailsAndValidations.GetInterfacePanelValidationMessage(ipName, validationName);

            var validationMessage =  (validationData.OverrideValidationIsHTML.HasValue ? validationData.OverrideValidationIsHTML.Value : false) ? validationData.OverrideValidationMessageHTML : validationData.OverrideValidationMessage;

            validationList.Add(new Tuple<string, Func<bool>>(validationMessage, validation));

            m_InterfacePanelValidations.Remove(ipName);
            m_InterfacePanelValidations.Add(ipName, validationList);
        }

        public ValidationWrapper ValidateUsingOneValidation(string ipName, string validationName, Func<bool> validation)
        {
            ValidationWrapper wrapper = new ValidationWrapper();

            bool hasError = validation.Invoke();

            if (hasError)
                wrapper.ErrorMessages.Add(GetInterfacePanelValidationMessage(ipName,validationName));

            return wrapper;
        }

        public ValidationWrapper ValidateUsingIPValidationList(string ipName)
        {
            ValidationWrapper wrapper = new ValidationWrapper();

            List<Tuple<string, Func<bool>>> validationList = null;

            if (m_InterfacePanelValidations.ContainsKey(ipName))
                validationList = m_InterfacePanelValidations[ipName];

            validationList.ForEach(item =>
                {
                    bool hasError = item.Item2.Invoke();

                    if (hasError)
                    {
                        wrapper.ErrorMessages.Add(item.Item1);
                    }
                   
                    
                });


            return wrapper;
        }

       

    }

    public class ValidationWrapper
    {
        public bool HasErrors
        {
            get
            {
                if (ErrorMessages == null || ErrorMessages.Count == 0)
                    return false;
                else
                    return true;
            }
        }
        public List<string> ErrorMessages = new List<string>();
    }
}


