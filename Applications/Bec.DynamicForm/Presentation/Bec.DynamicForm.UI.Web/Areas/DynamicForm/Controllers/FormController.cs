using Bec.DynamicForm.Business;
using Bec.DynamicForm.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bec.DynamicForm.UI.Web.Areas.DynamicForm.Controllers
{
    public class FormController : Controller
    {
        //
        // GET: /DynamicForm/Form/
        public ActionResult Index()
        {
            var model = FormLogic.get(null);
            return View(model);
        }
        public ActionResult add()
        {
            var model = new FormDTO();
            return View(model);
        }
        public ActionResult edit(int id)
        {
            var model = FormLogic.get(id);

            if (model != null && model.Count > 0)
                return View(model[0]);
            return RedirectToAction("index", "Form");
        }
        public ActionResult save(FormDTO model)
        {
            if (ModelState.IsValid)
            {
                int ret = FormLogic.add(model);
                return RedirectToAction("Index", "Form");
            }
            return View(model);
        }
        public ActionResult update(FormDTO model)
        {
            if (ModelState.IsValid)
            {
                FormLogic.update(model);
                return RedirectToAction("Index", "Form");
            }
            return View(model);
        }
	}
}