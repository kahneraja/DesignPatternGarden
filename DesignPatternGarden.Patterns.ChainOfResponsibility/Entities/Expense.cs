using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternGarden.Patterns.ChainOfResponsibility.Entities
{
    public class Expense
    {
        public double Total { get; set; }
        public ExpenseStatus Status { get; set; }

        public Expense()
        {
            Status = ExpenseStatus.Pending;
        }
    }
}
