using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DacmeOOM.Web.Api.Contracts.V1.ResponseModels
{
    public class OrgLevelResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int OrgTypeId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
    }
}
