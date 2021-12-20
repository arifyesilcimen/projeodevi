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
    public partial class Form5 : Form
    {
        string baglantiSatiri = "Server=localhost;User ID=postgres;password=9745;Database=kiroe";
        NpgsqlConnection conn;
        private string sql = null;
        private NpgsqlCommand cmd;
        private DataTable dt;
        int adet = 0;

        public Form5()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
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
                    MessageBox.Show("Urun eklenemedi!");
                }

                conn.Close();

            }
            catch (Exception ex)
            {
                conn.Close();

                //MessageBox.Show("Hata!");
            }


            adet += 1;
            string ad = textBox1.Text;
            string soyad = textBox2.Text;
            


            string[] bilgiler = { ad, soyad, Convert.ToString(adet) };

            listView1.Items.Add(new ListViewItem(bilgiler));
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(baglantiSatiri);


            listView1.View = View.Details;
            listView1.FullRowSelect = true;

            listView1.Columns.Add("Kitap Adi", 150);
            listView1.Columns.Add("Yazari", 150);
            listView1.Columns.Add("Adet", 150);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            try
            {
                conn.Open();
                sql = @"SELECT * from UrunSil(:ad, :yazar)";
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
                    MessageBox.Show("Urun silinemedi!");
                }

                conn.Close();

            }
            catch (Exception ex)
            {
                conn.Close();

                //MessageBox.Show("Hata!");
            }

            
            adet -= 1;
            textBox1.Clear();
            textBox2.Clear();
            string ad = textBox1.Text;
            string soyad = textBox2.Text;



            string[] bilgiler = { ad, soyad, Convert.ToString(adet) };

            listView1.Items.Add(new ListViewItem(bilgiler));

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
