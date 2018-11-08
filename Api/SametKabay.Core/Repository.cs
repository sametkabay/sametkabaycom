using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SametKabay.Core;

namespace SametKabay.Core
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected SametKabayDbContext Context;

        protected Repository(SametKabayDbContext context)
        {
            Context = context;
        }
        public IQueryable<T> GetAll()
        {
            return Context.Set<T>();
        }
        public IQueryable<T> GetById(int id)
        {
            return (IQueryable<T>)Context.Set<T>().Find(id);
        }

        public async Task Insert(T entity)
        {
            Context.Set<T>().Add(entity);
            await Context.SaveChangesAsync();
        }

        public async Task Update(T entity, object key)
        {
            if (entity == null)
                return;
            T exist = Context.Set<T>().Find(key);
            if (exist != null)
            {
                Context.Entry(exist).CurrentValues.SetValues(entity);
                await Context.SaveChangesAsync();
            }

        }

        public async Task Delete(T entity)
        {
            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
        
    }
}
