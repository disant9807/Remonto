using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SQLite;

namespace Labo4ka7
{
   public static class StaticAdd
    {
        public static void AddAdmin()
        {
            try
            {
                Model1 db = new Model1();
                List<person> result = db.person
                    .Where(m => m.Status == "Админ")
                    .ToList();
                if (result.Count == 0)
                {
                    person addped = new person { FIO = "Администратор", AccesCode = "123", DateAdd = DateTime.Now, DateLastAutorization = DateTime.Now, DateOfRegistrarion = DateTime.Now, phoneSmart = 123, Status = "Админ" };
                    db.person.Add(addped);
                    db.SaveChanges();
                }
            }
            catch(Exception)
            {

            }
        }
    }
}
