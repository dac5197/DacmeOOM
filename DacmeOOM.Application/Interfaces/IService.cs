using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Domain.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> DeleteAsync(int id);
        Task<List<TEntity>> GetAsync();
        Task<TEntity> GetAsync(int id);
        Task<List<TEntity>> GetUntrackedAsync();
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
