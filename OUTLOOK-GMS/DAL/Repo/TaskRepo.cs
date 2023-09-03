using DAL.iINTERFACES;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    public class TaskRepo : Repo, IRepo<EF.Models.Task, int, bool>
    {
        public bool Create(EF.Models.Task obj)
        {
            db.Tasks.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var exobj = Get(id);
            if (exobj == null)
            {
                return false;
            }
            db.Tasks.Remove(exobj);
            return db.SaveChanges() > 0;
        }

        public List<EF.Models.Task> Get()
        {
            return db.Tasks.ToList();
        }

        public EF.Models.Task Get(int id)
        {
            return db.Tasks.Find(id);
        }

        public bool Update(EF.Models.Task obj)
        {
            var exObj = Get(obj.TaskID);
            if (exObj == null)
            {
                return false;
            }
            exObj.TaskDescription = obj.TaskDescription;
            exObj.EstimatedTime = obj.EstimatedTime;
            exObj.TaskStatus = obj.TaskStatus;
            db.Tasks.AddOrUpdate(exObj);
            return db.SaveChanges() > 0;
        }
    }
}
