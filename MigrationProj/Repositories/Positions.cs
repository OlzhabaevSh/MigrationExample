namespace MigrationProj.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("dct.Positions")]
    public partial class Positions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Positions()
        {
            StaffLists = new HashSet<StaffLists>();
        }

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public int? WorkDuration { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StaffLists> StaffLists { get; set; }

        public virtual ICollection<Employees> Employees { get; set; }
    }
}
