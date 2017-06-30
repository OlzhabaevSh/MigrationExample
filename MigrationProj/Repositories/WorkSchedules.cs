namespace MigrationProj.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ma.WorkSchedules")]
    public partial class WorkSchedules
    {
        public int Id { get; set; }

        public byte WeekDay { get; set; }

        public bool IsMain { get; set; }

        [Required]
        [StringLength(64)]
        public string StartTime { get; set; }

        [Required]
        [StringLength(64)]
        public string EndTime { get; set; }

        public bool IsFilter { get; set; }

        public bool IsActive { get; set; }

        public int StaffListId { get; set; }

        public virtual StaffLists StaffLists { get; set; }
    }
}
