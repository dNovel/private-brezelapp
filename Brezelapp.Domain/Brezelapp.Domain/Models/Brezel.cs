// <copyright file="Brezel.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Brezel
    {
        private int rating;

        public Brezel()
        {
        }

        [Key]
        public int Id { get; set; }

        public float Price { get; set; }

        public int Rating
        {
            get
            {
                return this.rating;
            }

            set
            {
                if (value > 5)
                {
                    this.rating = 5;
                }
                else if (value < 0)
                {
                    this.rating = 0;
                }
                else
                {
                    this.rating = value;
                }
            }
        }

        public Store Store { get; set; }
    }
}