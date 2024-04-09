using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace Shopping
{
    internal class ControlXodimlar:ConnectDb
    {
        // bool - kiritilsa true, aks holda false. Bunda Xodimlar sinfidan olingan obyekt keladi,
        // Ammo bizga id kerak bo'lmaydi.
        public bool InsertXodim(Xodimlar xodim)
        {
            int e = 0;
            sqlText = "INSERT INTO xodimlar VALUES ('"+xodim.ism+"', '"+xodim.familiya+"', '"+xodim.telefon+"', "+xodim.maosh+", '"+xodim.rasm+"', '"+xodim.rol+"', '"+xodim.login+"', '"+xodim.parol+"', "+xodim.viloyat_id+");";
            try
            {
                cmd = new SqlCommand(sqlText, conn);
                e = cmd.ExecuteNonQuery();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if(e == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool updateXodim(Xodimlar xodim)
        {
            int e = 0;
            // update uchun sql kod.
            // bu metodga id ham keladi,
            sqlText = "UPDATE xodimlar SET ism='"+xodim.ism+"', familiya='"+xodim.familiya+"', telefon='"+xodim.telefon+"', maosh="+xodim.maosh+", rasm='"+xodim.rasm+"', rol='"+xodim.rol+"', fLogin='"+xodim.login+"', fPassword='"+xodim.parol+"', viloyat_id="+xodim.viloyat_id+" WHERE id="+xodim.id+"";
            try
            {
                cmd = new SqlCommand(sqlText, conn);
                e = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (e == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool deleteData(int id)
        {
            int e = 0;
            // delete uchun sql kod
            // bu metodga id ham keladi,
            sqlText = "DELETE xodimlar WHERE id="+id;
            try
            {
                cmd = new SqlCommand(sqlText, conn);
                e = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            if (e == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataTable getDataXodimlar()
        {
            DataTable dt = new DataTable();
            sqlText = "SELECT xodimlar.id, xodimlar.ism, xodimlar.familiya, xodimlar.telefon, xodimlar.maosh, xodimlar.rasm, xodimlar.rol, xodimlar.fLogin, xodimlar.fPassword, viloyatlar.nomi AS viloyat FROM xodimlar INNER JOIN viloyatlar ON xodimlar.viloyat_id=viloyatlar.id;";
            try
            {
                adapter = new SqlDataAdapter(sqlText, conn);
                adapter.Fill(dt);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return dt;
        }
        public DataTable searchData(string keyText)
        {
            DataTable dt = new DataTable();
            sqlText = "SELECT xodimlar.id, xodimlar.ism, xodimlar.familiya, xodimlar.telefon, xodimlar.maosh, xodimlar.rasm, xodimlar.rol, xodimlar.fLogin, xodimlar.fPassword, viloyatlar.nomi AS viloyat FROM xodimlar  INNER JOIN viloyatlar ON xodimlar.viloyat_id=viloyatlar.id WHERE xodimlar.ism LIKE '%"+ keyText + "%' OR xodimlar.familiya LIKE '%"+ keyText + "%' OR xodimlar.telefon LIKE '%"+ keyText + "%' OR xodimlar.rol LIKE '%"+ keyText + "%' OR viloyatlar.nomi LIKE '%"+ keyText + "%';";
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
        public int countXodimlar()
        {
            int soni = 0;
            DataTable dt = new DataTable();
            sqlText = "SELECT COUNT(id) AS soni FROM xodimlar;";
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
    public class Xodimlar
    {
        public int id;
        public string ism;
        public string familiya;
        public string telefon;
        public int maosh;
        public string rasm;
        public string rol;
        public int viloyat_id;
        public string login;
        public string parol;
        public Xodimlar(int id, string ism, string familiya, string telefon, int maosh, string rasm, string rol, int viloyat_id, string login, string parol)
        {
            this.id = id;
            this.ism = ism;
            this.familiya = familiya;
            this.telefon = telefon;
            this.maosh = maosh;
            this.rasm = rasm;
            this.rol = rol;
            this.viloyat_id = viloyat_id;
            this.login = login;
            this.parol = parol;
        }
        //Plimorfiz.
        public Xodimlar(string ism, string familiya, string telefon, int maosh, string rasm, string rol, int viloyat_id, string login, string parol)
        {
            this.ism = ism;
            this.familiya = familiya;
            this.telefon = telefon;
            this.maosh = maosh;
            this.rasm = rasm;
            this.rol = rol;
            this.viloyat_id = viloyat_id;
            this.login = login;
            this.parol = parol;
        }
    }
}
