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
    internal class RawMaterialRepo : Repo, IRepo<RawMaterial, int, bool>
    {
        public bool Create(RawMaterial obj)
        {
            db.RawMaterials.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.RawMaterials.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<RawMaterial> Get()
        {
            return db.RawMaterials.ToList();
        }

        public RawMaterial Get(int id)
        {
            return db.RawMaterials.Find(id);
        }

        public bool Update(RawMaterial obj)
        {
            var exObj = Get(obj.Id);
            if (exObj == null)
            {
                return false;
            }
            exObj.name = obj.name;
            exObj.supplier = obj.supplier;
            exObj.quantity = obj.quantity;
            exObj.percost = obj.percost;
            exObj.totalcost = exObj.totalcost;
            exObj.date = exObj.date;
            db.RawMaterials.AddOrUpdate(exObj);
            return db.SaveChanges() > 0;
        }
    }
}
