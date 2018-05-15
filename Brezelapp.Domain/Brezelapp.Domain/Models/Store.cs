// <copyright file="Store.cs" company="Dominik Steffen">
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

    public class Store : EntityModel, IEntityAutoDateFields
    {
        public Store()
            : base()
        {
        }

        [Key]
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateUpdated { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Rating
        {
            get
            {
                if (this.Brezels == null)
                {
                    return 0;
                }

                int ratAcc = 0;
                this.Brezels?.ForEach(brezel => brezel.Ratings.ForEach(rating => ratAcc += rating.Value));

                // Save this so we dont run into race conditions
                int c = this.Brezels.Count;

                ratAcc = ratAcc / (c == 0 ? 1 : c);

                return ratAcc;
            }
        }

        public Address Address { get; set; }

        public List<Brezel> Brezels { get; set; }

        public List<Rating> Ratings { get; set; }

        // public OpeningHours OpeningHours { get; set; }
    }
}