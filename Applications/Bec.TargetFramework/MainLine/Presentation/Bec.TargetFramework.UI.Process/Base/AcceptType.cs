using System;

namespace Bec.TargetFramework.UI.Process.Base
{
    public class AcceptType : IComparable
    {
        public string Type { get; set; }

        public float Quality { get; set; }

        public int Order { get; set; }

        public AcceptType(string type, float quality, int order)
        {
            this.Type = type;
            this.Quality = quality;
            if (type == "*/*")
            {
                this.Quality = 0;
            }
            this.Order = order;
        }

        public int CompareTo(object obj)
        {
            var other = (AcceptType)obj;
            var result = other.Quality.CompareTo(this.Quality);
            if (result == 0)
            {
                result = this.Order.CompareTo(other.Order);
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            if (object.ReferenceEquals(obj, null))
            {
                return false;
            }
            if (object.ReferenceEquals(this, obj))
            {
                return true;
            }
            var other = (AcceptType)obj;
            return this.Type.Equals(other.Type);
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}", this.Type, this.Quality, this.Order);
        }
    }
}