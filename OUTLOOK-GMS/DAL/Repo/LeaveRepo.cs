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
    public class LeaveRepo : Repo, IRepo<Leave, int, bool>
    {
        public bool Create(Leave obj)
        {
            db.Leaves.Add(obj);
            return db.SaveChanges() > 0;
        }
        public Leave GetLatestLeaveByEmployee(int employeeId)
        {
            return db.Leaves
                .Where(l => l.EmployeeId == employeeId)
                .OrderByDescending(l => l.Id)
                .FirstOrDefault();
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            db.Leaves.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Leave> Get()
        {
            return db.Leaves.ToList();
        }

        public Leave Get(int id)
        {
            return db.Leaves.Find(id);
        }

        public bool Update(Leave obj)
        {
            var exObj = Get(obj.Id);

            if (exObj == null)
            {
                return false;
            }

            exObj.EmployeeId = obj.EmployeeId;
            exObj.LeaveType = obj.LeaveType;
            exObj.StartDate = obj.StartDate;
            exObj.EndDate = obj.EndDate;
            exObj.Reason = obj.Reason;
            exObj.TotalAnnualLeaveEntitlement = obj.TotalAnnualLeaveEntitlement;
            exObj.RemainingLeave = obj.RemainingLeave;
            exObj.Status = obj.Status;

            db.Leaves.AddOrUpdate(exObj);
            return db.SaveChanges() > 0;
        }

        public List<Leave> GetByEmployeeId(int employeeId)
        {
            return db.Leaves.Where(a => a.EmployeeId == employeeId).ToList();
        }

        
    }
}
