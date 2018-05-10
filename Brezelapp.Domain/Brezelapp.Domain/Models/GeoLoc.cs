// <copyright file="GeoLoc.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Brezelapp.Contracts;

    public class GeoLoc : IEntityAutoDateFields
    {
        public GeoLoc(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public GeoLoc()
        {
        }

        [Key]
        public int Id { get; set; }

        public Guid GeoLocId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
