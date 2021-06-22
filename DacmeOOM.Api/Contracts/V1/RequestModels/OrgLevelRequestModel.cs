using DacmeOOM.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DacmeOOM.Web.Api.Contracts.V1.RequestModels
{
    public class OrgLevelRequestModel
    {
        public string Name { get; set; }
        public OrgType OrgType { get; set; }
        public int Level { get; set; }
    }
}
