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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
         HotelDbEntities conn= new HotelDbEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            string kul = textBox1.Text;
            string sifre = textBox2.Text;
            var tablo=conn.Admin.Where(x=>x.UserName==kul && x.UserPassword==sifre).FirstOrDefault();
            if (tablo!=null)
            {
                AnaForm anaForm = new AnaForm();
                anaForm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ve Şifre Hatalı");
            }

        }
    }
}
