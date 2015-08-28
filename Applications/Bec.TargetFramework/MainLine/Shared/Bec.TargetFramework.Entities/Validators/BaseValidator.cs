using Autofac.Integration.Mvc;
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

        public BaseValidator()
        {
            //m_IocContainer = DependencyResolver.Current as AutofacDependencyResolver;

            //m_FieldDetailsAndValidations = m_IocContainer.ApplicationContainer.Resolve<FieldDetailsAndValidationsContainerDTO>();

            //m_InterfacePanelValidations = new Dictionary<string, List<Tuple<string, Func< bool>>>>();
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


