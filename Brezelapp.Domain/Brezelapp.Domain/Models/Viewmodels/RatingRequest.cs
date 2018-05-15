// <copyright file="RatingRequest.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System.ComponentModel.DataAnnotations;
    using Brezelapp.Services.Contracts;

    public class RatingRequest : IMappable<Rating>
    {
        [Required]
        public int Value { get; set; }

        public string UserEmail { get; set; }

        public string Text { get; set; }

        public Rating MapToDbModel()
        {
            return new Rating()
            {
                Value = this.Value,
                UserEmail = this.UserEmail,
                Text = this.Text
            };
        }
    }
}