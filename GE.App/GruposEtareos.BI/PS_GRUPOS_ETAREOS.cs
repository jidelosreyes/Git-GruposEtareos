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
    
    public partial class PS_GRUPOS_ETAREOS
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PS_GRUPOS_ETAREOS()
        {
            this.PS_POS_CONDICIONADO = new HashSet<PS_POS_CONDICIONADO>();
        }
    
        public long ID { get; set; }
        public string COD_SEXO { get; set; }
        public long EDAD_MINIMA { get; set; }
        public long EDAD_MAXIMA { get; set; }
        public long ID_UNIDADMEDIDA { get; set; }
        public string DESC_GRUPOETAREO { get; set; }
        public bool ESTADO_GRUPOETAREO { get; set; }
        public string COD_USUARIO { get; set; }
    
        public virtual GN_UNIDAD_MEDIDA GN_UNIDAD_MEDIDA { get; set; }
        public virtual SEXO SEXO { get; set; }
        public virtual GN_USUARIO_SISTEMA GN_USUARIO_SISTEMA { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PS_POS_CONDICIONADO> PS_POS_CONDICIONADO { get; set; }
    }
}
