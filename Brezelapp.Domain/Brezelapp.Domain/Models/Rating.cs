// <copyright file="Rating.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Brezelapp.Contracts;

    public class Rating : IEntityAutoDateFields
    {
        public Rating()
        {
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int Value { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        [Required]
        public string UserEmail { get; set; }

        public string Text { get; set; }
    }
}