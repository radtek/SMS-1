using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Bec.TargetFramework.UI.Web.Helpers
{
    public class DTOHelper
    {
        public static T GetDtoFromJsonObject<T>(ServiceStack.Text.JsonObject jsonObject)
        {
            var dto = Activator.CreateInstance(typeof(T));

            dto.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).ToList().ForEach(prop =>
            {
                if (jsonObject.ContainsKey(prop.Name) && jsonObject[prop.Name] != null)
                {
                    var value = jsonObject[prop.Name].ToString();


                    if (!string.IsNullOrEmpty(value))
                    {

                        if (prop.PropertyType == (typeof(string)))
                            prop.GetSetMethod().Invoke(dto, new object[] { value.ToString() });
                        else if (prop.PropertyType == (typeof(int)))
                            prop.GetSetMethod().Invoke(dto, new object[] { int.Parse(value.ToString()) });
                        else if (prop.PropertyType == (typeof(float)))
                            prop.GetSetMethod().Invoke(dto, new object[] { float.Parse(value.ToString()) });
                        else if (prop.PropertyType == (typeof(DateTime)))
                            prop.GetSetMethod().Invoke(dto, new object[] { DateTime.Parse(value.ToString()) });
                        else if (prop.PropertyType == (typeof(Guid)))
                            prop.GetSetMethod().Invoke(dto, new object[] { Guid.Parse(value.ToString()) });
                        else if (prop.PropertyType == (typeof(bool)))
                            prop.GetSetMethod().Invoke(dto, new object[] { bool.Parse(value.ToString()) });
                        else if (prop.PropertyType == (typeof(decimal)))
                            prop.GetSetMethod().Invoke(dto, new object[] { decimal.Parse(value.ToString()) });
                        else if (prop.PropertyType == (typeof(int?)))
                            prop.GetSetMethod().Invoke(dto, new object[] { int.Parse(value.ToString()) });
                        else if (prop.PropertyType == (typeof(float?)))
                            prop.GetSetMethod().Invoke(dto, new object[] { new float?(float.Parse(value.ToString())) });
                        else if (prop.PropertyType == (typeof(DateTime?)))
                            prop.GetSetMethod().Invoke(dto, new object[] { new DateTime?(DateTime.Parse(value.ToString())) });
                        else if (prop.PropertyType == (typeof(bool?)))
                            prop.GetSetMethod().Invoke(dto, new object[] { new bool?(bool.Parse(value.ToString())) });
                        else if (prop.PropertyType == (typeof(decimal?)))
                            prop.GetSetMethod().Invoke(dto, new object[] { new decimal?(decimal.Parse(value.ToString())) });
                        else if (prop.PropertyType == (typeof(Guid?)))
                            prop.GetSetMethod().Invoke(dto, new object[] { new Guid?(Guid.Parse(value.ToString())) });
                    }
                    else
                    {
                        if (prop.PropertyType == typeof(int?)
                            || prop.PropertyType == typeof(long?)
                            || prop.PropertyType == typeof(Guid?)
                            || prop.PropertyType == typeof(bool?)
                            || prop.PropertyType == typeof(decimal?))
                            prop.GetSetMethod().Invoke(dto, new object[] { null });
                    }
                }
            });

            return (T) dto;
        }
    }
}