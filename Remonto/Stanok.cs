using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SQLite;

namespace Labo4ka7
{
    class Stanok
    {
        Model1 db = new Model1();
        public List<Machine> GetListMachine(string sorting, string sortingA, Machine filtering, DateTime MinDate, DateTime MaxDate,DateTime MinYear,DateTime MaxYear, int count, int page, bool uslovie)
        {
            if (sorting == "ID" && sortingA == "Возрастание")
            {
                if (uslovie == true)
                {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = db.Machine
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .Where(u => u.MachineId == filtering.MachineId || filtering.MachineId == 0)
                                           .Include(p => p.MachineReferenceBook)
                                           .Include(i => i.Repairs)
                                           .Include(p => p.person)
                                           .OrderBy(i => i.ID)
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;
                }
                else
                {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = db.Machine
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .OrderBy(i => i.ID)
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;
                }
            }
            if (sorting == "ID" && sortingA == "Убывание")
            {
                if (uslovie == true)
                {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = db.Machine
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .Where(u => u.MachineId == filtering.MachineId || filtering.MachineId == 0)
                                           .Include(p => p.MachineReferenceBook)
                                           .Include(i => i.Repairs)
                                           .Include(p => p.person)
                                           .OrderByDescending(i => i.ID)
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;
                }
                else
                {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = db.Machine
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .OrderByDescending(i => i.ID)
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;
                }
            }
            if (sorting == "Год выпуска" && sortingA == "Возрастание")
            {
                if (uslovie == true)
                {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = db.Machine
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .Where(u => u.MachineId == filtering.MachineId || filtering.MachineId == 0)
                                           .Include(p => p.MachineReferenceBook)
                                           .Include(i => i.Repairs)
                                           .Include(p => p.person)
                                           .OrderBy(i => i.YerOfIssue)
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;
                }
                else
                {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = db.Machine
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .OrderBy(i => i.YerOfIssue)
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;
                }
            }
            if (sorting == "Год выпуска" && sortingA == "Убывание")
            {
                if (uslovie == true)
                {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = db.Machine
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .Where(u => u.MachineId == filtering.MachineId || filtering.MachineId == 0)
                                           .Include(p => p.MachineReferenceBook)
                                           .Include(i => i.Repairs)
                                           .Include(p => p.person)
                                           .OrderByDescending(i => i.YerOfIssue)
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;
                }
                else
                {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = db.Machine
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .OrderByDescending(i => i.YerOfIssue)
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;
                }
            }
            if (sorting == "Клиент" && sortingA == "Возрастание")
            {
                if (uslovie == true)
                {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = db.Machine
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .Where(u => u.MachineId == filtering.MachineId || filtering.MachineId == 0)
                                           .Include(p => p.MachineReferenceBook)
                                           .Include(i => i.Repairs)
                                           .Include(p => p.person)
                                           .OrderBy(i => i.person.Where(m=>m.Status == "Клиент"))
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;
                }
                else
                {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = db.Machine
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .OrderBy(i => i.person.Where(m => m.Status == "Клиент"))
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;
                }
            }
            if (sorting == "Клиент" && sortingA == "Убывание")
            {
                if (uslovie == true)
                {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = db.Machine
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .Where(u => u.MachineId == filtering.MachineId || filtering.MachineId == 0)
                                           .Include(p => p.MachineReferenceBook)
                                           .Include(i => i.Repairs)
                                           .Include(p => p.person)
                                           .OrderByDescending(i => i.person.Where(m => m.Status == "Клиент"))
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;
                }
                else
                {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = db.Machine
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .OrderByDescending(i => i.person.Where(m => m.Status == "Клиент"))
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;
                }
            }
            if (sorting == "Дата добавления" && sortingA == "Возрастание")
            {
                if (uslovie == true)
                {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = db.Machine
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .Where(u => u.MachineId == filtering.MachineId || filtering.MachineId == 0)
                                           .Include(p => p.MachineReferenceBook)
                                           .Include(i => i.Repairs)
                                           .Include(p => p.person)
                                           .OrderBy(i => i.UploadDate)
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;
                }
                else
                {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = db.Machine
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .OrderBy(i => i.UploadDate)
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;
                }
            }
            if (sorting == "Дата добавления" && sortingA == "Убывание")
            {
                if (uslovie == true)
                {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = db.Machine
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .Where(u => u.MachineId == filtering.MachineId || filtering.MachineId == 0)
                                           .Include(p => p.MachineReferenceBook)
                                           .Include(i => i.Repairs)
                                           .Include(p => p.person)
                                           .OrderByDescending(i => i.UploadDate)
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;
                }
                else
                {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = db.Machine
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .OrderByDescending(i => i.UploadDate)
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;
                }
            }
            if (sorting == "Менеджер" && sortingA == "Возрастание")
            {
                if (uslovie == true)
                {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = db.Machine
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .Where(u => u.MachineId == filtering.MachineId || filtering.MachineId == 0)
                                           .Include(p => p.MachineReferenceBook)
                                           .Include(i => i.Repairs)
                                           .Include(p => p.person)
                                           .OrderBy(i => i.person.Where(m=>m.Status == "Менеджер"))
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;
                }
                else
                {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = db.Machine
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .OrderBy(i => i.person.Where(m => m.Status == "Менеджер"))
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;
                }
            }
            if (sorting == "Менеджер" && sortingA == "Убывание")
            {
                if (uslovie == true)
                {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = db.Machine
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .Where(u => u.MachineId == filtering.MachineId || filtering.MachineId == 0)
                                           .Include(p => p.MachineReferenceBook)
                                           .Include(i => i.Repairs)
                                           .Include(p => p.person)
                                           .OrderByDescending(i => i.person.Where(m => m.Status == "Менеджер"))
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;
                }
                else
                {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = db.Machine
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .OrderByDescending(i => i.person.Where(m => m.Status == "Менеджер"))
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;
                }
            }
            return null;
        }
        public int GetKolvoMachine (string sorting, string sortingA, Machine filtering, DateTime MinDate, DateTime MaxDate, int count, int page, bool uslovie)
        {
            if (uslovie == true)
            {
                var filterANDsorting = db.Machine
                                                   .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                                   .Where(o => o.YerOfIssue == filtering.YerOfIssue || filtering.YerOfIssue == DateTime.MinValue)
                                                   .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                                   .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                                   .Include(p => p.MachineReferenceBook)
                                                   .Include(i => i.Repairs)
                                                   .Include(p => p.person)
                                                   .OrderByDescending(i => i.UploadDate)
                                                   .Skip((count * (page - 1)))
                                                   .Take(count);
                return filterANDsorting.Count();
            }
            else
            {
                var filterANDsorting = db.Machine
                                                   .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                                   .Where(o => o.YerOfIssue == filtering.YerOfIssue || filtering.YerOfIssue == DateTime.MinValue)
                                                   .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                                   .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                                   .OrderByDescending(i => i.UploadDate)
                                                   .Skip((count * (page - 1)))
                                                   .Take(count);
                return filterANDsorting.Count();
            }
        }
        public List <Machine> GetListMachineClient (string sorting, string sortingA, Machine filtering, DateTime MinDate, DateTime MaxDate, DateTime MinYear, DateTime MaxYear, int count, int page, person client, person master)
        {
            List<Machine> AllMac = new List<Machine>();
            if (master != null && client != null)
            {
                List<person> ForMacMaster = new List<person>();
                ForMacMaster.AddRange(db.person
                .Where(z => z.Status == "Менеджер")
                .Include(m => m.Machine.Select(o => o.person))
                .Include(m => m.Machine.Select(o => o.MachineReferenceBook))
                .ToList());

                ForMacMaster = ForMacMaster.Where(m => m.FIO.StartsWith(master.FIO)).ToList();
                List<Machine> AllMacMaster = new List<Machine>();
                foreach (person p in ForMacMaster)
                {
                    AllMacMaster.AddRange(p.Machine.ToList());
                }
                AllMacMaster = AllMacMaster
                    .Distinct()
                    .ToList();

                List<person> ForMacClient = new List<person>();
                ForMacClient.AddRange(db.person
                .Where(z => z.Status == "Клиент")
                .Include(m => m.Machine.Select(o => o.person))
                .Include(m => m.Machine.Select(o => o.MachineReferenceBook))
                .ToList());

                ForMacClient = ForMacClient.Where(m => m.FIO.StartsWith(client.FIO)).ToList();

                List<Machine> AllMacClient = new List<Machine>();
                foreach (person p in ForMacClient)
                {
                    AllMacClient.AddRange(p.Machine.ToList());
                }
                AllMacClient = AllMacClient
                    .Distinct()
                    .ToList();
                AllMac = AllMacClient.Intersect(AllMacMaster).ToList();
            }
            if (master != null && client == null)
            {
                List<person> ForMacMaster = new List<person>();
                ForMacMaster.AddRange(db.person
                .Where(z => z.Status == "Менеджер")
                .Include(m => m.Machine.Select(o => o.person))
                .Include(m => m.Machine.Select(o => o.MachineReferenceBook))
                .ToList());

                ForMacMaster = ForMacMaster.Where(m => m.FIO.StartsWith(master.FIO)).ToList();

                List<Machine> AllMacMaster = new List<Machine>();
                foreach (person p in ForMacMaster)
                {
                    AllMacMaster.AddRange(p.Machine.ToList());
                }
                AllMacMaster = AllMacMaster
                    .Distinct()
                    .ToList();          
                AllMac = AllMacMaster;
            }
            if (master == null && client != null)
            {
                List<person> ForMacClient = new List<person>();
                ForMacClient.AddRange(db.person
                .Where(m => m.FIO.StartsWith(client.FIO))
                .Where(z => z.Status == "Клиент")
                .Include(m => m.Machine.Select(o => o.person))
                .Include(m => m.Machine.Select(o => o.MachineReferenceBook))
                .ToList());

                ForMacClient = ForMacClient.Where(m => m.FIO.StartsWith(client.FIO)).ToList();

                List<Machine> AllMacClient = new List<Machine>();
                foreach (person p in ForMacClient)
                {
                    AllMacClient.AddRange(p.Machine.ToList());
                }
                AllMacClient = AllMacClient
                    .Distinct()
                    .ToList();
                AllMac = AllMacClient;
            }
            if (sorting == "ID" && sortingA == "Возрастание")
            {                              
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = AllMac
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .OrderBy(i => i.ID)
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;               
            }
            if (sorting == "ID" && sortingA == "Убывание")
            {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = AllMac
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .OrderByDescending(i => i.ID)
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;       
            }
            if (sorting == "Год выпуска" && sortingA == "Возрастание")
            {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = AllMac
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .OrderBy(i => i.YerOfIssue)
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;               
            }
            if (sorting == "Год выпуска" && sortingA == "Убывание")
            {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = AllMac
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .OrderByDescending(i => i.YerOfIssue)
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;
            }
            if (sorting == "Клиент" && sortingA == "Возрастание")
            {              
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = AllMac
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .OrderBy(i => i.person.Where(m => m.Status == "Клиент"))
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;
            }
            if (sorting == "Клиент" && sortingA == "Убывание")
            {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = AllMac
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .OrderByDescending(i => i.person.Where(m => m.Status == "Клиент"))
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;                
            }
            if (sorting == "Дата добавления" && sortingA == "Возрастание")
            {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = AllMac
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .OrderBy(i => i.UploadDate)
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;              
            }
            if (sorting == "Дата добавления" && sortingA == "Убывание")
            {               
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = AllMac
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .OrderByDescending(i => i.UploadDate)
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;                
            }
            if (sorting == "Менеджер" && sortingA == "Возрастание")
            {              
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = AllMac
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .OrderBy(i => i.person.Where(m => m.Status == "Менеджер"))
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;               
            }
            if (sorting == "Менеджер" && sortingA == "Убывание")
            {
                    List<Machine> GetListMachine = new List<Machine>();
                    GetListMachine = AllMac
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(o => o.YerOfIssue >= MinYear || MinYear == DateTime.MinValue)
                                           .Where(o => o.YerOfIssue <= MaxYear || MaxYear == DateTime.MinValue)
                                           .Where(o => o.UploadDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(i => i.UploadDate >= MinDate || MinDate == DateTime.MinValue)
                                           .OrderByDescending(i => i.person.Where(m => m.Status == "Менеджер"))
                                           .Skip((count * (page - 1)))
                                           .Take(count)
                                           .ToList();
                    return GetListMachine;
            }
            return null;
        }
        public Machine FindByIdmac(int ID, bool uslovie)
        {
            if (uslovie == true)
            {
                var FindCLient = db.Machine
                                           .Where(c => c.ID == ID)
                                           .Include(c => c.MachineReferenceBook)
                                           .Include(p => p.person)
                                           .Include(v => v.Repairs)
                                           .FirstOrDefault();
                Machine r = new Machine();
                r = FindCLient;
                return r;
            }
            else if(uslovie == false)
            {
                var FindCLient = db.Machine
                                           .Where(c => c.ID == ID)
                                           .FirstOrDefault();
                Machine r = new Machine();
                r = FindCLient;
                return r;
            }
            return null;
        }
        public bool addMachine(Machine mach, person manager, person client)
        {
            try
            {
                var Manager = db.person
                    .Where(z => z.ID == manager.ID)
                    .Where(x => x.Status == "Менеджер")
                    .FirstOrDefault();
                var Client = db.person
                    .Where(c => c.ID == client.ID)
                    .Where(x => x.Status == "Клиент")
                    .FirstOrDefault();
                mach.person.Add(Manager);
                mach.person.Add(Client);
                mach.UploadDate = DateTime.Now;
                db.Machine.Add(mach);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DellMachine(int id)

        { try
            {
                var result = db.Machine
                    .Where(z => z.ID == id)
                    .Include(b => b.Repairs)
                    .Include(z => z.person)
                    .Include(b => b.MachineReferenceBook)
                    .FirstOrDefault();
                db.Repairs.RemoveRange(result.Repairs);
                db.Machine.Remove(result);
                db.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
            
        }
        public int GetMaxIDMachine()
        {
            try
            {
                var Poi = db.Machine
                    .Max(p => p.ID);
                return Poi;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public bool SaveMachine(Machine mac)
        {
            var editor = db.Machine
                                   .Where(c => c.ID == mac.ID)
                                   .FirstOrDefault();
            if (mac.YerOfIssue != DateTime.MinValue && mac.YerOfIssue != null)
                editor.YerOfIssue = mac.YerOfIssue;
            if(mac.MachineId != 0)
            editor.MachineId = mac.MachineId;
            db.SaveChanges();
            return true;
        }
    }
}
