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
    
    public partial class StaffRoomBreakTypes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StaffRoomBreakTypes()
        {
            this.StaffRoomBreaks = new HashSet<StaffRoomBreaks>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StaffRoomBreaks> StaffRoomBreaks { get; set; }
    }
}
