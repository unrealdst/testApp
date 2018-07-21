using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestApp.Models
{
    public class PackageViewModel
    {
        public string CompanyName { get; set; }
        public bool Promoted { get; set; }
        public PriceTagViewModel PriceTag { get; set; }
    }
}