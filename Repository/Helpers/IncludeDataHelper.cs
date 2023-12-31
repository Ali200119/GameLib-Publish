﻿using System;
using System.Linq.Expressions;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Repository.Helpers
{
	public static class IncludeDataHelper
	{
		public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] includes) where T: BaseEntity
		{
			if (includes is not null)
			{
				query = includes.Aggregate(query, (current, include) => current.Include(include));
			}

			return query;
		}
    }
}