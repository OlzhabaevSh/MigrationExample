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
    
    public partial class AmbulanceCards
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public AmbulanceCards()
        {
            this.AmbulanceCardLogs = new HashSet<AmbulanceCardLogs>();
            this.MaintenanceEveryYearDispancers = new HashSet<MaintenanceEveryYearDispancers>();
            this.MaintenanceHistoryDiagnosis = new HashSet<MaintenanceHistoryDiagnosis>();
            this.MaintenanceImmunizations = new HashSet<MaintenanceImmunizations>();
            this.MaintenanceLastDiagnosis = new HashSet<MaintenanceLastDiagnosis>();
            this.MaintenancePrivileges = new HashSet<MaintenancePrivileges>();
            this.Maintenances = new HashSet<Maintenances>();
            this.MaintenanceScreenings = new HashSet<MaintenanceScreenings>();
        }
    
        public int Id { get; set; }
        public Nullable<int> MaritalStatusId { get; set; }
        public string WorkPlace { get; set; }
        public Nullable<int> BloodGruopId { get; set; }
        public Nullable<int> RhFactorId { get; set; }
        public Nullable<System.DateTime> DischargeFromHospitalDate { get; set; }
        public string Hospital { get; set; }
        public string AllergicHistory { get; set; }
        public string EpidemiologicalHistory { get; set; }
        public string ReactionsFromMedicaments { get; set; }
        public string IndividualCharacteristics { get; set; }
        public string SpecialCases { get; set; }
        public string SmokingInfo { get; set; }
        public string DrinkInfo { get; set; }
        public Nullable<int> WorkSpecialityId { get; set; }
        public string PatientPosition { get; set; }
        public string SocialStatus { get; set; }
        public Nullable<int> BloodGroup_Id { get; set; }
        public bool IsDeleted { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedOn { get; set; }
        public Nullable<System.DateTime> DeathDate { get; set; }
        public Nullable<System.DateTime> PolyclinicJoiningDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AmbulanceCardLogs> AmbulanceCardLogs { get; set; }
        public virtual AmbulanceCardPregnants AmbulanceCardPregnants { get; set; }
        public virtual Patients Patients { get; set; }
        public virtual BloodGroups BloodGroups { get; set; }
        public virtual MaritalStatuses MaritalStatuses { get; set; }
        public virtual RhFactors RhFactors { get; set; }
        public virtual WorkSpecialities WorkSpecialities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaintenanceEveryYearDispancers> MaintenanceEveryYearDispancers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaintenanceHistoryDiagnosis> MaintenanceHistoryDiagnosis { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaintenanceImmunizations> MaintenanceImmunizations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaintenanceLastDiagnosis> MaintenanceLastDiagnosis { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaintenancePrivileges> MaintenancePrivileges { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Maintenances> Maintenances { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaintenanceScreenings> MaintenanceScreenings { get; set; }
    }
}
