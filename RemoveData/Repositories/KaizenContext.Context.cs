﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KaizenContext : DbContext
    {
        public KaizenContext()
            : base("name=KaizenContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<AmbulanceCardLogs> AmbulanceCardLogs { get; set; }
        public virtual DbSet<AmbulanceCardPregnants> AmbulanceCardPregnants { get; set; }
        public virtual DbSet<AmbulanceCards> AmbulanceCards { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<ClinicalExaminationActionPlaces> ClinicalExaminationActionPlaces { get; set; }
        public virtual DbSet<MaintenanceAnotherReasons> MaintenanceAnotherReasons { get; set; }
        public virtual DbSet<MaintenanceClinicalExaminations> MaintenanceClinicalExaminations { get; set; }
        public virtual DbSet<MaintenanceDayHospitalDates> MaintenanceDayHospitalDates { get; set; }
        public virtual DbSet<MaintenanceDayHospitals> MaintenanceDayHospitals { get; set; }
        public virtual DbSet<MaintenanceDiagnosis> MaintenanceDiagnosis { get; set; }
        public virtual DbSet<MaintenanceDiractions> MaintenanceDiractions { get; set; }
        public virtual DbSet<MaintenanceDocumentDetailAnswers> MaintenanceDocumentDetailAnswers { get; set; }
        public virtual DbSet<MaintenanceDocumentDetails> MaintenanceDocumentDetails { get; set; }
        public virtual DbSet<MaintenanceDocuments> MaintenanceDocuments { get; set; }
        public virtual DbSet<MaintenanceEveryYearDispancers> MaintenanceEveryYearDispancers { get; set; }
        public virtual DbSet<MaintenanceHistoryDiagnosis> MaintenanceHistoryDiagnosis { get; set; }
        public virtual DbSet<MaintenanceImmunizations> MaintenanceImmunizations { get; set; }
        public virtual DbSet<MaintenanceInfoTemplates> MaintenanceInfoTemplates { get; set; }
        public virtual DbSet<MaintenanceInjections> MaintenanceInjections { get; set; }
        public virtual DbSet<MaintenanceLastDiagnosis> MaintenanceLastDiagnosis { get; set; }
        public virtual DbSet<MaintenanceMassages> MaintenanceMassages { get; set; }
        public virtual DbSet<MaintenanceMedicaments> MaintenanceMedicaments { get; set; }
        public virtual DbSet<MaintenancePrivileges> MaintenancePrivileges { get; set; }
        public virtual DbSet<MaintenanceProcedures> MaintenanceProcedures { get; set; }
        public virtual DbSet<Maintenances> Maintenances { get; set; }
        public virtual DbSet<MaintenanceScreenings> MaintenanceScreenings { get; set; }
        public virtual DbSet<MaintenanceStuffs> MaintenanceStuffs { get; set; }
        public virtual DbSet<NotificationDetails> NotificationDetails { get; set; }
        public virtual DbSet<NotificationProcedures> NotificationProcedures { get; set; }
        public virtual DbSet<NotifyOperations> NotifyOperations { get; set; }
        public virtual DbSet<NotifyProcedurePropertyTypes> NotifyProcedurePropertyTypes { get; set; }
        public virtual DbSet<NotifyProcedures> NotifyProcedures { get; set; }
        public virtual DbSet<NotifyProcedureTypes> NotifyProcedureTypes { get; set; }
        public virtual DbSet<NotifyPropertyTypes> NotifyPropertyTypes { get; set; }
        public virtual DbSet<NotifyStatus> NotifyStatus { get; set; }
        public virtual DbSet<PatientAttachments> PatientAttachments { get; set; }
        public virtual DbSet<Patients> Patients { get; set; }
        public virtual DbSet<Pregnancies> Pregnancies { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Tickets> Tickets { get; set; }
        public virtual DbSet<UserActivations> UserActivations { get; set; }
        public virtual DbSet<Areas> Areas { get; set; }
        public virtual DbSet<AreaTypes> AreaTypes { get; set; }
        public virtual DbSet<BloodGroups> BloodGroups { get; set; }
        public virtual DbSet<Citizenship> Citizenship { get; set; }
        public virtual DbSet<ClinicalExaminationCancelReasons> ClinicalExaminationCancelReasons { get; set; }
        public virtual DbSet<ClinicalExaminationGroups> ClinicalExaminationGroups { get; set; }
        public virtual DbSet<ClinicalExaminationRegistrationTypes> ClinicalExaminationRegistrationTypes { get; set; }
        public virtual DbSet<ClinicalExaminationTypes> ClinicalExaminationTypes { get; set; }
        public virtual DbSet<DayHospitalTypes> DayHospitalTypes { get; set; }
        public virtual DbSet<DiagnosisCharacters> DiagnosisCharacters { get; set; }
        public virtual DbSet<Diagnosises> Diagnosises { get; set; }
        public virtual DbSet<DiagnosisTypes> DiagnosisTypes { get; set; }
        public virtual DbSet<DiseasesCharacters> DiseasesCharacters { get; set; }
        public virtual DbSet<DispancerDiagnosisDetails> DispancerDiagnosisDetails { get; set; }
        public virtual DbSet<DispancerReasonPetitions> DispancerReasonPetitions { get; set; }
        public virtual DbSet<DocumentAnswerTemplates> DocumentAnswerTemplates { get; set; }
        public virtual DbSet<DocumentQuestionTemplateAnswerTypes> DocumentQuestionTemplateAnswerTypes { get; set; }
        public virtual DbSet<DocumentQuestionTemplates> DocumentQuestionTemplates { get; set; }
        public virtual DbSet<DocumentQuestionTemplateTypes> DocumentQuestionTemplateTypes { get; set; }
        public virtual DbSet<DocumentTemplates> DocumentTemplates { get; set; }
        public virtual DbSet<DocumentTemplateType> DocumentTemplateType { get; set; }
        public virtual DbSet<DosageTypes> DosageTypes { get; set; }
        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<ExtraGenitalDiseases> ExtraGenitalDiseases { get; set; }
        public virtual DbSet<Genders> Genders { get; set; }
        public virtual DbSet<HealthStatuses> HealthStatuses { get; set; }
        public virtual DbSet<Holydays> Holydays { get; set; }
        public virtual DbSet<InjectionTypes> InjectionTypes { get; set; }
        public virtual DbSet<LastDiagnosises> LastDiagnosises { get; set; }
        public virtual DbSet<MaintenanceInjectionType> MaintenanceInjectionType { get; set; }
        public virtual DbSet<MaintenanceStatuses> MaintenanceStatuses { get; set; }
        public virtual DbSet<MaintenanceTypes> MaintenanceTypes { get; set; }
        public virtual DbSet<MaritalStatuses> MaritalStatuses { get; set; }
        public virtual DbSet<MassageTypes> MassageTypes { get; set; }
        public virtual DbSet<Medicaments> Medicaments { get; set; }
        public virtual DbSet<Nationalities> Nationalities { get; set; }
        public virtual DbSet<OrgUnits> OrgUnits { get; set; }
        public virtual DbSet<OrgUnitTypes> OrgUnitTypes { get; set; }
        public virtual DbSet<PatientAddresses> PatientAddresses { get; set; }
        public virtual DbSet<PatientAttachmentTypes> PatientAttachmentTypes { get; set; }
        public virtual DbSet<PatientLivingStatuses> PatientLivingStatuses { get; set; }
        public virtual DbSet<PatientStatuses> PatientStatuses { get; set; }
        public virtual DbSet<PatientTypes> PatientTypes { get; set; }
        public virtual DbSet<Phones> Phones { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Priorities> Priorities { get; set; }
        public virtual DbSet<Privileges> Privileges { get; set; }
        public virtual DbSet<ProcedureTypes> ProcedureTypes { get; set; }
        public virtual DbSet<QueueTypes> QueueTypes { get; set; }
        public virtual DbSet<ReasonPetitions> ReasonPetitions { get; set; }
        public virtual DbSet<RhFactors> RhFactors { get; set; }
        public virtual DbSet<StuffTypes> StuffTypes { get; set; }
        public virtual DbSet<TicketStatuses> TicketStatuses { get; set; }
        public virtual DbSet<VisitTypes> VisitTypes { get; set; }
        public virtual DbSet<WorkSpecialities> WorkSpecialities { get; set; }
        public virtual DbSet<EmployeeLeaves> EmployeeLeaves { get; set; }
        public virtual DbSet<EmployeeLeaveTypes> EmployeeLeaveTypes { get; set; }
        public virtual DbSet<Sectors> Sectors { get; set; }
        public virtual DbSet<StaffLists> StaffLists { get; set; }
        public virtual DbSet<StaffRoomBreaks> StaffRoomBreaks { get; set; }
        public virtual DbSet<StaffRoomBreakTypes> StaffRoomBreakTypes { get; set; }
        public virtual DbSet<StaffRooms> StaffRooms { get; set; }
        public virtual DbSet<StaffRoomTypes> StaffRoomTypes { get; set; }
        public virtual DbSet<WorkSchedules> WorkSchedules { get; set; }
    }
}
