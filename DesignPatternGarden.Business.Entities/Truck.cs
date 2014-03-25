using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternGarden.Business.Entities
{
    public class Truck
    {
        public int Id { get; set; }
        public Farm Farm { get; set; }
        public List<Animal> Animals { get; set; }

        public Truck()
        {
            Animals = new List<Animal>();
        }
    }
}
