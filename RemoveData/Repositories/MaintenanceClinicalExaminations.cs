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
    
    public partial class MaintenanceClinicalExaminations
    {
        public int Id { get; set; }
        public int MaintenanceId { get; set; }
        public Nullable<int> ClinicalExaminationGroupId { get; set; }
        public Nullable<int> HealthStatusId { get; set; }
        public Nullable<int> ClinicalExaminationRegistrationTypeId { get; set; }
        public Nullable<int> DiseasesCharacterId { get; set; }
        public Nullable<int> ClinicalExaminationCancelReasonId { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> NextDate { get; set; }
        public Nullable<System.DateTime> FinishDate { get; set; }
        public Nullable<int> ClinicalExaminationTypeId { get; set; }
        public Nullable<int> DiagnosisId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public Nullable<int> ClinicalExaminationActionPlaceId { get; set; }
    
        public virtual ClinicalExaminationActionPlaces ClinicalExaminationActionPlaces { get; set; }
        public virtual Maintenances Maintenances { get; set; }
        public virtual ClinicalExaminationCancelReasons ClinicalExaminationCancelReasons { get; set; }
        public virtual ClinicalExaminationGroups ClinicalExaminationGroups { get; set; }
        public virtual ClinicalExaminationRegistrationTypes ClinicalExaminationRegistrationTypes { get; set; }
        public virtual ClinicalExaminationTypes ClinicalExaminationTypes { get; set; }
        public virtual Diagnosises Diagnosises { get; set; }
        public virtual DiseasesCharacters DiseasesCharacters { get; set; }
        public virtual Employees Employees { get; set; }
        public virtual HealthStatuses HealthStatuses { get; set; }
    }
}
