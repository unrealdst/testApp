using System.ComponentModel.DataAnnotations;

namespace TestApp.Models
{
    public class DimensionInputModel
    {
        [Range(0, int.MaxValue)]
        [Required]
        public string Width { get; set; }

        [Range(0, int.MaxValue)]
        [Required]
        public string Height { get; set; }

        [Range(0, int.MaxValue)]
        [Required]
        public string Depth { get; set; }

        [Range(0, int.MaxValue)]
        [Required]
        public string Weight { get; set; }
    }
}