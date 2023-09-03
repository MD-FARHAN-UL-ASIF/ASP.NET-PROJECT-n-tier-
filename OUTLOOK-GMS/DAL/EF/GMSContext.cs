using DAL.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class GMSContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Attendance> Attendences { get; set; }
        public DbSet<Leave>  Leaves { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ProductionPlan> ProductionPlans { get; set; }
        public DbSet<Workstation> Workstations { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Salary> Salaries { get; set; }

        public DbSet<GmsBudget> GmsBudgets { get; set; }

    }
}
