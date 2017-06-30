using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationProj.ViewModels
{
    class EmployeeDataVM
    {
        public DateTime BirthDate { get; set; }
        public string IIN { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string MO { get; set; }
        public ICollection<string> Departments { get; set; }
        public ICollection<string> Positions { get; set; }
        public string Email { get; set; }
        public ICollection<string> Roles { get; set; }
        public ICollection<WorkScheduleVM> WorkSchedules { get; set; }
    }

    class WorkScheduleVM
    {
        public int DayOfWeek { get; set; }
        public bool IsMain { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool IsFilter { get; set; }
        public bool IsActive { get; set; }
    }

    class InputData
    {
        public ICollection<string> Positions { get; set; }
        public ICollection<string> Roles { get; set; }
        public ICollection<string> Departments { get; set; }
    }

}
