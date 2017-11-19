using Abp.Dependency;
using Abp.EntityFramework;
using Mao.EntityFramework;
using Mao.EntityFramework.EntityFramework;
using Mao.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mao.EntityFramework.Extensions
{
    public class SqlExecuter : ISqlExecuter, ITransientDependency
    {
        private readonly IDbContextProvider<MaoDbContext> _dbContextProvider;

        public SqlExecuter(IDbContextProvider<MaoDbContext> dbContextProvider)
        {
            _dbContextProvider = dbContextProvider;
        }

        /// <summary>
        /// 执行给定的命令
        /// </summary>
        /// <param name="sql">命令字符串</param>
        /// <param name="parameters">要应用于命令字符串的参数</param>
        /// <returns>执行命令后由数据库返回的结果</returns>
        public int Execute(string sql, params object[] parameters)
        {
            return _dbContextProvider.GetDbContext().Database.ExecuteSqlCommand(sql, parameters);
        }

        /// <summary>
        /// 创建一个原始 SQL 查询，该查询将返回给定泛型类型的元素。
        /// </summary>
        /// <typeparam name="T">查询所返回对象的类型</typeparam>
        /// <param name="sql">SQL 查询字符串</param>
        /// <param name="parameters">要应用于 SQL 查询字符串的参数</param>
        /// <returns></returns>
        public async Task<List<T>> SqlQueryAsync<T>(string sql, params object[] parameters)
        {
            //转换para


            return await _dbContextProvider.GetDbContext().Database.SqlQuery<T>(sql, parameters).ToListAsync();
        }
    }
}
