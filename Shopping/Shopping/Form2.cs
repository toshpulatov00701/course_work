using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // UserLogin.cs dan foydalangan holda userni tekshiramiz

            String uLogin = textBox1.Text;
            String uPassword = textBox2.Text;
            
            UserLogin userLogin = new UserLogin(uLogin, uPassword);

            if (UserLogin.isLogin)
            {
                Form3 form3 = new Form3();
                this.Hide();
                form3.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Login yoki parol xato.");
                textBox1.Text = "";
                textBox2.Text = "";
            }




        }
    }
}
