using System;

namespace Bec.TargetFramework.Data.Infrastructure
{
    public class EntityError
    {
        public String ErrorName;
        public String EntityTypeName;
        public Object[] KeyValues;
        public String PropertyName;
        public string ErrorMessage;
    }
}