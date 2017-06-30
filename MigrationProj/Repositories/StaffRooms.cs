namespace MigrationProj.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ma.StaffRooms")]
    public partial class StaffRooms
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StaffRooms()
        {
            StaffLists = new HashSet<StaffLists>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(512)]
        public string Title { get; set; }

        public int TypeId { get; set; }

        public bool IsDeleted { get; set; }

        [StringLength(512)]
        public string LastUpdatedBy { get; set; }

        public DateTime? LastUpdatedOn { get; set; }

        [Required]
        [StringLength(512)]
        public string Number { get; set; }

        [Required]
        [StringLength(64)]
        public string StartTime { get; set; }

        [Required]
        [StringLength(64)]
        public string EndTime { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StaffLists> StaffLists { get; set; }

        public virtual StaffRoomTypes StaffRoomTypes { get; set; }
    }
}
