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
    
    public partial class DispancerReasonPetitions
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DispancerReasonPetitions()
        {
            this.MaintenanceEveryYearDispancers = new HashSet<MaintenanceEveryYearDispancers>();
            this.MaintenanceLastDiagnosis = new HashSet<MaintenanceLastDiagnosis>();
        }
    
        public int Id { get; set; }
        public string NameRU { get; set; }
        public string NameKZ { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaintenanceEveryYearDispancers> MaintenanceEveryYearDispancers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaintenanceLastDiagnosis> MaintenanceLastDiagnosis { get; set; }
    }
}
