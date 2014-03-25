using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternGarden.Patterns.ChainOfResponsibility.Entities
{
    public interface IExpenseHandler
    {
        bool ApproveExpense(Expense expense);
        void SetNextHandler(IExpenseHandler handler);
    }
}
