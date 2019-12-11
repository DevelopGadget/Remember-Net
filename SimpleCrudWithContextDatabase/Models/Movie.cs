using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCrudWithContextDatabase.Models {
    public class Movie {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Required]
        [StringLength (50)]
        public string Name { get; set; }

        [Required]
        [StringLength (50)]
        public string Gender { get; set; }

        [Required]
        [DataType (DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}