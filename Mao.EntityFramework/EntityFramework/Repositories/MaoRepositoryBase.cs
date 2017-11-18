using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
using Mao.EntityFramework.EntityFramework;

namespace Mao.EntityFramework.Repositories
{
    public abstract class MaoRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<MaoDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected MaoRepositoryBase(IDbContextProvider<MaoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class MaoRepositoryBase<TEntity> : MaoRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected MaoRepositoryBase(IDbContextProvider<MaoDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
