using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Domain.Models
{
    public class OrgLevelModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int OrgTypeId { get; set; }
        public OrgTypeModel OrgType { get; set; }
        public List<EmployeeRoleModel> EmployeeRoles { get; set; }
        public List<OrgUnitModel> OrgUnits { get; set; }
    }
}
