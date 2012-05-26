using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Buncis.Logic.ViewModel;

namespace Buncis.Logic.Models.Pages
{
    public class BuncisPageListingModel
    {
        public IEnumerable<BuncisPageViewModel> BuncisPages { get; set; }
    }
}
