using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bec.TargetFramework.Presentation.Web.Helpers
{
    public class Edit<T>
    {
        public T Model { get; set; }
        
    }

    public static class Edit
    {
        public static string MakeModel(JObject res)
        {
            JObject m = new JObject();
            m["Model"] = res;
            return m.ToString(Formatting.None);
        }

        public static Edit<T> MakeModel<T>(T res)
        {
            Edit<T> m = new Edit<T> { Model = res };
            return m;
        }

        public static Dictionary<T, T2> ReadFormValues<T, T2>(HttpRequestBase request, string prefix, Func<string, T> mapKey, Func<string, T2> mapVal)
        {
            Dictionary<T, T2> ret = new Dictionary<T, T2>();
            foreach (string k in request.Form.AllKeys.Where(k => k.StartsWith(prefix))) ret.Add(mapKey(k.Substring(prefix.Length)), mapVal(request.Form[k]));
            return ret;
        }
    }
}