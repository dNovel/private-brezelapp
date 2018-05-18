// <copyright file="StoresController.cs" company="Dominik Steffen">
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
        [ProducesResponseType(typeof(StoreResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Post([FromBody] StoreRequest storeView)
        {
            try
            {
                Store store = storeView.MapToDbModel();
                Store res = await this.storeService.CreateStore(store);

                if (res == null)
                {
                    return this.StatusCode(500);
                }

                // TODO: return this.CreatedAtAction("GetStoreById", "Stores", res.Id, res);
                StoreResponse storeResponse = this.autoMapper.Map<Store, StoreResponse>(store);
                return this.Ok(storeResponse);
            }
            catch (Exception e)
            {
                return this.StatusCode(500, e);
            }
        }

        [HttpGet("{id}", Name = "GetStoreById")]
        [ProducesResponseType(typeof(StoreResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetStoreById([FromRoute] Guid id)
        {
            // TODO: Correct implementation
            try
            {
                Store store = await this.storeService.GetStoreById(id);
                StoreResponse storeResponse = this.autoMapper.Map<Store, StoreResponse>(store);

                return this.Ok(storeResponse);
            }
            catch (Exception)
            {
                // refactore for datatype
                return this.StatusCode(500);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<StoreResponse>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
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

                List<StoreResponse> storeResponse = this.autoMapper.Map<List<Store>, List<StoreResponse>>(stores);

                return this.Ok(storeResponse);
            }
            catch (Exception)
            {
                // refactore for datatype
                return this.StatusCode(500);
            }
        }

        [HttpPut("{storeId}")]
        [ProducesResponseType(typeof(StoreResponse), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Update([FromRoute] Guid storeId, [FromBody] StoreRequest storeView)
        {
            // TODO: Correct implementation
            try
            {
                Store store = storeView.MapToDbModel();
                Store storeUpdated = await this.storeService.UpdateStore(storeId, store);
                if (storeUpdated == null)
                {
                    return this.NotFound();
                }

                StoreResponse storeResponse = this.autoMapper.Map<Store, StoreResponse>(storeUpdated);

                return this.Ok(storeResponse);
            }
            catch (Exception e)
            {
                // refactore for datatype
                return this.StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{storeId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Delete([FromRoute] Guid storeId)
        {
            try
            {
                bool result = await this.storeService.DeleteStoreById(storeId);
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
