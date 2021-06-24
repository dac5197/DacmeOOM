using DacmeOOM.Core.Domain.Interfaces;
using DacmeOOM.Core.Domain.Models;
using DacmeOOM.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Infrastructure.Services
{
    class OrgTypeService : BaseService<OrgTypeModel, ApplicationDbContext>, IOrgTypeService
    {
        private readonly ApplicationDbContext _context;

        public OrgTypeService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
