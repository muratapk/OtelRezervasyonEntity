using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelRezervasyon
{
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void ekleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.MdiParent= this;
            form1.Show();
        }

        private void ekeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Menuler menuler = new Menuler();
            menuler.MdiParent = this;
            menuler.Show(); 
        }
    }
}
