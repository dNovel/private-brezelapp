// <copyright file="GeoLocResponse.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Brezelapp.Contracts;

    public class GeoLocResponse
    {
        public Guid GeoLocId { get; set; }

        public double Latitude { get; protected set; }

        public double Longitude { get; protected set; }

        public DateTime DateUpdated { get; set; }
    }
}
