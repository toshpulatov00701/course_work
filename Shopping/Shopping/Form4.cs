using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shopping
{
    public partial class Form4 : Form
    {
        public string oldPhotoName = "";
        public string oldPhotoPath = "";
        public string newPhotoName = "";
        public Form4()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label11.Text = DateTime.Now.ToString("dd-MM-yyyy");
            label12.Text = DateTime.Now.ToString("H:mm:ss");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            this.Hide();
            form3.ShowDialog();
            this.Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            ControlViloyatlar controlViloyatlar = new ControlViloyatlar();

            DataTable dataTable = controlViloyatlar.getDataViloyatlar();
            foreach(DataRow row in dataTable.Rows)
            {
                comboBox2.Items.Add(row["nomi"].ToString());
            }

            pictureBox1.Image = Image.FromFile("../../Resources/users/" + UserLogin.userPhoto);
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            uploadDataToGridView();
        }
        public void uploadDataToGridView()
        {
            ControlXodimlar controlXodimlar = new ControlXodimlar();
            dataGridView1.DataSource = controlXodimlar.getDataXodimlar();
            dataGridView1.Columns["id"].Width = 50;
            dataGridView1.Columns["rasm"].Visible = false;
            dataGridView1.Columns["fLogin"].Visible = false;
            dataGridView1.Columns["fPassword"].Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string ism = textBox2.Text.Trim();
            string familiya = textBox3.Text.Trim();
            string telefon = textBox4.Text.Trim();
            int maosh = int.Parse(textBox5.Text.Trim());
            //string rasm = "rasm";
            string rol = comboBox1.SelectedItem.ToString();
            ControlViloyatlar controlViloyatlar = new ControlViloyatlar();
            int viloyat_id = controlViloyatlar.getIdByName(comboBox2.SelectedItem.ToString());
            string login = textBox7.Text.Trim();
            string parol = textBox8.Text.Trim();
            uploadPoto();
            // textBoxlarni bo'sh bo'lmasligini tekshiramiz
            if (ism != "" && familiya != "" && telefon != "" &&  maosh != 0 && newPhotoName != "" &&  rol != "" &&  login != "" &&  parol != "" && viloyat_id != 0)
            {
                Xodimlar xodimObj = new Xodimlar(ism, familiya, telefon, maosh, newPhotoName, rol,viloyat_id, login, parol);
                ControlXodimlar controlXodim = new ControlXodimlar();
                if (controlXodim.InsertXodim(xodimObj))
                {
                    MessageBox.Show("Ma'lumot kiritildi.");
                    clearBoxs();
                }
                else
                {
                    MessageBox.Show("Ma'lumot kiritilmadi.");
                }
            }
            else
            {
                MessageBox.Show("Barcha maydonlar to'ldirilishi shart.");
            }
        }
        public void uploadPoto()
        {
            if(oldPhotoPath != "") {
                newPhotoName = "user_";
                string photoType = oldPhotoName.Substring(oldPhotoName.LastIndexOf('.'));
                newPhotoName += (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();
                newPhotoName = newPhotoName.Remove(newPhotoName.IndexOf('.'), 1);
                newPhotoName += photoType;

                File.Copy(oldPhotoPath, @"..\..\Resources\users\" + newPhotoName);
            }
            
        }
        // ma'lumotlar saqlangandan keyin textBoxlarni tozalaymiz.
        public void clearBoxs()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            //textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            comboBox1.SelectedIndex = 0;
            newPhotoName = "";
            oldPhotoName = "";
            oldPhotoPath = "";
            pictureBox2.Image = null;
            uploadDataToGridView();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Rasm yuklaymiz
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(pictureBox2 != null)
            {
                openFileDialog.Filter = "(*.jpg;*.jpeg;*.png;*.bmp;)|*.jpg;*.jpeg;*.png;*.bmp;";
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    oldPhotoName = openFileDialog.SafeFileName;
                    oldPhotoPath = openFileDialog.FileName;
                    pictureBox2.Image = Image.FromFile(oldPhotoPath);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //delete
            //dataGridView'da tanlangan elementni o'chiradi
            if(textBox1.Text != "")
            {
                int id = int.Parse(textBox1.Text);
                //rasmni o'chirish uchun
                string rasm = pictureBox2.Tag.ToString();
                DialogResult dr = MessageBox.Show("Element o'chirilsinmi?", "O'chirish", MessageBoxButtons.YesNo);
                if(dr == DialogResult.Yes)
                {
                    ControlXodimlar controlXodimlar = new ControlXodimlar();
                    if (controlXodimlar.deleteData(id))
                    {
                        MessageBox.Show("Element o'chirildi.");
                        try
                        {
                            if (File.Exists(@"..\..\Resources\users\" + rasm))
                            {
                                File.Delete(@"..\..\Resources\users\" + rasm);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        clearBoxs();
                    }
                    else
                    {
                        MessageBox.Show("Element o'chirildi.");
                    }
                }
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["ism"].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["familiya"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["telefon"].FormattedValue.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["maosh"].FormattedValue.ToString();

                //pictureBox2.Image = Image.FromFile(@"..\..\Resources\users\" + dataGridView1.Rows[e.RowIndex].Cells["rasm"].FormattedValue.ToString());
                if(UserLogin.Username == dataGridView1.Rows[e.RowIndex].Cells["fLogin"].FormattedValue.ToString())
                {
                    pictureBox2.Image = pictureBox1.Image;
                }
                else
                {
                    using (FileStream fs = new FileStream(@"..\..\Resources\users\" + dataGridView1.Rows[e.RowIndex].Cells["rasm"].FormattedValue.ToString(), FileMode.Open))
                    {
                        Image image = Image.FromStream(fs);
                        pictureBox2.Image = image;
                    }
                }
                

                pictureBox2.Tag = dataGridView1.Rows[e.RowIndex].Cells["rasm"].FormattedValue.ToString();

                comboBox1.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["rol"].FormattedValue.ToString();
                comboBox2.SelectedItem = dataGridView1.Rows[e.RowIndex].Cells["viloyat"].FormattedValue.ToString();
                
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["fLogin"].FormattedValue.ToString();
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["fPassword"].FormattedValue.ToString();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(textBox1.Text != "")
            {
                int id = int.Parse(textBox1.Text);
                string ism = textBox2.Text;
                string familiya = textBox3.Text;
                string telefon = textBox4.Text;
                int maosh = int.Parse(textBox5.Text);
                
                string rasm = pictureBox2.Tag.ToString();
                //boshqa rasm tanlanganda undan avvalgisini o'chiramiz
                if(oldPhotoName != "")
                {
                    try
                    {
                        if(File.Exists(@"..\..\Resources\users\" + rasm))
                        {
                            File.Delete(@"..\..\Resources\users\" + rasm);
                        }
                    }catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    uploadPoto();
                    rasm = newPhotoName;
                }

                string rol = comboBox1.SelectedItem.ToString();
                ControlViloyatlar controlViloyatlar = new ControlViloyatlar();
                int viloyat_id = controlViloyatlar.getIdByName(comboBox2.SelectedItem.ToString());
                string login = textBox7.Text;
                string parol = textBox8.Text;

                ControlXodimlar controlXodimlar = new ControlXodimlar();
                if (controlXodimlar.updateXodim(new Xodimlar(id, ism, familiya, telefon, maosh, rasm, rol,viloyat_id, login, parol)))
                {
                    MessageBox.Show("Ma'lumot o'zgardi.");
                    clearBoxs();
                }
                else
                {
                    MessageBox.Show("Ma'lumot o'zgarmadi.");
                }



            }
            else
            {
                MessageBox.Show("Element tanlanmagan.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string keyText = textBox9.Text.Trim();
            if(keyText != "")
            {
                ControlXodimlar controlXodimlar = new ControlXodimlar();
                dataGridView1.DataSource = controlXodimlar.searchData(keyText);
                dataGridView1.Columns["id"].Width = 50;
                dataGridView1.Columns["rasm"].Visible = false;
                dataGridView1.Columns["fLogin"].Visible = false;
                dataGridView1.Columns["fPassword"].Visible = false;
            }
            else
            {
                MessageBox.Show("Qidiruv maydoni bo'sh bo'lmasligi kerak.");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            clearBoxs();
        }
    }
}
