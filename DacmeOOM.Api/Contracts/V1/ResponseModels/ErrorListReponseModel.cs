﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DacmeOOM.Web.Api.Contracts.V1.ResponseModels
{
    public class ErrorListReponseModel
    {
        public string Title { get; set; }
        public int Status { get; set; }
        public List<ErrorResponseModel> Errors { get; set; }

        public void SetBadRequest(List<ErrorResponseModel> errors)
        {
            Title = "Bad Request";
            Status = 400;
            Errors = errors;
        }
    }
}
