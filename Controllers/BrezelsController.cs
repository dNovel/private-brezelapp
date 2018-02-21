using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Brezelapp.Services.Contracts;
using AutoMapper;
using Brezelapp.Models.Viewmodels;
using Brezelapp.Models;

namespace Brezelapp.Controllers.V1
{

    [Route("api/[controller]")]
    public class BrezelsController : Controller
    {
        private IStoreService storeService;
        private IBrezelService brezelService;
        private IMapper autoMapper;

        public BrezelsController(IStoreService storeService, IBrezelService brezelService, IMapper mapper)
        {
            this.storeService = storeService;
            this.brezelService = brezelService;
            this.autoMapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BrezelView brezelView)
        {
            try
            {
                Brezel brezel = this.autoMapper.Map<BrezelView, Brezel>(brezelView);

                var res = await this.brezelService.CreateBrezel(brezel);

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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrezelById([FromRoute] int id)
        {
            try
            {
                Brezel brezel = await this.brezelService.GetBrezelById(id);

                if (brezel == null)
                {
                    return this.NotFound();
                }

                // TODO: return this.CreatedAtAction("GetStoreById", "Stores", res.Id, res);
                return this.Ok(brezel);
            }
            catch (Exception e)
            {
                return this.StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrezel([FromRoute] int id, [FromBody] BrezelView brezelView)
        {
            try
            {
                Brezel brezel = this.autoMapper.Map<BrezelView, Brezel>(brezelView);

                int touched = await this.brezelService.UpdateBrezel(id, brezel);

                if (touched <= 0)
                {
                    return this.NotFound();
                }

                // TODO: return this.CreatedAtAction("GetStoreById", "Stores", res.Id, res);
                brezel.Id = id;
                return this.Ok(brezel);
            }
            catch (Exception e)
            {
                return this.StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            // TODO: Correct implementation
            try
            {
                bool result = await this.brezelService.DeleteBrezelById(id);
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
