// <copyright file="StoreRequest.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models.Viewmodels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Brezelapp.Services.Contracts;

    public class StoreRequest : IMappable<Store>
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public AddressRequest Address { get; set; }

        public Store MapToDbModel()
        {
            return new Store()
            {
                Name = this.Name,
                Description = this.Description,
                Address = this.Address?.MapToDbModel()
            };
        }
    }
}