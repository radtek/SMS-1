using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Infrastructure.Extensions
{
    public static class EnumExtensions
    {
        public static string GetStringValue(this Enum value)
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Get the stringvalue attributes
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];

            // Return the first if there was a match.
            return attribs.Length > 0 ? attribs[0].StringValue : null;
        }

        public static Guid GetGuidValue(this Enum value)
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo fieldInfo = type.GetField(value.ToString());

            // Get the stringvalue attributes
            StringValueAttribute[] attribs = fieldInfo.GetCustomAttributes(
                typeof(StringValueAttribute), false) as StringValueAttribute[];

            // Return the first if there was a match.
            return attribs.Length > 0 ? Guid.Parse( attribs[0].StringValue) : Guid.Empty;
        }

        public static T? GetEnumValue<T>(string attribValue)
            where T: struct
        {
            var type = typeof(T);
            foreach (var fieldInfo in type.GetFields())
            {
                var sa = fieldInfo.GetCustomAttribute<StringValueAttribute>();
                if (sa != null && sa.StringValue == attribValue) return (T)fieldInfo.GetValue(null);
            }
            return null;
        }

        public static int GetIntValue(this Enum argEnum)
        {
            return Convert.ToInt32(argEnum);
        }
    }

    public class StringValueAttribute : Attribute
    {

        #region Properties

        /// <summary>
        /// Holds the stringvalue for a value in an enum.
        /// </summary>
        public string StringValue { get; protected set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor used to init a StringValue Attribute
        /// </summary>
        /// <param name="value"></param>
        public StringValueAttribute(string value)
        {
            this.StringValue = value;
        }

        #endregion

    }

}
