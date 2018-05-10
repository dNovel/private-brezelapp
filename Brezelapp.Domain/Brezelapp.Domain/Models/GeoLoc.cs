// <copyright file="StoreRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    public class GeoLoc
    {
        protected GeoLoc()
        {
        }

        public GeoLoc(double latitude, double longitude)
        {
            this.Latitude = latitude;
            this.Longitude = longitude;
        }

        public double Latitude { get; protected set; }

        public double Longitude { get; protected set; }
    }
}
