using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityFrameworkCodeFirstApproach.Model
{
    public class Company
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [ForeignKey("Country")]
        public int CountryId {  get; set; }

        public DateTime DateOfIncorporation { get; set; }

        public Country Country { get; set; }

        public int CountryCode {  get; set; }

    }
}
