using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mesleki_ingilizce
{
    public partial class Complete : Form
    {
        public Complete()
        {
            InitializeComponent();
        }
        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=mesleki.accdb");
        private void Complete_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand("SELECT * FROM Complete", baglanti);
            OleDbDataReader rd = komut.ExecuteReader();

            while (rd.Read())
            {
                listBox1.Items.Add(rd["cumle"].ToString().ToLower());
                listBox2.Items.Add(rd["meal"].ToString().ToLower());
                

            }
        }

        private void Complete_KeyDown(object sender, KeyEventArgs e)
        {
            Complete frm = new Complete();
            if (e.KeyCode == Keys.Escape)
            {
                frm.Visible = false;
            }
        }
    }
}
