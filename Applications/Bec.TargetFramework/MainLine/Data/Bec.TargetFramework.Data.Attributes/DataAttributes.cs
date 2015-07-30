using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Data.Attributes
{
    public class CollectionUpdateBehaviourAttribute : Attribute
    {
        public UpdateBehaviour Behaviour { get; private set; }
        public CollectionUpdateBehaviourAttribute(UpdateBehaviour behaviour)
        {
            Behaviour = behaviour;
        }
    }

    public enum UpdateBehaviour { Ignore, Replace }
}
