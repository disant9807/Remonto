using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SQLite;

namespace Labo4ka7
{
    class Manager
    {
        Model1 db = new Model1();
        public bool addManager(person manager)
        {
            try
            {
                manager.Status = "Менеджер";
                manager.DateAdd = DateTime.Now;
                manager.DateLastAutorization = DateTime.Now.Date;
                manager.DateOfRegistrarion = DateTime.Now.Date;
                db.person.Add(manager);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public person FindByIdManager(int ID)
        {
            try
            {
                person per = db.person
                   .Where(z => z.Status == "Менеджер")
                   .Where(u => u.ID == ID)
                   .Include(v => v.Repairs)
                   .Include(c=>c.Machine)
                   .Include(c=> c.RepairsReferenceBook)
                   .FirstOrDefault();
                return per;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public int GetKolvoManager(string sorting, bool sortingA, person filtering, DateTime minAdd, DateTime maxAdd, DateTime minAut, DateTime maxAut, int count)
        {
            var filterANDsorting = db.person
                .Where(Z => Z.Status == "Менеджер")
                .Where(u => u.FIO.StartsWith(filtering.FIO) || filtering.FIO == null)
                .Where(o => o.phoneSmart == filtering.phoneSmart || filtering.phoneSmart == 0)
                .Where(o => o.phoneStac == filtering.phoneStac || filtering.phoneStac == 0)
                .Where(v => v.DateOfRegistrarion == filtering.DateOfRegistrarion || filtering.DateOfRegistrarion == null)
                .Where(v => v.DateLastAutorization == filtering.DateLastAutorization || filtering.DateLastAutorization == null)
                .Where(b => b.DateOfRegistrarion <= minAdd || minAdd == DateTime.MinValue)
                .Where(m => m.DateOfRegistrarion >= maxAdd || maxAdd == DateTime.MinValue)
                .Where(b => b.DateLastAutorization <= minAut || minAut == DateTime.MinValue)
                .Where(m => m.DateLastAutorization >= maxAut || maxAut == DateTime.MinValue)
                .OrderByDescending(i => i.DateAdd)
                .Take(count);
            return filterANDsorting.Count();
        }
        public List<person> GetListManager(string sorting, string sortingA, person filtering, DateTime minAdd, DateTime maxAdd, DateTime minAut, DateTime maxAut, int count, int page)
        {
            try
            {
                if (sortingA == "Возрастание")
                {
                    List<person> masters = db.person
                    .Where(Z => Z.Status == "Менеджер")
                    .Where(o => o.phoneSmart == filtering.phoneSmart || filtering.phoneSmart == 0)
                    .Where(o => o.phoneStac == filtering.phoneStac || filtering.phoneStac == 0)
                    .Where(v => v.DateOfRegistrarion == filtering.DateOfRegistrarion || filtering.DateOfRegistrarion == DateTime.MinValue)
                    .Where(v => v.DateLastAutorization == filtering.DateLastAutorization || filtering.DateLastAutorization == DateTime.MinValue)
                    .Where(b => b.DateOfRegistrarion <= minAdd || minAdd == DateTime.MinValue)
                    .Where(m => m.DateOfRegistrarion >= maxAdd || maxAdd == DateTime.MinValue)
                    .Where(b => b.DateLastAutorization <= minAut || minAut == DateTime.MinValue)
                    .Where(m => m.DateLastAutorization >= maxAut || maxAut == DateTime.MinValue)
                    .Include(z => z.RepairsReferenceBook)
                    .Include(v => v.Repairs)
                    .Include(p => p.Machine)
                    .ToList();

                    List<person> Clietns2 = masters
                            .Where(u => u.FIO.StartsWith(filtering.FIO) || filtering.FIO == "")
                            .OrderBy(sorting)
                            .Skip((count * (page - 1)))
                            .Take(count)
                            .ToList();
                    return Clietns2;
                }
                if (sortingA == "Убывание")
                {
                    List<person> masters = db.person
                    .Where(Z => Z.Status == "Менеджер")
                    .Where(o => o.phoneSmart == filtering.phoneSmart || filtering.phoneSmart == 0)
                    .Where(o => o.phoneStac == filtering.phoneStac || filtering.phoneStac == 0)
                    .Where(v => v.DateOfRegistrarion == filtering.DateOfRegistrarion || filtering.DateOfRegistrarion == DateTime.MinValue)
                    .Where(v => v.DateLastAutorization == filtering.DateLastAutorization || filtering.DateLastAutorization == DateTime.MinValue)
                    .Where(b => b.DateOfRegistrarion <= minAdd || minAdd == DateTime.MinValue)
                    .Where(m => m.DateOfRegistrarion >= maxAdd || maxAdd == DateTime.MinValue)
                    .Where(b => b.DateLastAutorization <= minAut || minAut == DateTime.MinValue)
                    .Where(m => m.DateLastAutorization >= maxAut || maxAut == DateTime.MinValue)
                    .Include(z => z.RepairsReferenceBook)
                    .Include(v => v.Repairs)
                    .Include(p => p.Machine)
                    .ToList();

                    List<person> Clietns2 = masters
                            .Where(u => u.FIO.StartsWith(filtering.FIO) || filtering.FIO == "")
                            .OrderByDescending(sorting)
                            .Skip((count * (page - 1)))
                            .Take(count)
                            .ToList();
                    return Clietns2;
                }
                if (sorting == null)
                {
                    List<person> masters = db.person
                        .Where(o => o.phoneSmart == filtering.phoneSmart || filtering.phoneSmart == 0)
                        .Where(o => o.phoneStac == filtering.phoneStac || filtering.phoneStac == 0)
                        .ToList();
                    return masters;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public int GetMaxIDManager()
        {
            try
            {
                var Poi = db.person
                    .Where(o => o.Status == "Менеджер")
                    .Max(p => p.ID);
                return Poi;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public bool SaveManager(person manager)
        {
            try
            {
                var editorsPerson = db.person
                                       .Where(c => c.ID == manager.ID)
                                       .FirstOrDefault();
                if (manager.FIO != null)
                    editorsPerson.FIO = manager.FIO;
                if (manager.phoneSmart != 0 || manager.phoneSmart != 0)
                    editorsPerson.phoneSmart = manager.phoneSmart;
                if (manager.phoneStac != 0 || manager.phoneStac != 0)
                    editorsPerson.phoneStac = manager.phoneStac;
                if (manager.AccesCode != null)
                    editorsPerson.AccesCode = manager.AccesCode;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DelManager(int id)
        {
            try
            {
                var editorsPerson = db.person
                                       .Where(c => c.ID == id)
                                       .Include(b=>b.Repairs)
                                       .Include(v => v.Machine)
                                       .Include(n => n.RepairsReferenceBook)
                                       .FirstOrDefault();
                db.person.Remove(editorsPerson);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
