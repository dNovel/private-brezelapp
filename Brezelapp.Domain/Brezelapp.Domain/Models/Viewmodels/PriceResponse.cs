// <copyright file="PriceResponse.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System;

    public class PriceResponse
    {
        public Guid PriceId { get; set; }

        public string Currency { get; set; }

        public string Amount { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}