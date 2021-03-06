﻿using CompanyCalculationConfigurationRepository.Interfaces;
using CompanyCalculationConfigurationRepository.Models;
using InputLogger.Interfaces;
using PackagePriceCalculationService.Interfaces;
using PackagePriceCalculationService.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PackagePriceCalculationService.Services
{
    public class PackagePriceCalculation : IPackagePriceCalculation
    {
        private readonly ICompanyCalculationConfigurationRepository companyCalculationConfigurationRepository;
        private readonly IInputLogger inputLogger;

        public PackagePriceCalculation(ICompanyCalculationConfigurationRepository companyCalculationConfigurationRepository,
            IInputLogger inputLogger)
        {
            this.companyCalculationConfigurationRepository = companyCalculationConfigurationRepository;
            this.inputLogger = inputLogger;
        }

        public CalculationResultModel CalculateCost(CalculationCostParameters parameters)
        {
            var configs = companyCalculationConfigurationRepository.GetCofigs();
            List<SingleCompanyCost> costs = configs.Companys.Select(x => CalculateCost(x, parameters)).Where(x => x != null).ToList();
            costs = costs.OrderBy(x => x.Cost).ToList();
            costs.First().Promoted = true;

            var result = new CalculationResultModel()
            {
                SingleCompanyCosts = costs
            };

            return result;
        }

        private SingleCompanyCost CalculateCost(CompanyConfigurationModel config, CalculationCostParameters parameters)
        {
            decimal? weightPrice = CalculateWeight(config.Weight, parameters.WieghtParameters);

            decimal? dimensionPrice = CalculateDimensionPrice(config.Size, parameters.DimensionsParameters);

            if (weightPrice == null || dimensionPrice == null)
            {
                SaveNotValdiateInput(parameters);
                return null;
            }

            var cost = Math.Max(weightPrice.Value, dimensionPrice.Value);
            SingleCompanyCost result = new SingleCompanyCost()
            {
                CompanyName = config.Name,
                Promoted = false,
                Cost = cost,
                CostType = cost == weightPrice ? CostType.Weight : CostType.Dimension
            };
            return result;
        }

        private void SaveNotValdiateInput(CalculationCostParameters parameters)
        {
            this.inputLogger.SaveWrongInput($"{parameters.DimensionsParameters.Depth}|{parameters.DimensionsParameters.Height}|{parameters.DimensionsParameters.Width}|{parameters.WieghtParameters.Weight}|{DateTime.Now}");
        }

        private decimal? CalculateWeight(WeightConfigurationModel config, WeightParameters weightParameters)
        {
            int size = weightParameters.Weight;

            if (!config.Validation.ItIsInBracket(size))
            {
                return null;
            }

            var costBrackets = config.Brackets.FirstOrDefault(x => x.ItIsInBracket(size));
            if (costBrackets == null)
            {
                costBrackets = config.Brackets.Single(x => x.OversizeCost != null);
            }
            decimal result = costBrackets.Price;
            if (costBrackets.OversizeCost != null && size > costBrackets.Max)
            {
                result = result + ((size - costBrackets.Max) * costBrackets.OversizeCost.Value);
            }
            return result;
        }

        private decimal? CalculateDimensionPrice(SizeConfigurationModel config, DimensionsParameters dimensionsParameters)
        {
            int size = dimensionsParameters.Depth * dimensionsParameters.Height * dimensionsParameters.Width;

            if (!config.Validation.ItIsInBracket(size))
            {
                return null;
            }

            var costBrackets = config.Brackets.First(x => x.ItIsInBracket(size));
            return costBrackets.Price;

        }
    }
}
