// <copyright file="GeoLocRequest.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class GeoLocRequest
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
