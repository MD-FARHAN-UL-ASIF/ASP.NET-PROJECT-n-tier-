using DAL.EF.Models;
using DAL.iINTERFACES;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class SalaryRepo : Repo, IRepo<Salary, int, bool>
    {
        public bool Create(Salary obj)
        {
            db.Salaries.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Salaries.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Salary> Get()
        {
            return db.Salaries.ToList();
        }

        public Salary Get(int id)
        {
            return db.Salaries.Find(id);
        }

        public bool Update(Salary obj)
        {
            var exObj = Get(obj.Id);
            if (exObj == null)
            {
                return false;
            }
            exObj.Amount = obj.Amount;
            exObj.Bonus = obj.Bonus;
            exObj.PaymentDate = exObj.PaymentDate;

            db.Salaries.AddOrUpdate(exObj);
            return db.SaveChanges() > 0;
        }
        public List<Salary> GetByEmployeeId(int employeeId)
        {
            return db.Salaries.Where(a => a.EmployeeId == employeeId).ToList();
        }

    }
}
