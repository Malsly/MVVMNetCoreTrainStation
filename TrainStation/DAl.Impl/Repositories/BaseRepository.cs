using DAL.Abstract;
using Microsoft.EntityFrameworkCore;
using ReposirotyAPI.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAl.Impl.Repositories
{
    public abstract class BaseRepository<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : ReposirotyAPIContext
    {
        private readonly TContext context;
        public BaseRepository(TContext context)
        {
            this.context = context;
        }

        public void Delete(int Id)
        {
            TEntity entity = context.Find<TEntity>(Id);
            context.Remove<TEntity>(entity);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public TEntity GetByID(int Id)
        {
            return context.Set<TEntity>().Find(Id);
        }

        public void Insert(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
