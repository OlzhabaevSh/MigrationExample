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
    
    public partial class MaintenanceDocumentDetailAnswers
    {
        public int Id { get; set; }
        public Nullable<int> MaintenanceDocumentDetailId { get; set; }
        public Nullable<int> DocumentAnswerTemplateId { get; set; }
    
        public virtual MaintenanceDocumentDetails MaintenanceDocumentDetails { get; set; }
        public virtual DocumentAnswerTemplates DocumentAnswerTemplates { get; set; }
    }
}