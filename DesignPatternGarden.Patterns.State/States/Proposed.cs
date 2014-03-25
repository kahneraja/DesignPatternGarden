using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternGarden.Patterns.State.States
{
    class Proposed : ICommands
    {
        public WorkItem Owner { get; set; }

        public Proposed(WorkItem owner)
        {
            Owner = owner;
        }

        public void Edit(string title, string desc)
        {
            throw new NotImplementedException();
        }

        public void SetState(string state)
        {
            switch (state)
            {
                case "Active":
                    Owner.State = state;
                    break;
                case "Closed":
                    Owner.State = state;
                    break;
                case "Resolved":
                    throw new Exception("Work Item is currently proposed, it needs to be Active before it can be Resolved.");
                default:
                    throw new Exception("Work Item is already proposed.");
            }
        }
    }
}
