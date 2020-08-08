using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SQLite;

namespace Labo4ka7
{
    class Stanki
    {
        Model1 db = new Model1();
        public bool addStanok(MachineReferenceBook stanok, person master)
        {
            try
            {
                db.person.Attach(master);
                stanok.person.Add(master);
                db.MachineReferenceBooks.Add(stanok);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public MachineReferenceBook FindByIdStanok(int ID)
        {
            try
            {
                MachineReferenceBook MacStan = db.MachineReferenceBooks
                    .Where(u => u.ID == ID)
                    .Include(v => v.person)
                    .FirstOrDefault();
                return MacStan;
            }
            catch (Exception)
            {
                return new MachineReferenceBook { };
            }
        }
        public int GetKolvoStankov(string sorting, bool sortingA, MachineReferenceBook filtering, int count)
        {
            var filterANDsorting = db.MachineReferenceBooks
                .Where(o => o.Country.StartsWith(filtering.Country) || filtering.Country == null)
                .Where(z => z.Mark.StartsWith(filtering.Mark) || filtering.Mark == null)
                .Where(i => i.Name.StartsWith(filtering.Name) || filtering.Name == null)
                .OrderByDescending(i => i.ID)
                .Take(count);
            return filterANDsorting.Count();
        }
        public List<MachineReferenceBook> GetListStankov(string sorting, string sortingA, MachineReferenceBook filtering2,DateTime MaxDate, DateTime MinDate, int count, int page)
        {
            try
            {
                MachineReferenceBook filtering = new MachineReferenceBook();
                if (filtering2 != null)
                {
                    filtering = filtering2;
                }

                if (filtering.Country == null)
                    filtering.Country = "";

                if (filtering.Name == null)
                    filtering.Name = "";

                if (filtering.Mark == null)
                    filtering.Mark = "";

                if (sortingA == "Возрастание")
                {
                    List<MachineReferenceBook> stanki = db.MachineReferenceBooks
                            .Where(m => m.DateAdd <= MaxDate)
                            .Where(m => m.DateAdd >= MinDate)
                            .Include(v => v.person)
                            .ToList();

                    stanki = stanki.Where(o => o.Country.StartsWith(filtering.Country) || filtering.Country == "")
                           .Where(z => z.Mark.StartsWith(filtering.Mark) || filtering.Mark == "")
                           .Where(i => i.Name.StartsWith(filtering.Name) || filtering.Name == "")
                           .OrderBy(sorting)
                           .Skip((count * (page - 1)))
                           .Take(count)
                           .ToList();

                    return stanki;
                }
                if (sortingA == "Убывание")
                {
                    List<MachineReferenceBook> stanki = db.MachineReferenceBooks
                            .Where(m => m.DateAdd <= MaxDate)
                            .Where(m => m.DateAdd >= MinDate)
                            .Include(v => v.person)
                            .ToList();

                    stanki = stanki.Where(o => o.Country.StartsWith(filtering.Country) || filtering.Country == "")
                           .Where(z => z.Mark.StartsWith(filtering.Mark) || filtering.Mark == "")
                           .Where(i => i.Name.StartsWith(filtering.Name) || filtering.Name == "")
                           .OrderByDescending(sorting)
                           .Skip((count * (page - 1)))
                           .Take(count)
                           .ToList();

                    return stanki;
                }
                return null;
            }
            catch (Exception)
            {
                return new List<MachineReferenceBook> { };
            }

        }
        public List<MachineReferenceBook> GetListStankovMaster(string sorting, string sortingA, MachineReferenceBook filtering2,DateTime MaxDate, DateTime MinDate, int count, int page, person master2)
        {
            try
            {
                MachineReferenceBook filtering = new MachineReferenceBook();
                if(filtering2 != null)
                {
                    filtering = filtering2;
                }

                if (filtering.Country == null)
                    filtering.Country = "";

                if (filtering.Name == null)
                    filtering.Name = "";

                if (filtering.Mark == null)
                    filtering.Mark = "";

                person master = new person();
                if(master2 != null )
                {
                    master = master2;
                }
                if (master.FIO == null)
                    master.FIO = "";

                List<person> Master = db.person
                    .Include(z => z.MachineReferenceBooks)
                    .ToList();

                Master = Master.Where(m => m.FIO.StartsWith(master.FIO))
                    .ToList();

                List<MachineReferenceBook> AllMac = new List<MachineReferenceBook>();
                foreach (person z in Master)
                {
                    AllMac.AddRange(z.MachineReferenceBooks.ToList());
                }
                AllMac = AllMac.Distinct().ToList();
                if (filtering.Country == null)
                    filtering.Country = "";
                if (filtering.Mark == null)
                    filtering.Mark = "";
                if (filtering.Name == null)
                    filtering.Name = "";

                    List<MachineReferenceBook> stanki = AllMac
                            .Where(m => m.DateAdd <= MaxDate)
                            .Where(m => m.DateAdd >= MinDate)
                            .ToList();

                stanki = stanki.Where(o => o.Country.StartsWith(filtering.Country) || filtering.Country == "")
                            .Where(z => z.Mark.StartsWith(filtering.Mark) || filtering.Mark == "")
                            .Where(i => i.Name.StartsWith(filtering.Name) || filtering.Name == "")
                            .OrderBy(sorting)
                            .Skip((count * (page - 1)))
                            .Take(count)
                            .ToList();

                    return stanki;             
            }
            catch(Exception)
            {
                return null;
            }
        }
        public int GetMaxIDStanok()
        {
            try
            {
                var Poi = db.MachineReferenceBooks
                    .Max(p => p.ID);
                return Poi;
            }
            catch (Exception)
            {          
                return 0;
            }
        }
        public bool SaveStanok(MachineReferenceBook stanok)
        {
            try
            {
                var editorsStanok = db.MachineReferenceBooks
                                       .Where(c => c.ID == stanok.ID)
                                       .FirstOrDefault();
                if (stanok.Country != null)
                    editorsStanok.Country = stanok.Country;
                if (stanok.Mark != null)
                    editorsStanok.Mark = stanok.Mark;
                if (stanok.Name != null)
                    editorsStanok.Name = stanok.Name;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DelStanok(int id)
        {
            try
            {
                var editorsStanok = db.MachineReferenceBooks
                                       .Where(c => c.ID == id)
                                       .FirstOrDefault();
                db.MachineReferenceBooks.Remove(editorsStanok);
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
