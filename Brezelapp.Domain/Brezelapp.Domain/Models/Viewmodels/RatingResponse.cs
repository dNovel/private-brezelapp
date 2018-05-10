// <copyright file="RatingResponse.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System;

    public class RatingResponse
    {
        public Guid RatingId { get; set; }

        public int Value { get; set; }

        public string UserEmail { get; set; }

        public string Text { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}