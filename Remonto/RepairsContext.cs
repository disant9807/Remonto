using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SQLite;

namespace Labo4ka7
{
    class RepairsContext
    {
        Model1 db = new Model1();
        public List<Repairs> GetListRepairs(string sorting, string sortingA, Repairs filtering, DateTime MinDate, DateTime MaxDate, DateTime EndMax, DateTime EndMin, DateTime StartDateMax, DateTime StartDateMin,int MaxOplata, int MinOplata, int MaxPaid, int MinPaid, int count, int page, bool uslovie)
        {
            if (sorting == "ID" && sortingA == "Возрастание")
            {
                List<Repairs> GetListRepairs = new List<Repairs>();
                if (uslovie == true)
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where (z=>z.paid <= MaxPaid)
                        .Where (c=>c.paid >= MinPaid)
                        .Where (n=>n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .Include(p => p.person)
                        .Include(m => m.RepairsReferenceBook)
                        .Include(z => z.Machine)
                        .OrderBy(i => i.ID)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                else
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderBy(i => i.ID)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
            }
            if (sorting == "ID" && sortingA == "Убывание")
            {
                List<Repairs> GetListRepairs = new List<Repairs>();
                if (uslovie == true)
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                         .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .Include(p => p.person)
                        .Include(m => m.RepairsReferenceBook)
                        .Include(z => z.Machine)
                        .OrderByDescending(i => i.ID)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                else
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderByDescending(i => i.ID)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
            }
            if (sorting == "Дата добавления" && sortingA == "Возрастание")
            {
                List<Repairs> GetListRepairs = new List<Repairs>();
                if (uslovie == true)
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                         .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .Include(p => p.person)
                        .Include(m => m.RepairsReferenceBook)
                        .Include(z => z.Machine)
                        .OrderBy(i => i.AddDate)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                else
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                         .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderBy(i => i.AddDate)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
            }
            if (sorting == "Дата добавления" && sortingA == "Убывание")
            {
                List<Repairs> GetListRepairs = new List<Repairs>();
                if (uslovie == true)
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == null)
                       .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                         .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .Include(p => p.person)
                        .Include(m => m.RepairsReferenceBook)
                        .Include(z => z.Machine)
                        .OrderByDescending(i => i.ID)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                else
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                         .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderByDescending(i => i.ID)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
            }
            if (sorting == "Дата начала" && sortingA == "Возрастание")
            {
                List<Repairs> GetListRepairs = new List<Repairs>();
                if (uslovie == true)
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                         .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .Include(p => p.person)
                        .Include(m => m.RepairsReferenceBook)
                        .Include(z => z.Machine)
                        .OrderBy(i => i.StartDate)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                else
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderBy(i => i.StartDate)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
            }
            if (sorting == "Дата начала" && sortingA == "Убывание")
            {
                List<Repairs> GetListRepairs = new List<Repairs>();
                if (uslovie == true)
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .Include(p => p.person)
                        .Include(m => m.RepairsReferenceBook)
                        .Include(z => z.Machine)
                        .OrderByDescending(i => i.StartDate)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                else
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderByDescending(i => i.StartDate)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
            }
            if (sorting == "Цена" && sortingA == "Возрастание")
            {
                List<Repairs> GetListRepairs = new List<Repairs>();
                if (uslovie == true)
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                         .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .Include(p => p.person)
                        .Include(m => m.RepairsReferenceBook)
                        .Include(z => z.Machine)
                        .OrderBy(i => i.price)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                else
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                         .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderBy(i => i.StartDate)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
            }
            if (sorting == "Цена" && sortingA == "Убывание")
            {
                List<Repairs> GetListRepairs = new List<Repairs>();
                if (uslovie == true)
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                         .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .Include(p => p.person)
                        .Include(m => m.RepairsReferenceBook)
                        .Include(z => z.Machine)
                        .OrderByDescending(i => i.price)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                else
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                         .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderByDescending(i => i.price)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
            }
            if (sorting == "Дополнительная информация" && sortingA == "Возрастание")
            {
                List<Repairs> GetListRepairs = new List<Repairs>();
                if (uslovie == true)
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                         .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .Include(p => p.person)
                        .Include(m => m.RepairsReferenceBook)
                        .Include(z => z.Machine)
                        .OrderBy(i => i.AdditionalInformation)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                else
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                         .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderBy(i => i.AdditionalInformation)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
            }
            if (sorting == "Дополнительная информация" && sortingA == "Убывание")
            {
                List<Repairs> GetListRepairs = new List<Repairs>();
                if (uslovie == true)
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                         .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .Include(p => p.person)
                        .Include(m => m.RepairsReferenceBook)
                        .Include(z => z.Machine)
                        .OrderByDescending(i => i.AdditionalInformation)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                else
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                         .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderByDescending(i => i.AdditionalInformation)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
            }
            if (sorting == "Характер поломки" && sortingA == "Возрастание")
            {
                List<Repairs> GetListRepairs = new List<Repairs>();
                if (uslovie == true)
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                         .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .Include(p => p.person)
                        .Include(m => m.RepairsReferenceBook)
                        .Include(z => z.Machine)
                        .OrderBy(i => i.CharacterOfFailure)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                else
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                         .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderBy(i => i.CharacterOfFailure)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
            }
            if (sorting == "Характер поломки" && sortingA == "Убывание")
            {
                List<Repairs> GetListRepairs = new List<Repairs>();
                if (uslovie == true)
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                         .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .Include(p => p.person)
                        .Include(m => m.RepairsReferenceBook)
                        .Include(z => z.Machine)
                        .OrderByDescending(i => i.CharacterOfFailure)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                else
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                         .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderByDescending(i => i.CharacterOfFailure)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
            }
            if (sorting == "Дата окончания" && sortingA == "Возрастание")
            {
                List<Repairs> GetListRepairs = new List<Repairs>();
                if (uslovie == true)
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                         .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .Include(p => p.person)
                        .Include(m => m.RepairsReferenceBook)
                        .Include(z => z.Machine)
                        .OrderBy(i => i.EndDate)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                else
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderBy(i => i.EndDate)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
            }
            if (sorting == "Дата окончание" && sortingA == "Убывание")
            {
                List<Repairs> GetListRepairs = new List<Repairs>();
                if (uslovie == true)
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .Include(p => p.person)
                        .Include(m => m.RepairsReferenceBook)
                        .Include(z => z.Machine)
                        .OrderByDescending(i => i.EndDate)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                else
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderByDescending(i => i.EndDate)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
            }
            if (sorting == "Оплачено" && sortingA == "Возрастание")
            {
                List<Repairs> GetListRepairs = new List<Repairs>();
                if (uslovie == true)
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .Include(p => p.person)
                        .Include(m => m.RepairsReferenceBook)
                        .Include(z => z.Machine)
                        .OrderBy(i => i.paid)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                else
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderBy(i => i.paid)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
            }
            if (sorting == "Оплачено" && sortingA == "Убывание")
            {
                List<Repairs> GetListRepairs = new List<Repairs>();
                if (uslovie == true)
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .Include(p => p.person)
                        .Include(m => m.RepairsReferenceBook)
                        .Include(z => z.Machine)
                        .OrderByDescending(i => i.paid)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                else
                {
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == null)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderByDescending(i => i.paid)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
            }
            return null;
        }
        public List<Repairs> GetListRepairsPerson(string sorting, string sortingA, Repairs filtering, DateTime MinDate, DateTime MaxDate, DateTime EndMax, DateTime EndMin, DateTime StartDateMax, DateTime StartDateMin,int MaxOplata, int MinOplata, int MaxPaid, int MinPaid, int count, int page,person client, person manager, person master)
        {
            try
            {
                List<Repairs> RepFilt = new List<Repairs>();
                if (client != null && manager != null && master != null)
                {
                    List<person> AllClient = new List<person>();
                    AllClient.AddRange(db.person
                        .Where(m => m.FIO.StartsWith(client.FIO))
                        .Where(z => z.Status == "Клиент")
                        .Include(v => v.Repairs.Select(z => z.person))
                        .Include(v => v.Repairs.Select(z => z.Machine))
                        .ToList());
                    List<person> AllManager = new List<person>();
                    AllManager.AddRange(db.person
                            .Where(m => m.FIO.StartsWith(manager.FIO))
                            .Where(z => z.Status == "Менеджер")
                            .Include(v => v.Repairs.Select(z => z.person))
                            .Include(v => v.Repairs.Select(z => z.Machine))
                            .ToList());
                    List<person> AllMaster = new List<person>();
                    AllMaster.AddRange(db.person
                            .Where(m => m.FIO.StartsWith(master.FIO))
                            .Where(z => z.Status == "Мастер")
                            .Include(v => v.Repairs.Select(z => z.person))
                            .Include(v => v.Repairs.Select(z => z.Machine))
                            .ToList());

                    AllClient = AllClient.Where(m => m.FIO.StartsWith(client.FIO)).ToList();
                    AllMaster = AllMaster.Where(m => m.FIO.StartsWith(master.FIO)).ToList();
                    AllManager = AllManager.Where(m => m.FIO.StartsWith(manager.FIO)).ToList();
                    List<Repairs> RepClient = new List<Repairs>();
                    foreach (person p in AllClient)
                    {
                        RepClient.AddRange(p.Repairs);
                    }
                    RepClient = RepClient.Distinct().ToList();
                    List<Repairs> RepManager = new List<Repairs>();
                    foreach (person z in AllManager)
                    {
                        RepManager.AddRange(z.Repairs);
                    }
                    RepManager = RepManager.Distinct().ToList();
                    List<Repairs> RepMaster = new List<Repairs>();
                    foreach (person x in AllMaster)
                    {
                        RepMaster.AddRange(x.Repairs);
                    }
                    RepMaster = RepMaster.Distinct().ToList();
                    RepFilt = RepClient.Intersect(RepMaster).ToList();
                    RepFilt = RepFilt.Intersect(RepManager).ToList();
                }
                else if (client != null && manager != null && master == null)
                {
                    List<person> AllClient = new List<person>();
                    AllClient.AddRange(db.person
                        .Where(m => m.FIO.StartsWith(client.FIO))
                        .Where(z => z.Status == "Клиент")
                        .Include(v => v.Repairs.Select(z => z.person))
                        .Include(v => v.Repairs.Select(z => z.Machine))
                        .ToList());
                    List<person> AllManager = new List<person>();
                    AllManager.AddRange(db.person
                            .Where(m => m.FIO.StartsWith(manager.FIO))
                            .Where(z => z.Status == "Менеджер")
                            .Include(v => v.Repairs.Select(z => z.person))
                            .Include(v => v.Repairs.Select(z => z.Machine))
                            .ToList());

                    AllClient = AllClient.Where(m => m.FIO.StartsWith(client.FIO)).ToList();
                    AllManager = AllManager.Where(m => m.FIO.StartsWith(manager.FIO)).ToList();
                    List<Repairs> RepClient = new List<Repairs>();
                    foreach (person p in AllClient)
                    {
                        RepClient.AddRange(p.Repairs);
                    }
                    RepClient = RepClient.Distinct().ToList();
                    List<Repairs> RepManager = new List<Repairs>();
                    foreach (person z in AllManager)
                    {
                        RepManager.AddRange(z.Repairs);
                    }
                    RepManager = RepManager.Distinct().ToList();
                    RepFilt = RepClient.Intersect(RepManager).ToList();
                }
                else if (client != null && master != null && manager == null)
                {
                    List<person> AllClient = new List<person>();
                    AllClient.AddRange(db.person
                        .Where(m => m.FIO.StartsWith(client.FIO))
                        .Where(z => z.Status == "Клиент")
                        .Include(v => v.Repairs.Select(z => z.person))
                        .Include(v => v.Repairs.Select(z => z.Machine))
                        .ToList());
                    List<person> AllMaster = new List<person>();
                    AllMaster.AddRange(db.person
                            .Where(m => m.FIO.StartsWith(master.FIO))
                            .Where(z => z.Status == "Мастер")
                            .Include(v => v.Repairs.Select(z => z.person))
                            .Include(v => v.Repairs.Select(z => z.Machine))
                            .ToList());
                    List<Repairs> RepClient = new List<Repairs>();

                    AllClient = AllClient.Where(m => m.FIO.StartsWith(client.FIO)).ToList();
                    AllMaster = AllMaster.Where(m => m.FIO.StartsWith(master.FIO)).ToList();

                    foreach (person p in AllClient)
                    {
                        RepClient.AddRange(p.Repairs);
                    }
                    RepClient = RepClient.Distinct().ToList();
                    List<Repairs> RepMaster = new List<Repairs>();
                    foreach (person x in AllMaster)
                    {
                        RepMaster.AddRange(x.Repairs);
                    }
                    RepMaster = RepMaster.Distinct().ToList();
                    RepFilt = RepClient.Intersect(RepMaster).ToList();
                }
                else if (client == null && master != null && manager != null)
                {
                    List<person> AllManager = new List<person>();
                    AllManager.AddRange(db.person
                            .Where(m => m.FIO.StartsWith(manager.FIO))
                            .Where(z => z.Status == "Менеджер")
                            .Include(v => v.Repairs.Select(z => z.person))
                            .Include(v => v.Repairs.Select(z => z.Machine))
                            .ToList());
                    List<person> AllMaster = new List<person>();
                    AllMaster.AddRange(db.person
                            .Where(m => m.FIO.StartsWith(master.FIO))
                            .Where(z => z.Status == "Мастер")
                            .Include(v => v.Repairs.Select(z => z.person))
                            .Include(v => v.Repairs.Select(z => z.Machine))
                            .ToList());

                    AllMaster = AllMaster.Where(m => m.FIO.StartsWith(client.FIO)).ToList();
                    AllManager = AllManager.Where(m => m.FIO.StartsWith(manager.FIO)).ToList();

                    List<Repairs> RepManager = new List<Repairs>();
                    foreach (person z in AllManager)
                    {
                        RepManager.AddRange(z.Repairs);
                    }
                    RepManager = RepManager.Distinct().ToList();
                    List<Repairs> RepMaster = new List<Repairs>();
                    foreach (person x in AllMaster)
                    {
                        RepMaster.AddRange(x.Repairs);
                    }
                    RepMaster = RepMaster.Distinct().ToList();
                    RepFilt = RepMaster.Intersect(RepManager).ToList();
                }
                else if (client != null && master == null && manager == null)
                {
                    List<person> AllClient = new List<person>();
                    AllClient.AddRange(db.person
                        .Where(m => m.FIO.StartsWith(client.FIO))
                        .Where(z => z.Status == "Клиент")
                        .Include(v => v.Repairs.Select(z => z.person))
                        .Include(v => v.Repairs.Select(z => z.Machine))
                        .ToList());
                    AllClient = AllClient.Where(m => m.FIO.StartsWith(client.FIO)).ToList();
                    List<Repairs> RepClient = new List<Repairs>();
                    foreach (person p in AllClient)
                    {
                        RepClient.AddRange(p.Repairs);
                    }
                    RepClient = RepClient.Distinct().ToList();
                    RepFilt = RepClient;
                }
                else if (client == null && master != null && manager == null)
                {
                    List<person> AllMaster = new List<person>();
                    AllMaster.AddRange(db.person
                            .Where(m => m.FIO.StartsWith(master.FIO))
                            .Where(z => z.Status == "Мастер")
                            .Include(v => v.Repairs.Select(z => z.person))
                            .Include(v => v.Repairs.Select(z => z.Machine))
                            .ToList());
                    AllMaster = AllMaster.Where(m => m.FIO.StartsWith(master.FIO)).ToList();
                    List<Repairs> RepMaster = new List<Repairs>();
                    foreach (person x in AllMaster)
                    {
                        RepMaster.AddRange(x.Repairs);
                    }
                    RepMaster = RepMaster.Distinct().ToList();
                    RepFilt = RepMaster;
                }
                else if (client == null && master == null && manager != null)
                {
                    List<person> AllManager = new List<person>();
                    AllManager.AddRange(db.person
                            .Where(m => m.FIO.StartsWith(manager.FIO))
                            .Where(z => z.Status == "Менеджер")
                            .Include(v => v.Repairs.Select(z => z.person))
                            .Include(v => v.Repairs.Select(z => z.Machine))
                            .ToList());
                    AllManager = AllManager.Where(m => m.FIO.StartsWith(manager.FIO)).ToList();
                    List<Repairs> RepManager = new List<Repairs>();
                    foreach (person z in AllManager)
                    {
                        RepManager.AddRange(z.Repairs);
                    }
                    RepManager = RepManager.Distinct().ToList();
                    RepFilt = RepManager;
                }
                if (filtering.AdditionalInformation == null)
                    filtering.AdditionalInformation = "";
                if (filtering.CharacterOfFailure == null)
                    filtering.CharacterOfFailure = "";
                if (filtering.IDMachine == null)
                    filtering.IDMachine = 0;
                foreach(Repairs r in RepFilt)
                {
                    if (r.AdditionalInformation == null)
                        r.AdditionalInformation = "";
                    if (r.CharacterOfFailure == null)
                        r.CharacterOfFailure = "";
                }
                if (sorting == "ID" && sortingA == "Возрастание")
                {
                    List<Repairs> GetListRepairs = new List<Repairs>();

                    GetListRepairs = RepFilt
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == "")
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == "")
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == 0)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderBy(i => i.ID)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                if (sorting == "ID" && sortingA == "Убывание")
                {
                    List<Repairs> GetListRepairs = new List<Repairs>();

                    GetListRepairs = RepFilt
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == "")
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == "")
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == 0)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderByDescending(i => i.ID)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                if (sorting == "Дата добавления" && sortingA == "Возрастание")
                {
                    List<Repairs> GetListRepairs = new List<Repairs>();

                    GetListRepairs = RepFilt
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == "")
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == "")
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == 0)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderBy(i => i.AddDate)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                if (sorting == "Дата добавления" && sortingA == "Убывание")
                {
                    List<Repairs> GetListRepairs = new List<Repairs>();
                    GetListRepairs = RepFilt
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == "")
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == "")
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == 0)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderByDescending(i => i.ID)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                if (sorting == "Дата начала" && sortingA == "Возрастание")
                {
                    List<Repairs> GetListRepairs = new List<Repairs>();

                    GetListRepairs = RepFilt
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == "")
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == "")
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == 0)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderBy(i => i.StartDate)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                if (sorting == "Дата начала" && sortingA == "Убывание")
                {
                    List<Repairs> GetListRepairs = new List<Repairs>();

                    GetListRepairs = RepFilt
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == "")
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == "")
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == 0)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderByDescending(i => i.StartDate)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                if (sorting == "Цена" && sortingA == "Возрастание")
                {
                    List<Repairs> GetListRepairs = new List<Repairs>();
                    GetListRepairs = RepFilt
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == "")
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == "")
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == 0)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderBy(i => i.StartDate)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                if (sorting == "Цена" && sortingA == "Убывание")
                {
                    List<Repairs> GetListRepairs = new List<Repairs>();
                    GetListRepairs = RepFilt
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == "")
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == "")
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == 0)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderByDescending(i => i.price)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                if (sorting == "Дополнительная информация" && sortingA == "Возрастание")
                {
                    List<Repairs> GetListRepairs = new List<Repairs>();
                    GetListRepairs = RepFilt
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == "")
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == "")
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == 0)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderBy(i => i.AdditionalInformation)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                if (sorting == "Дополнительная информация" && sortingA == "Убывание")
                {
                    List<Repairs> GetListRepairs = new List<Repairs>();
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == "")
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == "")
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == 0)
                       .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderByDescending(i => i.AdditionalInformation)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                if (sorting == "Характер поломки" && sortingA == "Возрастание")
                {
                    List<Repairs> GetListRepairs = new List<Repairs>();
                    GetListRepairs = RepFilt
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == "")
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == "")
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == 0)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderBy(i => i.CharacterOfFailure)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                if (sorting == "Характер поломки" && sortingA == "Убывание")
                {
                    List<Repairs> GetListRepairs = new List<Repairs>();
                    GetListRepairs = RepFilt
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == "")
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == "")
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == 0)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderByDescending(i => i.CharacterOfFailure)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;

                }
                if (sorting == "Дата окончания" && sortingA == "Возрастание")
                {
                    List<Repairs> GetListRepairs = new List<Repairs>();
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == "")
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == "")
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == 0)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderBy(i => i.EndDate)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                if (sorting == "Дата окончание" && sortingA == "Убывание")
                {
                    List<Repairs> GetListRepairs = new List<Repairs>();
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == "")
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == "")
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == 0)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderByDescending(i => i.EndDate)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                if (sorting == "Оплачено" && sortingA == "Возрастание")
                {
                    List<Repairs> GetListRepairs = new List<Repairs>();
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == "")
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == "")
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == 0)
                        .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderBy(i => i.paid)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                if (sorting == "Оплачено" && sortingA == "Убывание")
                {
                    List<Repairs> GetListRepairs = new List<Repairs>();
                    GetListRepairs = db.Repairs
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == "")
                        .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == "")
                        .Where(p => p.EndDate <= EndMax || EndMax == DateTime.MinValue)
                        .Where(o => o.EndDate >= EndMin || EndMin == DateTime.MinValue)
                        .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0 || filtering.IDMachine == 0)
                       .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == false)
                        .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                        .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                        .OrderByDescending(i => i.paid)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                    return GetListRepairs;
                }
                return null;
            }
            catch(Exception)
            {
                return null;
            }
        }
        public int GetKolvoRepairs(string sorting, string sortingA, Repairs filtering, DateTime MinDate, DateTime MaxDate, DateTime EndMax, DateTime EndMin, DateTime StartDateMax, DateTime StartDateMin,int MaxOplata, int MinOplata, int MaxPaid, int MinPaid, int count, int page, bool uslovie)
        {
            if (uslovie == true)
            {
                var filterANDsorting = db.Repairs
                    .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                    .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                    .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                    .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                    .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                    .Where(p => p.EndDate <= EndMax || EndMax == null)
                    .Where(o => o.EndDate >= EndMin || EndMin == null)
                    .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0)
                   .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == null)
                    .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                    .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                    .Include(p => p.person)
                    .Include(m => m.RepairsReferenceBook)
                    .OrderByDescending(i => i.AddDate)
                    .Skip((count * (page - 1)))
                    .Take(count);
                return filterANDsorting.Count();
            }
            else
            {
                var filterANDsorting = db.Repairs
                    .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                    .Where(o => o.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                    .Where(p => p.AddDate >= MinDate || MinDate == DateTime.MinValue)
                    .Where(z => z.AdditionalInformation.StartsWith(filtering.AdditionalInformation) || filtering.AdditionalInformation == null)
                    .Where(m => m.CharacterOfFailure.StartsWith(filtering.CharacterOfFailure) || filtering.CharacterOfFailure == null)
                    .Where(p => p.EndDate <= EndMax || EndMax == null)
                    .Where(o => o.EndDate >= EndMin || EndMin == null)
                    .Where(n => n.IDMachine == filtering.IDMachine || filtering.IDMachine == 0)
                    .Where(n => n.price <= MaxOplata)
                        .Where(m => m.price >= MinOplata)
                        .Where(z => z.paid <= MaxPaid)
                        .Where(c => c.paid >= MinPaid)
                        .Where(n => n.oplata == filtering.oplata || filtering.oplata == null)
                    .Where(b => b.StartDate >= StartDateMax || StartDateMax == DateTime.MinValue)
                    .Where(z => z.StartDate <= StartDateMin || StartDateMin == DateTime.MinValue)
                    .OrderByDescending(i => i.AddDate)
                    .Skip((count * (page - 1)))
                    .Take(count);
                return filterANDsorting.Count();
            }
        }
        public Repairs FindByIdRepairs(int ID, bool uslovie)
        {
            if (uslovie == true)
            {
                var FindCLient = db.Repairs
                                           .Where(c => c.ID == ID)
                                           .Include(p => p.person)
                    .Include(m => m.RepairsReferenceBook)
                    .Include(z => z.Machine)
                                           .FirstOrDefault();
                Repairs r = new Repairs();
                r = FindCLient;
                return r;
            }
            else if (uslovie == false)
            {
                var FindCLient = db.Repairs
                                           .Where(c => c.ID == ID)
                                           .FirstOrDefault();
                Repairs r = new Repairs();
                r = FindCLient;
                return r;
            }
            return null;
        }
        public bool addRepairs(Repairs mach, person _manager, person _client,List <RepairsReferenceBook> uslugi)
        {
            try
            {
                if (_manager.ID != 0)
                {
                    person manager = db.person
                        .Where(m => m.ID == _manager.ID)
                        .FirstOrDefault();
                    mach.person.Add(manager);
                }
                if (_client.ID != 0)
                {
                    person client = db.person
                        .Where(m => m.ID == _client.ID)
                        .FirstOrDefault();
                    mach.person.Add(client);
                }
           
                foreach (RepairsReferenceBook rep in uslugi)
                {
                    RepairsReferenceBook reps = db.RepairsReferenceBook
                        .Where(m => m.ID == rep.ID)
                        .FirstOrDefault();
                    mach.RepairsReferenceBook.Add(reps);
                }

                mach.AddDate = DateTime.Now;
                mach.EndDate = DateTime.Now;
                mach.StartDate = DateTime.Now;
                db.Repairs.Add(mach);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DellRepairs(Repairs mach)

        {
            try
            {
                var result = db.Repairs
                    .Where(m => m.ID == mach.ID)
                    .Include(b => b.RepairsReferenceBook)
                    .Include(m => m.person)
                    .Include(b => b.Machine)
                    .FirstOrDefault();
                db.Repairs.Remove(result);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public int GetMaxIDRepairs()
        {
            try
            {
                var Poi = db.Repairs
                    .Max(p => p.ID);
                return Poi;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public bool SaveRepairs(Repairs mac)
        {
            try
            {
                var editor = db.Repairs
                                       .Where(c => c.ID == mac.ID)
                                       .Include(m => m.person)
                                       .Include(z => z.RepairsReferenceBook)
                                       .FirstOrDefault();
                if (mac.IDMachine != null && mac.IDMachine != 0)
                    editor.IDMachine = mac.IDMachine;
                if (mac.paid != 0)
                    editor.paid = mac.paid;
                if (mac.price != 0)
                    editor.price = mac.price;
                if (mac.StartDate != DateTime.MinValue)
                    editor.StartDate = mac.StartDate;
                if (mac.EndDate != DateTime.MinValue)
                    editor.EndDate = mac.EndDate;
                if (mac.AdditionalInformation != "" && mac.AdditionalInformation != null)
                    editor.AdditionalInformation = mac.AdditionalInformation;
                if (mac.CharacterOfFailure != "" && mac.CharacterOfFailure != null)
                    editor.CharacterOfFailure = mac.CharacterOfFailure;
                editor.oplata = mac.oplata;
                if (mac.RepairsReferenceBook.Count != 0)
                {
                 editor.RepairsReferenceBook.Clear();
                 foreach (RepairsReferenceBook rep in mac.RepairsReferenceBook)
                {
                   RepairsReferenceBook reps = db.RepairsReferenceBook
                        .Where(m => m.ID == rep.ID)
                        //.Include(m => m.person)
                        //.Include(m => m.Repairs)
                      .FirstOrDefault();
                    editor.RepairsReferenceBook.Add(reps);
                }               
            }

            if (mac.person.Count != 0)
            {
                editor.person.Clear();
                foreach (person rep in mac.person)
                {
                    person pers = db.person
                         .Where(m => m.ID == rep.ID)
                       //.Include(m => m.person)
                       //.(m => m.Repairs)
                       .FirstOrDefault();
                    editor.person.Add(pers);
                }
            }
            db.SaveChanges();

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
