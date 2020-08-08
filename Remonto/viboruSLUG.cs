using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labo4ka7
{
    public partial class viboruSLUG : Form
    {
        public List<RepairsReferenceBook> uslugiAdd = new List<RepairsReferenceBook>();
        public List<RepairsReferenceBook> uslugiDell = new List<RepairsReferenceBook>();
        public List<RepairsReferenceBook> uslugaPerenos = new List<RepairsReferenceBook>();
        public delegate void initializeUslugi(List<RepairsReferenceBook> _uslugi);
        initializeUslugi del;
        public void RegisterHandler(initializeUslugi _del)
        {
            del = _del;
        }
        public viboruSLUG()
        {
            InitializeComponent();
            comboBox10.SelectedIndex = 3;
            comboBox9.SelectedIndex = 1;
            this.TopMost = true;
            button7_Click(null, null);
            button16_Click(null, null);
        }
        public void RegisterList(List<RepairsReferenceBook> _uslugaPerenos)
        {
            uslugaPerenos = _uslugaPerenos;
        }
        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button40_Click(object sender, EventArgs e)
        {

        }

        private void button37_Click(object sender, EventArgs e)
        {

        }

        private void label68_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button46_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {

        }
        public void InIsDatagrid(DataGridView d)
        {
            try
            {
                string[] vibran = Convert.ToString(d.CurrentCellAddress).Split(',');
                vibran[0] = vibran[0].Replace("{X=", "");
                vibran[1] = vibran[1].Replace("Y=", "");
                vibran[1] = vibran[1].Replace("}", "");
                int[] vibranRazdelen = new int[2];
                vibranRazdelen[0] = Convert.ToInt32(vibran[0]);
                vibranRazdelen[1] = Convert.ToInt32(vibran[1]);
                int id = Convert.ToInt32(d[0, vibranRazdelen[1]].Value);
                RepairsReferenceBook usluga = new RepairsReferenceBook();
                Uslugi poisk = new Uslugi();
                usluga = poisk.FindByIdmac(id, true);
                bool itog = true ;
                foreach(RepairsReferenceBook r in uslugiAdd)
                {
                    if (r.ID == usluga.ID)
                    {
                        itog = false;
                    }
                }
                if (itog == true)
                {
                    uslugiAdd.Add(usluga);
                    for (int y = 0; y < d.ColumnCount; y++)
                    {
                        d[y, vibranRazdelen[1]].Style.BackColor = Color.Green;
                    }
                }
                else if (itog == false)
                {
                    uslugiAdd.RemoveAll(m => m.ID == usluga.ID);
                    for (int y = 0; y < d.ColumnCount; y++)
                    {
                        d[y, vibranRazdelen[1]].Style.BackColor = Color.White;
                    }
                }
            }
            catch (Exception)
            {
                
            }
        }
        public void InitializeMac(string sorting, string sortingA, Machine filtering, DateTime MinData, DateTime MaxData, DateTime MinYear, DateTime MaxYear, int count, int page)
        {
            try
            {
                //dataGridView8.Rows.Clear();
                Stanok stanok = new Stanok();
                List<Machine> Machine = stanok.GetListMachine(sorting, sortingA, filtering, MinData, MaxData, MinYear, MaxYear, count, page, true);
                foreach (Machine mac in Machine)
                {
                 //   dataGridView8.Rows.Add(mac.ID, mac.YerOfIssue.Date.Year, mac.person.Where(z => z.Status == "Клиент").FirstOrDefault().FIO, mac.UploadDate, mac.person.Where(z => z.Status == "Менеджер").FirstOrDefault().FIO, mac.MachineReferenceBook.Name);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось загрузить список станков");
            }
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RepairsReferenceBook usluga = new RepairsReferenceBook();
            if (textBox1.Text != "")
                usluga.ServiceName = textBox1.Text;
            if (textBox2.Text != "")
                usluga.DescriptionIOfService = textBox2.Text;
            if (textBox3.Text != "")
                usluga.price = Convert.ToSingle(textBox3.Text);
            int page = Convert.ToInt32(numericUpDown1.Value);
            int count = Convert.ToInt32(numericUpDown2.Value);
            DateTime MinDAte = DateTime.MinValue;
            if (dateTimePicker1.Enabled == true)
                MinDAte = dateTimePicker1.Value;
            DateTime MaxDate = DateTime.MinValue;
            if (dateTimePicker2.Enabled == true)
                MaxDate = dateTimePicker2.Value;
            InitializeUslugi(comboBox10.Text, comboBox9.Text, usluga, MaxDate, MinDAte, count, page);
            uslugiAdd.Clear();
        }
        public void InitializeUslugi(string sorting, string sortingA, RepairsReferenceBook filtering, DateTime maxDate, DateTime MinDate, int count, int page)
        {
            try
            {
                dataGridView4.Rows.Clear();
                Uslugi uslugaAdd = new Uslugi();
                List<RepairsReferenceBook> listRepa = uslugaAdd.GetListUslugi(sorting, sortingA, filtering, MinDate, maxDate, count, page, true);
                foreach (RepairsReferenceBook repairs in listRepa)
                {
                    dataGridView4.Rows.Add(repairs.ID, repairs.ServiceName, repairs.price, repairs.AddDate, repairs.person.FirstOrDefault().FIO);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось загрузить услуги");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel7.Visible = true;
        }

        private void panel7_MouseLeave(object sender, EventArgs e)
        {
  
        }

        private void dataGridView4_DoubleClick(object sender, EventArgs e)
        {
             InIsDatagrid(dataGridView4);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach(RepairsReferenceBook rep in uslugiAdd)
            {
                if (uslugaPerenos.Find(m => m.ID == rep.ID) == null)
                    uslugaPerenos.Add(rep);
            }
            button16_Click(null, null);
           // del.Invoke(uslugaPerenos);

        }

        private void button16_Click(object sender, EventArgs e)
        {
            try
            {
                RepairsReferenceBook usluga = new RepairsReferenceBook();
               // if (textBox11.Text != "")
                    usluga.ServiceName = textBox11.Text;
                //if (textBox12.Text != "")
                    usluga.DescriptionIOfService = textBox12.Text;
                if (textBox10.Text != "")
                    usluga.price = Convert.ToSingle(textBox10.Text);
                int page = Convert.ToInt32(numericUpDown11.Value);
                int count = Convert.ToInt32(numericUpDown7.Value);
                DateTime MinDAte = DateTime.MinValue;
                if (dateTimePicker5.Enabled == true)
                    MinDAte = dateTimePicker5.Value;
                DateTime MaxDate = DateTime.MinValue;
                if (dateTimePicker6.Enabled == true)
                    MaxDate = dateTimePicker6.Value;

                dataGridView1.Rows.Clear();
                Uslugi uslugaAdd = new Uslugi();
                List<RepairsReferenceBook> listRepa = new List<RepairsReferenceBook>();
                listRepa = uslugaPerenos
                .Where(m => m.ServiceName.StartsWith(usluga.ServiceName) || usluga.ServiceName == "")
                .Where(m => m.DescriptionIOfService.StartsWith(usluga.DescriptionIOfService) || usluga.DescriptionIOfService == "")
                .Where(m => m.price == usluga.price || usluga.price == 0)
                .Where(z => z.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                .Where(z => z.AddDate >= MinDAte || MinDAte == DateTime.MinValue)
                .OrderByDescending(i => i.AddDate)
                .Skip((count * (page - 1)))
                .Take(count)
                .ToList();
                foreach (RepairsReferenceBook repairs in listRepa)
                {
                    dataGridView1.Rows.Add(repairs.ID, repairs.ServiceName, repairs.price, repairs.AddDate);
                }
                if (dataGridView1.Rows.Count != 0)
                Cena();
                uslugiDell.Clear();
            }
            catch(Exception)
            {
               MessageBox.Show("Не удалось загрузить услуги");
           }
        }
        public void Cena()
        {
            float stoimost = 0;
            
            for (int m = 0; m < dataGridView1.RowCount; m ++)
            {
                stoimost = stoimost + Convert.ToSingle(dataGridView1[2, m].Value);
            }
            textBox5.Text = Convert.ToString(stoimost);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel13.Visible = true;
        }

        private void panel13_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel13.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            panel7.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (RepairsReferenceBook rep in uslugiDell)
            {
                uslugaPerenos.RemoveAll(m => m.ID == rep.ID);
            }
            button16_Click(null, null);
            Cena();
        }
        public void delIzList(DataGridView d)
        {
            try
            {
                string[] vibran = Convert.ToString(d.CurrentCellAddress).Split(',');
                vibran[0] = vibran[0].Replace("{X=", "");
                vibran[1] = vibran[1].Replace("Y=", "");
                vibran[1] = vibran[1].Replace("}", "");
                int[] vibranRazdelen = new int[2];
                vibranRazdelen[0] = Convert.ToInt32(vibran[0]);
                vibranRazdelen[1] = Convert.ToInt32(vibran[1]);
                int id = Convert.ToInt32(d[0, vibranRazdelen[1]].Value);
                RepairsReferenceBook usluga = new RepairsReferenceBook();
                Uslugi poisk = new Uslugi();
                usluga = poisk.FindByIdmac(id, true);
                bool itog = true;
                foreach (RepairsReferenceBook r in uslugiDell)
                {
                    if (r.ID == usluga.ID)
                    {
                        itog = false;
                    }
                }
                if (itog == true)
                {
                    uslugiDell.Add(usluga);
                    for (int y = 0; y < d.ColumnCount; y++)
                    {
                        d[y, vibranRazdelen[1]].Style.BackColor = Color.Green;
                    }
                }
                else if (itog == false)
                {
                   
                    uslugiDell.RemoveAll(m => m.ID == usluga.ID);
                    for (int y = 0; y < d.ColumnCount; y++)
                    {
                        d[y, vibranRazdelen[1]].Style.BackColor = Color.White;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            delIzList(dataGridView1);
        }

        private void numericUpDown11_ValueChanged(object sender, EventArgs e)
        {
            label11.Text = Convert.ToString(numericUpDown11.Value);
        }

        private void button43_Click(object sender, EventArgs e)
        {
            
            numericUpDown11.Value++;
            button16_Click(null, null);
        }

        private void button41_Click(object sender, EventArgs e)
        {
            if (numericUpDown11.Value > 1)
            {
                numericUpDown11.Value--;
                button16_Click(null, null);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (numericUpDown1.Value > 1)
            {
                numericUpDown1.Value--;
                button7_Click(null, null);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numericUpDown1.Value++;
            button7_Click(null, null);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            label9.Text = Convert.ToString(numericUpDown1.Value);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            del.Invoke(uslugaPerenos);
            this.Close();

        }

        private void viboruSLUG_Load(object sender, EventArgs e)
        {
            button16_Click(null, null);
        }
    }
}
