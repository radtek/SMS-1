
#region

using System;

#endregion

namespace Bec.TargetFramework.Data.Validation.Validators
{
    public class ValidateRangeFluentHelper<TModel> : Validation<TModel>
    {
        private int _max;
        private int _min;
        private ValidationDataType _validationDataType;
        
        public override void OnValidating()
        {
            if (String.IsNullOrEmpty(this.GetErrorMessage()))
            {
                this.SetErrorMessage(string.Format("{0} must be between {1} and {2}", this.GetPropertyName(), this.GetMin(), this.GetMax()));
            }
        }
        
        public ValidateRangeFluentHelper<TModel> WithDataType(ValidationDataType validationDataType)
        {
            this._validationDataType = validationDataType;
            return this;
        }
        
        public ValidationDataType GetDataType()
        {
            return this._validationDataType;
        }
        
        public ValidateRangeFluentHelper<TModel> WithMin(int min)
        {
            this._min = min;
            return this;
        }
        
        public int GetMin()
        {
            return this._min;
        }
        
        public ValidateRangeFluentHelper<TModel> WithMax(int max)
        {
            this._max = max;
            return this;
        }
        
        public int GetMax()
        {
            return this._max;
        }
    }
}