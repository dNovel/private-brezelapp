using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Brezelapp.Models;
using Brezelapp.Services;
using Brezelapp.Services.Contracts;
using AutoMapper;
using Brezelapp.Models.Viewmodels;

namespace Brezelapp.Controllers.V1
{
    [Route("api/[controller]")]
    public class StoresController : Controller
    {
        private IStoreService storeService;
        private IBrezelService brezelService;

        private IMapper autoMapper;

        public StoresController(IStoreService storeService, IBrezelService brezelService, IMapper mapper)
        {
            this.storeService = storeService;
            this.brezelService = brezelService;
            this.autoMapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StoreView storeView)
        {
            try
            {
                Store store = this.autoMapper.Map<StoreView, Store>(storeView);

                var res = await this.storeService.CreateStore(store);
                //return this.CreatedAtAction("Get", "StoresController", res.Id, res);
                return this.Ok(res);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return this.BadRequest("Error");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            // TODO: Correct implementation
            return this.Ok(string.Format("Hello Store nr {0}", id));
        }
    }
}
