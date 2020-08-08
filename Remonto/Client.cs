using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SQLite;


namespace Labo4ka7
{
    class Client
    {
        Model1 db = new Model1();
       public bool addClient(person client)
        {
            try
            {
                client.Status = "Клиент";
                client.DateAdd = DateTime.Now;
                client.DateLastAutorization = DateTime.Now.Date;
                client.DateOfRegistrarion = DateTime.Now.Date;
                db.person.Add(client);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public person FindByIdClient(int ID)
        {
            person per = new person();
            try
            {
                var res = db.person
                    .Where(z => z.Status == "Клиент")
                    .Where(u => u.ID == ID);
                foreach (person o in res)
                {
                    per = o;
                } 
                return per;
            }
            catch (Exception)
            {
                //MessageBox.Show("Ошибка, не удалось найти клиента");
                return per;
            }
        }
        public int GetKolvoClient(string sorting, bool sortingA, person filtering, DateTime min, DateTime max, int count)
        {         
                var filterANDsorting = db.person
                    .Where(Z => Z.Status == "Клиент")
                    .Where(C => C.CompanyName.StartsWith(filtering.CompanyName) || filtering.CompanyName == null)
                    .Where(u => u.FIO.StartsWith(filtering.FIO) || filtering.FIO == null)
                    .Where(o => o.phoneSmart == filtering.phoneSmart || filtering.phoneSmart == 0)
                    .Where(o => o.phoneStac == filtering.phoneStac || filtering.phoneStac == 0)
                    .Where(v => v.DateAdd == filtering.DateAdd || filtering.DateAdd == null)
                    .Where(b => b.DateAdd <= min || min == DateTime.MinValue)
                    .Where(m => m.DateAdd >= max || max == DateTime.MinValue)
                    .OrderByDescending(i => i.DateAdd)
                    .Take(count);
                return filterANDsorting.Count();          
        }

        public List<person> GetListClient(string sorting, string sortingA, person filtering, DateTime min, DateTime max, int count, int page)
        {
            try
            {

                if (sortingA == "Возрастание")
                {
                    List<person> Clietns = db.person
                            .Where(Z => Z.Status == "Клиент")
                            .Where(o => o.phoneSmart == filtering.phoneSmart || filtering.phoneSmart == 0)
                            .Where(o => o.phoneStac == filtering.phoneStac || filtering.phoneStac == 0)
                            .Where(v => v.DateAdd == filtering.DateAdd || filtering.DateAdd == DateTime.MinValue)
                            .Where(b => b.DateLastAutorization == min || filtering.DateLastAutorization == DateTime.MinValue)
                            .Where(b => b.DateOfRegistrarion >= min || min == DateTime.MinValue)
                            .Where(m => m.DateOfRegistrarion <= max || max == DateTime.MinValue)
                            .ToList();

                    List<person> Clietns2 = Clietns
                           .Where(C => C.CompanyName.Contains(filtering.CompanyName) || filtering.CompanyName == "")
                           .Where(u => u.FIO.Contains(filtering.FIO) || filtering.FIO == "")
                           .OrderByDescending(sorting)
                           .Skip((count * (page - 1)))
                           .Take(count)
                           .ToList();
                    return Clietns2;
                }
                if (sortingA == "Убывание")
                {
                    List<person> Clietns = db.person
                            .Where(Z => Z.Status == "Клиент")
                            //.Where(C => C.CompanyName.StartsWith(filtering.CompanyName) || filtering.CompanyName == "")
                            //.Where(u => u.FIO.StartsWith(filtering.FIO) || filtering.FIO == "")
                            .Where(o => o.phoneSmart == filtering.phoneSmart || filtering.phoneSmart == 0)
                            .Where(o => o.phoneStac == filtering.phoneStac || filtering.phoneStac == 0)
                            .Where(v => v.DateAdd == filtering.DateAdd || filtering.DateAdd == DateTime.MinValue)
                            .Where(b => b.DateLastAutorization == min || filtering.DateLastAutorization == DateTime.MinValue)
                            .Where(b => b.DateOfRegistrarion >= min || min == DateTime.MinValue)
                            .Where(m => m.DateOfRegistrarion <= max || max == DateTime.MinValue)
                            .ToList();

                    List<person> Clietns2 = Clietns
                            .Where(C => C.CompanyName.StartsWith(filtering.CompanyName) || filtering.CompanyName == "")
                            .Where(u => u.FIO.StartsWith(filtering.FIO) || filtering.FIO == "")
                            .OrderByDescending(sorting)
                            .Skip((count * (page - 1)))
                            .Take(count)
                            .ToList();
                    return Clietns2;

                  
                }
                return null;
            }
            catch(Exception)
            {              
                return null;
            }
        }
        public int GetMaxIDClient()
        {
            try
            {
                var Poi = db.person
                    .Max(p => p.ID);
                return Poi;
            }
            catch(Exception)
            {
                //MessageBox.Show("Не удалось найти максимальный ID");
                return 0;
            }
        }
        public bool SaveClient(person client)
        {
            try
            {
                var editorsPerson = db.person
                                       .Where(c => c.ID == client.ID)
                                       .FirstOrDefault();
                if (client.FIO != null)
                        editorsPerson.FIO = client.FIO;
                if (client.phoneSmart != 0 || client.phoneSmart != 0)
                    editorsPerson.phoneSmart = client.phoneSmart;
                if (client.phoneStac != 0 || client.phoneStac != 0)
                    editorsPerson.phoneStac = client.phoneStac;
                if (client.CompanyName != null)
                    editorsPerson.CompanyName = client.CompanyName;
                editorsPerson.DateLastAutorization = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DelClient(int id)
        {
            try
            {
                person editorsPerson = db.person
                                       .Where(c => c.ID == id)
                                       .Include(m=>m.Machine)
                                       .Include(x=>x.Repairs)
                                       .FirstOrDefault();
                    db.Machine.RemoveRange(editorsPerson.Machine);
                    db.Repairs.RemoveRange(editorsPerson.Repairs);
                db.person.Remove(editorsPerson);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                //MessageBox.Show("Не удалось удалить клиента ");
                return false;
            }
            
        }
    }
}
