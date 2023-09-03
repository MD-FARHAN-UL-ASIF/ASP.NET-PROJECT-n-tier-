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
    public class OrderRepo : Repo, IRepo<Order, int, bool>, iCusOrder
    {
        public bool Create(Order obj)
        {
            db.Orders.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            if (exobj == null)
            {
                return false;
            }
            db.Orders.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Order> Get()
        {
            return db.Orders.ToList();
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public bool Update(Order obj)
        {
            var exObj = Get(obj.OrderID);
            if (exObj == null)
            {
                return false;
            }
            exObj.OrderDate = obj.OrderDate;
            exObj.OrderStatus = obj.OrderStatus;
            exObj.TotalAmount = obj.TotalAmount;
            exObj.ShippingAddress = obj.ShippingAddress;
            exObj.BillingAddress = obj.BillingAddress;
            exObj.PaymentMethod = obj.PaymentMethod;
            exObj.PaymentStatus = obj.PaymentStatus;
            exObj.ShippingMethod = obj.ShippingMethod;
            exObj.ShippingCost = obj.ShippingCost;
            exObj.ExpectedDeliveryDate = obj.ExpectedDeliveryDate;
            exObj.TrackingNumber = obj.TrackingNumber;
            exObj.PromoCode = obj.PromoCode;
            exObj.TaxAmount = obj.TaxAmount;
            exObj.OrderPriority = obj.OrderPriority;
            exObj.Discounts = obj.Discounts;

            db.Orders.AddOrUpdate(exObj);
            return db.SaveChanges() > 0;
        }

        public List<Order> GetByCustomer(int id)
        {
            return db.Orders.Where(order => order.CustomerID == id).ToList();
        }

    }
}
