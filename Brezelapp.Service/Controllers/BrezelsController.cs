// <copyright file="BrezelsController.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Controllers.V1
{
    using System;
    using System.Threading.Tasks;
    using AutoMapper;
    using Brezelapp.Models;
    using Brezelapp.Models.Viewmodels;
    using Brezelapp.Services.Contracts;
    using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Post([FromBody] BrezelRequest brezelView)
        {
            try
            {
                Brezel brezel = this.autoMapper.Map<BrezelRequest, Brezel>(brezelView);

                var res = await this.brezelService.CreateBrezel(brezel);

                if (res == null)
                {
                    return this.StatusCode(500);
                }

                // TODO: return this.CreatedAtAction("GetStoreById", "Stores", res.Id, res);
                return this.Ok(res);
            }
            catch (Exception)
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
            catch (Exception)
            {
                return this.StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBrezel([FromRoute] int id, [FromBody] BrezelRequest brezelView)
        {
            try
            {
                Brezel brezel = this.autoMapper.Map<BrezelRequest, Brezel>(brezelView);

                int touched = await this.brezelService.UpdateBrezel(id, brezel);

                if (touched <= 0)
                {
                    return this.NotFound();
                }

                // TODO: return this.CreatedAtAction("GetStoreById", "Stores", res.Id, res);
                brezel.Id = id;
                return this.Ok(brezel);
            }
            catch (Exception)
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
            catch (Exception)
            {
                // refactore for datatype
                return this.StatusCode(500);
            }
        }
    }
}
