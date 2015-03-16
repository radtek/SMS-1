using Bec.DynamicForms.DataAccess;
using Bec.DynamicForms.Models;
using Bec.DynamicForms.MvcApp.Models;
using Bec.DynamicForms.ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bec.DynamicForms.MvcApp.Controllers
{
    public class ConfigureDynamicFormController : Controller
    {
        //
        // GET: /ConfigureDynamicForm/
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Forms_Summary()
        {
            var model = FormManager.Select(null);
            return View(model);
        }
        public ActionResult Form_Create()
        {
            var model = new FormModels();
            return View(model);
        }
        public ActionResult Form_Edit(int id)
        {
            var model = FormManager.Select(id);
            ViewBag.FormId = id;
            return View(model);
        }
       
        public string Form_AddNew(string Name, string Description, string ContactDetails, string ContactFields)
        {
            Form objForm = new Form();
            objForm.FormName = Name;
            objForm.Description = Description;
            objForm.ContactDetails = ContactDetails;
            objForm.ContactFields = ContactFields;
            int ret=FormManager.Add(objForm);
            
            return "success";
        }
       
        public string Form_Update(string FormId,string Name, string Description, string ContactDetails, string ContactFields)
        {
            Form objForm = new Form();
            int iformId = 0;
            int.TryParse(FormId, out iformId);
            objForm.FormId = iformId;
            objForm.FormName = Name;
            objForm.Description = Description;
            objForm.ContactDetails = ContactDetails;
            objForm.ContactFields = ContactFields;
            FormManager.Update(objForm);
            
            return "success";
        }
       
        public string Form_ChangeFormStatus(string FormId, string status)
        {
            Form objForm = new Form();
            int iformId = 0;
            int.TryParse(FormId, out iformId);
            
            bool isActive = false;
            if (status == "Active")
                isActive = true;
            string UserName = string.Empty;
            FormManager.Update(iformId, isActive, UserName);
            
            return "success";
        }
        public ActionResult Forms_Sections(string FormId, string FormName)
        {
            int iformId = 0;
            int.TryParse(FormId, out iformId);
            ViewBag.FormName = FormName;
            var model = FormManager.SelectSection(iformId);
            return View(model);
        }
        [HttpPost]
        public ActionResult AssignSections(List<SectionModels> collection)
        {

            foreach (SectionModels sec in collection)
            {
                if (sec.Enable.Equals("Active"))
                {
                    FormManager.AddSection(sec.FormId,sec.SectionId,sec.SectionNo,"");
                }
                else
                {
                    FormManager.DeleteSection(sec.FormId, sec.SectionId);
                }
            }
            return RedirectToAction("Forms_Summary", "ConfigureDynamicForm");
        }
       
        public ActionResult Section_Summary()
        {
            var model = SectionManager.Select(null);
            return View(model);
        }
        public ActionResult Section_Create()
        {
            var model = new SectionModels();
            model.Categories = FormManager.SelectCategories();
            return View(model);
        }
        public ActionResult Section_Edit(int id)
        {
            var model = SectionManager.Select(id);
            if (model.Count > 0)
            {
                model[0].Categories = FormManager.SelectCategories();
                model[0].IsCategoryBelongToSection();
                return View(model[0]);
            }
            return RedirectToAction("Section_Summary", "ConfigureDynamicForm"); 
        }
        public ActionResult AddSection(SectionModels model)
        {
            string CategoryIds = string.Empty;
            foreach(CategoryModel m in model.Categories)
            {
                if (m.Selected)
                    CategoryIds = CategoryIds + "|" + m.CategoryId;
            }
            string createdBy = string.Empty;
            SectionManager.Add(model.SectionName, model.Description, CategoryIds, createdBy);
            return RedirectToAction("Section_Summary", "ConfigureDynamicForm");
        }
        public ActionResult UpdateSection(SectionModels model)
        {
            string CategoryIds = string.Empty;
            foreach (CategoryModel m in model.Categories)
            {
                if (m.Selected)
                    CategoryIds = CategoryIds + "|" + m.CategoryId;
            }
            string createdBy = string.Empty;
            SectionManager.Update(model.SectionId,model.SectionName, model.Description,true, CategoryIds, createdBy);
            return RedirectToAction("Section_Summary", "ConfigureDynamicForm");
        }
        public string Section_ChangeStatus(string sectionId, string status)
        {
            Form objForm = new Form();
            int isectionId = 0;
            int.TryParse(sectionId, out isectionId);

            bool isActive = false;
            if (status == "Active")
                isActive = true;
            string UserName = string.Empty;
            SectionManager.UpdateStatus(isectionId, isActive, UserName);

            return "success";
        }
        public ActionResult Question_Create(int sectionId,int ParentQuestionId)
        {
            var model = new QuestionModels();
            model.Initialize();
            return View(model);
        }
        public ActionResult Question_Summary(int SectionId, string SectionName)
        {
            var model = QuestionManager.Select(null, SectionId);
            List<QuestionModels> ParentList = new List<QuestionModels>();
            ParentList = model.FindAll(Q => Q.ParentQuestionId == 0);
            if (ParentList.Count() > 0)
            {
                if (ParentList[0].VersionId != null)
                {
                   int VersionId = Convert.ToInt32(ParentList[0].VersionId);
                    int isExists = 0;//(SectionId, VersionId);
                    if (isExists > 0)
                    {
                       // isVersionInUse = true;
                       // btnAdd.Enabled = false;
                        //btnDelete.Enabled = false;
                    }
                    else
                    {
                       // isVersionInUse = false;
                       // btnDelete.Enabled = true;
                        //btnAdd.Enabled = true;
                    }
                }
            }
            var parentfilterList = (from p in ParentList
                              orderby p.SerialNo
                              select p);
            foreach(QuestionModels parent in parentfilterList)
            {
               var childList = model.FindAll(Q => Q.ParentQuestionId == parent.QuestionId);
               var childfilterList = (from p in childList
                                  orderby p.SerialNo
                                  select p);
               foreach (QuestionModels child in childfilterList)
               {
                  

                   var grandchildList = model.FindAll(Q => Q.ParentQuestionId == child.QuestionId);
                   var grandchildfilterList = (from p in grandchildList
                                          orderby p.SerialNo
                                          select p);
                   foreach (QuestionModels grandchild in grandchildfilterList)
                   {
                       child.ChildList.Add(grandchild);
                   }
                   parent.ChildList.Add(child);
                   
               }
                
            }
            
            //rptrQuestions.DataSource = filterList;
           // rptrQuestions.DataBind();
            return View(parentfilterList);
        }
        [HttpPost]
       
        public ActionResult Question_AddQuestion(QuestionModels model)
        {
            //model.AnswerChoiceList.Add(new AnswerChoiceModel(ChoiceName));
            QuestionManager.Add(model);
             return RedirectToAction("Question_Summary", "ConfigureDynamicForm");              
        }

        public ActionResult AddChoice()
        {
            return PartialView("AddEditAnswerChoices", new AnswerChoiceModel());
        }
        //[HttpPost]
        //public JsonResult AddTriggerChoice(AnswerChoiceModel objAnswerChoiceModel)
        //{
           
        //    //return SerializeControl("ConfigureDynamicForm/TriggerAnswers.cshtml", dataObject);
        //    //return Json(new { partial = PartialView("TriggerAnswers", dataObject) });
        //    return Json(new { htmlData = RenderRazorViewToString("~/views/ConfigureDynamicForm/TriggerAnswers.cshtml", objAnswerChoiceModel, ControllerContext, ViewData, TempData) }, JsonRequestBehavior.AllowGet);
        //   // var stringView = RenderRazorViewToString("~/Views/ConfigureDynamicForm/TriggerAnswers.cshtml", dataObject);
        //   // return Json(stringView , JsonRequestBehavior.AllowGet);
        //   // return Json(new { html = RenderViewToString("TriggerAnswers", dataObject) });
        //    //List<AnswerChoiceModel> list = new List<AnswerChoiceModel>();
        //    //return Json(new object( PartialView("TriggerAnswers", dataObject);
        //}
        //public static string RenderRazorViewToString(string viewName, object model, ControllerContext controllerContext, ViewDataDictionary viewData, TempDataDictionary tempData)
        //{
        //    viewData.Model = model;
        //    using (var sw = new System.IO.StringWriter())
        //    {
        //        var viewResult = ViewEngines.Engines.FindPartialView(controllerContext, viewName);
        //        var viewContext = new ViewContext(controllerContext, viewResult.View, viewData, tempData, sw);
        //        viewResult.View.Render(viewContext, sw);
        //        viewResult.ViewEngine.ReleaseView(controllerContext, viewResult.View);
        //        return sw.GetStringBuilder().ToString();
        //    }
        //}
      
       
	}
}
