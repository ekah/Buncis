using System.Collections.Generic;
using Buncis.Framework.Core.ViewModel;
using Buncis.Framework.Core.SupportClasses;

namespace Buncis.Framework.Core.Services.DailyBread
{
    public interface IDailyBreadService
    {
        IEnumerable<vBuncisDailyBreadItem> GetDailyBreadItemsNotDeleted(int clientId);
        vBuncisDailyBreadItem GetDailyBreadItem(int dailybreadId);
        ValidationDictionary<vBuncisDailyBreadItem> DeleteDailyBreadItem(int dailybreadId);
        ValidationDictionary<vBuncisDailyBreadItem> SaveDailyBreadItem(int clientId, vBuncisDailyBreadItem dailybread);
    }
}
