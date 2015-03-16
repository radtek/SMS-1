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
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.UI.Web.Areas.Component.Controllers
{
 
    [AllowAnonymous]
    public class AddressController : ApplicationControllerBase
    {
        private IAddressLogic m_AddressLogic;

        public AddressController(ILogger logger,IAddressLogic logic)
            : base(logger)
        {
            m_AddressLogic = logic;
        }

        //
        // GET: /Component/Address/
        public ActionResult AddAddressToTab(string containerId)
        {
            var result = new Ext.Net.MVC.PartialViewResult
            {
                ViewName = "Index",
                RenderMode = RenderMode.AddTo,
                ContainerId = containerId,
                WrapByScriptTag = false // we load the view via Loader with Script mode therefore script tags is not required
            };

            this.GetCmp<TabPanel>(containerId).SetLastTabAsActive();

            return result;
        }

        public ActionResult AddAddressToContainer(string containerId)
        {
            var result = new Ext.Net.MVC.PartialViewResult
            {
                ViewName = "Index",
                RenderMode = RenderMode.AddTo,
                Model = new AddressDTO(),
                ContainerId = containerId,
                ClearContainer = true,
                WrapByScriptTag = false // we load the view via Loader with Script mode therefore script tags is not required
            };

            return result;
        }

        [OverrideActionFilters]
        [AllowAnonymous]
        public virtual ActionResult GetPostCodeAddresses(string postCode, string building)
        {
            Ensure.NotNullOrEmpty(postCode);

            return Json(new { data = m_AddressLogic.FindAddressesByPostCode(postCode, building) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult AddAddressToContact(AddressDTO address, string addressesJsonValue, string jsonField)
        {
            var hidden = this.GetCmp<Hidden>("AddressesJson");

            ////// get current address list
            var addressList = JsonSerializer.DeserializeFromString<List<AddressDTO>>(addressesJsonValue);

            bool isNew = false;

            // if new address is primary reset all others
            if (address.IsPrimaryAddress.HasValue && address.IsPrimaryAddress.Value)
                addressList.ForEach(item => item.IsPrimaryAddress = false);

            if (address.AddressID.Equals(Guid.Empty))
            {
                address.AddressID = Guid.NewGuid();

                // geocode
                var geoCoding = m_AddressLogic.GeoCodePostcode(address.PostalCode);

                if (geoCoding.results != null && geoCoding.results.Any())
                {
                    address.Longitude = Convert.ToDouble(geoCoding.results[0].geometry.location.lng);
                    address.Latitude = Convert.ToDouble(geoCoding.results[0].geometry.location.lat);
                }

                isNew = true;
            }
            //address.AddressIDString = address.AddressID.ToString();

            if (isNew)
                addressList.Add(address);
            else
            {
                // refresh address
                addressList.Remove(addressList.Single(item => item.AddressID.Equals(address.AddressID)));
                addressList.Add(address);
            }

            hidden.SetValue(JsonSerializer.SerializeToString(addressList));
            hidden.Update();

            return this.Direct();
        }

        public ActionResult GetAddresses(string addressesJsonValue)
        {
            var addressList = JsonSerializer.DeserializeFromString<List<AddressDTO>>(addressesJsonValue);

            if (addressList != null && addressList.Count > 0)
            {
                addressList.ForEach(item => { item.AddressIDString = item.AddressID.ToString(); });

                return this.Store(addressList.ToList());
            }
            else
                return this.Store(new List<ListItem>());

        }

        public ActionResult EditAddress(string addressesJsonValue, string selectedAddress)
        {
            ////// get current address list
            var addressList = JsonSerializer.DeserializeFromString<List<AddressDTO>>(addressesJsonValue);

            var address = addressList.Single(item => item.Name.Equals(selectedAddress));

            var form = this.GetCmp<FormPanel>("AddressForm");

            form.Reload();

            return this.Direct();
        }
    }
}