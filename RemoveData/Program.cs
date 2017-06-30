using RemoveData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveData
{
    class Program
    {
        private static int OrgUnit30Id = 1;

        private static int OrgUnit32Id = 76;

        static void Main(string[] args)
        {
            var prs = GetRegisters();

            var registerRoleId = "ae2d087b-ca2c-4612-a94a-0b7539e6f806";

            using (var cntx = new Repositories.KaizenContext())
            {
                // roleId
                using (var trns = cntx.Database.BeginTransaction())
                {
                    var rl = cntx.AspNetRoles.First(x => x.Id == registerRoleId);

                    try
                    {
                        foreach (var empl in prs)
                        {
                            var guid = Guid.NewGuid().ToString();
                            var aspNetUser = cntx.AspNetUsers.FirstOrDefault(x => x.Email == empl.Email);

                            if (aspNetUser == null)
                            {
                                aspNetUser = new AspNetUsers()
                                {
                                    Email = empl.Email,
                                    EmailConfirmed = false,
                                    Id = guid,
                                    LockoutEnabled = false,
                                    PasswordHash = "Qwerty123!",
                                    PhoneNumberConfirmed = false,
                                    TwoFactorEnabled = false,
                                    UserName = empl.Email,
                                    SecurityStamp = guid
                                };
                                cntx.AspNetUsers.Add(aspNetUser);
                                cntx.SaveChanges();
                            }
                            else
                            {
                                guid = aspNetUser.Id;
                            }

                            rl.AspNetUsers.Add(aspNetUser);

                            cntx.SaveChanges();

                            var ls = new StaffLists()
                            {
                                IsDeleted = false,
                                IsMain = true,
                                IsRecording = false,
                                IsSelfRecording = false,
                                OrgUnitId = 44,
                                PositionId = 47,
                                StaffRoomId = 1,
                                Employees = new Employees()
                                {
                                    BirthDate = DateTime.Now.Date.AddYears(-25),
                                    FirstName = empl.FisrName,
                                    LastName = empl.LastName,
                                    IIN = "-",
                                    IsActive = true,
                                    IsDeleted = false,
                                    MiddleName = empl.MiddleName,
                                    OrgUnitId = 44,
                                    UserId = aspNetUser.Id
                                },
                            };

                            cntx.StaffLists.Add(ls);

                            cntx.SaveChanges();
                        }
                        
                        trns.Commit();
                    }
                    catch (Exception ex)
                    {
                        trns.Rollback();
                    }
                }
            }
        }

        static void ShowEmployees(int orgUnitId)
        {
            using (var cntx = new KaizenContext())
            {
                using (var trns = cntx.Database.BeginTransaction())
                {
                    try
                    {
                        var orgUnitIds = cntx
                        .OrgUnits
                        .Where(x => x.Id == orgUnitId || x.OrgUnitId == orgUnitId).Select(x => x.Id).Distinct();

                        var empls = cntx
                            .StaffLists
                            .Join(orgUnitIds,
                                outter => outter.OrgUnitId,
                                inner => inner,
                                (r, i) => r.Employees.UserId).Distinct().ToList();

                        var aspUsers = cntx.AspNetUsers.ToList();

                        var removeUsers = new List<AspNetUsers>();

                        foreach (var usr in aspUsers)
                        {
                            if (!empls.Any(x => x == usr.Id))
                            {
                                removeUsers.Add(usr);
                            }
                        }

                        cntx.AspNetUsers.RemoveRange(removeUsers);

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

        static void ShowPatients(int orgUnitId)
        {
            using (var cntx = new KaizenContext())
            {
                using (var trns = cntx.Database.BeginTransaction())
                {
                    try
                    {
                        var orgUnitIds = cntx
                        .OrgUnits
                        .Where(x => x.Id == orgUnitId || x.OrgUnitId == orgUnitId).Select(x => x.Id).Distinct();

                        var outterPatients = cntx.Patients.AsQueryable();

                        foreach (var i in orgUnitIds)
                        {
                            outterPatients = outterPatients.Where(x => x.OrgUnitId != i);
                        }

                        var outterPts = outterPatients.ToList();



                        //var ac = outterPts.Select(x => x.AmbulanceCards).ToList();
                        
                        //cntx.AmbulanceCards.RemoveRange(ac);

                        var tcts = outterPts.SelectMany(x => x.Tickets).ToList();
                        cntx.Tickets.RemoveRange(tcts);

                        cntx.Patients.RemoveRange(outterPts);
                        cntx.SaveChanges();
                        trns.Commit();
                    }
                    catch (Exception ex)
                    {
                        trns.Rollback();
                    }
                }

                

                //var test = from cntx.Patients 

            }
        }

        static ICollection<PersonVM> GetRegisters()
        {
            var prs = new List<PersonVM>();

            prs.Add(new PersonVM()
            {
                Email = "shamerdenova.azhan@kaizen.kz",
                LastName = "Шаймерденова",
                FisrName = "Айжан",
                MiddleName = "Бауржанқызы"
            });
            prs.Add(new PersonVM()
            {
                Email = "bedzhuma.esel@kaizen.kz",
                LastName = "Бэджума",
                FisrName = "Эсел",
                MiddleName = ""
            });
            prs.Add(new PersonVM()
            {
                Email = "bekenova.zhldyz@kaizen.kz",
                LastName = "Бекенова",
                FisrName = "Жұлдыз",
                MiddleName = "Ермекқызы"
            });
            prs.Add(new PersonVM()
            {
                Email = "berezhko.ludmila@kaizen.kz",
                LastName = "Бережко",
                FisrName = "Людмила",
                MiddleName = "Николаевна"
            });
            prs.Add(new PersonVM()
            {
                Email = "moskaleva.olga@kaizen.kz",
                LastName = "Москалева",
                FisrName = "Ольга",
                MiddleName = "Владимировна"
            });
            prs.Add(new PersonVM()
            {
                Email = "undirisbaeva.gulnur@kaizen.kz",
                LastName = "Ундирисбаева",
                FisrName = "Гулнур",
                MiddleName = "Манатқызы"
            });
            prs.Add(new PersonVM()
            {
                Email = "kenesbaeva.gauhar@kaizen.kz",
                LastName = "Кенесбаева",
                FisrName = "Гаухар",
                MiddleName = "Маликовна"
            });
            prs.Add(new PersonVM()
            {
                Email = "sultanova.g@kaizen.kz",
                LastName = "Султанова",
                FisrName = "Г",
                MiddleName = ""
            });
            prs.Add(new PersonVM()
            {
                Email = "bahotanova.tolkyn@kaizen.kz",
                LastName = "Байхотанова",
                FisrName = "Толкын",
                MiddleName = "Оналбековна"
            });
            prs.Add(new PersonVM()
            {
                Email = "koshigulova.chatura@kaizen.kz",
                LastName = "Койшигулова",
                FisrName = "Чатура",
                MiddleName = "Чаймухпновна"
            });

            return prs;
        }

    }

    class PersonVM
    {
        public string LastName { get; set; }

        public string FisrName { get; set; }

        public string MiddleName { get; set; }

        public string Email { get; set; }
    }

}
