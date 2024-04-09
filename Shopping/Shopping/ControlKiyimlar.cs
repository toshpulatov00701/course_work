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
    internal class ControlKiyimlar:ConnectDb
    {
        public int countKiyimlar()
        {
            int soni = 0;
            DataTable dt = new DataTable();
            sqlText = "SELECT COUNT(id) AS soni FROM kiyimlar;";
            try
            {
                adapter = new SqlDataAdapter(sqlText, conn);
                adapter.Fill(dt);
                soni = int.Parse(dt.Rows[0]["soni"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return soni;
            //bu metodni asosiy formaga chaqiramiz
        }
    }
}
