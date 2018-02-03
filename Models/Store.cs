using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Brezelapp.Models
{
    public class Store
    {
        public Store()
        {

        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public List<Brezel> Brezels { get; set; }
    }
}