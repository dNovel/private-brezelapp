// <copyright file="Store.cs" company="Dominik Steffen">
// Copyright (c) Dominik Steffen. All rights reserved.
// </copyright>

namespace Brezelapp.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Store
    {
        public Store()
        {
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int Rating
        {
            get
            {
                int ratAcc = 0;
                this.Brezels.ForEach(b => ratAcc += b.Rating.Value);
                ratAcc = ratAcc / this.Brezels.Count;

                return ratAcc;
            }
        }

        [Required]
        public Address Address { get; set; }

        public List<Brezel> Brezels { get; set; }

        public List<Rating> Ratings { get; set; }

        public OpeningHours OpeningHours { get; set; }
    }
}