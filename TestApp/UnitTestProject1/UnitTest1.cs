﻿using System;
using CompanyCalculationConfigurationRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            var a = new CompanyCalculationConfigurationRepository.CompanyCalculationConfigurationRepository();
            a.GetCofigs();
            
        }
    }
}
