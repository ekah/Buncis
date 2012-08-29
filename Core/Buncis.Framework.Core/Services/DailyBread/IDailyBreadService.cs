using System.Collections.Generic;
using Buncis.Framework.Core.ViewModel;
using Buncis.Framework.Core.SupportClasses;

namespace Buncis.Framework.Core.Services.DailyBread
{
    public interface IDailyBreadService
    {
        IEnumerable<ViewModelBuncisDailyBreadItem> GetAvailableDailyBreadItems(int clientId);
        ViewModelBuncisDailyBreadItem GetDailyBreadItem(int dailybreadId);
        ValidationDictionary<ViewModelBuncisDailyBreadItem> DeleteDailyBreadItem(int dailybreadId);
        ValidationDictionary<ViewModelBuncisDailyBreadItem> SaveDailyBreadItem(int clientId, ViewModelBuncisDailyBreadItem dailybread);
    }
}
