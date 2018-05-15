// <copyright file="PriceRequest.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System.ComponentModel.DataAnnotations;
    using Brezelapp.Services.Contracts;

    public class PriceRequest : IMappable<Price>
    {
        [Required]
        public string Currency { get; set; }

        [Required]
        public string Amount { get; set; }

        public Price MapToDbModel()
        {
            return new Price(this.Currency, this.Amount);
        }
    }
}