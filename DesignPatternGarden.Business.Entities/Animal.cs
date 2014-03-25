using DesignPatternGarden.Business.Entities.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternGarden.Business.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        public AnimalType Type { get; set; }
        public int Age { get; set; }
        public Farm Farm { get; set; }
        public bool IsAlive { get; set; }

        public Animal()
        {
            IsAlive = true;
        }

        public void Kill()
        {
            IsAlive = false;
        }
    }
}
