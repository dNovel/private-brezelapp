using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Brezelapp.Services.Contracts;

namespace Brezelapp.Controllers.V1
{

    [Route("api/[controller]")]
    public class BrezelsController : Controller
    {
        private IStoreService storeService;
        private IBrezelService brezelService;

        public BrezelsController(IStoreService storeService, IBrezelService brezelService)
        {
            this.storeService = storeService;
            this.brezelService = brezelService;
        }

        public BrezelsController(IConfiguration configuration, IHostingEnvironment hostingEnvironment)
        {

        }


    }
}
