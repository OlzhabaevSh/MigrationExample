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
    
    public partial class DocumentQuestionTemplates
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DocumentQuestionTemplates()
        {
            this.MaintenanceDocumentDetails = new HashSet<MaintenanceDocumentDetails>();
            this.DocumentAnswerTemplates = new HashSet<DocumentAnswerTemplates>();
        }
    
        public int Id { get; set; }
        public int DocumentTemplateId { get; set; }
        public string Message { get; set; }
        public Nullable<int> DocumentQuestionTemplateAnswerTypeId { get; set; }
        public Nullable<int> DocumentQuestionTemplateTypeId { get; set; }
        public bool IsDeleted { get; set; }
        public string LastUpdatedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedOn { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MaintenanceDocumentDetails> MaintenanceDocumentDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DocumentAnswerTemplates> DocumentAnswerTemplates { get; set; }
        public virtual DocumentQuestionTemplateAnswerTypes DocumentQuestionTemplateAnswerTypes { get; set; }
        public virtual DocumentQuestionTemplateTypes DocumentQuestionTemplateTypes { get; set; }
        public virtual DocumentTemplates DocumentTemplates { get; set; }
    }
}
