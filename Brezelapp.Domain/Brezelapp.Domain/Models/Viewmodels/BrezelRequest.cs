// <copyright file="BrezelRequest.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models.Viewmodels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Brezelapp.Services.Contracts;

    public class BrezelRequest : IMappable<Brezel>
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public PriceRequest Price { get; set; }

        public List<RatingRequest> Ratings { get; set; }

        [Required]
        public System.Guid StoreId { get; set; }

        public Brezel MapToDbModel()
        {
            return new Brezel()
            {
                Name = this.Name,
                Description = this.Description,
                Price = this.Price.MapToDbModel(),
                Ratings = this.Ratings.ConvertAll(r => r.MapToDbModel())
            };
        }
    }
}