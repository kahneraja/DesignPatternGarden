using DesignPatternGarden.Patterns.State;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternGarden.Tests.Integration
{
    [TestClass]
    public class StatePatternTests
    {
        [TestMethod]
        public void ChangeStateValid()
        {
            WorkItem workItem = new WorkItem();
            workItem.SetState("Active");
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "State changed from Proposed to Resolved.")]
        public void ChangeStateInvalid()
        {

            WorkItem workItem = new WorkItem();
            workItem.SetState("Resolved");
        }
        
    }
}
