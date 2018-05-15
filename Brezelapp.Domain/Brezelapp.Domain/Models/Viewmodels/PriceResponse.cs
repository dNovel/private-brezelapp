// <copyright file="PriceResponse.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System;
    using Newtonsoft.Json;

    public class PriceResponse
    {
        [JsonProperty("Id")]
        public Guid EntityId { get; set; }

        public string Currency { get; set; }

        public string Amount { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}