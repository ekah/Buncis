﻿using System;
using System.Linq;
using System.Linq.Expressions;

namespace Buncis.Framework.Core.Repository
{
    public interface IReadOnlyRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        T FindBy(Expression<Func<T, bool>> expression);

        IQueryable<T> FilterBy(Expression<Func<T, bool>> expression);
    }
}