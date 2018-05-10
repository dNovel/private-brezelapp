// <copyright file="StoreResponse.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models.Viewmodels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class StoreResponse
    {
        public Guid StoreId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DateUpdated { get; set; }

        public AddressResponse Address { get; set; }

        public List<BrezelResponse> Brezels { get; set; }

        public List<RatingResponse> Ratings { get; set; }
    }
}