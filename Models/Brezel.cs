using System.ComponentModel.DataAnnotations;

namespace Brezelapp.Models
{
    public class Brezel
    {
        public Brezel()
        {

        }

        [Key]
        public int Id { get; set; }

        public float Price { get; set; }

        private int rating;
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