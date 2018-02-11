using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Brezelapp.Models.Viewmodels
{
    public class StoreView
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }
    }
}