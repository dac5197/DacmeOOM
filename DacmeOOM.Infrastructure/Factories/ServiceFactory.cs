using DacmeOOM.Application.Interfaces;
using DacmeOOM.Infrastructure.DataAccess;
using DacmeOOM.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Infrastructure.Factories
{
    public class ServiceFactory : IServiceFactory
    {
        private IOrgLevelService _orgLevelHandler;
        private IOrgTypeService _orgTypeHandler;

        private readonly ApplicationDbContext _context;

        public ServiceFactory(ApplicationDbContext context)
        {
            _context = context;
        }

        public IOrgLevelService OrgLevel
        {
            get
            {
                if (_orgLevelHandler is null)
                {
                    _orgLevelHandler = new OrgLevelService(_context);
                }

                return _orgLevelHandler;
            }
        }

        public IOrgTypeService OrgType 
        {
            get
            {
                if (_orgTypeHandler is null)
                {
                    _orgTypeHandler = new OrgTypeService(_context);
                }
                
                return _orgTypeHandler;
            }
        }
    }
}
