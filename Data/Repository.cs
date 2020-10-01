using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CryptoMoon.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DataContext context;

        public Repository(DataContext context)
        {
            this.context = context;
        }

        public T Get(int id)
            => context.Set<T>().Find(id);

        public IEnumerable<T> GetAll()
            => context.Set<T>().ToList();

        public IEnumerable<T> GetWhere(Expression<Func<T, bool>> predicate)
            => context.Set<T>().Where(predicate).ToList();

        public void Add(T entity)
            => context.Set<T>().Add(entity);

        public void AddRange(IEnumerable<T> entities)
            => context.Set<T>().AddRange(entities);

        public void Remove(T entity)
            => context.Set<T>().Remove(entity);

        public void RemoveRange(IEnumerable<T> entities)
            => context.Set<T>().RemoveRange(entities);

        public void Remove(int id)
        {
            var entity = context.Set<T>().Find(id);

            if (entity != null)
                Remove(entity);
        }

        
    }
}
