// <copyright file="Brezel.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Brezelapp.Contracts;
    using Brezelapp.DB;

    public class Brezel : EntityModel, IEntityAutoDateFields
    {
        public Brezel()
            : base()
        {
        }

        [Key]
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public Price Price { get; set; }

        [Required]
        public Store Store { get; set; }

        public List<Rating> Ratings { get; set; }
    }
}