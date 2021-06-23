using DacmeOOM.Application.Interfaces;
using DacmeOOM.Application.Models;
using DacmeOOM.Validation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Validation.Validators
{
    public abstract class BaseValidator<TEntity> : IValidator<TEntity, ErrorModel> 
        where TEntity : class
    {
        public List<ErrorModel> Errors { get; set; }

        public Task<List<ErrorModel>> ValidateAsync(TEntity entity)
        {
            throw new NotImplementedException();            
        }
    }
}
