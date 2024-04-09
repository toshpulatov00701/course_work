using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping
{
    internal class ControlSavdolar:ConnectDb
    {
        public int getDayIncome()
        {
            int summa = 0;
            DataTable dt = new DataTable();
            sqlText = "SELECT SUM(savdolar.soni * kiyimlar.narx) as jami_summa FROM savdolar INNER JOIN kiyimlar ON kiyimlar.id=savdolar.kiyim_id WHERE DAY(savdolar.vaqt) = DAY(GETDATE()) AND MONTH(savdolar.vaqt) = MONTH(GETDATE()) AND YEAR(savdolar.vaqt) = YEAR(GETDATE());";
            try
            {
                adapter = new SqlDataAdapter(sqlText, conn);
                adapter.Fill(dt);
                summa = int.Parse(dt.Rows[0]["jami_summa"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return summa;
            //bu metodni asosiy formaga chaqiramiz
        }
        public int getMonthIncome()
        {
            int summa = 0;
            DataTable dt = new DataTable();
            sqlText = "SELECT SUM(savdolar.soni * kiyimlar.narx) as jami_summa FROM savdolar INNER JOIN kiyimlar ON kiyimlar.id=savdolar.kiyim_id WHERE MONTH(savdolar.vaqt) = MONTH(GETDATE()) AND YEAR(savdolar.vaqt) = YEAR(GETDATE());";
            try
            {
                adapter = new SqlDataAdapter(sqlText, conn);
                adapter.Fill(dt);
                summa = int.Parse(dt.Rows[0]["jami_summa"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return summa;
            //bu metodni asosiy formaga chaqiramiz
        }
        public int getYearIncome()
        {
            int summa = 0;
            DataTable dt = new DataTable();
            sqlText = "SELECT SUM(savdolar.soni * kiyimlar.narx) as jami_summa FROM savdolar INNER JOIN kiyimlar ON kiyimlar.id=savdolar.kiyim_id WHERE YEAR(savdolar.vaqt) = YEAR(GETDATE());";
            try
            {
                adapter = new SqlDataAdapter(sqlText, conn);
                adapter.Fill(dt);
                summa = int.Parse(dt.Rows[0]["jami_summa"].ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return summa;
            //bu metodni asosiy formaga chaqiramiz
        }
    }
}
