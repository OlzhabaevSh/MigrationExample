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
    
    public partial class Tickets
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tickets()
        {
            this.Maintenances = new HashSet<Maintenances>();
        }
    
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int TicketStatusId { get; set; }
        public int PositionId { get; set; }
        public Nullable<int> ReasonPetitionId { get; set; }
        public int VisitTypeId { get; set; }
        public int QueueTypeId { get; set; }
        public Nullable<int> EmployeeId { get; set; }
        public System.DateTime RegisteredOn { get; set; }
        public Nullable<System.DateTime> ScheduledTime { get; set; }
        public Nullable<System.DateTime> FinishOn { get; set; }
        public Nullable<int> TicketNumber { get; set; }
        public Nullable<int> DiagnosisId { get; set; }
        public Nullable<bool> IsFree { get; set; }
        public string CancelDescription { get; set; }
        public Nullable<System.DateTime> ProcessingStartTime { get; set; }
        public string HomeCallReason { get; set; }
        public Nullable<bool> IsFromScan { get; set; }
        public Nullable<int> Weight { get; set; }
        public Nullable<bool> IsInvited { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Maintenances> Maintenances { get; set; }
        public virtual Patients Patients { get; set; }
        public virtual Diagnosises Diagnosises { get; set; }
        public virtual Employees Employees { get; set; }
        public virtual Positions Positions { get; set; }
        public virtual QueueTypes QueueTypes { get; set; }
        public virtual ReasonPetitions ReasonPetitions { get; set; }
        public virtual TicketStatuses TicketStatuses { get; set; }
        public virtual VisitTypes VisitTypes { get; set; }
    }
}