using Bec.DynamicForm.Business;
using Bec.DynamicForm.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bec.DynamicForm.UI.Web.Areas.DynamicForm.Controllers
{
    public class QuestionController : Controller
    {
      
        public ActionResult add()
        {
            var model = new QuestionDTO();

            // model.Initialize();
            return View(model);
        }
        public ActionResult edit(int id)
        {
            var model = QuestionLogic.get(id);
            //  if(model.Count>0)
            //     model[0].Initialize();           
            return View(model[0]);
        }
        public ActionResult Index()
        {

            var model = QuestionLogic.get(null);
            return View(model);
            // return View(new Ext.Net.MVC.Examples.Areas.DragDrop_Advanced.DTO.Example3Model());
        }

        [HttpPost]
        public ActionResult save(QuestionDTO model)
        {
            QuestionLogic.add(model);
            return RedirectToAction("Index", "Question");
        }

        public ActionResult AddChoice()
        {
            return PartialView("AddEditAnswerChoices", new QuestionOptionDTO());
        }
	}
}