using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenIddict.Validation;

namespace IDL.Giftcloud.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceController : ControllerBase
    {
        //[Authorize(AuthenticationSchemes = OpenIddictValidationDefaults.AuthenticationScheme)]
        [Authorize]
        [HttpGet("message")]
        public IActionResult Message()
        {
            return Content("Successfully authenticated.");
        }
    }
}