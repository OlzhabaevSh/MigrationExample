//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RemoveData.Repositories
{
    using System;
    using System.Collections.Generic;
    
    public partial class Areas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Areas()
        {
            this.Pregnancies = new HashSet<Pregnancies>();
            this.Areas1 = new HashSet<Areas>();
            this.PatientAddresses = new HashSet<PatientAddresses>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public int AreaTypeId { get; set; }
        public Nullable<int> AreaId { get; set; }
        public string SystemId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pregnancies> Pregnancies { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Areas> Areas1 { get; set; }
        public virtual Areas Areas2 { get; set; }
        public virtual AreaTypes AreaTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientAddresses> PatientAddresses { get; set; }
    }
}
