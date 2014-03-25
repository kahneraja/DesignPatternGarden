using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternGarden.Patterns.State.States
{
    class Active : ICommands
    {
        public WorkItem Owner { get; set; }

        public Active(WorkItem workItem)
        {
            Owner = workItem;
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
                    throw new Exception("Work Item is already active.");
                case "Proposed":
                    Owner.State = state;
                    break;
                case "Resolved":
                    Owner.State = state;
                    break;
                default:
                    throw new Exception("Work Item is in an active state and cannot be .");
            }
        }
    }
}
