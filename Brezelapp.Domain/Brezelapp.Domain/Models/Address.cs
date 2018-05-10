// <copyright file="Address.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using NISOCountries.GeoNames;

    public class Address
    {
        private string countryAlpha3;
        private GeoLoc geoLoc;

        [Key]
        public int Id { get; set; }

        public string Street { get; set; }

        public string StreetNr { get; set; }

        public string Zipcode { get; set; }

        public string City { get; set; }

        public string Country
        {
            get
            {
                return this.countryAlpha3;
            }

            set
            {
                var countries = new GeonamesISOCountryReader().GetDefault();
                var discCountry = countries.Where(c => c.CountryName == value).Single().Alpha3;
                this.countryAlpha3 = discCountry;
            }
        }

        public GeoLoc GeoLoc
        {
            get
            {
                return this.geoLoc;
            }

            set
            {
                this.geoLoc = new GeoLoc(value.Latitude, value.Longitude);
            }
        }
    }
}
