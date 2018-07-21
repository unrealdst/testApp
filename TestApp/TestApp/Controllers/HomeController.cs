using CompanyCalculationConfigurationRepository;
using PackagePriceCalculationService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly PackagePriceCalculation packagePriceCalculation;
        public HomeController()
        {
            packagePriceCalculation = new PackagePriceCalculation(new CompanyCalculationConfigurationRepository.CompanyCalculationConfigurationRepository());
        }

        public ActionResult Index()
        {
            var model = new IndexViewModel()
            {
                DimensionViewModel = new DimensionViewModel()
                {
                    Depth = "1",
                    Height = "2",
                    Weight = "3",
                    Width = "4"
                },
                Packages = new List<PackageViewModel>()
                {
                    new PackageViewModel()
                    {
                        CompanyName="Company name 1",
                        Promoted = true,
                        PriceTag =
                            new PriceTagViewModel()
                            {
                                Currency = "CZK",
                                PriceValue ="50000",
                                PriceType = "Size"
                            }
                    },
                    new PackageViewModel()
                    {
                        CompanyName="Company name 2",
                        Promoted = false,
                        PriceTag =
                            new PriceTagViewModel()
                            {
                                Currency = "CZK",
                                PriceValue ="1000000",
                                PriceType = "wieght"
                            }
                    }
                }
            };
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}