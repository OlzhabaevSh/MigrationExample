using MigrationProj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using MigrationProj.Repositories;
using MigrationProj.ViewModels;

namespace MigrationProj
{
    /*
     * TODO:
     * Айбек, тебе из этого проекта скорее всего понадобятся 2 класса:
     * 1) EmailProvider 
     * 2) ExcelProvider
     * 
     * Первый создает строку названия почты нового сотрудника. Путем передачи ему имени и фамилии сотрудника.
     * Второй позволяет читать Excel-файлы посредством ADO (при этом файл должен быть открыт)
     * 
     * Всё остальное делается руками, в зависимости от тех данных, которые у тебя есть.
     * Но главное помнить, что тебе необходимо:
     * 1. Создать Employee
     * 2. Создать StaffList
     * 3. Создать AspNetUser
     * 4. Создать AspNetUserRole
     * 
     * Как мапить должности к ролям... не знаю. Я делал это вручную в самом эксель файле, а после уже инсертил
     * 
     */

    class Program
    {
        static private ExcelProvider _excelProvider = new ExcelProvider();

        static Dictionary<string, string> roles
        {
            get
            {
                var res = new Dictionary<string, string>();

                res.Add("Admin", "bbfe0690-5213-4af9-a03a-2f6d3a724250");
                res.Add("BeforeDoctorCabinet", "14E48BC4-A886-480E-9186-7C574D0B32DE");
                res.Add("DayHospitalDoctor", "36E8D69A-5EBC-40A8-A807-08EF8BA6BA1B");
                res.Add("DayHospitalSister", "9034C96E-17EC-4849-94C4-1AF04439F622");

                res.Add("DepartmentHead", "66A9780D-9F10-4B7A-A94F-400243697F7B");
                res.Add("DeputyHeadDoctor", "4D47B036-C335-4454-97D2-CEE3BFAD54E0");
                res.Add("Doctor", "aaa79c3c-07f8-4caf-8bd8-b634bfda0389");
                res.Add("HeadDoctor", "2DA0BE93-D589-4C49-8986-935A35F24B22");

                res.Add("HeadSister", "6360551D-C6C8-4645-807E-18AD13758D07");
                res.Add("Master", "73DCB7CB-634A-4244-B2D6-C60A32D8506B");
                res.Add("Registrator", "ae2d087b-ca2c-4612-a94a-0b7539e6f806");
                res.Add("SeniorSister", "A9B75C89-4829-427B-8CC6-A6CF340FEFCF");

                res.Add("Sister", "1637aa2a-d2c2-4f1d-b019-96c22001a25b");
                res.Add("SisterFilter", "31CAA875-4390-4567-8D93-9E6E02AEE353");
                res.Add("Statistics", "03C39B48-9615-4FD7-A898-1A15FD40B971");
                res.Add("Viewer", "0E8B6C96-E1AD-4BB7-A789-161DCD68935E");

                return res;
            }
        }



        static void Main(string[] args)
        {
            //var mo36 = new MyDATA() { OrgUnitId = 178, FileName = @"App_Data/orgUnitEmployees36.json" };
            var mo9Patients = new MyDATA() { OrgUnitId = 44, FileName = @"D:\orgUnits\orgUnit9\OrgUnit9.xlsx" };

            WritingEmployees(mo9Patients);
        }

        static void WritingEmployees(MyDATA mo)
        {
            var data = new ExcelProvider().ReadFile(mo.FileName, sourse => 
            {
                var sector = string.IsNullOrEmpty(Convert.ToString(sourse[7])) ? null : string.Format("Участок {0}", Convert.ToString(sourse[7]));

                return new
                {
                    Id = Convert.ToInt32(sourse[0]),
                    IIN = Convert.ToString(sourse[1]).TrimStart(' ').TrimEnd(' '),
                    LastName = Convert.ToString(sourse[2]).TrimStart(' ').TrimEnd(' '),
                    FirstName = Convert.ToString(sourse[3]).TrimStart(' ').TrimEnd(' '),
                    MiddleName = Convert.ToString(sourse[4]).TrimStart(' ').TrimEnd(' '),
                    Position = Regex.Replace(Convert.ToString(sourse[5]).TrimStart(' ').TrimEnd(' '), @"\s+", " "),
                    RoleId = Convert.ToString(sourse[6]),
                    Sector = sector,
                    Cabinet = Convert.ToString(sourse[8]).TrimStart(' ').TrimEnd(' '),
                    Monday = Convert.ToString(sourse[9]).TrimStart(' ').TrimEnd(' '),
                    Tuesday = Convert.ToString(sourse[10]).TrimStart(' ').TrimEnd(' '),
                    Wednesday = Convert.ToString(sourse[11]).TrimStart(' ').TrimEnd(' '),
                    Thursday = Convert.ToString(sourse[12]).TrimStart(' ').TrimEnd(' '),
                    Friday = Convert.ToString(sourse[13]).TrimStart(' ').TrimEnd(' '),
                    Saturday = Convert.ToString(sourse[14]).TrimStart(' ').TrimEnd(' '),
                    Synday = Convert.ToString(sourse[15]).TrimStart(' ').TrimEnd(' '),
                    FullName = String.Format("{0} {1} {2}", Convert.ToString(sourse[2]).TrimStart(' ').TrimEnd(' '), Convert.ToString(sourse[3]).TrimStart(' ').TrimEnd(' '), Convert.ToString(sourse[4]).TrimStart(' ').TrimEnd(' '))
                };
            });

            var psls = data.Select(x => x.Position).Distinct().ToList();

            var sctrs = data.Select(x => x.Sector).Where(x => x != null && x != "Участок 0").Distinct().ToList();

            var stfRooms = data.Select(x => x.Cabinet).Where(x => !string.IsNullOrEmpty(x)).Distinct().ToList();

            var nd = data.Select(x => x.FullName).Distinct().ToList();

            using (var cntx = new KaizenContext())
            {
                var positions = cntx.Positions.ToList();

                //var notFounded = psls.Where(x => !positions.Any(f => f.Title.ToLower().TrimStart(' ').TrimEnd(' ') == x.ToLower())).ToList();

                var sectors = cntx.Sectors.ToList();

                //var notFoundex = sctrs.Where(x => !sectors.Any(f => f.Title == x)).ToList();

                var stfRms = cntx.StaffRooms.ToList();

                var roles = cntx.AspNetRoles.ToList();

                using (var trns = cntx.Database.BeginTransaction())
                {
                    try
                    {
                        int k = 0;
                        foreach (var prs in data)
                        {
                            Console.WriteLine("K: " + k);
                            var empls = cntx.Employees.FirstOrDefault(x => x.LastName == prs.LastName && x.FirstName == prs.FirstName && x.MiddleName == prs.MiddleName);

                            if (empls == null)
                            {
                                empls = new Employees()
                                {
                                    BirthDate = DateTime.Now.Date.AddYears(-30),
                                    FirstName = prs.FirstName,
                                    IIN = string.IsNullOrEmpty(prs.IIN) ? "-" : prs.IIN,
                                    IsActive = true,
                                    IsDeleted = false,
                                    LastName = prs.LastName,
                                    MiddleName = prs.MiddleName,
                                    OrgUnitId = mo.OrgUnitId
                                };

                                cntx.Employees.Add(empls);
                                cntx.SaveChanges();
                            }

                            var position = positions.FirstOrDefault(f => f.Title.ToLower().TrimStart(' ').TrimEnd(' ') == prs.Position);

                            if (position == null)
                            {
                                position = new Positions()
                                {
                                    Title = prs.Position
                                };
                                cntx.Positions.Add(position);
                                cntx.SaveChanges();
                            }

                            int? sectorId = null;
                            var str = sectors.FirstOrDefault(f => f.Title == prs.Sector);
                            if (str != null)
                            {
                                sectorId = str.Id;
                            }

                            int? staffRoomId = null;
                            var sr = stfRms.FirstOrDefault(x => x.Title == prs.Cabinet);
                            if (sr != null)
                            {
                                staffRoomId = sr.Id;
                            }

                            if (!empls.StaffLists.Any(x => x.PositionId == position.Id && x.SectorId == sectorId && x.StaffRoomId == x.StaffRoomId))
                            {
                                empls.StaffLists.Add(new StaffLists()
                                {
                                    IsDeleted = false,
                                    IsMain = !empls.StaffLists.Any(),
                                    IsRecording = false,
                                    IsSelfRecording = false,
                                    OrgUnitId = mo.OrgUnitId,
                                    PositionId = position.Id,
                                    SectorId = sectorId,
                                    StaffRoomId = staffRoomId,
                                    WorkSchedules = Enumerable.Range(1, 7).Select(x => new WorkSchedules()
                                    {
                                        EndTime = "20:00",
                                        IsActive = x <= 5,
                                        IsFilter = false,
                                        IsMain = true,
                                        StartTime = "8:00",
                                        WeekDay = Convert.ToByte(x)
                                    }).ToList()
                                });
                                cntx.SaveChanges();
                            }
                            
                            if (string.IsNullOrEmpty(empls.UserId))
                            {
                                var email = EmailProvider.GetEmail(prs.LastName, prs.FirstName);

                                var aspUser = cntx.AspNetUsers.FirstOrDefault(x => x.Email == email);

                                if (aspUser == null)
                                {
                                    var guid = Guid.NewGuid().ToString();

                                    aspUser = new AspNetUsers()
                                    {
                                        AccessFailedCount = 0,
                                        Email = email,
                                        LockoutEnabled = false,
                                        PasswordHash = "Qwerty123!",
                                        PhoneNumberConfirmed = false,
                                        SecurityStamp = guid,
                                        Id = guid,
                                        TwoFactorEnabled = false,
                                        UserName = email
                                    };
                                    cntx.AspNetUsers.Add(aspUser);
                                }

                                empls.UserId = aspUser.Id;

                                cntx.SaveChanges();
                            }

                            var usr = cntx.AspNetUsers.FirstOrDefault(x => x.Id == empls.UserId);

                            var rl = roles.FirstOrDefault(x => x.Id == prs.RoleId);

                            if (!rl.AspNetUsers.Any(x => x.Id == usr.Id))
                            {
                                rl.AspNetUsers.Add(usr);
                                cntx.SaveChanges();
                            }
                            
                            
                            k++;
                        }

                        cntx.SaveChanges();
                        trns.Commit();
                    }
                    catch (Exception ex)
                    {
                        trns.Rollback();
                    }
                }

            }


        }


        static void WritePatients(MyDATA mo)
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
                        CanBeServicedAtHouse = Convert.ToInt32(sourse[8])
                    };
                }
                catch (Exception ex)
                {
                    return null;
                }
            });

            var groupedPatients = patients.Where(x => x != null).GroupBy(x => x.Id / 500).ToList();

            var sectors = new Dictionary<string, int>();

            using (var cntx = new KaizenContext())
            {
                var sectorsLcl = cntx.Sectors.ToList();
            }

            for (var i = 0; i < groupedPatients.Count; i++)
            {
                using (var cntx = new KaizenContext())
                {
                    using (var trns = cntx.Database.BeginTransaction())
                    {
                        try
                        {
                            Console.WriteLine("Started id: " + i);

                            var currentItem = groupedPatients[i];




                            var china = "";
                            //trns.Commit();
                        }
                        catch (Exception ex)
                        {
                            trns.Rollback();
                        }
                    }
                }
            }

            
        }

        static void WriteToDB(MyDATA mo)
        {
            //var dataStr = System.IO.File.ReadAllText(mo.FileName);
            var empls = new ExcelProvider().ReadFile(mo.FileName, sourse => 
            {
                return new
                {
                    Email = Convert.ToString(sourse[0]),
                    LastName = Convert.ToString(sourse[1]),
                    FistName = Convert.ToString(sourse[2]),
                    MiddleName = Convert.ToString(sourse[3]),
                    Position = Convert.ToString(sourse[4]),
                    RoleId = Convert.ToString(sourse[5]),
                };
            });



            using (var cntx = new KaizenContext())
            {
                using (var trns = cntx.Database.BeginTransaction())
                {
                    var poss = cntx.Positions.ToList();
                    var roles = cntx.AspNetRoles.ToList();

                    try
                    {
                        int k = 0;
                        foreach (var prs in empls)
                        {
                            Console.WriteLine("Log: " + k);
                            k++;
                            var guid = Guid.NewGuid().ToString();
                            var email = EmailProvider.GetEmail(prs.LastName, prs.FistName); // prs.Email;

                            var aspUser = new AspNetUsers()
                            {
                                Email = email,
                                UserName = email,
                                EmailConfirmed = false,
                                Id = guid,
                                LockoutEnabled = false,
                                PasswordHash = "Qwerty123!",
                                PhoneNumberConfirmed = false,
                                SecurityStamp = guid,
                                TwoFactorEnabled = false
                            };

                            cntx.AspNetUsers.Add(aspUser);
                            cntx.SaveChanges();

                            if (!string.IsNullOrEmpty(prs.RoleId) )
                            {
                                var rl = roles.First(x => x.Id == prs.RoleId);
                                rl.AspNetUsers.Add(aspUser);
                            }
                            
                            cntx.SaveChanges();

                            var empl = new Employees()
                            {
                                BirthDate = DateTime.Now.Date.AddYears(-25),
                                FirstName = prs.FistName,
                                IIN = "-",
                                IsActive = true,
                                IsDeleted = false,
                                LastName = prs.LastName,
                                MiddleName = prs.MiddleName,
                                OrgUnitId = mo.OrgUnitId,
                                UserId = guid
                            };

                            cntx.Employees.Add(empl);
                            cntx.SaveChanges();

                            if (!string.IsNullOrEmpty(prs.Position))
                            {
                                var psId = poss.First(x => x.Title == prs.Position).Id;
                                
                                var sl = new StaffLists()
                                {
                                    Employees = empl,
                                    IsDeleted = false,
                                    IsMain = true,
                                    IsRecording = true,
                                    IsSelfRecording = true,
                                    OrgUnitId = mo.OrgUnitId,
                                    PositionId = psId,
                                    StaffRoomId = 1,
                                    WorkSchedules = Enumerable.Range(1, 6).Select(x => new WorkSchedules()
                                    {
                                        EndTime = "20:00",
                                        IsActive = true,
                                        IsFilter = false,
                                        IsMain = true,
                                        StartTime = "8:00",
                                        WeekDay = Convert.ToByte(x)
                                    }).ToList()
                                };

                                cntx.StaffLists.Add(sl);
                            }
                            

                            cntx.SaveChanges();
                        }

                        cntx.SaveChanges();
                        //var ds = "";
                        trns.Commit();
                    }
                    catch (Exception ex)
                    {
                        trns.Rollback();
                    }

                }
            }
        }

        static void WriteToDB()
        {
            // MO 
            // 36 - ID: 178 | @"App_Data/orgUnitEmployees36.json"
            // 35 - ID: 179 | @"App_Data/orgUnitEmployees35.json"

            //var mo36 = new MyDATA() { OrgUnitId = 178, FileName = @"App_Data/orgUnitEmployees36.json" };
            var mo35 = new MyDATA() { OrgUnitId = 179, FileName = @"App_Data/orgUnitEmployees35.json" };

            var dataStr = System.IO.File.ReadAllText(mo35.FileName);
            var empls = Newtonsoft.Json.JsonConvert.DeserializeObject<ICollection<EmployeeDataVM>>(dataStr);

            using (var cntx = new KaizenContext())
            {
                using (var trns = cntx.Database.BeginTransaction())
                {
                    var poss = cntx.Positions.ToList();
                    var roles = cntx.AspNetRoles.ToList();

                    try
                    {
                        foreach (var prs in empls)
                        {
                            var guid = Guid.NewGuid().ToString();
                            var email = prs.Email;

                            var aspUser = new AspNetUsers()
                            {
                                Email = email,
                                UserName = email,
                                EmailConfirmed = false,
                                Id = guid,
                                LockoutEnabled = false,
                                PasswordHash = "Qwerty123!",
                                PhoneNumberConfirmed = false,
                                SecurityStamp = guid,
                                TwoFactorEnabled = false
                            };

                            cntx.AspNetUsers.Add(aspUser);
                            cntx.SaveChanges();

                            foreach (var rls in prs.Roles)
                            {
                                var rl = roles.First(x => x.Name == rls);
                                rl.AspNetUsers.Add(aspUser);
                            }

                            cntx.SaveChanges();

                            var empl = new Employees()
                            {
                                BirthDate = prs.BirthDate,
                                FirstName = prs.FirstName,
                                IIN = prs.IIN,
                                IsActive = true,
                                IsDeleted = false,
                                LastName = prs.LastName,
                                MiddleName = prs.MiddleName,
                                OrgUnitId = mo35.OrgUnitId,
                                UserId = guid
                            };

                            cntx.Employees.Add(empl);
                            cntx.SaveChanges();

                            foreach (var pos in prs.Positions)
                            {
                                var psId = poss.First(x => x.Title == pos).Id;

                                var sl = new StaffLists()
                                {
                                    Employees = empl,
                                    IsDeleted = false,
                                    IsMain = true,
                                    IsRecording = true,
                                    IsSelfRecording = true,
                                    OrgUnitId = mo35.OrgUnitId,
                                    PositionId = psId,
                                    WorkSchedules = prs.WorkSchedules.Select(x => new WorkSchedules()
                                    {
                                        EndTime = x.EndTime,
                                        IsActive = x.IsActive,
                                        IsFilter = x.IsFilter,
                                        IsMain = x.IsMain,
                                        StartTime = x.StartTime,
                                        WeekDay = Convert.ToByte(x.DayOfWeek)
                                    }).ToList()
                                };

                                cntx.StaffLists.Add(sl);
                            }

                            cntx.SaveChanges();
                        }

                        //var ds = "";
                        trns.Commit();
                    }
                    catch (Exception ex)
                    {
                        trns.Rollback();
                    }

                }
            }
        }

        static void Read(MyDATA mo)
        {
            using (var cntx = new KaizenContext())
            {
                var aspNetUsers = cntx.AspNetUsers.ToList();

                var orgUnitIds = cntx.OrgUnits.Where(x => x.OrgUnitId == mo.OrgUnitId).Select(x => x.Id).ToList();
                orgUnitIds.Add(mo.OrgUnitId);

                var employees = cntx
                                .Employees
                                .Join(orgUnitIds,
                                    outter => outter.OrgUnitId,
                                    inner => inner,
                                    (rs, inner) => rs).ToList();

                var errorCount = 0;
                var k = 0;

                var kList = new List<int>();

                var res = employees.Select(x =>
                {
                    var ni = new EmployeeDataVM()
                    {
                        BirthDate = x.BirthDate,
                        FirstName = !string.IsNullOrEmpty(x.LastName) ? x.FirstName : x.MiddleName,
                        IIN = x.IIN,
                        LastName = !string.IsNullOrEmpty(x.LastName) ? x.LastName : x.FirstName,
                        MiddleName = !string.IsNullOrEmpty(x.LastName) ? x.MiddleName : string.Empty,
                        MO = mo.OrgUnitId.ToString(),
                        Positions = x.StaffLists.Select(f => f.Positions.Title).Where(f => !string.IsNullOrEmpty(f)).Distinct().ToList(),
                    };
                    try
                    {
                        var aspUsr = aspNetUsers.First(f => f.Id == x.UserId);

                        ni.Email = aspUsr.Email;
                        ni.Roles = aspUsr.AspNetRoles.Select(f => f.Name).Where(f => !string.IsNullOrEmpty(f)).Distinct().ToList();

                        var ws = new List<WorkScheduleVM>();

                        for (var i = 1; i <= 7; i++)
                        {
                            var isActive = i <= 5;

                            ws.Add(new WorkScheduleVM()
                            {
                                DayOfWeek = i,
                                EndTime = "20:00",
                                IsActive = isActive,
                                IsFilter = false,
                                IsMain = true,
                                StartTime = "9:00"
                            });
                        }

                        var works = x.StaffLists.SelectMany(f => f.WorkSchedules).ToList();
                        if (works.Any())
                        {
                            ws = new List<WorkScheduleVM>();

                            for (var i = 1; i <= 7; i++)
                            {
                                var isActive = i <= 5;

                                var nl = works.FirstOrDefault(f => f.WeekDay == i);

                                var s = new WorkScheduleVM()
                                {
                                    DayOfWeek = i,
                                    EndTime = nl == null ? "20:00" : nl.EndTime,
                                    IsActive = isActive,
                                    IsFilter = false,
                                    IsMain = true,
                                    StartTime = nl == null ? "9:00" : nl.StartTime
                                };

                                ws.Add(s);
                            }
                        }

                        ni.WorkSchedules = ws;
                    }
                    catch (Exception ex)
                    {
                        errorCount++;
                        kList.Add(k);
                        return null;
                    }

                    k++;

                    return ni;
                }).ToList();

                var json = Newtonsoft.Json.JsonConvert.SerializeObject(res.Where(x => x != null).ToList());
                System.IO.File.WriteAllText(mo.FileName, json);

            }
        }

    }

    class MyDATA
    {
        public int OrgUnitId { get; set; }

        public string FileName { get; set; }
    }

}
