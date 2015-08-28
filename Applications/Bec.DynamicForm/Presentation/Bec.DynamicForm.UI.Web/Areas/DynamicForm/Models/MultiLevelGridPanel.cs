using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ext.Net.Utilities;
using Bec.DynamicForm.Entities.DTO;
using Bec.DynamicForm.Business;

namespace Ext.Net.MVC.Examples.Areas.GridPanel_RowExpander.Models
{
    public class MultiLevelGridPanel
    {
        public static GridPanel.Builder BuildLevel(int sectionId, string url)
        {
            // bind store
            IEnumerable<QuestionDTO> sectionQuestion = QuestionLogic.getBySectionId(sectionId);
            IList<FormSectionDTO> childSections = FormSectionLogic.getAllByFormId(null);
            IList<FormSectionDTO> data = new List<FormSectionDTO>();
            foreach (FormSectionDTO section in childSections)
            {
                section.QuestionId=-1;
                data.Add(section);
            }
            foreach(QuestionDTO dto in sectionQuestion)
            {
                FormSectionDTO section = new FormSectionDTO();
                section.SectionName = dto.Description;
                section.QuestionId = dto.QuestionId;
                section.FormSectionId = -1;
                section.FormSectionParentId = sectionId;
                data.Add(section);
            }
           

            //build grid
            var grid = new GridPanel
            {
                Height = 215,
                HideHeaders = sectionId != 1,
                DisableSelection = true,
                Store = 
                { 
                    new Store 
                    {                        
                        Model = 
                        {
                            new Model 
                            {
                                IDProperty = "FormSectionId",
                                Fields = 
                                {                                    
                                    new ModelField("FormSectionDTO"),
                                    new ModelField("FormSectionId", ModelFieldType.Int),
                                    new ModelField("SectionName", ModelFieldType.String)
                                }
                            }   
                        },                        
                        DataSource = data   
                    }
                },
                ColumnModel =
                {
                    Columns =
                    {
                        new Column { DataIndex = "SectionName", Text = "SectionName", Flex = 1 },
                        new CommandColumn{ Text="AddQuestion", ToolTip="Add Question"}

                    }
                   
                    
                },
               
                View =
                {
                    new GridView()
                    {
                        OverItemCls = " " //to avoid the known issue #6
                    }
                }
            };

            // add expander for all levels except last (last level is 5)
            if (sectionId!=-1)
            {
                var re = new RowExpander
                {
                    ScrollOffset = 10,
                    Loader = new ComponentLoader
                    {
                        Mode = LoadMode.Component,
                        Url = url,
                        LoadMask =
                        {
                            ShowMask = true
                        },
                        Params = {                            
                            new Ext.Net.Parameter("FormSectionParentId", "this.record.getId()", ParameterMode.Raw)
                        }
                    }
                };

                grid.Plugins.Add(re);
            }

            if (sectionId == 1)
            {
                grid.Title = "MultiLevel grid";
                grid.Width = 600;
                grid.Height = 600;
                grid.ResizableConfig = new Resizer { Handles = ResizeHandle.South };
            }

            return grid.ToBuilder();
        }
    }
}