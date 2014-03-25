using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternGarden.Patterns.State.States
{
    class Resolved : ICommands
    {
        public WorkItem Owner { get; set; }

        public Resolved(WorkItem workItem)
        {
            Owner = workItem;
        }

        public void Edit(string title, string desc)
        {
            throw new NotImplementedException();
        }

        public void SetState(string state)
        {
            throw new NotImplementedException();
        }
    }
}
