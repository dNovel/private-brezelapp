// <copyright file="StoreRequest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Brezelapp.Models.Viewmodels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class StoreRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }
    }
}