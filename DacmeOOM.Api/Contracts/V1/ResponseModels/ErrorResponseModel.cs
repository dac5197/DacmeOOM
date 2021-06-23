using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DacmeOOM.Web.Api.Contracts.V1.ResponseModels
{
    public class ErrorResponseModel
    {
        public string PropertyName { get; set; }
        public string Message { get; set; }
    }
}
