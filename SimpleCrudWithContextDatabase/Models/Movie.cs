using System;
using System.ComponentModel.DataAnnotations;

namespace SimpleCrudWithContextDatabase.Models {
    public class Movie {
        [Required]
        [StringLength (50)]
        public string Name { get; set; }

        [Required]
        [StringLength (50)]
        public string Gender { get; set; }

        [DataType (DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [MinLength (0)]
        public decimal Price { get; set; }
    }
}