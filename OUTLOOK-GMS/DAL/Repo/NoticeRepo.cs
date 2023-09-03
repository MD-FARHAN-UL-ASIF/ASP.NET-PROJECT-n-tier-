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
     public class NoticeRepo : Repo, IRepo<Notice, int, bool>
        {
            public bool Create(Notice obj)
            {
                db.Notices.Add(obj);
                return db.SaveChanges() > 0;
            }

            public bool Delete(int id)
            {
                var exobj = Get(id);
                db.Notices.Remove(exobj);
                return db.SaveChanges() > 0;
            }

            public List<Notice> Get()
            {
                return db.Notices.ToList();
            }

            public Notice Get(int id)
            {
                return db.Notices.Find(id);
            }

            public bool Update(Notice obj)
            {
                var exObj = Get(obj.Id);
                if (exObj == null)
                {
                    return false;
                }
                exObj.Title = obj.Title;
                exObj.Content = obj.Content;
                exObj.Date = obj.Date;
               

                db.Notices.AddOrUpdate(exObj);
                return db.SaveChanges() > 0;
            }
        
    }
}
