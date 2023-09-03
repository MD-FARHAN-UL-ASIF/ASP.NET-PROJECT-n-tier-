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
        public class EmployeeRepo : Repo, IRepo<Employee, int, bool>, IAuth
    {
            public bool Create(Employee obj)
            {
                db.Employees.Add(obj);
                return db.SaveChanges() > 0;
            }

            public bool Delete(int id)
            {
                var exobj = Get(id);
                db.Employees.Remove(exobj);
                return db.SaveChanges() > 0;
            }

            public List<Employee> Get()
            {
                return db.Employees.ToList();
            }

            public Employee Get(int id)
            {
                return db.Employees.Find(id);
            }
            public List<Employee> GetByName(String name)
            {
                return db.Employees.Where(a => a.Name == name).ToList();
            }

            public bool Update(Employee obj)
            {
                var exObj = Get(obj.Id);
                if (exObj == null)
                {
                    return false;
                }
                exObj.Name = obj.Name;
                exObj.UserName = obj.UserName;
                exObj.PhoneNumber = obj.PhoneNumber;
                exObj.Email = obj.Email;
                exObj.NID = obj.NID;
                exObj.DOB = obj.DOB;
                exObj.Gender = obj.Gender;
                exObj.Address = obj.Address;
                exObj.Status = obj.Status;
                exObj.Image = obj.Image;
                exObj.CreatedAt = obj.CreatedAt;
                exObj.UserType = obj.UserType;
                exObj.Department = obj.Department;
                exObj.Salary = obj.Salary;
                exObj.Password = obj.Password;

                db.Employees.AddOrUpdate(exObj);
                return db.SaveChanges() > 0;
            }
                public Employee Authenticate(string email, string password)
                {
                    var employee = from e in db.Employees where e.Email == email
                       
                               && e.Password.Equals(password)
                               select e;
                    if (employee != null) return employee.SingleOrDefault();
                    return null;

                }
    }

    
}
