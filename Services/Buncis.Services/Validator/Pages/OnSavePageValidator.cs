using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.Services;
using Buncis.Framework.Core.ViewModel;

namespace Buncis.Services.Validator.Pages
{
	public class OnSavePageValidator : ValidationDictionary<vBuncisPage>
	{
		public OnSavePageValidator(vBuncisPage objectToValidate)
			: base(objectToValidate)
		{

		}

		protected override void ValidationProcess()
		{
			// logic before save here
			isValid = true;
		}
	}
}
