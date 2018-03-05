using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPNETCOREDEMO.Models
{
    [Table("Contacts")]
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(10)]
        public string Number { get; set; }
        [StringLength(255)]
        public string  Email { get; set; }
    }
}