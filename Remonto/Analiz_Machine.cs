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
    public partial class Analiz_Machine : Form
    {
        Model1 db = new Model1();
        public Analiz_Machine()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                chart1.Series[0].Points.Clear();
                DateTime min = DateTime.MinValue;
                if (dateTimePicker3.Enabled == true)
                    min = dateTimePicker3.Value;
                DateTime max = DateTime.MaxValue;
                if (dateTimePicker4.Enabled == true)
                    max = dateTimePicker4.Value;
                List<MachineReferenceBook> mac = db.MachineReferenceBooks
                    .Include(n => n.Machine)
                    .Where(m => m.DateAdd >= min)
                    .Where(m => m.DateAdd <= max)
                    .Take(Convert.ToInt32(numericUpDown2.Value))
                    .ToList();
                mac = mac.OrderBy(m => m.Machine.Count).ToList();
                foreach (MachineReferenceBook ma in mac)
                {
                    chart1.Series[0].Points.AddXY("Марка: " + ma.Mark + "; Название: " + ma.Name, ma.Machine.Count());
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Ошибка((");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                chart2.Series[0].Points.Clear();
                DateTime min = DateTime.MinValue;
                if (dateTimePicker2.Enabled == true)
                    min = dateTimePicker2.Value;
                DateTime max = DateTime.MaxValue;
                if (dateTimePicker1.Enabled == true)
                    max = dateTimePicker1.Value;
                List<MachineReferenceBook> mac = db.MachineReferenceBooks
                    .Include(n => n.Machine.Select(z => z.Repairs))
                    .Where(m => m.DateAdd >= min)
                    .Where(m => m.DateAdd <= max)
                    .Take(Convert.ToInt32(numericUpDown1.Value))
                    .ToList();
                mac = mac.OrderBy(m => m.Machine.Count).ToList();
                foreach (MachineReferenceBook ma in mac)
                {
                    int count = 0;
                    foreach (Machine m in ma.Machine)
                    {
                        count = count + m.Repairs.Count;
                    }
                    chart2.Series[0].Points.AddXY("Марка: " + ma.Mark + "; Название: " + ma.Name, count);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Не работает :(");
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
                dateTimePicker4.Enabled = true;
            }
            else if (checkBox3.Checked == false)
            {
                dateTimePicker4.Enabled = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                dateTimePicker2.Enabled = true;
            }
            else if (checkBox4.Checked == false)
            {
                dateTimePicker2.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                dateTimePicker1.Enabled = true;
            }
            else if (checkBox2.Checked == false)
            {
                dateTimePicker1.Enabled = false;
            }
        }
    }
}
