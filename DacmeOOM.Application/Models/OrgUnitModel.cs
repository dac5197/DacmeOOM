using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Domain.Models
{
    public class OrgUnitModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int OrgModelId { get; set; }
        public OrgLevelModel Org { get; set; }
        public string Path { get; set; }
        public List<EmployeeRoleModel> Roles { get; set; }
    }
}
