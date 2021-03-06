﻿using Dapper;
using DapperExtensions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Creekdream.Domain.Entities;
using Creekdream.Domain.Repositories;

namespace Creekdream.Orm.Dapper
{
    /// <summary>
    /// Repository extension method
    /// </summary>
    public static class RepositoryExtensions
    {
        /// <summary>
        /// Sql statement query result
        /// </summary>
        public static async Task<IEnumerable<TEntity>> QueryAsync<TEntity, TPrimaryKey>(
            this IRepository<TEntity, TPrimaryKey> repository,
            string sql,
            object parameters = null)
            where TEntity : class, IEntity<TPrimaryKey>
        {
            var dapperRepository = (RepositoryBase<TEntity, TPrimaryKey>)repository;
            var dbTransaction = dapperRepository.DbTransaction;
            var dbConnection = dapperRepository.Database.Connection;

            return await dbConnection.QueryAsync<TEntity>(
                sql,
                param: parameters,
                transaction: dbTransaction);
        }

        /// <summary>
        /// Sql statement execution
        /// </summary>
        public static async Task<int> ExecuteAsync<TEntity, TPrimaryKey>(
            this IRepository<TEntity, TPrimaryKey> repository,
            string sql,
            object parameters = null)
            where TEntity : class, IEntity<TPrimaryKey>
        {
            var dapperRepository = (RepositoryBase<TEntity, TPrimaryKey>)repository;
            var dbTransaction = dapperRepository.DbTransaction;
            var dbConnection = dapperRepository.Database.Connection;

            return await dbConnection.ExecuteAsync(
                sql,
                param: parameters,
                transaction: dbTransaction);
        }

        /// <summary>
        /// Paging query
        /// </summary>
        public static async Task<IEnumerable<TEntity>> GetPaged<TEntity, TPrimaryKey>(
            this IRepository<TEntity, TPrimaryKey> repository,
            Expression<Func<TEntity, bool>> predicate,
            int pageIndex,
            int pageSize,
            string ordering = null)
            where TEntity : class, IEntity<TPrimaryKey>
        {
            var dapperRepository = (RepositoryBase<TEntity, TPrimaryKey>)repository;
            var dbTransaction = dapperRepository.DbTransaction;
            var dbConnection = dapperRepository.Database;

            var predicateGroup = dapperRepository.CreatePredicateGroup(predicate);
            return await Task.FromResult(
                dbConnection.GetPage<TEntity>(
                    predicateGroup,
                    ToSortable(ordering),
                    pageIndex,
                    pageSize,
                    transaction: dbTransaction));
        }

        /// <summary>
        /// The sort string is converted to an ISort array, for example: CreationTime desc,Id asc
        /// </summary>
        private static List<ISort> ToSortable(string ordering)
        {
            var sortList = new List<ISort>();
            if (!string.IsNullOrEmpty(ordering))
            {
                foreach (var sort in ordering.Split(','))
                {
                    var sortItem = sort.Split(' ');
                    var sortName = sortItem[0];
                    var sortIsAsc = sortItem[1].Equals("asc", StringComparison.OrdinalIgnoreCase);
                    sortList.Add(new Sort { PropertyName = sortName, Ascending = sortIsAsc });
                }
            }
            return sortList;
        }
    }
}

