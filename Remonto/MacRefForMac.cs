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
    public partial class MacRefForMac : Form
    {
        Machine _machine = new Machine();
        public MacRefForMac(int id)
        {
            try
            {
                InitializeComponent();
                comboBox5.SelectedIndex = 1;
                comboBox6.SelectedIndex = 0;
                Stanok posk = new Stanok();
                _machine = posk.FindByIdmac(id, false);
                zgruz(id);
                button7_Click(null, null);
            }
            catch(Exception)
            {
                MessageBox.Show("Не найден станок или что-то еще... ((");
            }
        }
        public void zgruz(int id)
        {try
            {
                Stanok stan = new Stanok();
                Machine machine = stan.FindByIdmac(id,true);
                Name__.Text = machine.MachineReferenceBook.Name;
                Mark.Text = machine.MachineReferenceBook.Mark;
                Country.Text = machine.MachineReferenceBook.Country;
                string[] data = Convert.ToString(machine.YerOfIssue).Split('.');
                string[] data2 = data[2].Split(' ');
            }
            catch(Exception)
            {

            }
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Country_Click(object sender, EventArgs e)
        {

        }

        private void Mark_Click(object sender, EventArgs e)
        {

        }

        private void Name___Click(object sender, EventArgs e)
        {

        }
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                MachineReferenceBook stanok = new MachineReferenceBook();
                person master = new person();
                if (textBoxMaster_MacRef.Text != "" && textBoxMaster_MacRef.Text != null)
                {
                    master.FIO = textBoxMaster_MacRef.Text;
                    List<person> masterList = new List<person>();
                    Master masterContext = new Master();
                    masterList = masterContext.GetListMaster(null, null, master, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, 1, 1);
                    if (masterList.Count != 0)
                        stanok.person = masterList;
                }
                if (textBoxCountry_Macref.Text != "" && textBoxCountry_Macref.Text != null)
                    stanok.Country = textBoxCountry_Macref.Text;
                if (textBoxMark_MacRef.Text != "" && textBoxMark_MacRef.Text != null)
                    stanok.Mark = textBoxMark_MacRef.Text;
                if (textBoxName_MacRef.Text != "" && textBoxMark_MacRef.Text != null)
                    stanok.Name = textBoxName_MacRef.Text;
                int count = Convert.ToInt32(numericUpDown2.Value);
                int page = Convert.ToInt32(numericUpDown9.Value);
                DateTime min = DateTime.MinValue;
                if (dateTimePicker21.Enabled == true)
                {
                    min = dateTimePicker21.Value;
                }
                DateTime max = DateTime.MaxValue;
                if (dateTimePicker22.Enabled == true)
                {
                    max = dateTimePicker22.Value;
                }
                InitializeMacRef(comboBox6.Text, comboBox5.Text, stanok,max,min, count, page);
            }
            catch(Exception)
            {
                MessageBox.Show("Почему то не могу применить фильтр ((");
            }
        }
        public void InitializeMacRef(string sorting, string sortingA, MachineReferenceBook filtering, DateTime max, DateTime min, int count, int page)
        {
            try
            {
                dataGridView2.Rows.Clear();
                Stanki stanki = new Stanki();
                List<MachineReferenceBook> Machines = stanki.GetListStankov(sorting, sortingA, filtering, max,min, count, page);
                foreach (MachineReferenceBook mac in Machines)
                {
                    if (mac.ID != 0)
                        if (mac.person.Count != 0)
                        dataGridView2.Rows.Add(mac.ID, mac.Country, mac.Mark, mac.person.FirstOrDefault().FIO, mac.Name, mac.DateAdd);
                    else if (mac.person.Count == 0)
                            dataGridView2.Rows.Add(mac.ID, mac.Country, mac.Mark, "Пусто", mac.Name, mac.DateAdd);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось загрузить справочник станков");
            }
        }
        public int InIsDatagrid(DataGridView d)
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
                return id;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Stanok stan = new Stanok();
                bool itog = stan.SaveMachine(_machine);
                if (itog == false)
                    throw new Exception();
                MessageBox.Show("Успешно");
                zgruz(_machine.ID);
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось изменить параметр станка");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            int id = InIsDatagrid(dataGridView2);
            if (id != 0)
                _machine.MachineId = id;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                numericUpDown9.Value++;
                label7.Text = Convert.ToString(numericUpDown9.Value);
                button7_Click(null, null);
            }
            catch (Exception)
            {

            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                numericUpDown9.Value--;
                label7.Text = Convert.ToString(numericUpDown9.Value);
                button7_Click(null, null);
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox13_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox13.Checked == true)
            {
                dateTimePicker21.Enabled = true;
                dateTimePicker22.Enabled = true;
            }
            if (checkBox13.Checked == false)
            {
                dateTimePicker21.Enabled = false;
                dateTimePicker22.Enabled = false;
            }
        }
    }
}
