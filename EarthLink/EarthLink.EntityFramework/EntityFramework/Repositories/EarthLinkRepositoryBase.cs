using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace EarthLink.EntityFramework.Repositories
{
    public abstract class EarthLinkRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<EarthLinkDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected EarthLinkRepositoryBase(IDbContextProvider<EarthLinkDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class EarthLinkRepositoryBase<TEntity> : EarthLinkRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected EarthLinkRepositoryBase(IDbContextProvider<EarthLinkDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
