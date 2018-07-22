using System.ComponentModel.DataAnnotations;

namespace TestApp.Models
{
    public class DimensionInputModel
    {
        [Required]
        public string Width { get; set; }

        [Required]
        public string Height { get; set; }

        [Required]
        public string Depth { get; set; }

        [Required]
        public string Weight { get; set; }
    }
}