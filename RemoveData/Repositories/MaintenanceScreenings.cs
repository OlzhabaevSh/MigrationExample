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
    
    public partial class MaintenanceScreenings
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public int Age { get; set; }
        public float Wieght { get; set; }
        public float Height { get; set; }
        public float IMT { get; set; }
        public float HeadCircleLengh { get; set; }
        public float BloodPressureFrom { get; set; }
        public float BloodPressureTo { get; set; }
        public int PulseAmount { get; set; }
        public float BloodGlucose { get; set; }
        public float BloodCholesterol { get; set; }
        public float XeAmount { get; set; }
        public int AmbulanceCardId { get; set; }
        public float UrineGlucose { get; set; }
    
        public virtual AmbulanceCards AmbulanceCards { get; set; }
    }
}
