using System;
using System.Linq.Expressions;

namespace Buncis.Framework.Core.SupportClasses.Filters
{
    public interface IFilter<T> where T : class
    {
        Expression<Func<T, bool>> FilterExpression { get; }
    }
}
