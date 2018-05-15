// <copyright file="GeoLocRequest.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System.ComponentModel.DataAnnotations;
    using Brezelapp.Services.Contracts;

    public class GeoLocRequest : IMappable<GeoLoc>
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public GeoLoc MapToDbModel()
        {
            return new GeoLoc(this.Latitude, this.Longitude);
        }
    }
}
