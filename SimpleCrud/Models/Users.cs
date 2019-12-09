using System.ComponentModel.DataAnnotations;

namespace SimpleCrud.Models {
    public class Users {
        [Required]
        [StringLength (30)]
        public string name { get; set; }

        [Required]
        [StringLength (30)]
        public string username { get; set; }

        [Required]
        [StringLength (30)]
        public string password { get; set; }

        [Required]
        [StringLength (30)]
        public string role { get; set; }

        [Required]
        [Range (18, 60)]
        public int age { get; set; }
    }
}