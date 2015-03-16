
using Bec.DynamicForm.UI.Web.DTO;
using Bec.DynamicForm.Business;
using Bec.DynamicForm.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net;
using Ext.Net.MVC;
using System.Text;
namespace Bec.DynamicForm.UI.Web.Controllers
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
            var model = FormManager.selectForm(null);
            return View(model);
        }
        public ActionResult Form_Create()
        {
            var model = new FormDTO();
            return View(model);
        }
        public ActionResult Form_Edit(int id)
        {
            var model = FormManager.selectForm(id);
           
            if (model != null && model.Count > 0)
                return View(model[0]);
            return RedirectToAction("Forms_Summary", "ConfigureDynamicForm"); 
        }

        public ActionResult Form_add(FormDTO model)
        {
            if (ModelState.IsValid)
            {
                int ret = FormManager.addForm(model);
                return RedirectToAction("Forms_Summary", "ConfigureDynamicForm");
            }
            return View(model);
        }
        public ActionResult Form_Update(FormDTO model)
        {
            if (ModelState.IsValid)
            {
                FormManager.updateForm(model);
                return RedirectToAction("Forms_Summary", "ConfigureDynamicForm");
            }
            return View(model);
        }
        public ActionResult Section_Summary(int FormId,string FormName)
        {
            var model = FormSectionManager.Select(null,FormId);
            ViewBag.FormName = FormName;
            ViewBag.FormId = FormId;
            return View(model);
        }
       
        public ActionResult Section_Create(int formid)
        {
            var model = new FormSectionDTO();
            model.FormId = formid;
            
            return View(model);
        }
        public ActionResult Section_Edit(int id)
        {
            var model = FormSectionManager.Select(id,null);
            if (model.Count > 0)
            {                
                return View(model[0]);
            }
            return RedirectToAction("Section_Summary", "ConfigureDynamicForm"); 
        }
        public ActionResult AddSection(FormSectionDTO model)
        {
            if (ModelState.IsValid)
            {
                FormSectionManager.addSection(model);
                return RedirectToAction("Section_Summary", "ConfigureDynamicForm", new {formid=model.FormId,formName="" });
            }
            return View(model);
        }
        public ActionResult UpdateSection(FormSectionDTO model)
        {
            if (ModelState.IsValid)
            {
                FormSectionManager.updateSection(model);
                return RedirectToAction("Section_Summary", "ConfigureDynamicForm", new { formid = model.FormId, formName = "" });
            }
            return View(model);
        }
        
        public ActionResult Question_Create()
        {
            var model = new QuestionDTO();
          
           // model.Initialize();
            return View(model);
        }
        public ActionResult Question_Edit1(int id)
        {
            var model = QuestionManager.SelectQuestion(id);
          //  if(model.Count>0)
           //     model[0].Initialize();           
            return View(model[0]);
        }
        public ActionResult Question_Summary()
        {
            
            var model = QuestionManager.SelectQuestion(null);           
            return View(model);
           // return View(new Ext.Net.MVC.Examples.Areas.DragDrop_Advanced.DTO.Example3Model());
        }
        
        [HttpPost]
        public ActionResult Question_AddQuestion(QuestionDTO model)
        {            
            QuestionManager.addQuestion(model);
             return RedirectToAction("Question_Summary", "ConfigureDynamicForm");              
        }

        public ActionResult AddChoice()
        {
            return PartialView("AddEditAnswerChoices", new QuestionOptionDTO());
        }
        public ActionResult Section_Questions(int sectionid)
        {
            List<FormSectionDTO> allSections = FormSectionManager.Select(null, null);

            foreach(FormSectionDTO obj in allSections)
            {
                if(obj.FormSectionParentId>0)
                {
                    obj.Parent=new FormSectionDTO();
                    obj.Parent.FormSectionId=obj.FormSectionParentId;
                    
                }
            }
            IList<FormSectionDTO> tree=Bec.DynamicForm.Entities.Helpers.TreeHelper.ConvertToForest(allSections);
            IEnumerable<FormSectionDTO> filter = tree.Where(t => t.FormSectionId == sectionid);


            return View(filter);
        }
        public ActionResult QuestionGrid(int formSectionid)
        {
            var model = QuestionManager.SelectQuestion(null);
            ViewBag.FromSectionId = formSectionid;
            return View(model);
            // return View(new Ext.Net.MVC.Examples.Areas.DragDrop_Advanced.DTO.Example3Model());
        }
        public ActionResult Submit(string selection, string FromSectionId)
        {
            
            StringBuilder result = new StringBuilder();
            result.Append("<b>Selected Rows (ids)</b></br /><ul>");
            SelectedRowCollection src = JSON.Deserialize<SelectedRowCollection>(selection);
            SelectedRowCollection section=JSON.Deserialize<SelectedRowCollection>(FromSectionId);
            int formSectionId=-1;
            foreach(SelectedRow sec in section)
            {
               if(  int.TryParse(sec.RecordID,out formSectionId))
                   break;
            }
            foreach (SelectedRow row in src)
            {
               // result.Append("<li>" + row.RecordID + "</li>");
                
               long QuestionId=-1;
               if( long.TryParse(row.RecordID,out QuestionId))
               {
                   FormSectionManager.addQuestionToFormSection(formSectionId, QuestionId, 0, true, false);
               }
            }

            result.Append("</ul>");
            X.GetCmp<Label>("Label1").Html = result.ToString();

            return this.Direct();
        }

// your recursive ordering

        public ActionResult GetNodes(string node)
        {
            if (!string.IsNullOrEmpty(node))
            {
                NodeCollection nodes = new NodeCollection();
                node = node.Replace("nds", "");
                int sectionParentId = -1;
                int.TryParse(node, out sectionParentId);

                List<FormSectionDTO> List = FormSectionManager.Select(null, null);
                var childList = List.Where(m => m.FormSectionParentId == sectionParentId);
                List<QuestionDTO> questions = QuestionManager.SelectQuestion(sectionParentId);

                if (childList == null)
                {
                    return this.Store(nodes);
                }

                foreach (FormSectionDTO mapNode in childList)
                {                  
                                     
                    nodes.Add(NodeHelper.CreateNodeWithOutChildren(mapNode,false));
                }
                foreach (QuestionDTO mapNode in questions)
                {                  

                    nodes.Add(NodeHelper.CreateNodeWitChildren(mapNode));
                }

                return this.Store(nodes);
            }

            return new HttpStatusCodeResult(500);
        }
        public ActionResult SubmitNodes(SubmittedNode data)
        {
            NodeCollection nodes = new NodeCollection();
            FormSectionDTO model = new FormSectionDTO();
            model.FormSectionId = -1;
            string node = data.NodeID.Replace("nds", "");
            int sectionParentId = -1;
            int.TryParse(node, out sectionParentId);
            model.FormSectionParentId =sectionParentId ;
            model.SectionName = "Edit me";
            nodes.Add(NodeHelper.CreateNodeWithOutChildren(model, false));
            return this.Store(nodes);
        }
	}
}
