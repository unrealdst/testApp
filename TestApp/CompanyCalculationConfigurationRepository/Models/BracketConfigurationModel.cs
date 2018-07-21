namespace CompanyCalculationConfigurationRepository.Models
{
    public class BracketConfigurationModel
    {
        public decimal Min { get; set; }

        public decimal Max { get; set; }

        public decimal Price { get; set; }

        public decimal? OversizeCost { get; set; }
    }
}