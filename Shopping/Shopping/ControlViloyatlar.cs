using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping
{
    internal class ControlViloyatlar:ConnectDb
    {
        public static DataTable dt = new DataTable();
        public DataTable getDataViloyatlar()
        {
            sqlText = "SELECT * FROM viloyatlar";
            try
            {
                adapter = new SqlDataAdapter(sqlText, conn);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dt;
        }
        public int getIdByName(string name)
        {
            int id = 0;
            foreach (DataRow row in dt.Rows)
            {
                if (row["nomi"].ToString() == name)
                {
                    id = int.Parse(row["id"].ToString());
                }
            }
            return id;
        }
    }
}
