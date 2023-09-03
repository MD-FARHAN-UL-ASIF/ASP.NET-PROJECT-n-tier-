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
    public class ProductRepo : Repo, IRepo<Product, int, bool>
    {
        public bool Create(Product obj)
        {
            db.Products.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Products.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Product> Get()
        {
            return db.Products.ToList();
        }

        public Product Get(int id)
        {
            return db.Products.Find(id);
        }

        public bool Update(Product obj)
        {
            var exObj = Get(obj.Id);
            if (exObj == null)
            {
                return false;
            }
            exObj.name = obj.name;
            exObj.quantity = obj.quantity;
            exObj.perprice = obj.perprice;
            exObj.totalprice = exObj.totalprice;
            exObj.date = exObj.date;




            db.Products.AddOrUpdate(exObj);
            return db.SaveChanges() > 0;
        }
    }
}
