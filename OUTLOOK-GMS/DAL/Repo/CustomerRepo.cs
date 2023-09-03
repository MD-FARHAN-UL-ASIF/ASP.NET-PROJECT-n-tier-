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
    internal class CustomerRepo : Repo, IRepo<Customer, int, bool>
    {
        public bool Create(Customer obj)
        {
            db.Customers.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            if (exobj == null)
            {
                return false;
            }
            db.Customers.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Customer> Get()
        {
            return db.Customers.ToList();
        }

        public Customer Get(int id)
        {
            return db.Customers.Find(id);
        }

        public bool Update(Customer obj)
        {
            var exObj = Get(obj.CustomerID);
            if (exObj == null)
            {
                return false;
            }
            exObj.FirstName = obj.FirstName;
            exObj.LastName = obj.LastName;
            exObj.Address = obj.Address;
            exObj.ContactEmail = obj.ContactEmail;
            exObj.ContactPhone = obj.ContactPhone;
            exObj.Address = obj.Address;
            exObj.Password = obj.Password;

            db.Customers.AddOrUpdate(exObj);
            return db.SaveChanges() > 0;
        }
    }
}
