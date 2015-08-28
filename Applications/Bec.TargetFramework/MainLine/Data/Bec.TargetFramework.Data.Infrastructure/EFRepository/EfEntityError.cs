using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Data.Infrastructure
{
    public class EfEntityError : EntityError
    {
        public string EntityStateName;
        public Dictionary<string,object> EntityValues = new Dictionary<string,object>();

        public EfEntityError()
        {}

        public EfEntityError(EntityInfo entityInfo, String errorName, String errorMessage, String propertyName)
        {
            if (entityInfo != null)
            {
                this.EntityTypeName = entityInfo.Entity.GetType().FullName;
            }
            ErrorName = ErrorName;
            ErrorMessage = errorMessage;
            PropertyName = propertyName;
        }
    }

    public class EFEntityInfo : EntityInfo
    {
        internal EFEntityInfo()
        {
        }

        //internal String EntitySetName;
        //internal ObjectStateEntry ObjectStateEntry;
    }

    public class EntityError
    {

        public String ErrorName;
        public String EntityTypeName;
        public Object[] KeyValues;
        public String PropertyName;
        public string ErrorMessage;

    }

    public class EntityInfo
    {
        protected internal EntityInfo()
        {
        }

        public Object Entity { get; internal set; }
        public EntityState EntityState { get; set; }
        public bool ForceUpdate { get; set; }
    }
}
