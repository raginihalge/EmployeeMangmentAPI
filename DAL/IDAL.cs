﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDAL
    {
        DataTable GetData(SqlCommand cmd);
        bool Excute(SqlCommand cmd);
    }
}
