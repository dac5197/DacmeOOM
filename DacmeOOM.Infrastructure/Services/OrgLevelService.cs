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
    public class OrgLevelService : BaseService<OrgLevelModel, ApplicationDbContext>, IOrgLevelService
    {
        private readonly ApplicationDbContext _context;

        public OrgLevelService(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
