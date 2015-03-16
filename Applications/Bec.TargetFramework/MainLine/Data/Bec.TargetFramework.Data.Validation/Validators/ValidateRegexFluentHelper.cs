namespace Bec.TargetFramework.Data.Validation.Validators
{
    public class ValidateRegexFluentHelper<TModel> : Validation<TModel>
    {
        private string _pattern;

        public string GetPattern()
        {
            return this._pattern;
        }

        public ValidateRegexFluentHelper<TModel> SetPattern(string pattern)
        {
            this._pattern = pattern;
            return this;
        }
    }
}