//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GruposEtareos.BI
{
    using System;
    using System.Collections.Generic;
    
    public partial class SV_PROFESIONAL_AUTORIZA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SV_PROFESIONAL_AUTORIZA()
        {
            this.PS_SERVICIOS = new HashSet<PS_SERVICIOS>();
        }
    
        public string PROFESIONAL_AUTORIZA { get; set; }
        public string DESC_PROFESIONAL_AUTORIZA { get; set; }
        public Nullable<bool> PYP_412 { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PS_SERVICIOS> PS_SERVICIOS { get; set; }
    }
}