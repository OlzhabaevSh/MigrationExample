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
    
    public partial class MaintenancePrivileges
    {
        public int Id { get; set; }
        public int PrivilegeId { get; set; }
        public int AmbulanceCardId { get; set; }
    
        public virtual AmbulanceCards AmbulanceCards { get; set; }
        public virtual Privileges Privileges { get; set; }
    }
}