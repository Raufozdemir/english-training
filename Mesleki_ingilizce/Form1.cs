using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace Mesleki_ingilizce
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public void kullan()
        {
            if (comboBox1.Text == "Assembler")
            {
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Assembler ORDER BY rnd(-(1000*Kimlik)*time())", baglanti);
                OleDbDataReader rd = komut.ExecuteReader();

                while (rd.Read())
                {
                    textBox1.Text = rd["cumle"].ToString().ToLower();
                    textBox3.Text = rd["meal"].ToString();

                }
            }
            else if (comboBox1.Text == "Cache")
            {
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Cache ORDER BY rnd(-(1000*Kimlik)*time())", baglanti);
                OleDbDataReader rd = komut.ExecuteReader();

                while (rd.Read())
                {
                    textBox1.Text = rd["cumle"].ToString().ToLower();
                    textBox3.Text = rd["meal"].ToString();

                }
            }
            else if (comboBox1.Text == "Ram")
            {
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Ram ORDER BY rnd(-(1000*Kimlik)*time())", baglanti);
                OleDbDataReader rd = komut.ExecuteReader();

                while (rd.Read())
                {
                    textBox1.Text = rd["cumle"].ToString().ToLower();
                    textBox3.Text = rd["meal"].ToString();

                }
            }

            else if (comboBox1.Text == "Operating")
            {
                OleDbCommand komut = new OleDbCommand("SELECT * FROM Operating ORDER BY rnd(-(1000*Kimlik)*time())", baglanti);
                OleDbDataReader rd = komut.ExecuteReader();

                while (rd.Read())
                {
                    textBox1.Text = rd["cumle"].ToString().ToLower();
                    textBox3.Text = rd["meal"].ToString();

                }
            }
            else if (comboBox1.Text == "İmage")
            {
                OleDbCommand komut = new OleDbCommand("SELECT * FROM İmage ORDER BY rnd(-(1000*Kimlik)*time())", baglanti);
                OleDbDataReader rd = komut.ExecuteReader();

                while (rd.Read())
                {
                    textBox1.Text = rd["cumle"].ToString().ToLower();
                    textBox3.Text = rd["meal"].ToString();

                }
            }
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=mesleki.accdb");
        private void Form1_Load(object sender, EventArgs e)
           
        {
            textBox3.Visible = false;
            button5.Visible = false;
            button6.Visible = false;
            baglanti.Open();
            DataTable dt = baglanti.GetSchema("Tables");
            for (int i = 0; i < dt.Rows.Count; i++) //Combobox için olan kısım
            {
                if (dt.Rows[i]["TABLE_TYPE"].ToString() == "TABLE")
                    comboBox1.Items.Add(dt.Rows[i]["TABLE_NAME"]);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            kullan();
          

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String a, b;
            a = textBox2.Text.ToUpper();
            b = textBox3.Text.ToUpper();
            textBox2.Clear();
            

            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Bölüm Seçiniz");
            }
            else
                if (a.Trim() == b.Trim())
            {
                button6.Visible = true;
                button5.Visible = false;
              
               
                
                kullan();

            }
            else if (a.Trim() != b.Trim())
            {
                button6.Visible = false;
                button5.Visible = true;
               
               


            }



        }

        private void button4_Click(object sender, EventArgs e)
        {
            String a, b;
            a = textBox2.Text.ToUpper();
            b = textBox3.Text.ToUpper();
            textBox2.Text = b;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            kullan();
            textBox2.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string ekle = "insert into Complete(cumle,meal) values (@cumle,@meal)";
            OleDbCommand komut = new OleDbCommand(ekle, baglanti);
            komut.Parameters.AddWithValue("@cumle", textBox1.Text);
            komut.Parameters.AddWithValue("@meal", textBox3.Text);
            komut.ExecuteNonQuery();
            string silmeSorgusu = "DELETE from "+comboBox1.Text+" where meal=@meal";
            OleDbCommand silKomutu = new OleDbCommand(silmeSorgusu, baglanti);
            silKomutu.Parameters.AddWithValue("@meal", textBox3.Text);
            silKomutu.ExecuteNonQuery();
            textBox1.Clear();
            textBox2.Clear();
            kullan();


        }

        private void button7_Click(object sender, EventArgs e)
        {
            Complete frm = new Complete();
            frm.Show();
            
            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                
                button1.PerformClick();
            

            }
            if (e.KeyCode == Keys.Up)
            {
                
                button4.PerformClick();

            }
            if (e.KeyCode == Keys.Right)
            {

                button2.PerformClick();

            }
            if (e.KeyCode == Keys.Left)
            {
                button3.PerformClick();
            }
        }

     
    }
}
