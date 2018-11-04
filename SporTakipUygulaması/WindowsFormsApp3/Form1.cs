using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Resimleme Resimleme = new Resimleme();
        SuperligTakımDataContext dc = new SuperligTakımDataContext();
        List<UserControl1> TIL = new List<UserControl1>();

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.IndianRed;
            panel2.BackColor = Color.Transparent;
            panel3.BackColor = Color.Transparent;
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Transparent;
            panel2.BackColor = Color.IndianRed;
            panel3.BackColor = Color.Transparent;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.Transparent;
            panel2.BackColor = Color.Transparent;
            panel3.BackColor = Color.IndianRed;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var sor = from a in dc.Takımlar
                      orderby a.Puan
                      select a;
            foreach(var deg in sor)
            {
                Yerlestir(Resimleme.ResimGetirme(deg.Logo.ToArray()), deg.Takım_Name, Convert.ToString(deg.Oyun), Convert.ToString(deg.Galibiyet), Convert.ToString(deg.Puan));
            }
        }
        public void Yerlestir(Image resim,string takim,string oyun,string galibiyet,string puan)
        {
            UserControl1 it = new UserControl1();
            it.bunifuPictureBox1.Image = resim;
            it.label1.Text = takim;
            it.label2.Text = oyun;
            it.label3.Text = galibiyet;
            it.label4.Text = puan;
            it.Dock = DockStyle.Top;
            TIL.Add(it);
            panel4.Controls.Add(it);
        }
    }
}
