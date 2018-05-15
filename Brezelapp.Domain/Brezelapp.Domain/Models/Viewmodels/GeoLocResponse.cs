// <copyright file="GeoLocResponse.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System;
    using Newtonsoft.Json;

    public class GeoLocResponse
    {
        [JsonProperty("Id")]
        public Guid EntityId { get; set; }

        public double Latitude { get; protected set; }

        public double Longitude { get; protected set; }

        public DateTime DateUpdated { get; set; }
    }
}
