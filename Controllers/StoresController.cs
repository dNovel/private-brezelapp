using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Brezelapp.Models;
using Brezelapp.Services;

namespace Brezelapp.Controllers.V1
{
    [Route("api/[controller]")]
    public class StoresController : Controller
    {
        public StoresController()
        {

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Store store)
        {
            Store s = new Store()
            {
                Id = 1337,
                Longitude = 0.0d,
                Latitude = 0.0d,
                Brezels = new List<Brezel>(),
                Name = "Test Store"
            };

            s.Brezels.Add(new Brezel()
            {
                Id = 1,
                Rating = 3,
                Price = 5.0f
            });

            return CreatedAtAction("Get", new { id = s.Id }, s);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRouteAttribute] int id)
        {
            return Ok(string.Format("Hello Store nr {0}", id));
        }
    }
}
