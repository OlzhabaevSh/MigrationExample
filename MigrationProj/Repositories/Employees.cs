namespace MigrationProj.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dct.Employees")]
    public partial class Employees
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employees()
        {
            StaffLists = new HashSet<StaffLists>();
        }

        public int Id { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        public DateTime? LastVisit { get; set; }

        public bool IsActive { get; set; }

        public int? OrgUnitId { get; set; }

        [StringLength(512)]
        public string WorkExperience { get; set; }

        [Required]
        [StringLength(128)]
        public string IIN { get; set; }

        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(512)]
        public string FirstName { get; set; }

        [StringLength(512)]
        public string LastName { get; set; }

        [StringLength(512)]
        public string MiddleName { get; set; }

        [StringLength(512)]
        public string PhoneNumber { get; set; }

        [StringLength(512)]
        public string Address { get; set; }

        [StringLength(1)]
        public string Gender { get; set; }

        [StringLength(512)]
        public string GlobalEntityId { get; set; }

        public bool IsDeleted { get; set; }

        [StringLength(512)]
        public string LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedOn { get; set; }

        public virtual OrgUnits OrgUnits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StaffLists> StaffLists { get; set; }

        public virtual ICollection<Positions> Positions { get; set; }
    }
}
