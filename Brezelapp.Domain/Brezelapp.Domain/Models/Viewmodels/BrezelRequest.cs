// <copyright file="BrezelRequest.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models.Viewmodels
{
    using System.ComponentModel.DataAnnotations;

    public class BrezelRequest
    {
        private int rating;

        public BrezelRequest()
        {
        }

        [Required]
        public float Price { get; set; }

        [Required]
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
    }
}