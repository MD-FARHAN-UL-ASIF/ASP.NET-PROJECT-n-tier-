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
    internal class ProductionPlanRepo : Repo, IRepo<ProductionPlan, int, bool>
    {
        public bool Create(ProductionPlan obj)
        {
            db.ProductionPlans.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            if (exobj == null)
            {
                return false;
            }
            db.ProductionPlans.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<ProductionPlan> Get()
        {
            return db.ProductionPlans.ToList();
        }

        public ProductionPlan Get(int id)
        {
            return db.ProductionPlans.Find(id);
        }

        public bool Update(ProductionPlan obj)
        {
            var exObj = Get(obj.PlanID);
            if (exObj == null)
            {
                return false;
            }
            exObj.ProductionStartDate = obj.ProductionStartDate;
            exObj.ProductionEndDate = obj.ProductionEndDate;
            exObj.QuantityToProduce = obj.QuantityToProduce;
            //exObj.InputMaterials = obj.InputMaterials;
            exObj.OutputProduct = obj.OutputProduct;

            db.ProductionPlans.AddOrUpdate(exObj);
            return db.SaveChanges() > 0;
        }
    }
}
