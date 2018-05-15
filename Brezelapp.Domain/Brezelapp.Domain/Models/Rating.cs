// <copyright file="Rating.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Brezelapp.Contracts;
    using Brezelapp.DB;

    public class Rating : EntityModel, IEntityAutoDateFields
    {
        public Rating(int value, string useremail, string text)
        {
            this.Value = value;
            this.UserEmail = useremail;
            this.Text = text;
        }

        public Rating()
            : base()
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