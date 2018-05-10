// <copyright file="PriceRequest.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class PriceRequest
    {
        [Required]
        public string Currency { get; set; }

        [Required]
        public string Amount { get; set; }
    }
}