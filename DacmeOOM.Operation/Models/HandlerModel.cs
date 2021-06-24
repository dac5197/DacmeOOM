using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Application.Models
{
    public class HandlerModel<TEntity> where TEntity : class
    {
        public TEntity Entity { get; set; }

        [MaybeNull, AllowNull]
        public ErrorListModel ErrorList { get; set; }

        public bool IsSuccess => (ErrorList == null);

        
    }
}
