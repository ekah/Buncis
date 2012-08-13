using System.Collections.Generic;
using Buncis.Framework.Core.ViewModel;
using Buncis.Framework.Core.SupportClasses;

namespace Buncis.Framework.Core.Services.DailyBread
{
	public interface IDailyBreadService
	{
		IEnumerable<vDailyBread> GetDailyBreadsNotDeleted(int clientId);
		vDailyBread GetDailyBread(int newsId);
		ValidationDictionary<vDailyBread> DeleteDailyBread(int dailybreadId);
		ValidationDictionary<vDailyBread> SaveDailyBread(int clientId, vDailyBread dailybread);
	}
}
