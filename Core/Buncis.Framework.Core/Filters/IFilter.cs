using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace Buncis.Framework.Core.Filters
{
    public interface IFilter<T> where T : class
    {
        Expression<Func<T, bool>> Expression { get; }
    }
}
