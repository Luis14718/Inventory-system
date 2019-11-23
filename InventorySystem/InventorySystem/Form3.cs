using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventorySystem
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_obejctClick(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.TopLevel = false;
            frm.Visible = true;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            tabControl1.TabPages[0].Controls.Add(frm);
            Form5 frm2 = new Form5();
            frm2.TopLevel = false;
            frm2.Visible = true;
            frm2.FormBorderStyle = FormBorderStyle.None;
            frm2.Dock = DockStyle.Fill;
            tabControl1.TabPages[1].Controls.Add(frm2);

            Form6 frm3 = new Form6();
            frm3.TopLevel = false;
            frm3.Visible = true;
            frm3.FormBorderStyle = FormBorderStyle.None;
            frm3.Dock = DockStyle.Fill;
            tabControl1.TabPages[2].Controls.Add(frm3);
            Form7 frm4 = new Form7();
            frm4.TopLevel = false;
            frm4.Visible = true;
            frm4.FormBorderStyle = FormBorderStyle.None;
            frm4.Dock = DockStyle.Fill;
            tabControl1.TabPages[3].Controls.Add(frm4);
        }
    }
}
