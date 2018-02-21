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

                if (res == null)
                {
                    return this.StatusCode(500);
                }

                // TODO: return this.CreatedAtAction("GetStoreById", "Stores", res.Id, res);
                return this.Ok(res);
            }
            catch (Exception e)
            {
                return this.StatusCode(500);
            }
        }

        [HttpGet("{id}", Name = "GetStoreById")]
        public async Task<IActionResult> GetStoreById([FromRoute] int id)
        {
            // TODO: Correct implementation
            try
            {
                Store store = await this.storeService.GetStoreById(id);
                return this.Ok(store);
            } catch (Exception e)
            {
                // refactore for datatype
                return this.StatusCode(500);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStores([FromQuery(Name = "offset")] int offset = 0, [FromQuery(Name = "limit")] int limit = 20)
        {
            // TODO: Correct implementation
            try
            {
                List<Store> stores = await this.storeService.GetStores(offset, limit);

                if (stores == null)
                {
                    return this.NotFound();
                }

                return this.Ok(stores);
            }
            catch (Exception e)
            {
                // refactore for datatype
                return this.StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] StoreView storeView)
        {
            // TODO: Correct implementation
            try
            {
                Store store = this.autoMapper.Map<StoreView, Store>(storeView);
                Store storeUpdated = await this.storeService.UpdateStore(id, store);
                if (storeUpdated == null)
                {
                    return this.NotFound();
                }

                return this.Ok(storeUpdated);
            }
            catch (Exception e)
            {
                // refactore for datatype
                return this.StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            // TODO: Correct implementation
            try
            {
                bool result = await this.storeService.DeleteStoreById(id);
                if (!result)
                {
                    return this.NotFound();
                }

                return this.NoContent();
            }
            catch (Exception e)
            {
                // refactore for datatype
                return this.StatusCode(500);
            }
        }
    }
}
