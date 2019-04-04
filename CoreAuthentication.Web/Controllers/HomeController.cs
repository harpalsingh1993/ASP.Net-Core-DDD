using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoreAuthentication.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace CoreAuthentication.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class HomeController : ControllerBase
    {
        [Authorize]
        public async Task<ActionResult> Get()
        {
            return Ok("string");
        }
        [ActionName("Token")]
        public async Task<ActionResult> GetToken()
        {
            return Ok("GetToken");
        }
    }
}
