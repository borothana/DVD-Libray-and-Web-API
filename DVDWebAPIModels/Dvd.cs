using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDWebAPIModels
{
    public class Dvd
    {
        
        public int DvdId { get; set; }
        [Required(ErrorMessage = "Title is required!")]
        public string Title { get; set; }
        [Range(1950, 2050, ErrorMessage = "Invalid release year!")]
        public int ReleaseYear { get; set; }
        [Required(ErrorMessage = "Rating is required!")]
        public int RatingId { get; set; }
        [Required(ErrorMessage = "Director is required!")]
        public int DirectorId { get; set; }
        public string Note { get; set; }

        public virtual Rating Rating { get; set; }
        public virtual Director Director { get; set; }
    }
}
