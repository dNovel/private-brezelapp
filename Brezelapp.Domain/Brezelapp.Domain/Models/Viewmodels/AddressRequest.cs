// <copyright file="AddressRequest.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System.ComponentModel.DataAnnotations;
    using Brezelapp.Services.Contracts;

    public class AddressRequest : IMappable<Address>
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

        public Address MapToDbModel()
        {
            return new Address()
            {
                Street = this.Street,
                StreetNr = this.StreetNr,
                Zipcode = this.Zipcode,
                City = this.City,
                Country = this.Country,
                GeoLoc = this.GeoLoc?.MapToDbModel() ?? new GeoLoc()
            };
        }
    }
}
