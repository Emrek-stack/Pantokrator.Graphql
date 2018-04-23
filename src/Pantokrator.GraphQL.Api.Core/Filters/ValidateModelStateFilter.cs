using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Pantokrator.GraphQL.Api.Core.Filters
{
    public class ValidateModelStateFilter : ActionFilterAttribute
    {
        private readonly ILogger<ValidateModelStateFilter> _logger;

        public ValidateModelStateFilter(ILogger<ValidateModelStateFilter> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            List<string> errors = new List<string>();

            if (!actionContext.ModelState.IsValid)
            {
                foreach (var modelState in actionContext.ModelState.Values)
                {
                    if (modelState.Errors.Any())
                    {
                        foreach (ModelError modelStateError in modelState.Errors)
                        {
                            errors.Add(modelStateError.ErrorMessage);
                        }
                    }
                }
            }

            if (errors.Any())
            {
                var errorResult = new JsonResult(errors)
                {
                    StatusCode = 400
                };

                _logger.LogTrace($"{actionContext.ActionDescriptor.DisplayName} is called with wrong arguments.", JsonConvert.SerializeObject(errors));

                actionContext.Result = errorResult;
            }

            base.OnActionExecuting(actionContext);
        }
    }
}