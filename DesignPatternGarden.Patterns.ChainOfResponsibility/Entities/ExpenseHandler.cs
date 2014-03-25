using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternGarden.Patterns.ChainOfResponsibility.Entities
{
    public class ExpenseHandler : IExpenseHandler
    {
        private IExpenseHandler Handler { get; set; }
        private IExpenseHandler NextHandler { get; set; }

        public ExpenseHandler(IExpenseHandler handler)
        {
            Handler = handler;
        }

        public bool ApproveExpense(Expense expense)
        {

            bool result = Handler.ApproveExpense(expense);

            if (!result && NextHandler != null)
            {
                result = NextHandler.ApproveExpense(expense);
            }

            return result;
        }

        public void SetNextHandler(IExpenseHandler handler)
        {
            NextHandler = handler;
        }
    }
}
