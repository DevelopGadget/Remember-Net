using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleCrudWithSQLDatabase.Models {
    public class Game {
        [Key]
        [DatabaseGenerated (DatabaseGeneratedOption.Identity)]
        public int GameId { get; set; }

        [Required]
        [StringLength (50)]
        public string Name { get; set; }

        [Required]
        [StringLength (50)]
        public string Gender { get; set; }

        [Required]
        [StringLength (50)]
        public string Platoforms { get; set; }
    }
}