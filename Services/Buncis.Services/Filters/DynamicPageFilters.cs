using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using Buncis.Data.Domain.Pages;
using Buncis.Framework.Core.Filters;

namespace Buncis.Services.Filters
{
	public class DynamicPageFilters : IDynamicPageFilters
	{
		//private Predicate<DynamicPage> _predicate;

		private ParameterExpression argParam = Expression.Parameter(typeof(DynamicPage), "p");
		private Expression _expression;

		public Expression<Func<DynamicPage, bool>> FilterExpression
		{
			get
			{
				Expression<Func<DynamicPage, bool>> e = Expression.Lambda<Func<DynamicPage, bool>>(_expression, argParam);
				return e;
			}
		}

		public DynamicPageFilters()
		{
			Init();
		}

		public IDynamicPageFilters Init()
		{
			Expression pageIdProperty = Expression.Property(argParam, "PageId");
			ConstantExpression val1 = Expression.Constant(0, typeof(int));
			Expression e1 = Expression.GreaterThan(pageIdProperty, val1);

			_expression = e1;

			return this;
		}

		public IDynamicPageFilters GetByClientId(int clientId)
		{
			Expression clientIdProperty = Expression.Property(argParam, "ClientId");
			ConstantExpression val1 = Expression.Constant(clientId, typeof(int));
			Expression e1 = Expression.Equal(clientIdProperty, val1);

			_expression = Expression.AndAlso(_expression, e1);

			return this;
		}

		public IDynamicPageFilters GetByPageId(int pageId)
		{
			Expression pageIdProperty = Expression.Property(argParam, "PageId");
			ConstantExpression val1 = Expression.Constant(pageId, typeof(int));
			Expression e1 = Expression.Equal(pageIdProperty, val1);

			_expression = Expression.AndAlso(_expression, e1);

			return this;
		}

		public IDynamicPageFilters GetByPageUrl(string pageUrl)
		{
			Expression urlProperty = Expression.Property(argParam, "PageUrl");
            ConstantExpression val1 = Expression.Constant(pageUrl, typeof(string));
			Expression e1 = Expression.Equal(urlProperty, val1);

			_expression = Expression.AndAlso(_expression, e1);

			return this;
		}

		public IDynamicPageFilters GetNotDeleted()
		{
			Expression isDeletedProperty = Expression.Property(argParam, "IsDeleted");
			ConstantExpression val1 = Expression.Constant(false, typeof(bool));
			Expression e1 = Expression.Equal(isDeletedProperty, val1);

			_expression = Expression.AndAlso(_expression, e1);

			return this;
		}
	}
}
