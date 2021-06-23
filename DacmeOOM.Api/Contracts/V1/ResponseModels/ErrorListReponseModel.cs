using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DacmeOOM.Web.Api.Contracts.V1.ResponseModels
{
    public class ErrorListReponseModel
    {
        public List<ErrorResponseModel> Errors { get; set; }
    }
}
