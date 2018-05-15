// <copyright file="GeoLoc.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Brezelapp.Contracts;
    using Brezelapp.DB;

    public class GeoLoc : EntityModel, IEntityAutoDateFields
    {
        public GeoLoc(double latitude, double longitude)
            : base()
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public GeoLoc()
            : base()
        {
        }

        [Key]
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}
