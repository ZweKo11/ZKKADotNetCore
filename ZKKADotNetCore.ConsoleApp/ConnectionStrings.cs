﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZKKADotNetCore.ConsoleApp
{
    internal static class ConnectionStrings
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = "DESKTOP-49VCNU9",
            InitialCatalog = "DotNetTrainingBatch4",
            UserID = "sa",
            Password = "sa@123"
        };
    }
}
