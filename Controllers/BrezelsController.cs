using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Brezelapp.Controllers.V1
{
    [Route("api/[controller]")]
    public class BrezelsController : Controller
    {
        public BrezelsController(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {

        }

        
    }
}
