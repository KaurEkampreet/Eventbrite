using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PicController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        
        public IActionResult GetImage(int id)
    }
}
