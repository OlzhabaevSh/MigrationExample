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
    
    public partial class DiagnosisTypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DiagnosisTypes()
        {
            this.MaintenanceEveryYearDispancers = new HashSet<MaintenanceEveryYearDispancers>();
            this.MaintenanceLastDiagnosis = new HashSet<MaintenanceLastDiagnosis>();
            this.Diagnosises = new HashSet<Diagnosises>();
        }
    
        public int Id { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string Code { get; set; }
        public string NameKZ { get; set; }
        public string NameRU { get; set; }
        public Nullable<int> DiagnosisCharacterId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaintenanceEveryYearDispancers> MaintenanceEveryYearDispancers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaintenanceLastDiagnosis> MaintenanceLastDiagnosis { get; set; }
        public virtual DiagnosisCharacters DiagnosisCharacters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Diagnosises> Diagnosises { get; set; }
    }
}
