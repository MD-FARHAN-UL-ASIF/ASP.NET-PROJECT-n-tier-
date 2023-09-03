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
    public class GmsBudgetRepo : Repo, IRepo<GmsBudget, int, bool>
    {
        public bool Create(GmsBudget obj)
        {
            db.GmsBudgets.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.GmsBudgets.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<GmsBudget> Get()
        {
            return db.GmsBudgets.ToList();
        }

        public GmsBudget Get(int id)
        {
            return db.GmsBudgets.Find(id); ;
        }

        public bool Update(GmsBudget obj)
        {
            var exObj = Get(obj.Id);
            if (exObj == null)
            {
                return false;
            }
            exObj.BudgetAmount = obj.BudgetAmount;
            exObj.StartDate = obj.StartDate;
            exObj.EndDate = obj.EndDate;
            exObj.Status = obj.Status;
            exObj.SalaryPercentage = obj.SalaryPercentage;
            exObj.ProductionPercentage = obj.ProductionPercentage;
            exObj.OtherExpensesPercentage = obj.OtherExpensesPercentage;

            db.GmsBudgets.AddOrUpdate(exObj);
            return db.SaveChanges() > 0;
        }

    }
}
