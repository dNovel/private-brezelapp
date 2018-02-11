using System.ComponentModel.DataAnnotations;

namespace Brezelapp.Models.Viewmodels
{
    public class BrezelView
    {
        public BrezelView()
        {

        }

        [Required]
        public float Price { get; set; }

        private int rating;

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