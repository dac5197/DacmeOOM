using DacmeOOM.Application.Interfaces;
using DacmeOOM.Infrastructure.DataAccess;
using DacmeOOM.Infrastructure.Handlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Infrastructure.Factories
{
    public class HandlerFactory : IHandlerFactory
    {
        private IOrgHandler _orgHandler;
        private readonly ApplicationDbContext _context;

        public HandlerFactory(ApplicationDbContext context)
        {
            _context = context;
        }

        public IOrgHandler OrgHandler
        {
            get
            {
                if (_orgHandler is null)
                {
                    _orgHandler = new OrgHandler(_context);
                }

                return _orgHandler;
            }
        }
    }
}
