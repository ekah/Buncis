using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Framework.Core.Services
{
    public abstract class ValidationDictionary<TValidatedType> where TValidatedType : class
    {
        public string ValidationMessage { get; protected set; }

        private readonly Dictionary<string, string> _validationSummary;
        public Dictionary<string, string> ValidationSummary
        {
            get
            {
                return _validationSummary;
            }
        }

        protected bool isValid;
        public bool IsValid
        {
            get
            {
                return isValid;
            }
        }

        protected TValidatedType validatedObject;
        public TValidatedType ValidatedObject
        {
            get
            {
                return validatedObject;
            }
        }

        public ValidationDictionary(TValidatedType objectToValidate)
        {
            _validationSummary = new Dictionary<string, string>();
            validatedObject = objectToValidate;
        }

        protected void AddError(string key, string message)
        {
            _validationSummary.Add(key, message);
        }

        public void Validate()
        {
            if (validatedObject == null)
            {
                throw new Exception("Validated Object has not beet set yet");
            }

            ValidationProcess();
        }

        protected abstract void ValidationProcess();
    }
}
