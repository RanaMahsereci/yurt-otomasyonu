﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace YurKaSist
{
    public class SqlBaglantim
    {
        public SqlConnection baglanti() {

        SqlConnection baglan = new SqlConnection("Data Source=DESKTOP-2QD0TDL;Initial Catalog=YurtOtomasyon;Integrated Security=True");
        baglan.Open();
        return baglan;  
        
        } }
}
