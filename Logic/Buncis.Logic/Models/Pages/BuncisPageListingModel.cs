using System;
using System.Collections.Generic;
using System.Linq;
using Buncis.Framework.Core.ViewModel;

namespace Buncis.Logic.Models.Pages
{
    public class BuncisPageListingModel
    {
        public IEnumerable<vBuncisPage> BuncisPages { get; set; }
    }
}
