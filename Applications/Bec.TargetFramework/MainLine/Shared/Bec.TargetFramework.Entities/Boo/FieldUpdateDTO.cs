using System.Security.Cryptography;
using System.Text;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public partial class FieldUpdateDTO
    {
        public string GetHash()
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(
                this.ActivityType.ToString() +
                this.ActivityID.ToString() +
                this.ParentType.ToString() +
                this.ParentID.ToString() +
                this.FieldName.ToString()
                )).Select(c => c.ToString("x2")));
        }
    }
}
