using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Data.Domain;

namespace Buncis.Core.Services
{
    public interface IPageService
    {
        DynamicPage GetPageByFriendlyUrl(string friendlyUrl);
    }
}
