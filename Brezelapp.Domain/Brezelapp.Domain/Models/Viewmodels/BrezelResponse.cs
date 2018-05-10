// <copyright file="BrezelResponse.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models.Viewmodels
{
    using System;
    using System.Collections.Generic;

    public class BrezelResponse
    {
        public Guid BrezelId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateUpdated { get; set; }

        public StoreResponse Store { get; set; }

        public PriceResponse Price { get; set; }

        public List<RatingResponse> Ratings { get; set; }
    }
}