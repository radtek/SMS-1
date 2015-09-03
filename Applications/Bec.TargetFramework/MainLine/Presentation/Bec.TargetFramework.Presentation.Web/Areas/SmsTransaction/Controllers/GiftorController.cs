using System;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.SmsTransaction.Controllers
{
    [ClaimsRequired("Add", "SmsTransaction", Order = 1000)]
    public class GiftorController : ApplicationControllerBase
    {
        public JsonResult Get()
        {
            return Json(new
            {
                Items = new[]
                {
                    new { Id = Guid.NewGuid().ToString(), Salutation = "Mr", FirstName = "Dave", LastName = "Smiths", Email = "john@smiths.c", Line1 = "Marlesfield House", Line2 = "114-116 Main Road", Town = "Sidcup", PostalCode = "DA14 6NG"},  
                    new { Id = Guid.NewGuid().ToString(), Salutation = "Mrs", FirstName = "Elis", LastName = "Smiths", Email = "am@smiths.c", Line1 = "Marlesfield House", Line2 = "114-116 Main Road", Town = "Sidcup", PostalCode = "DA14 6NG"}
                },
                Count = 2
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Create(string salutation, string firstName, string lastName, string email)
        {
            return Json(new { result = true });
        }

        [HttpPost]
        public JsonResult Update(Guid id, string salutation, string firstName, string lastName, string email)
        {
            return Json(new {result = true});
        }

        [HttpDelete]
        public JsonResult Delete(Guid id)
        {
            return Json(new { result = true });
        }
    }
}