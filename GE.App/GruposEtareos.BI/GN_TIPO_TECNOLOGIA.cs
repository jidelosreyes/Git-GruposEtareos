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
    
    public partial class GN_TIPO_TECNOLOGIA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GN_TIPO_TECNOLOGIA()
        {
            this.PS_SERVICIOS = new HashSet<PS_SERVICIOS>();
        }
    
        public long ID { get; set; }
        public string COD_NORMATIVO { get; set; }
        public string DESCRIPCION_SERVICIO { get; set; }
        public short COD_TIPO_SERVICIO { get; set; }
        public bool ESTADO { get; set; }
    
        public virtual GN_TIPO_SERVICIOS GN_TIPO_SERVICIOS { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PS_SERVICIOS> PS_SERVICIOS { get; set; }
    }
}