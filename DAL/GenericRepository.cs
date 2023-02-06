using DAL;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ApiTestContext context;
        public GenericRepository(ApiTestContext context)
        {
            this.context = context;
        }
        public virtual void Edit(T entity)
        {
            context.Set<T>().Update(entity);
        }
        public void Add(T entity)
        {
            context.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
        }
        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().Where(expression);
        }
        public virtual IEnumerable<T> GetAll()
        {
            return context.Set<T>().ToList();
        }
        public virtual T GetById(int id)
        {
            return context.Set<T>().Find(id);
        }
        public virtual void Remove(T entity)
        {
            context.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
        }
    }
}
