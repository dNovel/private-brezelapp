// <copyright file="Address.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Brezelapp.Contracts;
    using Brezelapp.DB;
    using NISOCountries.GeoNames;

    public class Address : EntityModel, IEntityAutoDateFields
    {
        private string countryAlpha3;
        private GeoLoc geoLoc;

        public Address()
            : base()
        {
        }

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
                //var countries = new GeonamesISOCountryReader().GetDefault();
                //var discCountry = countries.Where(c => c.CountryName == value).Single().Alpha3;
                this.countryAlpha3 = value;
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
                this.geoLoc = value;
            }
        }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}
