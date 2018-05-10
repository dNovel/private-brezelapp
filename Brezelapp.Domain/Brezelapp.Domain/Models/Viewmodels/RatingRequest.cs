// <copyright file="RatingRequest.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class RatingRequest
    {
        [Required]
        public int Value { get; set; }

        public string UserEmail { get; set; }

        public string Text { get; set; }
    }
}