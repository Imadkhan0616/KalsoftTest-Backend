using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KALSOFT_Test.Domain.Models
{
    public class PropertyDetailsModel
    {
        [Key]
        public int id { get; set; }

        [Required]
        public string developerName { get; set; }

        [Required]
        public string projectName { get; set; }

        [Required]
        public string unit { get; set; }

        [Required]
        public string unitType { get; set; }

        [Required]
        public string level { get; set; }

        [Required]
        public string location { get; set; }

        [Required]
        public decimal size { get; set; }

        [Required]
        public int exposureId { get; set; }

        [Required]
        public int bedroom { get; set; }

        [Required]
        public int bathroom { get; set; }

        [Required]
        public bool parking { get; set; }

        [Required]

        public bool locker { get; set; }

        [Required]
        public bool balcony { get; set; }

        //[Required]
        //public ExposureModel exposure { get; set; }
    }
}
