using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ext.Net;
using Ext.Net.MVC;
using Bec.TargetFramework.UI.Process.Base;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;

namespace Bec.TargetFramework.UI.Web.Controllers
{
    [DirectController]
    public class MenuController : ApplicationControllerBase
    {
        public MenuController(IStateLogic logic, ILogger logger)
            : base(logger)
        {
            m_StateLogic = logic;
        }

       

        private IStateLogic m_StateLogic;

        //
        // GET: /Menu/
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Returns TopBar Center Menu Item List
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [DirectMethod]
        public ActionResult TopBarMenuItems(string id)
        {
            List<MenuItem> menuItems = new List<MenuItem>();

            m_StateLogic.GetStateItemTreeDTOForStateID(Guid.Parse("A9270D71-6EF7-48EB-8CC7-DFBE58F949E4")).ForEach(
                sta =>
                {
                    MenuItem mi = new MenuItem { Text = sta.StateItemName };

                    var menu = new Menu();

                    sta.Children.ForEach(ci => menu.Add(new MenuItem { Text = ci.StateItemName }));

                    if (menu.Items.Count > 0)
                        mi.Menu.Add(menu);

                    menuItems.Add(mi);
                });

            return this.Direct(ComponentLoader.ToConfig(menuItems));
        }

        /// <summary>
        /// Returns TopBar Right Menu Items
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [DirectMethod]
        public ActionResult TopRightMenuItems(string id)
        {
            List<AbstractComponent> items = new List<AbstractComponent>();

            items.Add(new ToolbarFill());

            int index = 0;
            m_StateLogic.GetStateItemTreeDTOForStateID(Guid.Parse("4689fbf4-4d75-11e4-9b12-bb2d7efdf86d")).ForEach(
                sta =>
                {
                    if (index == 0)
                        items.Add(new HyperLink { Text = sta.StateItemName });
                    else
                    {
                        items.Add(new ToolbarSpacer());
                        items.Add(new ToolbarSeparator());
                        items.Add(new ToolbarSpacer());

                        items.Add(new HyperLink { Text = sta.StateItemName });
                    }

                    index++;
                });

            items.Add(new ToolbarSpacer());
            items.Add(new ToolbarSeparator());
            items.Add(new ToolbarSpacer());

            return this.Direct(ComponentLoader.ToConfig(items));
        }
    }
}