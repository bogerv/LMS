using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace LMS.EntityFramework.Repositories
{
    public abstract class LmsRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<LmsDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected LmsRepositoryBase(IDbContextProvider<LmsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    internal abstract class LmsRepositoryBase<TEntity> : LmsRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected LmsRepositoryBase(IDbContextProvider<LmsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
