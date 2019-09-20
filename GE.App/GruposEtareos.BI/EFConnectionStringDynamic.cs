using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GruposEtareos.BI
{
    public class EFConnectionStringDynamic
    {
        private static DataLayer.clsDataServices objDataLayer { get { return new DataLayer.clsDataServices(); } }

        public static string getConnectionStringUDL()
        {
            System.Data.SqlClient.SqlConnectionStringBuilder sqlString = new System.Data.SqlClient.SqlConnectionStringBuilder()
            {
                ConnectionString = objDataLayer.ConnectionString,
                IntegratedSecurity = true,
                MultipleActiveResultSets = true
            };
            //Build an Entity Framework connection string

            System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder entityString = new System.Data.Entity.Core.EntityClient.EntityConnectionStringBuilder()
            {
                Provider = (objDataLayer.ProviderName == "SqlClient" ? "System.Data.SqlClient" : objDataLayer.ProviderName),
                Metadata = "res://*/GruposEtareosModel.csdl|res://*/GruposEtareosModel.ssdl|res://*/GruposEtareosModel.msl",
                ProviderConnectionString = sqlString.ToString()
            };
            return entityString.ConnectionString;
        }
    }
}
