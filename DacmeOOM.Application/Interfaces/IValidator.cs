using DacmeOOM.Core.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Domain.Interfaces
{
    public interface IValidator<TEntity, TError> 
        where TEntity : class 
        where TError : class
    {
        Task<List<TError>> ValidateAsync(TEntity entity);
    }
}
