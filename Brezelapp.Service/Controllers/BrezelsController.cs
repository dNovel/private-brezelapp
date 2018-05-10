// <copyright file="BrezelsController.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Controllers.V1
{
    using System;
    using System.Collections.Generic;
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
        [ProducesResponseType(typeof(BrezelResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] BrezelRequest brezelReq)
        {
            try
            {
                Brezel brezel = this.autoMapper.Map<BrezelRequest, Brezel>(brezelReq);

                Brezel createdBrezel = await this.brezelService.CreateBrezel(brezel);

                if (createdBrezel == null)
                {
                    return this.StatusCode(500);
                }

                BrezelResponse brezelResponse = this.autoMapper.Map<Brezel, BrezelResponse>(createdBrezel);

                // TODO: return this.CreatedAtAction("GetStoreById", "Stores", res.Id, res);
                return this.Ok(brezelResponse);
            }
            catch (Exception)
            {
                return this.StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BrezelResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
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
                BrezelResponse brezelResponse = this.autoMapper.Map<Brezel, BrezelResponse>(brezel);

                return this.Ok(brezelResponse);
            }
            catch (Exception)
            {
                return this.StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateBrezel([FromRoute] int id, [FromBody] BrezelRequest brezelReq)
        {
            try
            {
                Brezel brezel = this.autoMapper.Map<BrezelRequest, Brezel>(brezelReq);

                int touched = await this.brezelService.UpdateBrezel(id, brezel);

                if (touched <= 0)
                {
                    return this.NotFound();
                }

                // TODO: return this.CreatedAtAction("GetStoreById", "Stores", res.Id, res);
                brezel.Id = id;
                return this.Ok();
            }
            catch (Exception)
            {
                return this.StatusCode(500);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
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
