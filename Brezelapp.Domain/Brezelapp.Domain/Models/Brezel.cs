// <copyright file="Brezel.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Brezel
    {
        public Brezel()
        {
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public Price Price { get; set; }

        public List<Rating> Ratings { get; set; }

        [Required]
        public Store Store { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}