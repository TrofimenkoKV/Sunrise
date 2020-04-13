using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.AspNetCore.Diagnostics;

namespace Sunrise.Controller
{
    [ApiController]
    public class ErrorHandlerController : ControllerBase
    {
        [Route("/error")]
        public IActionResult ErrorLocalDevelopment([FromServices] IWebHostEnvironment webHostEnvironment)
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            return Problem(
                title: context.Error.Message);
        }

    }
}