using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
//Bec.TargetFramework.Entities
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Services;
using Bec.TargetFramework.UI.Process.Base;
using Ext.Net;
using Ext.Net.MVC;
using Fabrik.Common;
using ServiceStack.Text;
using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.UI.Web.Areas.Component.Controllers
{
    public class ContactController : ApplicationControllerBase
    {
        public ContactController(ILogger logger)
            : base(logger)
        {

        }

        //
        // GET: /Component/Address/
        public ActionResult AddContactToTab(string containerId)
        {
            var result = new Ext.Net.MVC.PartialViewResult
            {
                ViewName = "Index",
                RenderMode = RenderMode.AddTo,
                Model = new ContactDTO(),
                ContainerId = containerId,
                ClearContainer = true,
                WrapByScriptTag = false // we load the view via Loader with Script mode therefore script tags is not required
            };

            this.GetCmp<TabPanel>(containerId).SetLastTabAsActive();

            return result;
        }

        public ActionResult AddContactToContainer(string containerId)
        {
            var model = new ContactDTO();

            var result = new Ext.Net.MVC.PartialViewResult
            {
                ViewName = "Index",
                RenderMode = RenderMode.AddTo,
                Model = model,
                ContainerId = containerId,
                ClearContainer = true,
                WrapByScriptTag = false // we load the view via Loader with Script mode therefore script tags is not required
            };

            return result;
        }

        [HttpPost]
        public ActionResult ValidateBranchContact(ContactDTO viewModel)
        {
            Ensure.NotNull(viewModel);

            var addressList = JsonSerializer.DeserializeFromString<List<AddressDTO>>(viewModel.AddressesJson);

            List<string> errors = new List<string>();

            if (addressList.Count == 0)
                errors.Add("You must enter at least one address");

            ConstructFormErrors("ContactErrors", errors);

            return this.Direct();
        }

        [HttpPost]
        public ActionResult ValidateUserContact(ContactDTO viewModel)
        {
            Ensure.NotNull(viewModel);

            var addressList = JsonSerializer.DeserializeFromString<List<AddressDTO>>(viewModel.AddressesJson);

            List<string> errors = new List<string>();

            if (addressList.Count == 0)
                errors.Add("You must enter at least one address");

            ConstructFormErrors("ContactErrors", errors);

            return this.Direct();
        }


        public ActionResult ValidateContact()
        {
            return PartialView();
        }
    }
}