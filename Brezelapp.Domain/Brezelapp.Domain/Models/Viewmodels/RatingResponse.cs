// <copyright file="RatingResponse.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System;
    using Newtonsoft.Json;

    public class RatingResponse
    {
        [JsonProperty("Id")]
        public Guid EntityId { get; set; }

        public int Value { get; set; }

        public string UserEmail { get; set; }

        public string Text { get; set; }

        public DateTime DateUpdated { get; set; }
    }
}