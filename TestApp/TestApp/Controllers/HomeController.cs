using InputLogger.Repostories;
using PackagePriceCalculationService.Models;
using PackagePriceCalculationService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TestApp.Helpers;
using TestApp.Models;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        private const string indexTempDataKey = "indexTempData";
        private readonly PackagePriceCalculation packagePriceCalculation;
        public HomeController()
        {
            packagePriceCalculation = new PackagePriceCalculation(new CompanyCalculationConfigurationRepository.CompanyCalculationConfigurationRepository(),
                new InputLogger.Repostories.InputLogger());
        }

        public ActionResult Index()
        {
            var model = new IndexViewModel()
            {
                DimensionViewModel = new DimensionViewModel()
                {
                    Depth = "0",
                    Height = "0",
                    Weight = "0",
                    Width = "0"
                },
                Packages = new List<PackageViewModel>()
                {
                    new PackageViewModel()
                    {
                        CompanyName="Cargo4You",
                        Promoted = true,
                        PriceTag = new PriceTagViewModel()
                        {
                            Currency = "EUR",
                            PriceValue ="0",
                            PriceType = String.Empty
                        }
                    }
                }
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Calculate(DimensionInputModel input)
        {
            var result = new GenericJsonResult();
            if (!ModelState.IsValid)
            {
                result = new GenericJsonResult()
                {
                    Data = PartialView("ErrorSection", ModelState.Where(x => x.Value.Errors.Any()).Select(x => $"{x.Key} : { String.Join(" ", x.Value.Errors.Select(y => y.ErrorMessage))}")).RenderToString(),
                    Success = false
                };
            }
            else
            {
                var parameters = new CalculationCostParameters()
                {
                    DimensionsParameters = new DimensionsParameters()
                    {
                        Depth = Convert.ToInt32(input.Depth),
                        Height = Convert.ToInt32(input.Height),
                        Width = Convert.ToInt32(input.Width)
                    },
                    WieghtParameters = new WeightParameters()
                    {
                        Weight = Convert.ToInt32(input.Weight)
                    }
                };

                CalculationResultModel calculationResult = packagePriceCalculation.CalculateCost(parameters);

                var Packages = new List<PackageViewModel>();
                Packages = calculationResult.SingleCompanyCosts.Select(x => new PackageViewModel()
                {
                    CompanyName = x.CompanyName,
                    PriceTag = new PriceTagViewModel()
                    {
                        Currency = "EUR",
                        PriceType = x.CostType.ToString(),
                        PriceValue = x.Cost.ToString()
                    },
                    Promoted = x.Promoted
                }).ToList();

                result = new GenericJsonResult()
                {
                    Data = PartialView("CalculationResult", Packages).RenderToString(),
                    Success = true
                };
            }

            return Json(result, JsonRequestBehavior.AllowGet);
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