// <copyright file="GeoLoc.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class GeoLoc
    {
        public GeoLoc(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        protected GeoLoc()
        {
        }

        [Key]
        public int Id { get; set; }

        public double Latitude { get; protected set; }

        public double Longitude { get; protected set; }
    }
}
