using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.IO;
using System.Data;

namespace Queue_Monitoring
{
    class ExcelOLEDB
    {
        public DataTable ReturnSchedule(string filename)
        {
            string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";Extended Properties=\"Excel 12.0;HDR=NO;Readonly=True;IMEX=1\"";
            DataTable ds = new DataTable();
            using (OleDbConnection oledb = new OleDbConnection(ConnectionString))
            {
                oledb.Open();
                OleDbDataAdapter ad = new OleDbDataAdapter("select * from [" + DateTime.Now.DayOfWeek + "$A5:BM]", oledb);
                ad.Fill(ds);
                oledb.Close();
                return ds;
            }

        }
    }
}
