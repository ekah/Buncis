using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Framework.Core.Services;
using Buncis.Framework.Core.ViewModel;

namespace Buncis.Services.Validator.News
{
	public class OnSaveNewsValidator : ValidationDictionary<vBuncisNews>
	{
		public OnSaveNewsValidator(vBuncisNews objectToValidate)
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
