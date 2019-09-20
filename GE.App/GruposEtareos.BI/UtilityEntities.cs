using System;
using System.Configuration;

namespace GruposEtareos.BI
{
    public static class UtilityEntities
    {
        public static string sNameSpace { get; set; }

        public static string sClass { get; set; }

        public static string sOperation { get; set; }

        public static string sFile { get; set; }

        public static Exception exception { get; set; }

        public static string sMessageException { get; set; }

        public static string LogFile { get { return ConfigurationManager.AppSettings["LogFile"].ToString(); } set { LogFile = ""; } }

        public static int? SystemId { get; set; }

        public static string SystemPassword { get; set; }

        public static string WebApiUrl { get; set; }
    }
}
