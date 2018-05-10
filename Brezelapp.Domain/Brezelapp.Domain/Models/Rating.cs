// <copyright file="Rating.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Rating
    {
        private DateTime dateUpdated;

        public Rating()
        {
            this.DateCreated = DateTime.UtcNow;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int Value { get; set; }

        public DateTime DateCreated { get; protected set; }

        [Required]
        public string UserEmail { get; set; }

        public string Text { get; set; }

        public DateTime GetDateUpdated()
        {
            return this.dateUpdated;
        }

        public void SetDateUpdated()
        {
            this.dateUpdated = DateTime.Now;
        }
    }
}