using Bec.DynamicForm.Business;
using Bec.DynamicForm.Entities.DTO;
using Bec.DynamicForm.UI.Web.DTO;
using Ext.Net;
using Ext.Net.MVC;
using Ext.Net.MVC.Examples.Areas.GridPanel_RowExpander.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bec.DynamicForm.UI.Web.Areas.DynamicForm.Controllers
{
    public class SectionController : Controller
    {
        //
        // GET: /DynamicForm/Section/
        public ActionResult Index(int FormId)
        {
            var model = FormSectionLogic.getAllByFormId(FormId);
            //ViewBag.FormName = FormName;
            ViewBag.FormId = FormId;
            return View(model);
        }
       

        public ActionResult add(int formid)
        {
            var model = new FormSectionDTO();
            model.FormId = formid;

            return View(model);
        }
        public ActionResult edit(int id)
        {
            var model = FormSectionLogic.get(id);

            return View(model);

        }
        public ActionResult save(FormSectionDTO model)
        {
            if (ModelState.IsValid)
            {
                FormSectionLogic.add(model);
                return RedirectToAction("Index", "Section", new { formid = model.FormId, formName = "" });
            }
            return View(model);
        }
        public ActionResult update(FormSectionDTO model)
        {
            if (ModelState.IsValid)
            {
                FormSectionLogic.update(model);
                return RedirectToAction("Index", "Section", new { formid = model.FormId, formName = "" });
            }
            return View(model);
        }


        public ActionResult configureSection(int sectionid)
        {
            List<FormSectionDTO> allSections = FormSectionLogic.getAllByFormId(null);

            foreach (FormSectionDTO obj in allSections)
            {
                if (obj.FormSectionParentId > 0)
                {
                    obj.Parent = new FormSectionDTO();
                    obj.Parent.FormSectionId = obj.FormSectionParentId.Value;

                }
            }
            IList<FormSectionDTO> tree = Bec.DynamicForm.Entities.Helpers.TreeHelper.ConvertToForest(allSections);
            IEnumerable<FormSectionDTO> filter = tree.Where(t => t.FormSectionId == sectionid);
            ViewBag.id = sectionid;

            return View(filter);
        }
        public ActionResult selectQuestion(int formSectionid)
        {
            var model = QuestionLogic.get(null);
            ViewBag.FromSectionId = formSectionid;
            return View(model);
            // return View(new Ext.Net.MVC.Examples.Areas.DragDrop_Advanced.DTO.Example3Model());
        }
        [DirectMethod]
        public ActionResult addChild(int formSectionid)
        {
            return RedirectToAction("addChild", "Section", new { formSectionParentId = formSectionid });

        }
        public ActionResult saveChild(int formSectionParentId)
        {
            FormSectionDTO model = new FormSectionDTO();
            model.FormSectionParentId = formSectionParentId;
            return View(model);

        }
        public ActionResult DirectEventSubmit(FormSectionDTO section)
        {
            FormSectionLogic.add(section);
            return RedirectToAction("Section_Questions", "ConfigureDynamicForm", new { sectionid = section.FormSectionParentId });

            // X.Msg.Alert("Submit", JSON.Serialize(section)).Show();
            // return this.Direct();
        }
        public ActionResult ViewQuestionGrid(int formSectionid)
        {
            return RedirectToAction("selectQuestion", "Section", new { formSectionid = formSectionid });
            // return View(new Ext.Net.MVC.Examples.Areas.DragDrop_Advanced.DTO.Example3Model());
        }
        public ActionResult Submit(string selection, string FromSectionId)
        {
            SelectedRowCollection src = JSON.Deserialize<SelectedRowCollection>(selection);
            int formSectionId = -1;
            int.TryParse(FromSectionId, out formSectionId);
            foreach (SelectedRow row in src)
            {
                long QuestionId = -1;
                if (long.TryParse(row.RecordID, out QuestionId))
                {
                    FormSectionLogic.addQuestionToSectionForm(formSectionId, QuestionId, 0, true, false);
                }
            }

            return RedirectToAction("configureSection", "Section", new { sectionid = FromSectionId });

        }
        public ActionResult BuildLevel(int FormSectionParentId)
        {
            
            return this.ComponentConfig(MultiLevelGridPanel.BuildLevel(FormSectionParentId, Url.Action("BuildLevel")));
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

                List<FormSectionDTO> List = FormSectionLogic.getAllByFormId(null);
                var childList = List.Where(m => m.FormSectionParentId == sectionParentId);
                List<QuestionDTO> questions = QuestionLogic.get(sectionParentId);

                if (childList == null)
                {
                    return this.Store(nodes);
                }

                foreach (FormSectionDTO mapNode in childList)
                {

                    nodes.Add(NodeHelper.CreateNodeWithOutChildren(mapNode, false));
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
            model.FormSectionParentId = sectionParentId;
            model.SectionName = "Edit me";
            nodes.Add(NodeHelper.CreateNodeWithOutChildren(model, false));
            return this.Store(nodes);
        }
	}
}