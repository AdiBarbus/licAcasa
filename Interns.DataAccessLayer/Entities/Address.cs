using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Interns.DataAccessLayer.Entities
{
    public class Address 
    {
        [Key, ForeignKey("User")]
        public int? UserId { get; set; }
        [Required]
        public string City { get; set; }
        public string County { get; set; }
        [Required]
        public string Street { get; set; }
        public int Number { get; set; }
        public int Zip { get; set; }
        public virtual User User { get; set; }
    }
}
