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
    public class OrgLevelHandler : BaseHandler<OrgLevelModel, ApplicationDbContext>, IOrgLevelHandler
    {
        private readonly ApplicationDbContext _context;

        public OrgLevelHandler(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
