using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruposEtareos.BI
{
    public class ApplicationUser : IdentityUser
    {
        public string CODUSUARIO { get; set; }
    }
}
