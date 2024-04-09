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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void label1_MouseHover(object sender, EventArgs e)
        {
            // hover bo'lganda rangi o'zgarishi
            label1.ForeColor = Color.Red;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.FromArgb(247, 176, 21);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label11.Text = DateTime.Now.ToString("dd-MM-yyyy");
            label12.Text = DateTime.Now.ToString("H:mm:ss");
            pictureBox1.Image = Image.FromFile("../../Resources/users/" + UserLogin.userPhoto);
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Red;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.FromArgb(247, 176, 21);
        }

        private void label3_MouseHover(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Red;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.FromArgb(247, 176, 21);
        }

        private void label4_MouseHover(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Red;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.FromArgb(247, 176, 21);
        }

        private void label5_MouseHover(object sender, EventArgs e)
        {
            label5.ForeColor = Color.Red;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.FromArgb(247, 176, 21);
        }

        private void label6_MouseHover(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Red;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.FromArgb(247, 176, 21);
        }

        private void label7_MouseHover(object sender, EventArgs e)
        {
            label7.ForeColor = Color.Red;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.ForeColor = Color.FromArgb(247, 176, 21);
        }

        private void label8_MouseHover(object sender, EventArgs e)
        {
            label8.ForeColor = Color.Red;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.FromArgb(247, 176, 21);
        }

        private void label9_MouseHover(object sender, EventArgs e)
        {
            label9.ForeColor = Color.Red;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label9.ForeColor = Color.FromArgb(247, 176, 21);
        }

        private void label10_MouseHover(object sender, EventArgs e)
        {
            label10.ForeColor = Color.Red;
        }

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            label10.ForeColor = Color.FromArgb(247, 176, 21);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            this.Hide();
            form4.ShowDialog();
            this.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            ControlSavdolar controlSavdolar = new ControlSavdolar();
            label14.Text = controlSavdolar.getDayIncome().ToString();
            label15.Text = controlSavdolar.getMonthIncome().ToString();
            label17.Text = controlSavdolar.getYearIncome().ToString();

            ControlXodimlar controlXodimlar = new ControlXodimlar();
            label19.Text = controlXodimlar.countXodimlar().ToString();

            ControlKiyimlar controlKiyimlar = new ControlKiyimlar();
            label21.Text = controlKiyimlar.countKiyimlar().ToString();
        }
    }
}
