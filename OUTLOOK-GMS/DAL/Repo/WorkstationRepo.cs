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
    internal class WorkstationRepo : Repo, IRepo<Workstation, int, bool>
    {
        public bool Create(Workstation obj)
        {
            db.Workstations.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            if (exobj == null)
            {
                return false;
            }
            db.Workstations.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<Workstation> Get()
        {
            return db.Workstations.ToList();
        }

        public Workstation Get(int id)
        {
            return db.Workstations.Find(id);
        }

        public bool Update(Workstation obj)
        {
            var exObj = Get(obj.WorkstationID);
            if (exObj == null)
            {
                return false;
            }
            exObj.WorkstationName = obj.WorkstationName;
            exObj.WorkstationType = obj.WorkstationType;
            exObj.Supervisor = obj.Supervisor;
            exObj.Shifts = obj.Shifts;
            exObj.DefectRate = obj.DefectRate;
            exObj.ProductionVolume = obj.ProductionVolume;

            db.Workstations.AddOrUpdate(exObj);
            return db.SaveChanges() > 0;
        }
    }
}
