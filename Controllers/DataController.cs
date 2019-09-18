using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Pishkhan.Controllers
{
    [Authorize()]
    public class DataController : Controller
    {
        [Route("data")]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}