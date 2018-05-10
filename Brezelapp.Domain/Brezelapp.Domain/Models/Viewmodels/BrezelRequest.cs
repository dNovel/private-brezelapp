// <copyright file="BrezelRequest.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models.Viewmodels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class BrezelRequest
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public PriceRequest Price { get; set; }

        public List<RatingRequest> Rating { get; set; }
    }
}