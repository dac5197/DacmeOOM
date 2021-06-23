using DacmeOOM.Web.Api.Contracts.V1.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DacmeOOM.Web.Api.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState
                                                .Where(x => x.Value.Errors.Any())
                                                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value.Errors.Select(x => x.ErrorMessage)).ToArray();

                ErrorListReponseModel errorResponses = new();

                foreach (var error in errorsInModelState)
                {
                    foreach (var errorMessage in error.Value)
                    {
                        ErrorResponseModel errorResponse = new() 
                        { 
                            PropertyName = error.Key,
                            Message = errorMessage
                        };

                        errorResponses.Errors.Add(errorResponse);
                    }
                }

                context.Result = new BadRequestObjectResult(errorResponses);
                return;
            }

            await next();
        }
    }
}
