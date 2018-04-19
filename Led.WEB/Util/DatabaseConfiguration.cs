using Led.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace Led.WEB.Util
{
    public static class DatabaseConfiguration
    {
        public static EFUnitOfWork GetEFUnitOfWork(string nameConnectionString = "LedContextLocalhost")
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings[nameConnectionString]?.ConnectionString;

            return (new EFUnitOfWork(ConnectionString));
        }
    }
}