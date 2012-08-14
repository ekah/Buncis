using System.Collections.Generic;
using Buncis.Framework.Core.ViewModel;
using Buncis.Framework.Core.SupportClasses;

namespace Buncis.Framework.Core.Services.test
{
	public interface ItestService
	{
		IEnumerable<object> GettestsNotDeleted(int clientId);
		object Gettest(int newsId);
		ValidationDictionary<object> Deletetest(int testId);
		ValidationDictionary<object> Savetest(int clientId, object test);
	}
}
