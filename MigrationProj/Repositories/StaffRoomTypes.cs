namespace MigrationProj.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ma.StaffRoomTypes")]
    public partial class StaffRoomTypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StaffRoomTypes()
        {
            StaffRooms = new HashSet<StaffRooms>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(512)]
        public string Title { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StaffRooms> StaffRooms { get; set; }
    }
}
