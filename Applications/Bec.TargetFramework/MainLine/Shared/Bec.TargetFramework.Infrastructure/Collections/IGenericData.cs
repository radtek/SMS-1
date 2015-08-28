using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Infrastructure.Collections
{
    public interface IGenericData : IEnumerable<KeyValuePair<string, object>>
    {
        /// <summary>
        /// Checks if view data contains a parameter.
        /// </summary>
        /// <param name="key">Parameter key</param>
        /// <returns><c>true</c> if found; otherwise <c>false</c>.</returns>
        bool Contains(string key);

        /// <summary>
        /// Gets or sets a view data parameter.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        object this[string name] { get; set; }

        T GetValue<T>(string name);

        /// <summary>
        /// Try get a value from the dictionary.
        /// </summary>
        /// <param name="name">Name of parameter</param>
        /// <param name="value">Value if any.</param>
        /// <returns><c>true</c> if found; otherwise <c>false</c>.</returns>
        bool TryGetValue(string name, out object value);

        /// <summary>
        /// Used by spark view engine.
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        object Eval(string expression);
    }
}
