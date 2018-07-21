namespace PackagePriceCalculationService.Models
{
    public class SingleCompanyCost
    {
        public string CompanyName { get; set; }
        public CostType CostType { get; set; }
        public decimal Cost { get; set; }
        public bool Promoted { get; set; }
    }
}