// <copyright file="Store.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Brezelapp.Contracts;

    public class Store : IEntityAutoDateFields
    {
        public Store()
        {
        }

        [Key]
        public int Id { get; set; }

        public Guid StoreId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Rating
        {
            get
            {
                int ratAcc = 0;
                this.Brezels.ForEach(brezel => brezel.Ratings.ForEach(rating => ratAcc += rating.Value));
                ratAcc = ratAcc / this.Brezels.Count;

                return ratAcc;
            }
        }

        [Required]
        public Address Address { get; set; }

        public List<Brezel> Brezels { get; set; }

        public List<Rating> Ratings { get; set; }

        // public OpeningHours OpeningHours { get; set; }
    }
}