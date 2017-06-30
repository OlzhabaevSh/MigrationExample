namespace MigrationProj.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ma.StaffLists")]
    public partial class StaffLists
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StaffLists()
        {
            WorkSchedules = new HashSet<WorkSchedules>();
        }

        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public int OrgUnitId { get; set; }

        public int PositionId { get; set; }

        public bool IsSelfRecording { get; set; }

        public bool IsRecording { get; set; }

        public double? AdmissionDuration { get; set; }

        public int? StaffRoomId { get; set; }

        public int? SectorId { get; set; }

        public double? Salary { get; set; }

        public bool IsMain { get; set; }

        public bool IsDeleted { get; set; }

        [StringLength(512)]
        public string LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedOn { get; set; }

        public virtual Employees Employees { get; set; }

        public virtual OrgUnits OrgUnits { get; set; }

        public virtual Positions Positions { get; set; }

        public virtual Sectors Sectors { get; set; }

        public virtual StaffRooms StaffRooms { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkSchedules> WorkSchedules { get; set; }
    }
}
