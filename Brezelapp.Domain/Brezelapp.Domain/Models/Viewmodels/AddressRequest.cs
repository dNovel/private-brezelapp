// <copyright file="AddressRequest.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class AddressRequest
    {
        [Required]
        public string Street { get; set; }

        [Required]
        public string StreetNr { get; set; }

        [Required]
        public string Zipcode { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        public GeoLocRequest GeoLoc { get; set; }
    }
}
