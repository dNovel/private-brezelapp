// <copyright file="Brezel.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Brezel
    {
        private Rating rating;

        public Brezel()
        {
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public Price Price { get; set; }

        [Required]
        public Rating Rating { get; set; }

        [Required]
        public Store Store { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}