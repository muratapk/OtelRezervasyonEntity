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
    public partial class Bill_Form : Form
    {
        HotelDbEntities db = new HotelDbEntities();
        public Bill_Form()
        {
            InitializeComponent();
        }

        private void Bill_Form_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Lütfen Seçim Yapınız");
            comboBox1.SelectedIndex = 0;
            comboBox1.DataSource = db.Customer.ToList();
            comboBox1.ValueMember = "CustomerId";
            comboBox1.DisplayMember = "CustomerName";
            comboBox2.DataSource = db.Services.ToList();
            comboBox2.ValueMember = "ServiceId";
            comboBox2.DisplayMember = "ServiceName";
            comboBox3.DataSource = db.Rooms.ToList();
            comboBox3.ValueMember = "RoomId";
            comboBox3.DisplayMember = "RoomType";
            comboBox4.DataSource = db.lokanta.ToList();
            comboBox4.ValueMember = "lokantaId";
            comboBox4.DisplayMember = "lokantaId";
            comboBox5.DataSource = db.HotelService.ToList();
            comboBox5.ValueMember = "HotelServiceId";
            comboBox5.DisplayMember = "HotelServiceName";
            doldur();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Bill bill = new Bill();
            bill.CustomerId = Convert.ToInt16(comboBox1.SelectedValue);
            bill.ServiceId= Convert.ToInt16(comboBox2.SelectedValue);
            bill.RoomId= Convert.ToInt16(comboBox3.SelectedValue);  
            bill.LokantaId= Convert.ToInt16(comboBox4.SelectedValue);
            bill.HotelServiceId= Convert.ToInt16(comboBox5.SelectedValue);
            bill.payment = Convert.ToInt16(checkBox1.Checked); ;
            db.Bill.Add(bill);
            db.SaveChanges();
            MessageBox.Show("Kayıt Eklendi");
            doldur();
        }
        private void doldur()
        {
           // dataGridView1.DataSource = (from a in db.Bill select a).ToList();
            //dataGridView1.DataSource = db.Bill.ToList();
            //linq komut ile çalış komut
            var liste=(from a in db.Bill join b in db.Services on a.ServiceId equals b.ServiceId
                       join c in db.Customer on a.CustomerId equals c.CustomerId
                       join d in db.Rooms on a.RoomId equals d.RoomId join e in db.HotelService
                       on a.HotelServiceId equals e.HotelServiceId
                       select new {a.BillId,b.ServiceName, b.ServiceId, c.CustomerName,c.CustomerId,d.RoomId,d.RoomType,e.HotelServiceId,e.HotelServiceName}).ToList();
            dataGridView1.DataSource= liste;
        }
    }
}
