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
    
    public partial class LastDiagnosises
    {
        public int Id { get; set; }
        public string NameRU { get; set; }
        public string NameKZ { get; set; }
        public string PublishCode { get; set; }
        public Nullable<int> DiagnosisCharacterId { get; set; }
    
        public virtual DiagnosisCharacters DiagnosisCharacters { get; set; }
    }
}
