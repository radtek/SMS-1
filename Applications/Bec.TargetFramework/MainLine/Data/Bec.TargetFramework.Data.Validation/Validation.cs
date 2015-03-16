
#region

using System;
using System.Linq.Expressions;

#endregion

namespace Bec.TargetFramework.Data.Validation
{
    public class Validation<TModel>
    {
        private string _errorMessage;
        private string _propertyName;
        private Func<TModel, bool> _validater;
        private Expression<Func<TModel, object>> _property;
        
        public Expression<Func<TModel, object>> GetProperty()
        {
            return this._property;
        }
        
        public Validation<TModel> SetProperty(Expression<Func<TModel, object>> property)
        {
            this._property = property;
            return this;
        }
        
        public string GetPropertyName()
        {
            var memberExpression = this.GetProperty().Body as MemberExpression ?? ((UnaryExpression)this.GetProperty().Body).Operand as MemberExpression;
            
            if (memberExpression == null)
            {
                this._propertyName = default(string);
                return this._propertyName;
            }
            
            this._propertyName = memberExpression.Member.Name;
            
            return this._propertyName;
        }
        
        public Validation<TModel> SetErrorMessage(string errorMessage)
        {
            this._errorMessage = errorMessage;
            return this;
        }
        
        public Validation<TModel> SetValidater(Func<TModel, bool> validater)
        {
            this._validater = validater;
            return this;
        }
        
        public Func<TModel, bool> GetValidater()
        {
            return this._validater;
        }
        
        public string GetErrorMessage()
        {
            return this._errorMessage;
        }
        
        public ValidationResult GetValidationResult()
        {
            return new ValidationResult
            {
                ErrorMessage = this.GetErrorMessage(),
                PropertyName = this.GetPropertyName()
            };
        }
        
        public virtual void OnValidating()
        {
            if (string.IsNullOrEmpty(this._errorMessage))
            {
                this._errorMessage = string.Format("{0} is not valid", this.GetPropertyName());
            }
        }
    }
}