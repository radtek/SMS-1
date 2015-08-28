using System.Collections.Generic;
using System.Web.Mvc;

namespace Bec.TargetFramework.Web.Framework.Mvc
{
    /// <summary>
    /// Base nopCommerce model
    /// </summary>
    public partial class BaseTargetFrameworkModel
    {
        public BaseTargetFrameworkModel()
        {
            this.CustomProperties = new Dictionary<string, object>();
        }
        public virtual void BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
        }

        /// <summary>
        /// Use this property to store any custom value for your models. 
        /// </summary>
        public Dictionary<string, object> CustomProperties { get; set; }
    }

    /// <summary>
    /// Base nopCommerce entity model
    /// </summary>
    public partial class BaseNopEntityModel : BaseTargetFrameworkModel
    {
        public virtual int Id { get; set; }
    }
}
