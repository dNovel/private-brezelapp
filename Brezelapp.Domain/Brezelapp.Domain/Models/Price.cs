// <copyright file="Brezel.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    public class Price
    {
        protected Price()
        {
        }

        public Price(string currency, string amount)
        {
            this.Currency = currency;
            this.Amount = amount;
        }

        // TODO: Refactor currency to a package with ISO values
        public string Currency { get; set; }

        public string Amount { get; set; }
    }
}