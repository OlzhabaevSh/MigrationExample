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
    
    public partial class MaintenanceImmunizations
    {
        public int Id { get; set; }
        public int AmbulanceCardId { get; set; }
        public string Vaccionation { get; set; }
        public string Injection { get; set; }
        public string InjectionType { get; set; }
        public string AreaReaction { get; set; }
        public string CountryFrom { get; set; }
        public System.DateTime VaccinationDate { get; set; }
        public string VaccinationType { get; set; }
        public string Dose { get; set; }
        public string AllReaction { get; set; }
        public string Series { get; set; }
    
        public virtual AmbulanceCards AmbulanceCards { get; set; }
    }
}