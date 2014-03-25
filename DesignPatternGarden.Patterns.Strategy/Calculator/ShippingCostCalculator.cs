using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternGarden.Patterns.Strategy
{
    public class ShippingCostCalculator
    {

        IShippingCalculator Calculator;

        public ShippingCostCalculator(IShippingCalculator calculator)
        {
            Calculator = calculator;
        }

        public double Calculate(Order order)
        {
            return Calculator.Calculate(order);
        }
    }
}
