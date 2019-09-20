using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruposEtareos.BI.EntitiesAditional
{
    public class PS_ClasificacionServicios
    {
        public string CLASIFICACION { get; set; }
        public string COD_EPS { get; set; }
        public string COD_PLAN { get; set; }
        public string COD_REGIONAL { get; set; }
        public string Regimen { get; set; }
        public string DIAGNOSTICO { get; set; }
        public string GRUPO_ETAREO { get; set; }
        public string CANTIDAD { get; set; }
        public List<object> Condicion { get; set; }
        public List<DIAGNOSTICO> DataDiagnostico { get; set; }
        public List<PS_GRUPOS_ETAREOS> DataGrupoEtareo { get; set; }
        public string DataCantidad { get; set; }
        public int IdClasifica { get; set; }
    }
}
