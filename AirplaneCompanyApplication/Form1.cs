using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using AirplaneCompanyApplication.Entity;

namespace AirplaneCompanyApplication
{
    public partial class Form1 : Form
    {
        //SqlConnection connection = new SqlConnection("Data Source=LAPTOP-B27S2D4O\\SQLEXPRESS;Initial Catalog=AirplaneServices;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Context context = new Context();
            context.Database.CreateIfNotExists();
  
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mainpanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //SqlDataAdapter adapter = new SqlDataAdapter("select * from Passenger", connection);
            //DataSet dataset = new DataSet();
            //adapter.Fill(dataset);
            //dataGridView1.DataSource = dataset.Tables[0];

            Context context = new Context();
            int FlightID = Int32.Parse(textBox10.Text);
            var query = from q in context.Passenger
                        join p in context.Person on q.PersonID equals p.PersonID
                        where q.FlightID == FlightID

                         select new
                        {
                            q.PassengerID,
                            q.PersonID,
                            q.FlightID,
                            q.PNR,
                            q.SeatNumber,
                            p.ID,
                            p.Name,
                            p.Surname,
                            p.Gender
                        };
            dataGridView1.DataSource = query.ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Context context = new Context();
            context.Airplane.Add(new Airplane()
            {
                Brand = textBox12.Text,
                Name = textBox11.Text,
                Capacity = Int32.Parse(textBox7.Text)
            });

            textBox11.Text = "";
            textBox7.Text = "";
            textBox12.Text = "";
            context.SaveChanges();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Context context = new Context();
            int airplaneid = Int32.Parse(textBox3.Text);
            var cap = from c in context.Airplane
                      where c.AirplaneID == airplaneid
                      select c.Capacity;

            int capacity = -1;
            foreach (var c in cap)
                capacity = Int32.Parse(c.ToString());
            context.Flight.Add(new Flight()
            {
                AirplaneID = Int32.Parse(textBox3.Text),
                FromFlight = textBox1.Text,
                ToFlight = textBox2.Text,
                Date = DateTime.Parse(dateTimePicker1.Text),
                Hour = DateTime.Parse(dateTimePicker2.Text),
                Price = Int32.Parse(textBox6.Text),
                EmptySeat = capacity
            });
            textBox3.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox6.Text = "";
            context.SaveChanges();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
