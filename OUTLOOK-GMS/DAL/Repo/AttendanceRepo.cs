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
    public class AttendanceRepo : Repo, IRepo<Attendance, int, bool>
    {
        public bool Create(Attendance obj)
        {
            db.Attendences.Add(obj);
            return db.SaveChanges()>0;
        }

        public bool Delete(int AttendanceId)
        {
            var exobj = Get(AttendanceId);
            db.Attendences.Remove(exobj);
            return db.SaveChanges()>0;
        }

        public List<Attendance> Get()
        {
            return db.Attendences.ToList();
        }

        public Attendance Get(int AttendanceId)
        {
            return db.Attendences.Find(AttendanceId);
        }



        public bool Update(Attendance obj)
        {
            try
            {
                var exObj = Get(obj.AttendanceId);
                if (exObj == null)
                {
                    return false; // Attendance record not found, cannot update
                }

                exObj.EmployeeId = obj.EmployeeId;
                exObj.Date = obj.Date;
                exObj.ClockInTime = obj.ClockInTime;
                exObj.ClockOutTime = obj.ClockOutTime;

                // Note: Depending on your context and db structure, you might not need AddOrUpdate
                db.Attendences.AddOrUpdate(exObj);

                return db.SaveChanges() > 0; // Save changes and return success status
            }
            catch (Exception ex)
            {
                // Log or display the inner exception details for troubleshooting
                throw new Exception("Error updating attendance.", ex);
            }
        }

        public List<Attendance> GetByEmployeeId(int employeeId)
        {
            return db.Attendences.Where(a => a.EmployeeId == employeeId).ToList();
        }
        public List<Attendance> GetByDate(DateTime date)
        {
            return db.Attendences.Where(a => a.Date == date).ToList();
        }
    }
}
