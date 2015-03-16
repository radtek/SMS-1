using System;
using System.Linq.Expressions;

namespace Bec.TargetFramework.Data.Validation.Validators
{
    public class ValidateLengthFluentHelper<TModel> : Validation<TModel>
    {
        private int _max;
        private int _min;

        public override void OnValidating()
        {
            if (String.IsNullOrEmpty(this.GetErrorMessage()))
            {
                this.SetErrorMessage(string.Format("{0} must be between {1} and {2} characters long.", this.GetPropertyName(), _min, _max));
            }
        }

        public int GetMin()
        {
            return this._min;
        }

        public int GetMax()
        {
            return this._max;
        }

        public new ValidateLengthFluentHelper<TModel> SetProperty(Expression<Func<TModel, object>> propertySelector)
        {
            base.SetProperty(propertySelector);
            return this;
        }

        public ValidateLengthFluentHelper<TModel> WithMin(int min)
        {
            this._min = min;
            return this;
        }

        public ValidateLengthFluentHelper<TModel> WithMax(int max)
        {
            this._max = max;
            return this;
        }
    }
}