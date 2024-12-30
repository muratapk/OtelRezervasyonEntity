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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        HotelDbEntities conn=new HotelDbEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.UserName = textBox1.Text;
            admin.UserPassword = textBox2.Text;
            admin.Authority = comboBox1.Text;
            conn.Admin.Add(admin);  
            conn.SaveChanges();
            MessageBox.Show("Kayıt Edildi");
            doldur();

        }
        void doldur()
        {
            var tablom = conn.Admin.ToList();
            dataGridView1.DataSource = tablom;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            doldur();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int satir = dataGridView1.CurrentRow.Index;
            //satir numarasını al
            textBox1.Text = dataGridView1.Rows[satir].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[satir].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[satir].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.Rows[satir].Cells[0].Value.ToString();
            //id numarasını textbox3.text 
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt16(textBox3.Text);
            var tablom = conn.Admin.Where(x => x.UserId == Id).FirstOrDefault();
            conn.Admin.Remove(tablom);
            conn.SaveChanges();
            MessageBox.Show("Kayıt Silindi");
            doldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt16(textBox3.Text);
            var tablom = conn.Admin.Where(x => x.UserId == Id).FirstOrDefault();
            tablom.UserName = textBox1.Text;
            tablom.UserPassword = textBox2.Text;
            tablom.Authority = comboBox1.Text;
            conn.SaveChanges();
            doldur();
            MessageBox.Show("Kayıt Düzeldi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Boş Bırakamazsınız");
                textBox1.Focus();
                textBox1.BackColor = Color.Teal;
            }
            else
            {
                string usersearch = textBox1.Text;
                var tablo = conn.Admin.Where(x => x.UserName.Contains(usersearch)).ToList();
                dataGridView1.DataSource = tablo;
            }
          
        }
    }
}
