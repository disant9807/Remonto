using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.SQLite;

namespace Labo4ka7
{
    class Uslugi
    {
        Model1 db = new Model1();
        public List<RepairsReferenceBook> GetListUslugi(string sorting, string sortingA, RepairsReferenceBook filtering, DateTime MinDate, DateTime MaxDate, int count, int page, bool uslovie)
        {
            if (filtering.ServiceName == null)
                filtering.ServiceName = "";
            if (filtering.DescriptionIOfService == null)
                filtering.DescriptionIOfService = "";

            if (sorting == "ID" && sortingA == "Возрастание")
            {
                List<RepairsReferenceBook> GetListUslugi = new List<RepairsReferenceBook>();
                if (uslovie == true)
                {
                    GetListUslugi = db.RepairsReferenceBook
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(o => o.price == filtering.price || filtering.price == 0)
                        .Include(p => p.person)
                        .Include(m => m.Repairs)
                        .ToList();
                    return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                        .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                        .OrderBy(i => i.ID)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                }
                else
                {
                    GetListUslugi = db.RepairsReferenceBook
                                       .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                       .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                                       .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                                       .Where(o => o.price == filtering.price || filtering.price == 0)
                                       .ToList();

                    return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                        .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                        .OrderBy(i => i.ID)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                }
            }
            if (sorting == "ID" && sortingA == "Убывание")
            {
                List<RepairsReferenceBook> GetListUslugi = new List<RepairsReferenceBook>();
                if (uslovie == true)
                {
                    GetListUslugi = db.RepairsReferenceBook
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(o => o.price == filtering.price || filtering.price == 0)
                        .Include(p => p.person)
                        .Include(m => m.Repairs)
                        .ToList();

                    return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                       .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                       .OrderByDescending(i => i.ID)
                       .Skip((count * (page - 1)))
                       .Take(count)
                       .ToList();
                }
                else
                {
                    GetListUslugi = db.RepairsReferenceBook
                                       .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                       .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                                       .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                                       .Where(o => o.price == filtering.price || filtering.price == 0)
                                       .ToList();

                    return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                      .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                      .OrderByDescending(i => i.ID)
                      .Skip((count * (page - 1)))
                      .Take(count)
                      .ToList();
                }
            }
            if (sorting == "Название услуги" && sortingA == "Возрастание")
            {
                List<RepairsReferenceBook> GetListUslugi = new List<RepairsReferenceBook>();
                if (uslovie == true)
                {
                    GetListUslugi = db.RepairsReferenceBook
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(o => o.price == filtering.price || filtering.price == 0)
                        .Include(p => p.person)
                        .Include(m => m.Repairs)
                        .ToList();

                    return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                       .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                        .OrderBy(i => i.ServiceName)
                       .Skip((count * (page - 1)))
                       .Take(count)
                       .ToList();
                }
                else
                {
                    GetListUslugi = db.RepairsReferenceBook
                                       .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                       .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                                       .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                                       .Where(o => o.price == filtering.price || filtering.price == 0)
                                       .ToList();

                    return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                      .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                       .OrderBy(i => i.ServiceName)
                      .Skip((count * (page - 1)))
                      .Take(count)
                      .ToList();
                }
            }
            if (sorting == "Название услуги" && sortingA == "Убывание")
            {
                List<RepairsReferenceBook> GetListUslugi = new List<RepairsReferenceBook>();
                if (uslovie == true)
                {
                    GetListUslugi = db.RepairsReferenceBook
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(o => o.price == filtering.price || filtering.price == 0)
                        .Include(p => p.person)
                        .Include(m => m.Repairs)
                        .ToList();

                    return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                      .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                      .OrderByDescending(i => i.ServiceName)
                      .Skip((count * (page - 1)))
                      .Take(count)
                      .ToList();
                }
                else
                {
                    GetListUslugi = db.RepairsReferenceBook
                                       .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                       .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                                       .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                                       .Where(o => o.price == filtering.price || filtering.price == 0)
                                       .ToList();

                    return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                       .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                       .OrderByDescending(i => i.ServiceName)
                       .Skip((count * (page - 1)))
                       .Take(count)
                       .ToList();
                }
            }
            if (sorting == "Стоймость" && sortingA == "Возрастание")
            {
                List<RepairsReferenceBook> GetListUslugi = new List<RepairsReferenceBook>();
                if (uslovie == true)
                {
                    GetListUslugi = db.RepairsReferenceBook
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(o => o.price == filtering.price || filtering.price == 0)
                        .Include(p => p.person)
                        .Include(m => m.Repairs)
                        .ToList();

                    return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                        .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                        .OrderBy(i => i.price)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                }
                else
                {
                    GetListUslugi = db.RepairsReferenceBook
                                       .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                       .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                                       .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                                       .Where(o => o.price == filtering.price || filtering.price == 0)
                                       .ToList();

                    return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                        .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                        .OrderBy(i => i.price)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                }
            }
            if (sorting == "Стоймость" && sortingA == "Убывание")
            {
                List<RepairsReferenceBook> GetListUslugi = new List<RepairsReferenceBook>();
                if (uslovie == true)
                {
                    GetListUslugi = db.RepairsReferenceBook
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(o => o.price == filtering.price || filtering.price == 0)
                        .Include(p => p.person)
                        .Include(m => m.Repairs)
                        .ToList();

                    return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                         .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                         .OrderByDescending(i => i.price)
                         .Skip((count * (page - 1)))
                         .Take(count)
                         .ToList();
                }
                else
                {
                    GetListUslugi = db.RepairsReferenceBook
                                       .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                       .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                                       .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                                       .Where(o => o.price == filtering.price || filtering.price == 0)
                                       .ToList();

                    return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                          .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                          .OrderByDescending(i => i.price)
                          .Skip((count * (page - 1)))
                          .Take(count)
                          .ToList();
                }
            }
            if (sorting == "Дата добавления" && sortingA == "Возрастание")
            {
                List<RepairsReferenceBook> GetListUslugi = new List<RepairsReferenceBook>();
                if (uslovie == true)
                {
                    GetListUslugi = db.RepairsReferenceBook
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(o => o.price == filtering.price || filtering.price == 0)
                        .Include(p => p.person)
                        .Include(m => m.Repairs)
                        .ToList();

                    return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                         .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                         .OrderBy(i => i.AddDate)
                         .Skip((count * (page - 1)))
                         .Take(count)
                         .ToList();
                }
                else
                {
                    GetListUslugi = db.RepairsReferenceBook
                                       .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                       .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                                       .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                                       .Where(o => o.price == filtering.price || filtering.price == 0)
                                       .ToList();


                    return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                         .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                         .OrderBy(i => i.AddDate)
                         .Skip((count * (page - 1)))
                         .Take(count)
                         .ToList();
                }
            }
            if (sorting == "Дата добавления" && sortingA == "Убывание")
            {
                List<RepairsReferenceBook> GetListUslugi = new List<RepairsReferenceBook>();
                if (uslovie == true)
                {
                    GetListUslugi = db.RepairsReferenceBook
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(o => o.price == filtering.price || filtering.price == 0)
                        .Include(p => p.person)
                        .Include(m => m.Repairs)
  
                        .ToList();


                    return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                        .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                        .OrderByDescending(i => i.AddDate)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                }
                else
                {
                    GetListUslugi = db.RepairsReferenceBook
                                       .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                       .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                                       .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                                       .Where(o => o.price == filtering.price || filtering.price == 0)
                                       .ToList();

                    return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                        .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                        .OrderByDescending(i => i.AddDate)
                        .Skip((count * (page - 1)))
                        .Take(count)
                        .ToList();
                }
            }
            if (sorting == "Менеджер" && sortingA == "Возрастание")
            {
                List<RepairsReferenceBook> GetListUslugi = new List<RepairsReferenceBook>();
                if (uslovie == true)
                {
                    GetListUslugi = db.RepairsReferenceBook
                        .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                        .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                        .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                        .Where(o => o.price == filtering.price || filtering.price == 0)
                        .Include(p => p.person)
                        .Include(m => m.Repairs)
                        .ToList();

                    return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                       .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                       .OrderBy(i => i.AddDate)
                       .Skip((count * (page - 1)))
                       .Take(count)
                       .ToList();
                }
                else
                {
                    GetListUslugi = db.RepairsReferenceBook
                                       .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                       .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                                       .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                                       .Where(o => o.price == filtering.price || filtering.price == 0)
                                       .ToList();


                    return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                      .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                      .OrderBy(i => i.AddDate)
                      .Skip((count * (page - 1)))
                      .Take(count)
                      .ToList();
                }
            }
            return null;
        }
        public int GetKolvoUslugi(string sorting, string sortingA, RepairsReferenceBook filtering, DateTime MinDate, DateTime MaxDate, int count, int page, bool uslovie)
        {
            if (uslovie == true)
            {
                var filterANDsorting = db.RepairsReferenceBook
                    .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                    .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == null)
                    .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                    .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                    .Where(o => o.price == filtering.price || filtering.price == 0)
                    .Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == null)
                    .Include(p => p.person)
                    .Include(m => m.Repairs)
                    .OrderByDescending(i => i.AddDate)
                    .Skip((count * (page - 1)))
                    .Take(count);
                return filterANDsorting.Count();
            }
            else
            {
                var filterANDsorting = db.RepairsReferenceBook
                    .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                    .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == null)
                    .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                    .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                    .Where(o => o.price == filtering.price || filtering.price == 0)
                    .Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == null)
                    .OrderByDescending(i => i.AddDate)
                    .Skip((count * (page - 1)))
                    .Take(count);
                return filterANDsorting.Count();
            }
        }
        public List<RepairsReferenceBook> GetListUslugiManager(string sorting, string sortingA, RepairsReferenceBook filtering, DateTime MinDate, DateTime MaxDate, int count, int page, person manager)
        {
            try
            {
                List<person> Manag = db.person
                    .Where(z => z.FIO.StartsWith(manager.FIO))
                    .Include(m => m.RepairsReferenceBook.Select(X=>X.person))
                    .ToList();
                List<RepairsReferenceBook> RepRef = new List<RepairsReferenceBook>();
                foreach (person p in Manag)
                {
                    RepRef.AddRange(p.RepairsReferenceBook);
                }
                RepRef = RepRef.Distinct().ToList();
                if (filtering.DescriptionIOfService == null)
                    filtering.DescriptionIOfService = "";
                if (filtering.ServiceName == null)
                    filtering.ServiceName = "";
                if (sorting == "ID" && sortingA == "Возрастание")
                {
                    List<RepairsReferenceBook> GetListUslugi = new List<RepairsReferenceBook>();
                    
                        GetListUslugi = RepRef
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                                           .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(o => o.price == filtering.price || filtering.price == 0)
                                           .ToList();

                        return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                            .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                            .OrderBy(i => i.ID)
                            .Skip((count * (page - 1)))
                            .Take(count)
                            .ToList();
                    
                }
                if (sorting == "ID" && sortingA == "Убывание")
                {
                    List<RepairsReferenceBook> GetListUslugi = new List<RepairsReferenceBook>();
                    
                        GetListUslugi = RepRef
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                                           .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(o => o.price == filtering.price || filtering.price == 0)
                                           .ToList();

                        return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                          .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                          .OrderByDescending(i => i.ID)
                          .Skip((count * (page - 1)))
                          .Take(count)
                          .ToList();
                    
                }
                if (sorting == "Название услуги" && sortingA == "Возрастание")
                {
                    List<RepairsReferenceBook> GetListUslugi = new List<RepairsReferenceBook>();
                    
                        GetListUslugi = RepRef
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                                           .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(o => o.price == filtering.price || filtering.price == 0)
                                           .ToList();

                        return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                          .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                           .OrderBy(i => i.ServiceName)
                          .Skip((count * (page - 1)))
                          .Take(count)
                          .ToList();
                    
                }
                if (sorting == "Название услуги" && sortingA == "Убывание")
                {
                    List<RepairsReferenceBook> GetListUslugi = new List<RepairsReferenceBook>();
                    
                        GetListUslugi = RepRef
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                                           .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(o => o.price == filtering.price || filtering.price == 0)
                                           .ToList();

                        return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                           .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                           .OrderByDescending(i => i.ServiceName)
                           .Skip((count * (page - 1)))
                           .Take(count)
                           .ToList();
                    
                }
                if (sorting == "Стоймость" && sortingA == "Возрастание")
                {
                    List<RepairsReferenceBook> GetListUslugi = new List<RepairsReferenceBook>();
                   
                        GetListUslugi = RepRef
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                                           .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(o => o.price == filtering.price || filtering.price == 0)
                                           .ToList();

                        return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                            .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                            .OrderBy(i => i.price)
                            .Skip((count * (page - 1)))
                            .Take(count)
                            .ToList();
                    
                }
                if (sorting == "Стоймость" && sortingA == "Убывание")
                {
                    List<RepairsReferenceBook> GetListUslugi = new List<RepairsReferenceBook>();
                    
                        GetListUslugi = RepRef
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                                           .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(o => o.price == filtering.price || filtering.price == 0)
                                           .ToList();

                        return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                              .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                              .OrderByDescending(i => i.price)
                              .Skip((count * (page - 1)))
                              .Take(count)
                              .ToList();
                    
                }
                if (sorting == "Дата добавления" && sortingA == "Возрастание")
                {
                    List<RepairsReferenceBook> GetListUslugi = new List<RepairsReferenceBook>();
                    
                        GetListUslugi = RepRef
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                                           .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(o => o.price == filtering.price || filtering.price == 0)
                                           .ToList();


                        return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                             .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                             .OrderBy(i => i.AddDate)
                             .Skip((count * (page - 1)))
                             .Take(count)
                             .ToList();
                    }
                
                if (sorting == "Дата добавления" && sortingA == "Убывание")
                {
                    List<RepairsReferenceBook> GetListUslugi = new List<RepairsReferenceBook>();
                   
                        GetListUslugi = RepRef
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                                           .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(o => o.price == filtering.price || filtering.price == 0)
                                           .ToList();

                        return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                            .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                            .OrderByDescending(i => i.AddDate)
                            .Skip((count * (page - 1)))
                            .Take(count)
                            .ToList();
                    
                }
                if (sorting == "Менеджер" && sortingA == "Возрастание")
                {
                    List<RepairsReferenceBook> GetListUslugi = new List<RepairsReferenceBook>();
                    GetListUslugi = RepRef
                                           .Where(p => p.ID == filtering.ID || filtering.ID == 0)
                                           .Where(z => z.AddDate >= MinDate || MinDate == DateTime.MinValue)
                                           .Where(p => p.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                                           .Where(o => o.price == filtering.price || filtering.price == 0)
                                           .ToList();


                        return GetListUslugi.Where(m => m.ServiceName.StartsWith(filtering.ServiceName) || filtering.ServiceName == "")
                          .Where(p => p.DescriptionIOfService.StartsWith(filtering.DescriptionIOfService) || filtering.DescriptionIOfService == "")
                          .OrderBy(i => i.AddDate)
                          .Skip((count * (page - 1)))
                          .Take(count)
                          .ToList();
                    
                }
                return null;
            }
            catch(Exception)
            {
                return null;
            }
        }
        public RepairsReferenceBook FindByIdmac(int ID, bool uslovie)
        {
            if (uslovie == true)
            {
                var FindCLient = db.RepairsReferenceBook
                                           .Where(c => c.ID == ID)
                                           .Include(p => p.person)
                                           .Include(v => v.Repairs)
                                           .FirstOrDefault();
                RepairsReferenceBook r = new RepairsReferenceBook();
                r = FindCLient;
                return r;
            }
            else if (uslovie == false)
            {
                var FindCLient = db.RepairsReferenceBook
                                           .Where(c => c.ID == ID)
                                           .FirstOrDefault();
                RepairsReferenceBook r = new RepairsReferenceBook();
                r = FindCLient;
                return r;
            }
            return null;
        }
        public bool addUslugi(RepairsReferenceBook mach, person manager)
        {
            try
            {
                db.person.Attach(manager);
                mach.person.Add(manager);
                db.RepairsReferenceBook.Add(mach);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool DellUslugi(RepairsReferenceBook mach)

        {
            try
            {
                db.RepairsReferenceBook.Remove(mach);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public int GetMaxIDMachine()
        {
            try
            {
                var Poi = db.RepairsReferenceBook
                    .Max(p => p.ID);
                return Poi;
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public bool SaveMachine(RepairsReferenceBook mac)
        {
            var editor = db.RepairsReferenceBook
                                   .Where(c => c.ID == mac.ID)
                                   .FirstOrDefault();
            if (mac.DescriptionIOfService != null|| mac.DescriptionIOfService != "")
                editor.DescriptionIOfService = mac.DescriptionIOfService;
            if(mac.price != 0)
                editor.price = mac.price;
            if(mac.ServiceName != null|| mac.ServiceName != "")
            editor.ServiceName = mac.ServiceName;
            db.SaveChanges();
            return true;
        }
    }
}
