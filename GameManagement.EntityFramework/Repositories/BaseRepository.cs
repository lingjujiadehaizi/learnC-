using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameManagement.Contracts;
using Microsoft.EntityFrameworkCore;

namespace GameManagement.EntityFramework.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected GameManagementDbContext GameDbContext { get; set; }
        protected BaseRepository(GameManagementDbContext repoistoryContext)
        {
            GameDbContext = repoistoryContext;
        }
        public void Create(T entity)
        {
            GameDbContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            GameDbContext.Set<T>().Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return GameDbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return GameDbContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            GameDbContext.Set<T>().Update(entity);
        }
    }
}
