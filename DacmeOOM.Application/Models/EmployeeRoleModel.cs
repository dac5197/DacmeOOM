using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Application.Models
{
    public class EmployeeRoleModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeModel Employee { get; set; }
        public int OrgUnitId { get; set; }
        public OrgUnitModel OrgUnit { get; set; }
        public int OrgModelId { get; set; }
        public OrgModel Org { get; set; }
        public string Path { get; set; }
    }
}
