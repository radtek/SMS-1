using Ext.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ext.Net;

namespace Bec.TargetFramework.Web.Framework.Extensions
{
    public static class ControlExtensions
    {
        public static void ApplyBuilderDefaults(this ComboBox.Builder builder, Action< ComboBox.Builder> action)
        {
            action.Invoke(builder);
        }
    }


}
