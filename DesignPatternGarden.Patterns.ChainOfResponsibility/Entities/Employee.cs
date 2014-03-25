using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternGarden.Patterns.ChainOfResponsibility.Entities
{
    public class Employee : IExpenseHandler
    {
        public string Name { get; set; }
        public EmployeeType Type { get; set; }
        public double ExpenseApprovalLimit
        {
            get
            {
                switch (Type)
                {
                    case EmployeeType.Manager:
                        return 200;
                    case EmployeeType.President:
                        return 300;
                    default:
                        return 100;
                }

            }
        }

        private IExpenseHandler NextHandler { get; set; }

        public bool ApproveExpense(Expense expense)
        {
            if (expense.Total <= ExpenseApprovalLimit)
            {
                expense.Status = ExpenseStatus.Approved;
                return true;
            }

            return false;
        }

        public void SetNextHandler(IExpenseHandler handler)
        {
            NextHandler = handler;
        }
    }
}
