﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DacmeOOM.Core.Domain.Models
{
    public class EmployeeModel : BaseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public EmployeeRoleModel Role { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TermDate { get; set; }
    }
}
