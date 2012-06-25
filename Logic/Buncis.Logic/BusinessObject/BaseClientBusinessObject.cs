using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Buncis.Logic.BusinessObject
{
    public abstract class BaseClientBusinessObject<T> : BaseBusinessObject<T> where T : class
    {
        public int ClientId { get; set; }
    }
}
