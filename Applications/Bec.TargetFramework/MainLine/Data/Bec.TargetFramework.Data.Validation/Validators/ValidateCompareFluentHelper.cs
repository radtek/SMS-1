using System;
using System.Linq.Expressions;

namespace Bec.TargetFramework.Data.Validation.Validators
{
    public class ValidateCompareFluentHelper<TModel> : Validation<TModel>
    {
        private Expression<Func<TModel, object>> _otherPropertySelector;
        private ValidationDataType _validationDataType;
        private ValidationOperator _validationOperator;

        public override void OnValidating()
        {
            if (String.IsNullOrEmpty(this.GetErrorMessage()))
            {
                this.SetErrorMessage(string.Format("{0} must be {1} than {2}", this.GetPropertyName(), _validationOperator, this.GetOtherProperty().GetPropertyName()));
            }
        }

        public new ValidateCompareFluentHelper<TModel> SetErrorMessage(string errorMessage)
        {
            base.SetErrorMessage(errorMessage);
            return this;
        }

        public ValidateCompareFluentHelper<TModel> SetOtherProperty(Expression<Func<TModel, object>> otherPropertySelector)
        {
            this._otherPropertySelector = otherPropertySelector;
            return this;
        }

        public Expression<Func<TModel, object>> GetOtherProperty()
        {
            return this._otherPropertySelector;
        }

        public ValidateCompareFluentHelper<TModel> WithOperator(ValidationOperator @operator)
        {
            this._validationOperator = @operator;
            return this;
        }

        public ValidationOperator GetOperator()
        {
            return this._validationOperator;
        }

        public ValidateCompareFluentHelper<TModel> WithDataType(ValidationDataType validationDataType)
        {
            this._validationDataType = validationDataType;
            return this;
        }

        public ValidationDataType GetDataType()
        {
            return this._validationDataType;
        }
    }
}