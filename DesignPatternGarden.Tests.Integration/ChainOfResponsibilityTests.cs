using DesignPatternGarden.Patterns.ChainOfResponsibility.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatternGarden.Tests.Integration
{
    [TestClass]
    public class ChainOfResponsibilityTests
    {
        Department department;

        [TestInitialize]
        public void Init()
        {
            department = new Department();
            department.Employees.Add(new Employee { Name = "John", Type = EmployeeType.Manager });
            department.Employees.Add(new Employee { Name = "Jenny", Type = EmployeeType.Staff });
            department.Employees.Add(new Employee { Name = "Carl", Type = EmployeeType.Staff });
            department.Employees.Add(new Employee { Name = "Tim", Type = EmployeeType.Staff });
            department.Employees.Add(new Employee { Name = "Alex", Type = EmployeeType.Manager });
            department.Employees.Add(new Employee { Name = "Amanda", Type = EmployeeType.President });
        }

        [TestMethod]
        public void CreateExpense()
        {
            Expense expense = new Expense { Total = 150 };

            Assert.IsNotNull(expense);
        }

        [TestMethod]
        public void TestExpenseDenial()
        {
            Expense expense = new Expense { Total = 150 };
            Employee employee = new Employee { Type = EmployeeType.Staff };
            bool result = employee.ApproveExpense(expense);
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TestExpenseApproval()
        {
            Expense expense = new Expense { Total = 150 };

            Employee employee = new Employee { Name = "John", Type = EmployeeType.Manager };

            employee.ApproveExpense(expense);
            Assert.IsTrue(expense.Status == ExpenseStatus.Approved);
        }

        [TestMethod]
        public void TestDepartmentApproval()
        {
            Expense expense = new Expense { Total = 150 };



            foreach (Employee employee in department.Employees)
            {
                bool approved = employee.ApproveExpense(expense);
                if (approved)
                {
                    break;
                }
            }
            
            Assert.IsTrue(expense.Status == ExpenseStatus.Approved);
        }

        [TestMethod]
        public void TestChainDepartmentApproval()
        {
            Expense expense = new Expense { Total = 150 };
            
            Employee Amanda = new Employee { Name = "Amanda", Type = EmployeeType.President };
            Employee John = new Employee { Name = "John", Type = EmployeeType.Manager };
            Employee Alex = new Employee { Name = "Alex", Type = EmployeeType.Manager };
            Employee Jenny = new Employee { Name = "Jenny", Type = EmployeeType.Staff };
            Employee Tim = new Employee { Name = "Tim", Type = EmployeeType.Staff };
            Employee Carl = new Employee { Name = "Carl", Type = EmployeeType.Staff };
            Employee Max = new Employee { Name = "Max", Type = EmployeeType.Staff};

            ExpenseHandler handlerAmanda = new ExpenseHandler(Amanda);
            ExpenseHandler handlerJohn = new ExpenseHandler(John);
            handlerJohn.SetNextHandler(handlerAmanda);
            ExpenseHandler handlerAlex = new ExpenseHandler(Alex);
            handlerAlex.SetNextHandler(handlerAmanda);

            ExpenseHandler handlerJenny = new ExpenseHandler(Jenny);
            handlerJenny.SetNextHandler(handlerJohn);
            ExpenseHandler handlerTim = new ExpenseHandler(Tim);
            handlerTim.SetNextHandler(handlerJohn);
            ExpenseHandler handlerCarl = new ExpenseHandler(Carl);
            handlerCarl.SetNextHandler(handlerAlex);
            ExpenseHandler handlerMax = new ExpenseHandler(Max);
            handlerMax.SetNextHandler(handlerAlex);

            bool approved = handlerMax.ApproveExpense(expense);

            Assert.IsTrue(expense.Status == ExpenseStatus.Approved);
        }

        [TestMethod]
        public void TestChainDepartmentDenial()
        {
            Expense expense = new Expense { Total = 400 };

            Employee Amanda = new Employee { Name = "Amanda", Type = EmployeeType.President };
            Employee John = new Employee { Name = "John", Type = EmployeeType.Manager };
            Employee Alex = new Employee { Name = "Alex", Type = EmployeeType.Manager };
            Employee Jenny = new Employee { Name = "Jenny", Type = EmployeeType.Staff };
            Employee Tim = new Employee { Name = "Tim", Type = EmployeeType.Staff };
            Employee Carl = new Employee { Name = "Carl", Type = EmployeeType.Staff };
            Employee Max = new Employee { Name = "Max", Type = EmployeeType.Staff };


            ExpenseHandler handlerAmanda = new ExpenseHandler(Amanda);
            ExpenseHandler handlerJohn = new ExpenseHandler(John);
            handlerJohn.SetNextHandler(handlerAmanda);
            ExpenseHandler handlerAlex = new ExpenseHandler(Alex);
            handlerAlex.SetNextHandler(handlerAmanda);

            ExpenseHandler handlerJenny = new ExpenseHandler(Jenny);
            handlerJenny.SetNextHandler(handlerJohn);
            ExpenseHandler handlerTim = new ExpenseHandler(Tim);
            handlerTim.SetNextHandler(handlerJohn);
            ExpenseHandler handlerCarl = new ExpenseHandler(Carl);
            handlerCarl.SetNextHandler(handlerAlex);
            ExpenseHandler handlerMax = new ExpenseHandler(Max);
            handlerMax.SetNextHandler(handlerAlex);

            bool approved = handlerMax.ApproveExpense(expense);

            Assert.IsFalse(expense.Status == ExpenseStatus.Approved);
        }
    }
}
