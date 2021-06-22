using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Application.Models
{
    public class OrgTypeModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<OrgLevelModel> OrgLevels { get; set; } 
    }
}
