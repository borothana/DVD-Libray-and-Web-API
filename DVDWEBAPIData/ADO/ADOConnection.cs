﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVDWEBAPIData.ADO
{
    public class ADOConnection
    {
        public static string CnnString = ConfigurationManager.ConnectionStrings["ADOString"].ToString();
    }
}
