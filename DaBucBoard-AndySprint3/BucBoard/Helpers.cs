using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace BucBoard
{
    public class Helpers
    {
        public static string GetRDSConnectionString()
        {
            var appConfig = ConfigurationManager.AppSettings;

            string dbname = appConfig["bucboard"];

            if (string.IsNullOrEmpty(dbname)) return null;

            string username = appConfig["bucboard"];
            string password = appConfig["se2fall2018"];
            string hostname = appConfig["aa2etok2i8rmb6.c6qfhcwpa69s.us-east-2.rds.amazonaws.com"];
            string port = appConfig["3306"];

            return "Data Source=" + hostname + ";Initial Catalog=" + dbname + ";User ID=" + username + ";Password=" + password + ";";
        }
    }
}