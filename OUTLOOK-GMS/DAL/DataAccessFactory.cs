using DAL.EF.Models;
using DAL.iINTERFACES;
using DAL.Repo;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataAccessFactory
    {
        public static IRepo<Employee, int, bool> EmployeeData()
        {
            return new EmployeeRepo();
        }
        public static IRepo<Attendance, int, bool> AttendanceData()
        {
            return new AttendanceRepo();
        }

        public static IRepo<Notice, int, bool> NoticeData()
        {
            return new NoticeRepo();
        }

        public static IRepo<Leave, int, bool> LeaveData()
        {
            return new LeaveRepo();
        }
        public static IAuth AuthData()
        {
            return new EmployeeRepo();
        }
        public static IRepo<Token, int, Token> TokenData()
        {
            return new TokenRepo();
        }
        public static IRepo<Customer, int, bool> CoustomerData()
        {
            return new CustomerRepo();
        }
        public static IRepo<Order, int, bool> OrderData()
        {
            return new OrderRepo();
        }

        public static iCusOrder CustomerOrderData()
        {
            return new OrderRepo();
        }

        public static IRepo<ProductionPlan, int, bool> PlanData()
        {
            return new ProductionPlanRepo();
        }

        public static IRepo<Workstation, int, bool> WorkData()
        {
            return new WorkstationRepo();
        }

        public static IRepo<EF.Models.Task, int, bool> TaskData()
        {
            return new TaskRepo();
        }

        public static IRepo<Product, int, bool> ProductData()
        {
            return new ProductRepo();
        }

        public static IRepo<Salary, int, bool> SalaryData()
        {
            return new SalaryRepo();
        }
        public static IRepo<GmsBudget, int, bool> GmsBudgetData()
        {
            return new GmsBudgetRepo();
        }

    }
}
