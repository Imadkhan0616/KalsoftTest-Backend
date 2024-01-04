using System.ComponentModel.DataAnnotations;

namespace KALSOFT_Test.Domain.Models
{
    public class ExposureModel
    {
        [Key]
        public int? id { get; set; }

        [Required]
        public string? name { get; set; }
    }
}
