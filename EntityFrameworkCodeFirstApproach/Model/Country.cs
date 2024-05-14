using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCodeFirstApproach.Model
{
    public class Country
    {

        [Key]
        public int Id {  get; set; }

        [Required]
        public string? Name { get; set; }
    }
}
