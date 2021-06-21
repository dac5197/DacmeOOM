using DacmeOOM.Application.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Application.Models
{
    public class OrgModel : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public OrgType OrgType { get; set; }
        public int Level { get; set; }
    }
}
