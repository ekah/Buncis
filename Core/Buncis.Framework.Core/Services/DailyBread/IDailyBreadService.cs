using System.Collections.Generic;
using Buncis.Framework.Core.ViewModel;
using Buncis.Framework.Core.SupportClasses;

namespace Buncis.Framework.Core.Services.DailyBread
{
	public interface IDailyBreadService
	{
		IEnumerable<ViewModelDailyBreadItem> GetAvailableDailyBreadItems(int clientId);
		ViewModelDailyBreadItem GetDailyBreadItem(int dailybreadId);
		ValidationDictionary<ViewModelDailyBreadItem> DeleteDailyBreadItem(int dailybreadId);
		ValidationDictionary<ViewModelDailyBreadItem> SaveDailyBreadItem(int clientId, ViewModelDailyBreadItem viewModelDailyBread);
		string GetDailyBreadUrl(int dailyBreadId, string dailyBreadTitle);

		/// <summary>
		/// Get recent daily bread, get top 10 daily bread
		/// </summary>
		/// <param name="clientId"></param>
		/// <returns></returns>
		IEnumerable<ViewModelDailyBreadItem> GetRecentDailyBread(int clientId);
	}
}
