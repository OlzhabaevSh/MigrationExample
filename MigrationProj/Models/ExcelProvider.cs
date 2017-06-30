using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MigrationProj.Models
{
    class ExcelProvider
    {
        private string _connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = {0};Extended Properties =\'Excel 8.0;HDR=YES;\'";

        public ICollection<T> ReadFile<T>(string filePath, Func<DataRow, T> converter)
        {
            var res = new List<T>();

            DataTable dt = new DataTable();

            using (OleDbConnection conn = new OleDbConnection(string.Format(_connectionString, filePath)))
            {
                conn.Open();
                
                var command = "SELECT * FROM [Sheet1$]";

                using (OleDbDataAdapter da = new OleDbDataAdapter(command, conn))
                {
                    da.Fill(dt);
                }

                conn.Close();
            }

            for (var i = 0; i < dt.Rows.Count; i++)
            {
                var vl = dt.Rows[i];
                var item = converter(vl);
                res.Add(item);
            }

            return res;
        }
    }
}
