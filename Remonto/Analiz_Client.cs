using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace Labo4ka7
{
    public partial class Analiz_Client : Form
    {
        Model1 db = new Model1();
        public Analiz_Client()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                chart1.Series[0].Points.Clear();
                DateTime min = new DateTime();
                min = DateTime.MinValue;
                if (dateTimePicker3.Enabled == true)
                    min = dateTimePicker3.Value;
                DateTime max = DateTime.MaxValue;
                if (dateTimePicker4.Enabled == true)
                {
                    max = dateTimePicker4.Value;
                }
                List<person> clients = db.person
                    .Include(c => c.Machine)
                    .Where(x => x.DateAdd >= min)
                    .Where(c => c.DateAdd <= max)
                    .Where(t => t.Status == "Клиент")
                    .Take(Convert.ToInt32(numericUpDown2.Value))
                    .ToList();
                clients = clients
                    .OrderBy(m => m.Machine.Count)
                    .ToList();
                foreach (person p in clients)
                {
                    chart1.Series[0].Points.AddXY(p.FIO, p.Machine.Count);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Попытка проникнуть в 4е измерение провалена !");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dateTimePicker3.Enabled = true;
            }
           else if (checkBox1.Checked == false)
            {
                dateTimePicker3.Enabled = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                dateTimePicker3.Enabled = true;
            }
            else if (checkBox3.Checked == false)
            {
                dateTimePicker3.Enabled = false;
            }
        }
    }
}
