﻿using DataLayer.HealthCare.DataModels;
using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.HealthCare.Repositories
{
    public abstract class EfCoreComfortHealthContextRepository<TEntity,TContext> : IRepository<TEntity>
    where TEntity : class, IEntity
    where TContext : ComfortHealthContext
    {
        private readonly TContext context;
        public EfCoreComfortHealthContextRepository(TContext context)
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

        //************take first 20 records*******************
        public async Task<List<TEntity>> GetAllbyNumber(int num)
        {
            return await context.Set<TEntity>().Take(num).ToListAsync();
        }

        //************End take first 20 records*******************

        public async Task<List<TEntity>> GetAll()
        {
            return await context.Set<TEntity>().ToListAsync();
        }



        public async Task<TEntity> Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return entity;
        }
    }
}

