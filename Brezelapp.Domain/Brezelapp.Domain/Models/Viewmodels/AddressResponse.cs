// <copyright file="AddressResponse.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System;

    public class AddressResponse
    {
        public Guid AddressId { get; set; }

        public string Street { get; set; }

        public string StreetNr { get; set; }

        public string Zipcode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public DateTime DateUpdated { get; set; }

        public GeoLocResponse GeoLoc { get; set; }
    }
}
