using DataLayer.AuthTenants.DataModels;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.AuthTenants.Repositories
{
    public abstract class EfCoreTenantsContextRepository<TEntity,TContext> : IRepository<TEntity>
    where TEntity : class, IEntity
    where TContext : TenantsContext
    {
        private readonly TContext context;
        public EfCoreTenantsContextRepository(TContext context)
        {
            this.context = context;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity> Delete(int id)
        {
            var entity = await context.Set<TEntity>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }
            context.Set<TEntity>().Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity> Get(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }

        //public async Task<TEntity> GetbyKey(string key)
        //{
        //    return await context.Set<TEntity>().Select(k=>k.text_value==key).FirstOrDefault();
        //}

        public async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }

        public Task<List<TEntity>> GetAllbyNumber(int num)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
    }
}

