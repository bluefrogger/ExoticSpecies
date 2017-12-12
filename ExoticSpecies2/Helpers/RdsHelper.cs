using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ExoticSpeciesOfTheNorth.Helpers
{
    public class RdsHelper
    {
        public static string GetRdsConnStr()
        {
            var AppConfig = ConfigurationManager.AppSettings;

            string hostname = AppConfig["RDS_HOSTNAME"];
            string dbname = AppConfig["RDS_DB_NAME"];
            string username = AppConfig["RDS_USERNAME"];
            string password = AppConfig["RDS_PASSWORD"];
            string port = AppConfig["RDS_PORT"];

            string ConnStr = $"Data Source={hostname},{port}; Initial Catalog={dbname}; User ID={username}; Password={password};";
            return ConnStr;
        }
    }
}