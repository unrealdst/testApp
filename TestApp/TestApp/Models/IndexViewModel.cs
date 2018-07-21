using System.Collections.Generic;

namespace TestApp.Models
{
    public class IndexViewModel
    {
        public DimensionViewModel DimensionViewModel { get; set; }
        public IEnumerable<PackageViewModel> Packages { get; set; }
    } 
}