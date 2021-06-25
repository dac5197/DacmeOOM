﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DacmeOOM.Web.Api.Contracts.V1.RequestModels
{
    public class OrgLevelPutRequestModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int OrgTypeId { get; set; }
    }
}
