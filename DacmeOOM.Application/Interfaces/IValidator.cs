using DacmeOOM.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Application.Interfaces
{
    public interface IValidator<TEntity, TError> 
        where TEntity : class 
        where TError : class
    {
        Task<List<TError>> ValidateAsync(TEntity entity);
    }
}
