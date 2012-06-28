using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.ViewModel;
using Buncis.Framework.Core.Services;

namespace Buncis.Services.Validator.Pages
{
    public class OnDeletePageValidator : ValidationDictionary<vBuncisPage>
    {
        public OnDeletePageValidator(vBuncisPage objectToValidate)
            : base(objectToValidate)
        {

        }

        protected override void ValidationProcess()
        {
            if (validatedObject != null)
            {
                isValid = true;
            }
            else
            {
                isValid = false;
            }
        }
    }
}
