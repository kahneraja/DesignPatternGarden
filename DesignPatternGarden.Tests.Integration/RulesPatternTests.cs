using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesignPatternGarden.Business.Entities;
using DesignPatternGarden.Business.Entities.Types;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatternGarden.Tests.Integration
{
    [TestClass]
    public class RulesPatternTests
    {
        Farm farm;

        [TestInitialize]
        public void init()
        {
            // Generate Test Data
            farm = new Farm { Id = 1, Address = "NSW, Australia", Title = "John's Farm" };
            farm.Animals.Add(new Animal { Id = 1, Type = AnimalType.Cow, Age = 10 });
            farm.Animals.Add(new Animal { Id = 2, Type = AnimalType.Goat, Age = 20 });
            farm.Animals.Add(new Animal { Id = 3, Type = AnimalType.Sheep, Age = 30 });
            farm.Animals.Add(new Animal { Id = 4, Type = AnimalType.Cow, Age = 40 });
            farm.Animals.Add(new Animal { Id = 5, Type = AnimalType.Sheep, Age = 50 });
            farm.Animals.Add(new Animal { Id = 6, Type = AnimalType.Goat, Age = 60 });
            farm.Animals.Add(new Animal { Id = 7, Type = AnimalType.Cow, Age = 70 });
            farm.Animals.Add(new Animal { Id = 8, Type = AnimalType.Cow, Age = 80 });
        }

        [TestMethod]
        public void build_farm_graph()
        {
            Assert.IsTrue(farm.Animals.Count > 0, "Unable to create a Farm Graph");
        }

        [TestMethod]
        public void test_age_kill_handmade()
        {
            foreach (Animal animal in farm.Animals)
            {
                if (animal.Age > 5)
                {
                    if (animal.Type == AnimalType.Cow)
                    {
                        // Kill cow if older than 5.
                        animal.Kill();
                    }
                }
            }

            Assert.IsFalse(farm.Animals.Where(
                    x => x.Age <= 5
                    && x.IsAlive == true
                    && x.Type == AnimalType.Cow).Count() > 0, "Old animal was not killed.");
        }
    }
}
