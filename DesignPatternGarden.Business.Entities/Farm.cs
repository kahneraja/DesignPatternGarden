using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternGarden.Business.Entities
{
    public class Farm
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public List<Animal> Animals { get; set; }
        public List<Truck> Trucks { get; set; }
        

        public Farm()
        {
            Animals = new List<Animal>();
            Trucks = new List<Truck>();
        }
    }
}
