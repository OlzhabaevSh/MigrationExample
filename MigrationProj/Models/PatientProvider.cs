using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MigrationProj.Models
{
    class PatientProvider
    {
        public void WritePatient(MyDATA mo)
        {
            var patients = new ExcelProvider().ReadFile(mo.FileName, sourse =>
            {
                try
                {
                    var fullName = Regex.Replace(Convert.ToString(sourse[3]), @"\s+", " ");
                    var name = fullName.Split(' ');
                    return new
                    {
                        Id = Convert.ToInt32(sourse[0]),
                        Sector = string.Format("Участок {0}", Convert.ToString(sourse[1])),
                        IIN = Convert.ToString(sourse[2]),
                        LastName = name[0],
                        FirstName = name[1],
                        MiddleName = name.Length > 2 ? name[2] : string.Empty,
                        Date = Convert.ToDateTime(sourse[4]),
                        Gender = Convert.ToInt32(sourse[5]),
                        Street = Convert.ToString(sourse[6]),
                        House = Convert.ToString(sourse[7]),
                        CanBeServicedAtHouse = Convert.ToInt32(sourse[8]),
                        IsSector = Convert.ToString(sourse[1]) != string.Empty
                    };
                }
                catch (Exception ex)
                {
                    return null;
                }
            });

            Console.WriteLine("Patients readed. Count: " + patients.Count());

            var groupedPatients = patients.Where(x => x != null).GroupBy(x => x.Id / 500).ToList();

            var sectors = new Dictionary<string, int>();

            using (var cntx = new PatientRepo.PatientRepo())
            {
                var sectorsLcl = cntx.Sectors.ToList();
                sectorsLcl.ForEach(item => 
                {
                    try
                    {
                        sectors.Add(item.Title, item.Id);
                    }
                    catch (Exception ex)
                    {

                    }
                });
            }

            for (var i = 0; i < groupedPatients.Count; i++)
            {
                using (var cntx = new PatientRepo.PatientRepo())
                {
                    using (var trns = cntx.Database.BeginTransaction())
                    {
                        try
                        {
                            Console.Clear();
                            for (var s = 0; s <= i; s++)
                            {
                                Console.WriteLine("Started id: " + s);
                            }

                            var currentItem = groupedPatients[i];

                            var ac = new List<PatientRepo.AmbulanceCards>();

                            var j = 0;

                            Console.WriteLine("--- Sub item: ");

                            foreach (var pt in currentItem)
                            {
                                Console.Write(j + "; ");
                                int? sectorId = null;

                                if (pt.IsSector)
                                {
                                    try
                                    {
                                        sectorId = sectors[pt.Sector];
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }

                                ac.Add(new PatientRepo.AmbulanceCards()
                                {
                                    IsDeleted = false,
                                    Patients = new PatientRepo.Patients()
                                    {
                                        BirthDate = pt.Date,
                                        CitizenshipId = null,
                                        FirstName = pt.FirstName,
                                        GenderId = pt.Gender,
                                        IIN = pt.IIN,
                                        IsCanServicedAtHome = pt.CanBeServicedAtHouse == 1,
                                        IsDeleted = false,
                                        LastName = pt.LastName,
                                        MiddleName = pt.MiddleName,
                                        OrgUnitId = mo.OrgUnitId,
                                        PatientStatusId = 3,
                                        PatientTypeId = 1,
                                        PriorityId = null,
                                        SectorId = sectorId
                                    }
                                });

                                j++;
                            }

                            cntx.AmbulanceCards.AddRange(ac);
                            cntx.SaveChanges();
                            //var china = "";
                            
                            trns.Commit();
                        }
                        catch (Exception ex)
                        {
                            trns.Rollback();
                        }
                    }
                }
            }

        }
    }
}
