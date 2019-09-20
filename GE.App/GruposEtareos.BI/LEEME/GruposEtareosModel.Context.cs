﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Core.EntityClient;
    using System.Data.Entity.Infrastructure;
    using System.Data.SqlClient;

    public partial class GruposEtareosEntities : DbContext
    {        
        private static DataLayer.clsDataServices objDataLayer { get { return new DataLayer.clsDataServices(); } }

        public GruposEtareosEntities()
            : base(getConnectionStringUDL())
        {
        }

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<GN_UNIDAD_MEDIDA> GN_UNIDAD_MEDIDA { get; set; }
        public virtual DbSet<SEXO> SEXOes { get; set; }
        public virtual DbSet<PS_GRUPOS_ETAREOS> PS_GRUPOS_ETAREOS { get; set; }
        public virtual DbSet<GN_USUARIO_SISTEMA> GN_USUARIO_SISTEMA { get; set; }
    }
}