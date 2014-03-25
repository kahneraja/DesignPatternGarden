using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternGarden.Patterns.State
{
    interface ICommands
    {
        void Edit(string title, string desc);
        void SetState(string state);
    }
}
