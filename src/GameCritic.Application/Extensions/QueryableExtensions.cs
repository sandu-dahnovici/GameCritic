using GameCritic.Application.Common.Models;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using GameCritic.Domain.Entities;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GameCritic.Application.Extensions
{
    public static class QueryableExtensions
    {
        public async static Task<PaginatedResult<TDto>> CreatePaginatedResultAsync<TEntity, TDto>(this IQueryable<TEntity> query, PagedRequest pagedRequest, IMapper mapper)
            where TEntity : BaseEntity
            where TDto : class
        {
            query = query.ApplyFilters(pagedRequest);

            var total = await query.CountAsync();

            query = query.Skip(pagedRequest.PageIndex * pagedRequest.PageSize).Take(pagedRequest.PageSize);

            var projectionResult = query.ProjectTo<TDto>(mapper.ConfigurationProvider);

            projectionResult = projectionResult.Sort(pagedRequest);

            var listResult = await projectionResult.ToListAsync();

            return new PaginatedResult<TDto>()
            {
                Items = listResult,
                PageSize = pagedRequest.PageSize,
                PageIndex = pagedRequest.PageIndex,
                Total = total
            };
        }

        private static IQueryable<T> Sort<T>(this IQueryable<T> query, PagedRequest pagedRequest)
        {
            if (!string.IsNullOrWhiteSpace(pagedRequest.ColumnNameForSorting))
            {
                query = query.OrderBy(pagedRequest.ColumnNameForSorting + " " + pagedRequest.SortDirection);
            }
            return query;
        }

        private static IQueryable<T> ApplyFilters<T>(this IQueryable<T> query, PagedRequest pagedRequest)
        {
            var predicate = new StringBuilder();

            predicate.Append($"{pagedRequest.Filter.Path}.Contains(@0)");

            query = query.Where(predicate.ToString(), pagedRequest.Filter.Value);

            return query;
        }
    }
}
