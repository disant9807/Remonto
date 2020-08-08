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
    public partial class Analiz_Repairs : Form
    {
        Model1 db = new Model1();
        public Analiz_Repairs()
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
                {
                    min = dateTimePicker3.Value;
                }
                DateTime max = DateTime.MaxValue;
                if (dateTimePicker4.Enabled == true)
                {
                    max = dateTimePicker4.Value;
                }
                List<Repairs> rep = db.Repairs
                    .Where(z => z.AddDate >= min)
                    .Where(x => x.AddDate <= max)
                    .Take(Convert.ToInt32(numericUpDown2.Value))
                    .ToList();
                rep = rep.OrderBy(m => (m.EndDate - m.StartDate)).ToList();
                foreach (Repairs r in rep)
                {
                    Machine mac = new Machine();
                    Stanok stan = new Stanok();
                    mac = stan.FindByIdmac(Convert.ToInt32(r.IDMachine), true);
                    MachineReferenceBook macs = mac.MachineReferenceBook;
                    DateTime start = r.StartDate.Date;
                    DateTime end = r.EndDate.Date;
                    int count = 0;
                    while (start != end)
                    {
                        start = start.AddDays(1);
                        if ((start.DayOfWeek != DayOfWeek.Saturday) && (start.DayOfWeek != DayOfWeek.Sunday)) count++;
                    }
                    chart1.Series[0].Points.AddXY(r.ID + "; Марка:" + macs.Mark + "; Название:" + macs.Name + "; Дата начала" + r.AddDate.Date, count);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Ошибка");
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                chart2.Series[0].Points.Clear();
                DateTime min = DateTime.MinValue;
                if (dateTimePicker2.Enabled == true)
                {
                    min = dateTimePicker2.Value;
                }
                DateTime max = DateTime.MaxValue;
                if (dateTimePicker1.Enabled == true)
                {
                    max = dateTimePicker1.Value;
                }
                List<Repairs> rep = db.Repairs
                    .Where(z => z.AddDate >= min)
                    .Where(x => x.AddDate <= max)
                    .Take(Convert.ToInt32(numericUpDown1.Value))
                    .ToList();
                rep = rep.OrderBy(m => m.price).ToList();
                foreach (Repairs r in rep)
                {
                    Machine mac = new Machine();
                    Stanok stan = new Stanok();
                    mac = stan.FindByIdmac(Convert.ToInt32(r.IDMachine), true);
                    MachineReferenceBook macs = mac.MachineReferenceBook;           
                    chart2.Series[0].Points.AddXY(r.ID + "; Марка:" + macs.Mark + "; Название:" + macs.Name + "; Дата начала" + r.AddDate.Date, r.price);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ошибка");
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
