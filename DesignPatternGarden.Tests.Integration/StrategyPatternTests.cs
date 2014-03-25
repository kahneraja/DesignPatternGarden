using DesignPatternGarden.Patterns.Strategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternGarden.Tests.Integration
{
    [TestClass]
    public class StrategyPatternTests
    {
        Order Order;

        [TestInitialize]
        public void Init()
        {
            Order = new Order();
            Order.Items.Add(new Item { Title = "Apple", Price = 10 });
            Order.Items.Add(new Item { Title = "Orange", Price = 10 });
            Order.Items.Add(new Item { Title = "Banana", Price = 10 });
        }

        [TestMethod]
        public void TestRegularDelivery()
        {
            ShippingCostCalculator calculator = new ShippingCostCalculator(new RegularShippingCalculator());
            double price = calculator.Calculate(Order);
            Assert.AreEqual(price, 35);
        }

        [TestMethod]
        public void TestSpeedyDelivery()
        {
            ShippingCostCalculator calculator = new ShippingCostCalculator(new SpeedyShippingCalculator());
            double price = calculator.Calculate(Order);
            Assert.AreEqual(price, 60);
        }

        [TestMethod]
        public void TestSecureDelivery()
        {
            ShippingCostCalculator calculator = new ShippingCostCalculator(new SecureShippingCalculator());
            double price = calculator.Calculate(Order);
            Assert.AreEqual(price, 90);
        }
    }
}
