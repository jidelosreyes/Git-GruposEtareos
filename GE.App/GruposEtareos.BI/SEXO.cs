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
    
    public partial class SEXO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SEXO()
        {
            this.PS_GRUPOS_ETAREOS = new HashSet<PS_GRUPOS_ETAREOS>();
            this.DIAGNOSTICOS = new HashSet<DIAGNOSTICO>();
            this.PS_SERVICIOS = new HashSet<PS_SERVICIOS>();
        }
    
        public string COD_SEXO { get; set; }
        public string DESC_SEXO { get; set; }
        public string APLICA_AFILIACION { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PS_GRUPOS_ETAREOS> PS_GRUPOS_ETAREOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DIAGNOSTICO> DIAGNOSTICOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PS_SERVICIOS> PS_SERVICIOS { get; set; }
    }
}