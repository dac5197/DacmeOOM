using DacmeOOM.Core.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Infrastructure.EFCore.Services
{
    public abstract class BaseService<TEntity, TContext> : IService<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        private readonly TContext _context;

        public BaseService(TContext context)
        {
            _context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);

            if (entity is null)
            {
                return false;
            }

            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<TEntity>> GetAsync()
        {
            var entities = await _context.Set<TEntity>().ToListAsync();
            return entities;
        }

        public async Task<TEntity> GetAsync(int id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id);
            return entity;
        }

        public async Task<List<TEntity>> GetUntrackedAsync()
        {
            var entities = await _context.Set<TEntity>().AsNoTracking().ToListAsync();
            return entities;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
