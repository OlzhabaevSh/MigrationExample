namespace MigrationProj.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dct.OrgUnits")]
    public partial class OrgUnits
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrgUnits()
        {
            Employees = new HashSet<Employees>();
            OrgUnits1 = new HashSet<OrgUnits>();
            StaffLists = new HashSet<StaffLists>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int OrgUnitTypeId { get; set; }

        public int? OrgUnitId { get; set; }

        public string Description { get; set; }

        public int? Weight { get; set; }

        [StringLength(512)]
        public string GlobalEntityId { get; set; }

        public bool IsDeleted { get; set; }

        [StringLength(512)]
        public string LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedOn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employees> Employees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrgUnits> OrgUnits1 { get; set; }

        public virtual OrgUnits OrgUnits2 { get; set; }

        public virtual OrgUnitTypes OrgUnitTypes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StaffLists> StaffLists { get; set; }
    }
}
