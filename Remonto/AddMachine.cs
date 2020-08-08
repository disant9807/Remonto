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
using System.ComponentModel.DataAnnotations.Schema;

namespace Labo4ka7
{
    public partial class AddMachine : Form
    {
        person client = new person();
        MachineReferenceBook machine = new MachineReferenceBook();
        person manager = new person();
        public AddMachine(person user)
        {
            try
            {
                InitializeComponent();
                comboBox8.SelectedIndex = 1;
                comboBox7.SelectedIndex = 1;
                comboBox3.SelectedIndex = 5;
                comboBox4.SelectedIndex = 1;
                for (int y = Convert.ToInt32(DateTime.Now.Year); y >= 1800; y--)
                {
                    comboBox1.Items.Add(y);
                }
                OkFilter_Client_Click(null, null);
                button7_Click(null, null);
                manager = user;
                this.dataGridView1.CurrentCell = this.dataGridView1[1, 0];
                this.dataGridView1.ClearSelection();
                this.dataGridView2.CurrentCell = this.dataGridView2[1, 0];
                this.dataGridView2.ClearSelection();
            }
            catch(Exception)
            {

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void OkFilter_Client_Click(object sender, EventArgs e)
        {
            if (PhoneSmartFilter_Client.Text == "Сотовый")
                PhoneSmartFilter_Client.Text = "0";
            if (PhoneStacFIlter_Client.Text == "Домашний")
                PhoneStacFIlter_Client.Text = "0";
            person filtering = new person { FIO = ImyaFilter_Client.Text, CompanyName = CompanyFilter_Client.Text, phoneSmart = Convert.ToInt32(PhoneSmartFilter_Client.Text), phoneStac = Convert.ToInt32(PhoneStacFIlter_Client.Text) };
            if (dateIzmenenieFilter_Client.Enabled == true)
                filtering.DateLastAutorization = dateIzmenenieFilter_Client.Value;
            DateTime min = new DateTime();
            if (dateMinFilter_Client.Enabled == true)
                min = dateMinFilter_Client.Value;
            DateTime max = new DateTime();
            if (dateMaxFilter_Client.Enabled == true)
                max = dateMaxFilter_Client.Value;

            string textForMethod = "DateAdd";
            switch (comboBox3.Text)
            {
                case "ID":
                    textForMethod = "ID";
                    break;
                case "Компания":
                    textForMethod = "CompanyName";
                    break;
                case "Имя":
                    textForMethod = "FIO";
                    break;
                case "Телефон.Сот":
                    textForMethod = "phoneSmart";
                    break;
                case "Телефон.Дом":
                    textForMethod = "phoneStac";
                    break;
                case "Дата добавления":
                    textForMethod = "DateAdd";
                    break;
                case "Дата последних изменений":
                    textForMethod = "DateLastAutorization";
                    break;
            }
            InitializeClient(textForMethod, comboBox4.Text, filtering, min, max, Convert.ToInt32(KollFilter_Client.Value), Convert.ToInt32(strFilter_Client.Value));
        }
        public void InitializeClient(string sorting, string sortingA, person filtering, DateTime min, DateTime max, int count, int page)
        {
            try
            {
                if (min == null)
                    min = DateTime.MinValue;
                if (max == null)
                    max = DateTime.MinValue;
                dataGridView1.Rows.Clear();
                Client client = new Client();
                List<person> Clients = client.GetListClient(sorting, sortingA, filtering, min, max, count, page);
                foreach (person opo in Clients)
                {
                    dataGridView1.Rows.Add(opo.ID, opo.CompanyName, opo.FIO, opo.phoneSmart, opo.phoneStac, opo.DateAdd, opo.DateLastAutorization);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Клиенты не найденны !");
            }
        }

        private void button7_Click(object sender, EventArgs e)
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
                    stanok.person.Add(masterList[0]);
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
            string textForMethod = "DateAdd";
            switch (comboBox8.Text)
            {
                case "ID":
                    textForMethod = "ID";
                    break;
                case "Страна":
                    textForMethod = "Country";
                    break;
                case "Марка":
                    textForMethod = "Mark";
                    break;
                case "Название":
                    textForMethod = "Name";
                    break;
                case "Дата добавления":
                    textForMethod = "DateAdd";
                    break;
            }
            InitializeMacRef(textForMethod, comboBox7.Text, stanok,max,min, count, page);
        }
        public void InitializeMacRef(string sorting, string sortingA, MachineReferenceBook filtering,DateTime max, DateTime min, int count, int page)
        {
            try
            {
                dataGridView2.Rows.Clear();
                Stanki stanki = new Stanki();
                List<MachineReferenceBook> Machines = stanki.GetListStankov(sorting, sortingA, filtering,max,min, count, page);
                foreach (MachineReferenceBook mac in Machines)
                {
                    foreach (person p in mac.person)
                    {
                        dataGridView2.Rows.Add(mac.ID, mac.Country, mac.Mark, p.FIO, mac.Name);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Справочник станков пуст");
            }
        }

        private void UpPageMacRef_Click(object sender, EventArgs e)
        {
            try
            {
                numericUpDown9.Value++;
                TextPageMacref.Text = Convert.ToString(numericUpDown9.Value);
                button7_Click(null, null);
            }
            catch(Exception)
            { }
        }

        private void DownPageMacref_Click(object sender, EventArgs e)
        {
            try
            {
            numericUpDown9.Value--;
            TextPageMacref.Text = Convert.ToString(numericUpDown9.Value);
            button7_Click(null, null);
            }
            catch (Exception)
            { }
        }

        private void UpPageClient_Click(object sender, EventArgs e)
        {
            try { 
            strFilter_Client.Value++;
            TextPageClient.Text = Convert.ToString(strFilter_Client.Value);
            OkFilter_Client_Click(null, null);
            }
            catch (Exception)
            { }
        }

        private void DownPageClient_Click(object sender, EventArgs e)
        {
            try {
            strFilter_Client.Value--;
            TextPageClient.Text = Convert.ToString(strFilter_Client.Value);
            OkFilter_Client_Click(null, null);
            }
            catch (Exception)
            { }
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
                MessageBox.Show("Ошибка, не выделенно ни одного элемента");
                return 0;
            }
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = InIsDatagrid(dataGridView2);
                Stanki poisk = new Stanki();
                machine = poisk.FindByIdStanok(id);                            
            }
            catch(Exception)
            {

            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                int id = InIsDatagrid(dataGridView1);
                Client poisk = new Client();
                client = poisk.FindByIdClient(id);
            }
            catch(Exception)
            {

            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 db = new Model1();
                Machine mac = new Machine();
                mac.YerOfIssue = new DateTime(Convert.ToInt32(comboBox1.Text), 1, 1);
                mac.UploadDate = DateTime.Now;
                mac.MachineId = machine.ID;
                Stanok stanok = new Stanok();
                bool itog = stanok.addMachine(mac, manager, client);
                if (itog == false)
                {
                    throw new Exception();
                }
                MessageBox.Show("Успешно");
                this.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось добавить станок");
            }
        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.ClearSelection();
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.ClearSelection();
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
