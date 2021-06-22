using DacmeOOM.Application.Models;
using DacmeOOM.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Infrastructure.Handlers
{
    public class OrgModelHandler : BaseHandler<OrgModel, ApplicationDbContext>
    {
        private readonly ApplicationDbContext _context;

        public OrgModelHandler(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
