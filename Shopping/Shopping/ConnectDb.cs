using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping
{
    internal class ConnectDb
    {
        protected SqlConnection conn;
        protected SqlCommand cmd;
        protected SqlDataReader reader;
        protected SqlDataAdapter adapter;
        protected string sqlText;
        //Constuktrga bazaga bog'lanishni yozamiz.
        public ConnectDb()
        {
            string connectString = "Server=DESKTOP-G6MKKOD\\SQLEXPRESS;Database=shopping;Trusted_Connection=True";
            try
            {
                this.conn = new SqlConnection(connectString);
                this.conn.Open();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }


        }
        ~ConnectDb()
        {
            this.conn = null;
        }
    }
}
