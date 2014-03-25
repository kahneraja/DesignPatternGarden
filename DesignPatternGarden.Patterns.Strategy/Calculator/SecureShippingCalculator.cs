using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternGarden.Patterns.Strategy
{
    public class SecureShippingCalculator : IShippingCalculator
    {
        public double Calculate(Order order)
        {
            return order.TotalPrice * 3;
        }
    }
}
