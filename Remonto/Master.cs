using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SQLite;

namespace Labo4ka7
{
    class Master
    {
        Model1 db = new Model1();
        public bool addMaster(person master)
        {
            try
            {
                master.Status = "Мастер";
                master.DateAdd = DateTime.Now;
                master.DateLastAutorization = DateTime.Now.Date;
                master.DateOfRegistrarion = DateTime.Now.Date;
                db.person.Add(master);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public person FindByIdMaster(int ID)
        {
            try
            { 
                 person per = db.person
                    .Where(z => z.Status == "Мастер")
                    .Where(u => u.ID == ID)
                    .Include(z => z.MachineReferenceBooks)
                    .Include(v => v.Repairs)
                    .FirstOrDefault();
                return per;
            }
            catch (Exception)
            {          
                return null;
            }
        }
        public int GetKolvoMaster(string sorting, bool sortingA, person filtering, DateTime minAdd, DateTime maxAdd, DateTime minAut, DateTime maxAut, int count)
        {
            var filterANDsorting = db.person
                .Where(Z => Z.Status == "Мастер")
                .Where(u => u.FIO.StartsWith(filtering.FIO) || filtering.FIO == "")
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
        public List<person> GetListMaster(string sorting, string sortingA, person filtering, DateTime minAdd, DateTime maxAdd, DateTime minAut, DateTime maxAut, int count, int page)
        {
            try
            {
                if (sortingA == "Возрастание")
                {
                    List<person> masters = db.person
                    .Where(Z => Z.Status == "Мастер")
                    .Where(o => o.phoneSmart == filtering.phoneSmart || filtering.phoneSmart == 0)
                    .Where(o => o.phoneStac == filtering.phoneStac || filtering.phoneStac == 0)
                    .Where(v => v.DateOfRegistrarion == filtering.DateOfRegistrarion || filtering.DateOfRegistrarion == DateTime.MinValue)
                    .Where(v => v.DateLastAutorization == filtering.DateLastAutorization || filtering.DateLastAutorization == DateTime.MinValue)
                    .Where(b => b.DateOfRegistrarion <= minAdd || minAdd == DateTime.MinValue)
                    .Where(m => m.DateOfRegistrarion >= maxAdd || maxAdd == DateTime.MinValue)
                    .Where(b => b.DateLastAutorization <= minAut || minAut == DateTime.MinValue)
                    .Where(m => m.DateLastAutorization >= maxAut || maxAut == DateTime.MinValue)
                    .Include(z => z.MachineReferenceBooks)
                    .Include(v => v.Repairs)
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
                   .Where(Z => Z.Status == "Мастер")
                   .Where(o => o.phoneSmart == filtering.phoneSmart || filtering.phoneSmart == 0)
                   .Where(o => o.phoneStac == filtering.phoneStac || filtering.phoneStac == 0)
                   .Where(v => v.DateOfRegistrarion == filtering.DateOfRegistrarion || filtering.DateOfRegistrarion == DateTime.MinValue)
                   .Where(v => v.DateLastAutorization == filtering.DateLastAutorization || filtering.DateLastAutorization == DateTime.MinValue)
                   .Where(b => b.DateOfRegistrarion <= minAdd || minAdd == DateTime.MinValue)
                   .Where(m => m.DateOfRegistrarion >= maxAdd || maxAdd == DateTime.MinValue)
                   .Where(b => b.DateLastAutorization <= minAut || minAut == DateTime.MinValue)
                   .Where(m => m.DateLastAutorization >= maxAut || maxAut == DateTime.MinValue)
                   .Include(z => z.MachineReferenceBooks)
                   .Include(v => v.Repairs)
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
        public int GetMaxIDMaster()
        {
            try
            {
                var Poi = db.person
                    .Where(o=> o.Status == "Мастер")
                    .Max(p => p.ID);
                return Poi;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public bool SaveMaster(person master)
        {
            try
            {
                var editorsPerson = db.person
                                       .Where(c => c.ID == master.ID)
                                       .FirstOrDefault();
                if (master.FIO != null)
                    editorsPerson.FIO = master.FIO;
                if (master.phoneSmart != 0 || master.phoneSmart != 0)
                    editorsPerson.phoneSmart = master.phoneSmart;
                if (master.phoneStac != 0 || master.phoneStac != 0)
                    editorsPerson.phoneStac = master.phoneStac;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DelMaster(int id)
        {
            try
            {
                var editorsPerson = db.person
                                       .Where(c => c.ID == id)
                                       .Include(c=>c.Repairs)
                                       .Include(t=>t.MachineReferenceBooks)
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
