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
    
    public partial class PatientAttachments
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Nullable<int> PatientAttachmentTypeId { get; set; }
        public string Path { get; set; }
        public string FileName { get; set; }
    
        public virtual Patients Patients { get; set; }
        public virtual PatientAttachmentTypes PatientAttachmentTypes { get; set; }
    }
}