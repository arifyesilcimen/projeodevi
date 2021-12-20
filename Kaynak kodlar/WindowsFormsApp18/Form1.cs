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
    public partial class Form1 : Form
    {
        

        public Form1()
        {
            InitializeComponent();
        }

        string baglantiSatiri = "Server=localhost;User ID=postgres;password=Duru2016;Database=proje";
        NpgsqlConnection conn;
        private string sql = null;
        private NpgsqlCommand cmd;
        private DataTable dt;

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new NpgsqlConnection(baglantiSatiri);

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                sql = @"SELECT * from GirisKontrol(:mail, :sifre)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("mail", textBox1.Text);
                cmd.Parameters.AddWithValue("sifre", textBox2.Text);

                int result = (int)cmd.ExecuteScalar();

                conn.Close();
                
                if (result == 1)
                {
                    //Form1 formKapa = new Form1();
                    //formKapa.Close();
                    //Form2 form2 = new Form2();
                    //form2.Show();
                }
                else {
                    MessageBox.Show("Bilgilerinizi kontrol edip tekrar giriş yapiniz!");
                }

                conn.Close();

            }
            catch (Exception ex)
            {
                conn.Close();

                //MessageBox.Show("Hata!");
            }

            Form1 formKapa = new Form1();
            formKapa.Close();
            Form2 form2 = new Form2();
            form2.Show();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                sql = @"SELECT * from GirisKontrol(:mail, :sifre)";
                cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("mail", textBox1.Text);
                cmd.Parameters.AddWithValue("sifre", textBox2.Text);

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

            Form1 formKapa = new Form1();
            formKapa.Close();
            Form5 form5 = new Form5();
            form5.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Select()
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
