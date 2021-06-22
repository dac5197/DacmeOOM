using DacmeOOM.Application.Interfaces;
using DacmeOOM.Application.Models;
using DacmeOOM.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Infrastructure.Handlers
{
    public class OrgHandler : BaseHandler<OrgLevelModel, ApplicationDbContext>, IOrgHandler
    {
        private readonly ApplicationDbContext _context;

        public OrgHandler(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
