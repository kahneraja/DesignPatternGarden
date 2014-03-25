using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternGarden.Patterns.Strategy
{
    public class Order

    {
        public DeliveryType DeliveryType;
        public List<Item> Items;
        public double TotalPrice
        {
            get
            {
                return Items.Sum(x => x.Price);
            }
        }

        public Order()
        {
            Items = new List<Item>();
        }

    }
}
