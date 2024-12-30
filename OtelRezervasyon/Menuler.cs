using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OtelRezervasyon
{
    public partial class Menuler : Form
    {
        public Menuler()
        {
            InitializeComponent();
        }
        HotelDbEntities conn = new HotelDbEntities();
        private void button1_Click(object sender, EventArgs e)
        {
            Menu yeni = new Menu();
            yeni.MenuName = textBox1.Text;
            yeni.MenuPrice = Convert.ToDecimal(textBox2.Text);
            conn.Menu.Add(yeni);
            conn.SaveChanges();
            MessageBox.Show("Kaydınızı Yapılmıştır");
            doldur();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int Id = Convert.ToInt16(textBox3.Text);
            var tablom = conn.Menu.Where(x => x.MenuId == Id).FirstOrDefault();
            tablom.MenuName = textBox1.Text;
            tablom.MenuPrice =Convert.ToDecimal(textBox2.Text);
            
            conn.SaveChanges();
            doldur();
            MessageBox.Show("Kayıt Düzeldi");
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
        private void doldur()
        {
            var liste=conn.Menu.ToList();
            dataGridView1.DataSource = liste;
        }

        private void Menuler_Load(object sender, EventArgs e)
        {
            doldur();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int satir = dataGridView1.CurrentRow.Index;
            //satir numarasını al
            textBox1.Text = dataGridView1.Rows[satir].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[satir].Cells[2].Value.ToString();
           
            textBox3.Text = dataGridView1.Rows[satir].Cells[0].Value.ToString();
        }
    }
}
