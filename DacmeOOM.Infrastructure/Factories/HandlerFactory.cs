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
        private IOrgLevelHandler _orgLevelHandler;
        private IOrgTypeHandler _orgTypeHandler;

        private readonly ApplicationDbContext _context;

        public HandlerFactory(ApplicationDbContext context)
        {
            _context = context;
        }

        public IOrgLevelHandler OrgLevel
        {
            get
            {
                if (_orgLevelHandler is null)
                {
                    _orgLevelHandler = new OrgLevelHandler(_context);
                }

                return _orgLevelHandler;
            }
        }

        public IOrgTypeHandler OrgType 
        {
            get
            {
                if (_orgTypeHandler is null)
                {
                    _orgTypeHandler = new OrgTypeHandler(_context);
                }
                
                return _orgTypeHandler;
            }
        }
    }
}
