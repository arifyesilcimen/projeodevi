using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace WindowsFormsApp18
{
    public partial class Form2 : Form
    {
        int fiyat = 20;
        string baglantiSatiri = "Server=localhost;User ID=postgres;password=1234;Database=kitaproje";
        NpgsqlConnection conn;
        private string sql = null;
        private NpgsqlCommand cmd;
        private DataTable dt;


        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            try
            {
                conn.Open();
                sql = @"SELECT * from UrunAra(:ad, :yazar)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("ad", textBox1.Text);
                cmd.Parameters.AddWithValue("yazar", textBox2.Text);

                int result = (int)cmd.ExecuteScalar();

                conn.Close();

                if (result == 1)
                {
                    //Form1 formKapa = new Form1();
                    //formKapa.Close();
                    //Form2 form2 = new Form2();
                    //form2.Show();
                }
                else
                {
                    MessageBox.Show("Bilgilerinizi kontrol edip tekrar giriş yapiniz!");
                }

                conn.Close();

            }
            catch (Exception ex)
            {
                conn.Close();

                //MessageBox.Show("Hata!");
            }

            string ad = textBox1.Text;
            string soyad = textBox2.Text;
            

            string[] bilgiler = { ad, soyad, Convert.ToString(fiyat) };

            listView1.Items.Add(new ListViewItem(bilgiler));


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(baglantiSatiri);

            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Kitap Adi", 150);
            listView1.Columns.Add("Yazari", 150);
            listView1.Columns.Add("Fiyat", 150);
        
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fiyat += 0;
            textBox3.Text = Convert.ToString(fiyat);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
