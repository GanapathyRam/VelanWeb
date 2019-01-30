using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;

namespace VV.ServiceGateway
{
    public static class BaseConfig
    {
        public static readonly string excelFor03 = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;

        public static readonly string excelFor07 = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
    }
}