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
    public partial class Form1 : Form
        
    {
        public delegate void addRep(int id);
        addRep del;
        public Form1()
        {
            InitializeComponent();
            StaticAdd.AddAdmin();
            comboBox3.SelectedIndex = 5;
            comboBox4.SelectedIndex = 1;
            comboBox6.SelectedIndex = 0;
            comboBox5.SelectedIndex = 1;
            comboBox8.SelectedIndex = 3;
            comboBox7.SelectedIndex = 1;
            comboBox10.SelectedIndex = 3;
            comboBox9.SelectedIndex = 1;
            comboBox12.SelectedIndex = 1;
            comboBox11.SelectedIndex = 1;
            comboBox13.SelectedIndex = 1;
            comboBox15.SelectedIndex = 1;
            for (int y = DateTime.Now.Year; y >= 1800; y--)
            {
                comboBox1.Items.Add(y);
            }
            comboBox1.Text = Convert.ToString(1800);
            for (int y = DateTime.Now.Year; y >= 1800; y--)
            {
                comboBox2.Items.Add(y);
            }
            comboBox2.Text = Convert.ToString(DateTime.Now.Year);
            panel1.Visible = false;
            panel2.Visible = true;
            label111.Visible = false;
            //label112.Visible = false;
            button4_Click(null, null);
            button7_Click(null, null);
            button11_Click(null, null);
            button26_Click(null, null);
            button21_Click(null, null);
            button56_Click(null, null);
            button16_Click(null, null);
        }
        int IdVibranStan;
        bool VibtanStan;
        bool vibranMac;
        bool uslovieRepMac;
        int IdVibranMac;
        int idForRepVibor;
      
        person autorization = new person();
        public void RegisterMacForRep(Machine mac)
        {
            uslovieRepMac = true;
            idForRepVibor = mac.ID;
            tabControl1.SelectedIndex = 5;
            button42.BackColor = Color.Green;
            button21_Click(null, null);
        }
        public void RegisterClientForMac(person client)
        {
            tabControl1.SelectedIndex = 3;
            button12_Click(null, null);
            textBox1.Text = client.FIO;
            button11_Click(null, null);
        }
        public void RegisterClientForRep(person client)
        {
            tabControl1.SelectedIndex = 5;
            button22_Click(null, null);
            textBox5.Text = client.FIO;
            button21_Click(null, null);
        }
        public void RegisterMacRefForMac(MachineReferenceBook machine)
        {
            button12_Click(null, null);
            VibtanStan = true;
            IdVibranStan = machine.ID;
            button37.BackColor = Color.Green;
            tabControl1.SelectedIndex = 3;
            button11_Click(null, null);
        }
        public void InitializeClient (string sorting, string sortingA, person filtering, DateTime min, DateTime max, int count, int page)
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
                    dataGridView1.Rows.Add(opo.ID, opo.CompanyName, opo.FIO, opo.phoneSmart,opo.phoneStac, opo.DateAdd, opo.DateLastAutorization);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Клиенты не найдены !");
            }
        }
        public void InitializeMaster(string sorting, string sortingA, person filtering, DateTime min, DateTime max, DateTime MinAut, DateTime MaxAut, int count, int page)
        {
            try
            {
                if (min == null)
                    min = DateTime.MinValue;
                if (max == null)
                    max = DateTime.MinValue;
                dataGridView3.Rows.Clear();
                Master master = new Master();
                List<person> Masters = master.GetListMaster(sorting, sortingA, filtering, min, max, MinAut, MaxAut, count, page);
                foreach (person opo in Masters)
                {
                    dataGridView3.Rows.Add(opo.ID, opo.FIO, opo.phoneSmart, opo.phoneStac, opo.DateAdd, opo.DateLastAutorization);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Мастеры не найдены !");
            }
        }

        public void InitializeManger(string sorting, string sortingA, person filtering, DateTime min, DateTime max, DateTime MinAut, DateTime MaxAut, int count, int page)
        {
            try
            {
                if (min == null)
                    min = DateTime.MinValue;
                if (max == null)
                    max = DateTime.MinValue;
                dataGridView6.Rows.Clear();
                Manager manager = new Manager();
                List<person> Managers = manager.GetListManager(sorting, sortingA, filtering, min, max, MinAut, MaxAut, count, page);
                foreach (person opo in Managers)
                {
                    dataGridView6.Rows.Add(opo.ID, opo.FIO, opo.phoneSmart, opo.phoneStac, opo.DateAdd, opo.DateLastAutorization);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Менеджеры не найдены !");
            }
        }
        public void initializeRepairs (string sorting, string sortingA, Repairs repairs, DateTime MaxStart, DateTime MinStart, DateTime MaxEnd, DateTime MinEnd, DateTime MaxAdd, DateTime MinAdd,int MaxOplata, int MinOplata, int MaxPaid, int MinPaid, int count,int page, person client, person manager, person master, string who)
        {
            try
            {
                if (who == "Никто")
                {
                    if (MaxStart == null)
                        MaxStart = DateTime.MinValue;
                    if (MinStart == null)
                        MinStart = DateTime.MinValue;
                    if (MaxEnd == null)
                        MaxEnd = DateTime.MinValue;
                    if (MinEnd == null)
                        MinEnd = DateTime.MinValue;
                    if (MinAdd == null)
                        MinAdd = DateTime.MinValue;
                    if (MaxAdd == null)
                        MaxAdd = DateTime.MinValue;
                    List<Repairs> repairList = new List<Repairs>();
                    RepairsContext poisk = new RepairsContext();
                    repairList = poisk.GetListRepairs(sorting, sortingA, repairs, MinAdd, MaxAdd, MaxEnd, MinEnd, MaxStart, MinStart,MaxOplata,MinOplata,MaxPaid,MinPaid, count, page, true);
                    dataGridView5.Rows.Clear();
                    foreach (Repairs rep in repairList)
                    {
                        string Manager = "";
                        if (rep.person.Where(m => m.Status == "Менеджер").FirstOrDefault() != null)
                        {
                            Manager = rep.person.Where(m => m.Status == "Менеджер").FirstOrDefault().FIO;
                        }
                        string Master = "";
                        if (rep.person.Where(m => m.Status == "Мастер").FirstOrDefault() != null)
                        {
                            Master = rep.person.Where(m => m.Status == "Мастер").FirstOrDefault().FIO;
                        }
                        string Client = "";
                        if (rep.person.Where(m => m.Status == "Клиент").FirstOrDefault() != null)
                        {
                            Client = rep.person.Where(m => m.Status == "Клиент").FirstOrDefault().FIO;
                        }
                        
                         dataGridView5.Rows.Add(rep.ID, rep.AddDate, rep.StartDate, "ID:" + rep.ID + "; Год выпуска:" + rep.Machine.YerOfIssue, Master, Client, Manager, rep.price);                                                 
                    }
                }
                if (who == "Клиент" || who == "Менеджер" || who == "Мастер")
                {
                    if (MaxStart == null)
                        MaxStart = DateTime.MinValue;
                    if (MinStart == null)
                        MinStart = DateTime.MinValue;
                    if (MaxEnd == null)
                        MaxEnd = DateTime.MinValue;
                    if (MinEnd == null)
                        MinEnd = DateTime.MinValue;
                    if (MinAdd == null)
                        MinAdd = DateTime.MinValue;
                    if (MaxAdd == null)
                        MaxAdd = DateTime.MinValue;
                    List<Repairs> repairList = new List<Repairs>();
                    RepairsContext poisk = new RepairsContext();
                    if (client.FIO != null && manager.FIO == null && master.FIO == null)
                    {
                        repairList = poisk.GetListRepairsPerson(sorting, sortingA, repairs, MinAdd, MaxAdd, MaxEnd, MinEnd, MaxStart, MinStart, MaxOplata, MinOplata, MaxPaid, MinPaid, count, page, client, null, null);
                    }
                    else if (client.FIO == null && manager.FIO != null && master.FIO == null)
                    {
                        repairList = poisk.GetListRepairsPerson(sorting, sortingA, repairs, MinAdd, MaxAdd, MaxEnd, MinEnd, MaxStart, MinStart, MaxOplata, MinOplata, MaxPaid, MinPaid, count, page, null, manager, null);
                    }
                    else if(client.FIO == null && manager.FIO == null && master.FIO != null)
                    {
                        repairList = poisk.GetListRepairsPerson(sorting, sortingA, repairs, MinAdd, MaxAdd, MaxEnd, MinEnd, MaxStart, MinStart, MaxOplata, MinOplata, MaxPaid, MinPaid, count, page, null, null, master);
                    }
                    else if(client.FIO != null && manager.FIO != null && master.FIO == null)
                    {
                        repairList = poisk.GetListRepairsPerson(sorting, sortingA, repairs, MinAdd, MaxAdd, MaxEnd, MinEnd, MaxStart, MinStart, MaxOplata, MinOplata, MaxPaid, MinPaid, count, page, client, manager, null);
                    }
                    else if(client.FIO != null && manager.FIO == null && master.FIO != null)
                    {
                        repairList = poisk.GetListRepairsPerson(sorting, sortingA, repairs, MinAdd, MaxAdd, MaxEnd, MinEnd, MaxStart, MinStart, MaxOplata, MinOplata, MaxPaid, MinPaid, count, page, client, null, master);
                    }
                    else if(client.FIO == null && manager.FIO != null && master.FIO != null)
                    {
                        repairList = poisk.GetListRepairsPerson(sorting, sortingA, repairs, MinAdd, MaxAdd, MaxEnd, MinEnd, MaxStart, MinStart, MaxOplata, MinOplata, MaxPaid, MinPaid, count, page, null, manager, master);
                    }
                    else if(client.FIO != null && manager.FIO != null && master.FIO != null)
                    {
                        repairList = poisk.GetListRepairsPerson(sorting, sortingA, repairs, MinAdd, MaxAdd, MaxEnd, MinEnd, MaxStart, MinStart, MaxOplata, MinOplata, MaxPaid, MinPaid, count, page, client, manager, master);
                    }
                    dataGridView5.Rows.Clear();
                    foreach (Repairs rep in repairList)
                    {
                        if (rep.person.Where(m => m.Status == "Мастер").FirstOrDefault() != null)
                            dataGridView5.Rows.Add(rep.ID, rep.AddDate, rep.StartDate, rep.Machine.YerOfIssue, rep.person.Where(m => m.Status == "Мастер").FirstOrDefault().FIO, rep.person.Where(m => m.Status == "Клиент").FirstOrDefault().FIO, rep.person.Where(m => m.Status == "Менеджер").FirstOrDefault().FIO, rep.price);
                        else if (rep.person.Where(m => m.Status == "Мастер").FirstOrDefault() == null)
                            dataGridView5.Rows.Add(rep.ID, rep.AddDate, rep.StartDate, rep.Machine.YerOfIssue, "", rep.person.Where(m => m.Status == "Клиент").FirstOrDefault().FIO, rep.person.Where(m => m.Status == "Менеджер").FirstOrDefault().FIO, rep.price);
                    }
                }
            }
            catch (Exception)
            {

            }
        }
        public void InitializeMacRef(string sorting, string sortingA, MachineReferenceBook filtering, DateTime max, DateTime min, int count, int page, person master, bool uslovie)
        {
            try
            {
                if (uslovie == false)
                {
                    dataGridView2.Rows.Clear();
                    Stanki stanki = new Stanki();
                    List<MachineReferenceBook> Machines = stanki.GetListStankov(sorting, sortingA, filtering, max, min, count, page);
                    foreach (MachineReferenceBook mac in Machines)
                    {
                        if (mac.ID != 0)
                        {
                            string MMaster = "";
                            if (mac.person.Count != 0)
                            {
                                MMaster = mac.person.FirstOrDefault().FIO;
                            }
                                dataGridView2.Rows.Add(mac.ID, mac.Country, mac.Mark, MMaster, mac.Name, mac.DateAdd);
                            
             
                        }
                    }
                }
                else if (uslovie == true)
                {
                    dataGridView2.Rows.Clear();
                    Stanki stanki = new Stanki();
                    List<MachineReferenceBook> Machines = stanki.GetListStankovMaster(sorting, sortingA, filtering, max, min, count, page,master);
                    foreach (MachineReferenceBook mac in Machines)
                    {
                        if (mac.ID != 0)
                        {
                            if (mac.person.FirstOrDefault().FIO != null)
                                dataGridView2.Rows.Add(mac.ID, mac.Country, mac.Mark, mac.person.FirstOrDefault().FIO, mac.Name, mac.DateAdd);
                            else if (mac.person.FirstOrDefault().FIO == null)
                            {
                                dataGridView2.Rows.Add(mac.ID, mac.Country, mac.Mark, "Пусто", mac.Name, mac.DateAdd);
                            }
                        }
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось загрузить справочник станков");
            }
        }
        public void InitializeMac(string sorting, string sortingA, Machine filtering,DateTime MinData, DateTime MaxData,DateTime MinYear,DateTime MaxYear, int count, int page, string uslovie,person client, person manager)
        {
            try
            {
                if (uslovie == "Никто")
                {
                    dataGridView8.Rows.Clear();
                    Stanok stanok = new Stanok();
                    List<Machine> Machine = stanok.GetListMachine(sorting, sortingA, filtering, MinData, MaxData, MinYear, MaxYear, count, page, true);                   
                    foreach (Machine mac in Machine)
                    {
                        string MManager = "";
                        if (mac.person.Where(z => z.Status == "Менеджер").FirstOrDefault() != null)
                            MManager = mac.person.Where(z => z.Status == "Менеджер").FirstOrDefault().FIO;
                        string CClient = "";
                        if (mac.person.Where(z => z.Status == "Клиент").FirstOrDefault() != null)
                            CClient = mac.person.Where(z => z.Status == "Клиент").FirstOrDefault().FIO;
                        dataGridView8.Rows.Add(mac.ID, mac.YerOfIssue.Date.Year,CClient , mac.UploadDate, MManager, mac.MachineReferenceBook.Name +" ; "  +mac.MachineReferenceBook.Mark);
                    }
                }
                if (uslovie == "Клиент")
                {
                    dataGridView8.Rows.Clear();
                    Stanok stanok = new Stanok();
                    Client PosikClient = new Client();                   
                    List<Machine> Machine = stanok.GetListMachineClient(sorting, sortingA, filtering, MinData, MaxData, MinYear, MaxYear, count, page,client, null);
                    foreach (Machine mac in Machine)
                    {
                        string MManager = "";
                        if (mac.person.Where(z => z.Status == "Менеджер").FirstOrDefault() != null)
                            MManager = mac.person.Where(z => z.Status == "Менеджер").FirstOrDefault().FIO;
                        string CClient = "";
                        if (mac.person.Where(z => z.Status == "Клиент").FirstOrDefault() != null)
                            CClient = mac.person.Where(z => z.Status == "Клиент").FirstOrDefault().FIO;
                        MachineReferenceBook macH = new MachineReferenceBook();
                        Stanki sant = new Stanki();
                        macH = sant.FindByIdStanok(mac.MachineId);
                        dataGridView8.Rows.Add(mac.ID, mac.YerOfIssue.Date.Year, CClient, mac.UploadDate, MManager, macH.Name + " ; " + macH.Mark);
                    }
                }
                if (uslovie == "Менеджер")
                {
                    dataGridView8.Rows.Clear();
                    Stanok stanok = new Stanok();
                    Manager PosikManager = new Manager();                
                    List<Machine> Machine = stanok.GetListMachineClient(sorting, sortingA, filtering, MinData, MaxData, MinYear, MaxYear, count, page, null, manager);
                    foreach (Machine mac in Machine)
                    {
                        string MManager = "";
                        if (mac.person.Where(z => z.Status == "Менеджер").FirstOrDefault() != null)
                            MManager = mac.person.Where(z => z.Status == "Менеджер").FirstOrDefault().FIO;
                        string CClient = "";
                        if (mac.person.Where(z => z.Status == "Клиент").FirstOrDefault() != null)
                            CClient = mac.person.Where(z => z.Status == "Клиент").FirstOrDefault().FIO;
                        MachineReferenceBook macH = new MachineReferenceBook();
                        Stanki sant = new Stanki();
                        macH = sant.FindByIdStanok(mac.MachineId);
                        dataGridView8.Rows.Add(mac.ID, mac.YerOfIssue.Date.Year, CClient, mac.UploadDate, MManager, macH.Name + " ; " + macH.Mark);
                    }
                }
                if (uslovie == "Менеджер и Клиент")
                {
                    
                    dataGridView8.Rows.Clear();
                    Stanok stanok = new Stanok();
                    Manager PosikManager = new Manager();
                    List<Machine> Machine = stanok.GetListMachineClient(sorting, sortingA, filtering, MinData, MaxData, MinYear, MaxYear, count, page, client, manager);
                    foreach (Machine mac in Machine)
                    {
                        string MManager = "";
                        if (mac.person.Where(z => z.Status == "Менеджер").FirstOrDefault() != null)
                            MManager = mac.person.Where(z => z.Status == "Менеджер").FirstOrDefault().FIO;
                        string CClient = "";
                        if (mac.person.Where(z => z.Status == "Клиент").FirstOrDefault() != null)
                            CClient = mac.person.Where(z => z.Status == "Клиент").FirstOrDefault().FIO;
                        MachineReferenceBook macH = new MachineReferenceBook();
                        Stanki sant = new Stanki();
                        macH = sant.FindByIdStanok(mac.MachineId);
                        dataGridView8.Rows.Add(mac.ID, mac.YerOfIssue.Date.Year, CClient, mac.UploadDate, MManager, macH.Name + " ; " + macH.Mark);
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось загрузить список станков");
            }
        }
        public void InitializeUslugi(string sorting, string sortingA, RepairsReferenceBook filtering, DateTime maxDate, DateTime MinDate, int count, int page, person manager, bool uslovie)
        {
            try
            {
                if (uslovie == false)
                {
                    dataGridView4.Rows.Clear();
                    Uslugi uslugaAdd = new Uslugi();
                    List<RepairsReferenceBook> listRepa = uslugaAdd.GetListUslugi(sorting, sortingA, filtering, MinDate, maxDate, count, page, true);
                    foreach (RepairsReferenceBook repairs in listRepa)
                    {
                        string managerrr = "";
                        if (repairs.person.Where(p => p.Status == "Менеджер").FirstOrDefault() != null)
                        {
                            managerrr = repairs.person.Where(p => p.Status == "Менеджер").FirstOrDefault().FIO;
                        }
                        dataGridView4.Rows.Add(repairs.ID, repairs.ServiceName, repairs.price, repairs.AddDate, managerrr);
                    }
                }
                if (uslovie == true)
                {
                    dataGridView4.Rows.Clear();
                    Uslugi uslugaAdd = new Uslugi();
                    List<RepairsReferenceBook> listRepa = uslugaAdd.GetListUslugiManager(sorting, sortingA, filtering, MinDate, maxDate, count, page,manager);
                    foreach (RepairsReferenceBook repairs in listRepa)
                    {
                        string managerrr = "";
                        if (repairs.person.Where(p => p.Status == "Менеджер").FirstOrDefault() != null)
                        {
                            managerrr = repairs.person.Where(p => p.Status == "Менеджер").FirstOrDefault().FIO;
                        }
                        dataGridView4.Rows.Add(repairs.ID, repairs.ServiceName, repairs.price, repairs.AddDate, managerrr);
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось загрузить услуги");
            }
        }
            public int InIsDatagrid (DataGridView d)
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
            catch(Exception)
            {
                MessageBox.Show("Ошибка, не выделено ни одного элемента");
                return 0;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                //if (autorization.Status != "Менеджер")
               // {
                //    throw new Exception();
                //}
                    AddClient form = new AddClient();
                    form.ShowDialog();
                    button4_Click(null, null);

            }
            catch(Exception)
            {
                MessageBox.Show("Ошибка или вы просто не являетесь менеджером");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            person filtering = new person { FIO = ImyaFilter_Client.Text, CompanyName = CompanyFilter_Client.Text, phoneSmart = 0, phoneStac = 0 };

            int phone;
            if (int.TryParse(PhoneSmartFilter_Client.Text, out phone))
               filtering.phoneSmart = int.Parse(PhoneSmartFilter_Client.Text);
            if (int.TryParse(PhoneStacFIlter_Client.Text,out phone))
               filtering.phoneStac = int.Parse(PhoneStacFIlter_Client.Text);

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

        private void button43_Click(object sender, EventArgs e)
        {
            if (strFilter_Client.Value != 0)
            {
                strFilter_Client.Value = strFilter_Client.Value + 1;
                button4_Click(null, null);
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            try
            {
                if (strFilter_Client.Value != 0)
                {
                    strFilter_Client.Value = strFilter_Client.Value - 1;
                    button4_Click(null, null);
                }
            }
            catch (Exception)
            {

            }
        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            label5.Text = Convert.ToString(strFilter_Client.Value);
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {

        }

        private void PhoneSmartFilter_Click(object sender, EventArgs e)
        {
            if(PhoneSmartFilter_Client.Text == "Сотовый")
            {
                PhoneSmartFilter_Client.Text = "";
            }
        }

        private void PhoneStacFIlter_Click(object sender, EventArgs e)
        {
            if (PhoneStacFIlter_Client.Text == "Домашний")
            {
                PhoneStacFIlter_Client.Text = "";
            }
        }

        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox9.Checked == true)
            {
                dateMinFilter_Client.Enabled = true;
                dateMaxFilter_Client.Enabled = true;
            }
            else
            {
                dateMinFilter_Client.Enabled = false;
                dateMaxFilter_Client.Enabled = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                dateIzmenenieFilter_Client.Enabled = true;
            }
            else
            {
                dateIzmenenieFilter_Client.Enabled = false;
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            MachineReferenceBook stanok = new MachineReferenceBook();
            person master = new person();           
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

            //ID
            //Страна
            //Марка
            //Мастер
            //Название
            //Дата добавления
            string textForMethod = "DateAdd";
            switch (comboBox6.Text)
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

            if (textBoxMaster_MacRef.Text != "" && textBoxMaster_MacRef.Text != "Мастер")
            {
                master.FIO = textBoxMaster_MacRef.Text;
                InitializeMacRef(textForMethod, comboBox5.Text, stanok,max,min, count, page,master ,true);
            }
            if (textBoxMaster_MacRef.Text == "" || textBoxMaster_MacRef.Text == "Мастер")
            {
                InitializeMacRef(textForMethod, comboBox5.Text, stanok, max, min, count, page, master , false);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
              //  if (autorization.Status != "Менеджер")
               //     throw new Exception();
                DialogResult result =  MessageBox.Show(
       "Если вы удалите данного клиента, то удалятся все его станки и ремонты. Удалить ?",
       "Сообщение",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Information,
       MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    int id = InIsDatagrid(dataGridView1);
                    Client client = new Client();
                    bool itog = client.DelClient(id);
                    if (itog == false)
                        throw new Exception();
                    MessageBox.Show("Успешно");
                    button4_Click(null, null);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Ошибка или вы просто не являетесь менеджером");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
               // if (autorization.Status != "Мастер")
               //     throw new Exception();
                AddMacRef form = new AddMacRef(autorization);
                form.ShowDialog();
                button7_Click(null, null);
            }
            catch(Exception)
            {
                MessageBox.Show("Ошибка или вы просто не являетесь мастером");
            }
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                //if (autorization.Status != "Мастер")
                //    throw new Exception();
                DialogResult result = MessageBox.Show(
          "Если вы удалите данный параметр, то удалятся все его станки. Удалить ?",
          "Сообщение",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Information,
          MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    int id = InIsDatagrid(dataGridView2);
                    Stanki poisk = new Stanki();
                    bool itog = poisk.DelStanok(id);
                    if (itog == false)
                        throw new Exception();
                    MessageBox.Show("Успешно");
                    button7_Click(null, null);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Ошибка или вы просто не являетесь мастером");
            }
        }
        public person autoriztions(int phone, string pass)
        {
            try
            {
                Model1 db = new Model1();
                person poiisk = new person();
                var result = db.person
                    .Where(o => o.AccesCode == pass)
                    .Where(z => z.phoneSmart == phone);
                foreach (person p in result)
                {
                    poiisk = p;
                }
                if (poiisk.FIO == null)
                    throw new Exception();
                return poiisk;
            }
            catch (Exception)
            {
                return new person { };
            }
        }
        private void button36_Click(object sender, EventArgs e)
        {
            try
            {
                autorization = autoriztions(Convert.ToInt32(textBox22.Text), textBox23.Text);
                if (autorization.FIO == null)
                    throw new Exception();
                panel4.Visible = true;
                label62.Text = autorization.FIO;
                label63.Text = autorization.Status;
                skrytie(autorization);
                panel2.Visible = false;
            }
            catch(Exception)
            {
                MessageBox.Show("Пользователь не найден.");
            }
        }
        public void skrytie (person aut)
        {
            if (aut.Status == "Менеджер")
            {
                button10.Enabled = false;
                button8.Enabled = false;
                button15.Enabled = true;
                button13.Enabled = true;
                button1.Enabled = true;
                button3.Enabled = true;
                button18.Enabled = true;
                button20.Enabled = true;
                button25.Enabled = true;
                button23.Enabled = true;
                button29.Enabled = false;
                button28.Enabled = false;
            }
            else if (aut.Status == "Мастер")
            {
                button10.Enabled = true;
                button8.Enabled = true;
                button15.Enabled = false;
                button13.Enabled = false;
                button1.Enabled = false;
                button3.Enabled = false;
                button18.Enabled = false;
                button20.Enabled = false;
                button25.Enabled = false;
                button23.Enabled = false;
            }
            else if (aut.Status == "Админ")
            {
                button10.Enabled = true;
                button8.Enabled = true;
                button15.Enabled = true;
                button13.Enabled = true;
                button1.Enabled = true;
                button3.Enabled = true;
                button18.Enabled = true;
                button20.Enabled = true;
                button25.Enabled = true;
                button23.Enabled = true;
                button29.Enabled = true;
                button28.Enabled = true;
            }
        }

        private void button30_Click(object sender, EventArgs e)
        {

        }

        private void linkRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddUser form = new AddUser(2);
            form.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel4.Visible = false;
            panel2.Visible = true;
        }
        public void viborMachine()
        {       
            tabControl1.SelectedIndex = 3;
            panel15.Visible = true;
            vibranMac = true;
            //label113.Visible = true;
            uslovie = true;
            button37_Click(null, null);
            button38_Click(null, null);
            ref Panel xPan = ref panel2;
            ref Label xText = ref label111;
            StaticPanel.panelNaMesto(true, xPan, xText, "Выберите станок Для добавления в ремонт");

        }
        private void button11_Click(object sender, EventArgs e)
        {try
            {
                if (textBox1.Text != "" && textBox1.Text != "Клиент" &&( textBox2.Text == "" || textBox2.Text == "Менеджер"))
                {
                    Machine machine = new Machine();
                    if (VibtanStan == true)
                        machine.MachineId = IdVibranStan;
                    DateTime MaxAdd = DateTime.MinValue;
                    DateTime MinAdd = DateTime.MinValue;
                    if (dateTimePicker1.Enabled == true)
                        MaxAdd = dateTimePicker1.Value;
                    if (dateTimePicker2.Enabled == true)
                        MinAdd = dateTimePicker2.Value;
                    DateTime MaxYear = DateTime.MinValue;
                    DateTime MinYear = DateTime.MinValue;
                    if (comboBox1.Enabled == true)
                        MinYear = new DateTime(Convert.ToInt32(comboBox1.Text), 1, 1);
                    if (comboBox2.Enabled == true)
                        MaxYear = new DateTime(Convert.ToInt32(comboBox2.Text), 1, 1);
                    int page = Convert.ToInt32(numericUpDown8.Value);
                    int count = Convert.ToInt32(numericUpDown5.Value);
                    person client = new person {FIO = textBox1.Text };
                    InitializeMac(comboBox8.Text, comboBox7.Text, machine, MinAdd, MaxAdd, MinYear, MaxYear, count, page,"Клиент", client,new person());
                }
                if (textBox2.Text != "" && textBox2.Text != "Менеджер"&& (textBox1.Text == "" || textBox1.Text == "Клиент"))
                {
                    Machine machine = new Machine();
                    if (VibtanStan == true)
                        machine.MachineId = IdVibranStan;
                    DateTime MaxAdd = DateTime.MinValue;
                    DateTime MinAdd = DateTime.MinValue;
                    if (dateTimePicker1.Enabled == true)
                        MaxAdd = dateTimePicker1.Value;
                    if (dateTimePicker2.Enabled == true)
                        MinAdd = dateTimePicker2.Value;
                    DateTime MaxYear = DateTime.MinValue;
                    DateTime MinYear = DateTime.MinValue;
                    if (comboBox1.Enabled == true)
                        MinYear = new DateTime(Convert.ToInt32(comboBox1.Text), 1, 1);
                    if (comboBox2.Enabled == true)
                        MaxYear = new DateTime(Convert.ToInt32(comboBox2.Text), 1, 1);
                    int page = Convert.ToInt32(numericUpDown8.Value);
                    int count = Convert.ToInt32(numericUpDown5.Value);
                    person manager = new person { FIO = textBox2.Text };
                    InitializeMac(comboBox8.Text, comboBox7.Text, machine, MinAdd, MaxAdd, MinYear, MaxYear, count, page, "Менеджер", new person(), manager);
                }
                if (textBox2.Text != "" && textBox2.Text != "Менеджер" && textBox1.Text != "" && textBox1.Text != "Клиент")
                {
                    Machine machine = new Machine();
                    if (VibtanStan == true)
                        machine.MachineId = IdVibranStan;
                    DateTime MaxAdd = DateTime.MinValue;
                    DateTime MinAdd = DateTime.MinValue;
                    if (dateTimePicker1.Enabled == true)
                        MaxAdd = dateTimePicker1.Value;
                    if (dateTimePicker2.Enabled == true)
                        MinAdd = dateTimePicker2.Value;
                    DateTime MaxYear = DateTime.MinValue;
                    DateTime MinYear = DateTime.MinValue;
                    if (comboBox1.Enabled == true)
                        MinYear = new DateTime(Convert.ToInt32(comboBox1.Text), 1, 1);
                    if (comboBox2.Enabled == true)
                        MaxYear = new DateTime(Convert.ToInt32(comboBox2.Text), 1, 1);
                    int page = Convert.ToInt32(numericUpDown8.Value);
                    int count = Convert.ToInt32(numericUpDown5.Value);
                    person manager = new person { FIO = textBox2.Text };
                     person client = new person { FIO = textBox1.Text };
                    InitializeMac(comboBox8.Text, comboBox7.Text, machine, MinAdd, MaxAdd, MinYear, MaxYear, count, page, "Менеджер и Клиент", client, manager);
                }
                if ((textBox2.Text == "" || textBox2.Text == "Менеджер") && (textBox1.Text == "" || textBox1.Text == "Клиент"))
                {
                    Machine machine = new Machine();
                    if (VibtanStan == true)
                        machine.MachineId = IdVibranStan;
                    DateTime MaxAdd = DateTime.MinValue;
                    DateTime MinAdd = DateTime.MinValue;
                    if (dateTimePicker1.Enabled == true)
                        MaxAdd = dateTimePicker1.Value;
                    if (dateTimePicker2.Enabled == true)
                        MinAdd = dateTimePicker2.Value;
                    DateTime MaxYear = DateTime.MinValue;
                    DateTime MinYear = DateTime.MinValue;
                    if (comboBox1.Enabled == true)
                        MinYear = new DateTime(Convert.ToInt32(comboBox1.Text), 1, 1);
                    if (comboBox2.Enabled == true)
                        MaxYear = new DateTime(Convert.ToInt32(comboBox2.Text), 1, 1);
                    int page = Convert.ToInt32(numericUpDown8.Value);
                    int count = Convert.ToInt32(numericUpDown5.Value);
                    List<person> Pers = new List<person>();
                    InitializeMac(comboBox8.Text, comboBox7.Text, machine, MinAdd, MaxAdd, MinYear, MaxYear, count, page, "Никто", new person(), new person());
                }
            }
            catch(Exception)
            {

            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            try
            {
                AddMachine form = new AddMachine(autorization);
                form.ShowDialog();
                button11_Click(null, null);
            }
            catch(Exception)
            {
                MessageBox.Show("Ошибка или вы не являетесь менеджером");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                numericUpDown9.Value++;
                label7.Text = Convert.ToString(numericUpDown9.Value);
                button7_Click(null, null);
            }
            catch(Exception)
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
            catch(Exception)
            {

            }
        }

        private void dataGridView8_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                numericUpDown8.Value++;
                label16.Text = Convert.ToString(numericUpDown9.Value);
                button11_Click(null, null);
            }
            catch (Exception)
            {

            }
        }

        private void button46_Click(object sender, EventArgs e)
        {
            try
            {
                numericUpDown8.Value--;
                label16.Text = Convert.ToString(numericUpDown9.Value);
                button11_Click(null, null);
            }
            catch (Exception)
            {

            }
        }

        private void textBoxName_MacRef_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            if (uslovieRepMac == false)
            {
                //label112.Visible = false;
                IdVibranStan = InIsDatagrid(dataGridView2);
                tabControl1.SelectedIndex = 3;
                if (uslovie == false)
                    panel2.Visible = false;
                if (uslovie == true)
                    panel2.Visible = true;
                panel2.Visible = false;
                button37.BackColor = Color.Green;
                ref Panel xPan = ref panel2;
                ref Label xText = ref label111;
                StaticPanel.panelNaMesto(false, xPan, xText, "Выберите станок");

            }
            if (uslovieRepMac == true)
            {
                //label112.Visible = false;
                //label111.Visible = true;
                IdVibranStan = InIsDatagrid(dataGridView2);
                tabControl1.SelectedIndex = 3;
                if (uslovie == false)
                    panel2.Visible = false;
                if (uslovie == true)
                    panel2.Visible = true;
                button37.BackColor = Color.Green;
                ref Panel xPan = ref panel2;
                ref Label xText = ref label111;
                StaticPanel.panelNaMesto(true, xPan, xText, "Выберите станок для ремонта");

            }
            
        }

        private void button37_Click(object sender, EventArgs e)
        {
            //label111.Visible = false;
            //label112.Visible = true;
            VibtanStan = true;
            IdVibranStan = 0;
            tabControl1.SelectedIndex = 2;
            panel1.Visible = true;
            //panel2.Visible = true;
            ref Panel xPan = ref panel2;
            ref Label xText = ref label111;
            StaticPanel.panelNaMesto(true, xPan, xText, "Выберите параметры станка");
        }

        private void button40_Click(object sender, EventArgs e)
        {
            VibtanStan = false;
            button37.BackColor = Color.Gray;
            panel1.Visible = false;
            panel2.Visible = false;
        }

        private void button38_Click(object sender, EventArgs e)
        {
            //label111.Visible = false;
            //label112.Visible = false;
            ref Panel xPan = ref panel2;
            ref Label xText = ref label111;
            StaticPanel.panelNaMesto(false, xPan, xText, "Выберите станок");
            VibtanStan = false;
            button37.BackColor = Color.Gray;
            if (uslovie == false)
                panel2.Visible = false;
            if (uslovie == true)
                panel2.Visible = true;
            panel1.Visible = false;
            tabControl1.SelectedIndex = 3;
            if (uslovieRepMac == true)
            {
                //abel111.Visible = true;
                //label112.Visible = false;
                StaticPanel.panelNaMesto(true, xPan, xText, "Выберите станок для ремонта");
                VibtanStan = false;
                button37.BackColor = Color.Gray;
                if (uslovie == false)
                    panel2.Visible = false;
                if (uslovie == true)
                    panel2.Visible = true;
                panel1.Visible = false;
                tabControl1.SelectedIndex = 3;
            }
        }
        private void tabControl1_Click(object sender, EventArgs e)
        {
            button40_Click(null, null);
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked ==true)
            {
                dateTimePicker2.Enabled = true;
                dateTimePicker1.Enabled = true;
            }
            else
            {
                dateTimePicker2.Enabled = false;
                dateTimePicker1.Enabled = false;
            }
        }

        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox8.Checked == true)
            {
                comboBox1.Enabled = true;
                comboBox2.Enabled = true;
            }
            else
            {
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            RepairsReferenceBook usluga = new RepairsReferenceBook();
            if (textBox11.Text != "")
                usluga.ServiceName = textBox11.Text;
            if (textBox12.Text != "")
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
            if (textBox25.Text != "")
            {
                person manager = new person { FIO = textBox25.Text };
                InitializeUslugi(comboBox10.Text, comboBox9.Text, usluga, MaxDate, MinDAte, count, page, manager,true);
            }
            else if (textBox25.Text == "")
            {
                InitializeUslugi(comboBox10.Text, comboBox9.Text, usluga, MaxDate, MinDAte, count, page, new person(), false);
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            try
            {
                //if (autorization.Status != "Менеджер")
                //    throw new Exception();
                AddUslugi form = new AddUslugi(autorization);
                form.ShowDialog();
                button19_Click(null,null);
                button16_Click(null,null);
                tabControl1.SelectedIndex = 4;
            }
            catch(Exception)
            {
                MessageBox.Show("Ошибка или вы не являетесь менеджером");
            }
        }

        private void button39_Click(object sender, EventArgs e)
        {

        }

        private void button44_Click(object sender, EventArgs e)
        { 

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label68_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (uslovie == false)
                panel2.Visible = false;
            if (uslovie == true)
                panel2.Visible = true;
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_Click(object sender, EventArgs e)
        {
           
        }

        private void numericUpDown12_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label57_Click(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(numericUpDown6.Value);
            int page = Convert.ToInt32(numericUpDown12.Value);
            DateTime MinAdd = DateTime.MinValue;
            if (dateTimePicker8.Enabled == true)
            {
                MinAdd = dateTimePicker8.Value;
            }
            DateTime MaxAdd = DateTime.MinValue;
            if (dateTimePicker13.Enabled == true)
            {
                MaxAdd = dateTimePicker13.Value;
            }
            DateTime Mintart = DateTime.MinValue;
            if (dateTimePicker14.Enabled == true)
            {
                Mintart = dateTimePicker14.Value;
            }
            DateTime MaxStart = DateTime.MinValue;
            if (dateTimePicker15.Enabled == true)
            {
                MaxStart = dateTimePicker15.Value;
            }
            DateTime MinEnd = DateTime.MinValue;
            if (dateTimePicker16.Enabled == true)
            {
                MinEnd = dateTimePicker16.Value;
            }
            DateTime MaxEnd = DateTime.MinValue;
            if (dateTimePicker17.Enabled == true)
            {
                MaxEnd = dateTimePicker17.Value;
            }
            Repairs filter = new Repairs();
            int MinOplata = Int32.MinValue;
            if (textBox3.Text != "" && textBox3.Text != null)
            {
                MinOplata = Convert.ToInt32(textBox3.Text);
            }
            int MaxOplata = Int32.MaxValue;
            if(textBox18.Text!= ""&& textBox18.Text != null)
            {
                MaxOplata = Convert.ToInt32(textBox18.Text);
            }
            int MaxPaid = Int32.MaxValue;
            if (textBox4.Text != "" && textBox4.Text != "")
            {
                MaxPaid = Convert.ToInt32(textBox4.Text);
            }
            int MinPaid = Int32.MinValue;
            if (textBox19.Text != "" && textBox19.Text != null)
            {
                MinPaid = Convert.ToInt32(textBox19.Text);
            }
            person Client = new person();
            if (uslovieRepMac == true)
            {
                filter.IDMachine = idForRepVibor;
            }
            if (textBox5.Text != "")
            {
               Client.FIO = textBox5.Text;
            }
            person Manger = new person();
            if (textBox6.Text != "")
            {
                Manger.FIO = textBox6.Text;
            }
            person Master = new person();
            if (textBox7.Text != "")
            {
                Master.FIO = textBox7.Text;
            }
            //if (checkBox16.Enabled == true)
            //{
                filter.oplata = checkBox16.Checked;
           // }
            if (textBox5.Text != "" || textBox6.Text != "" || textBox7.Text != "")
            {
                initializeRepairs(comboBox12.Text, comboBox11.Text, filter, MaxStart, Mintart, MaxEnd, MinEnd, MaxAdd, MinAdd, MaxOplata,MinOplata, MaxPaid,MinPaid, count, page, Client,Manger,Master,"Мастер");
            }
            else
            {
                initializeRepairs(comboBox12.Text, comboBox11.Text, filter, MaxStart, Mintart, MaxEnd, MinEnd, MaxAdd, MinAdd, MaxOplata, MinOplata, MaxPaid, MinPaid, count, page, Client, Manger, Master, "Никто");
            }
        }

        private void button44_Click_1(object sender, EventArgs e)
        {
            //label111.Visible = false;
            //label113.Visible = false;
            uslovie = false;
            if (uslovieRepMac == false)
            {
                IdVibranMac = InIsDatagrid(dataGridView8);
                panel15.Visible = false;
                vibranMac = false;
                del.Invoke(IdVibranMac);
                tabControl1.SelectedIndex = 5;
            }
            else if (uslovieRepMac == true)
            {
                idForRepVibor = InIsDatagrid(dataGridView8);
                panel15.Visible = false;
                vibranMac = false;
                tabControl1.SelectedIndex = 5;
                button42.BackColor = Color.Silver;
                del.Invoke(idForRepVibor);
                X_Click(null, null);
            }
            ref Panel xPan = ref panel2;
            ref Label xText = ref label111;
            StaticPanel.panelNaMesto(false, xPan, xText, "Выберите станок");
        }

        private void button25_Click(object sender, EventArgs e)
        {
            try
            {
               // if (autorization.Status != "Менеджер")
                //    throw new Exception();
                Add_Repairs form = new Add_Repairs(0, autorization);
                del = form.RegisterMachine;
                form.RegisterHandler(new Add_Repairs.initializeMac(viborMachine));
                form.RegisterRepaiersVibor(new Add_Repairs.ViborRepairs(RegForVibor));
                form.ShowDialog();
                button21_Click(null, null);
                uslovieRepMac = true;
            }
            catch(Exception)
            {
                MessageBox.Show("Ошибка или вы не являетесь Менеджером");
            }
        }
        public void RegForVibor ()
        {
            tabControl1.SelectedIndex = 5;
            button22_Click(null, null);
            button21_Click(null, null);
        }
        private void button39_Click_1(object sender, EventArgs e)
        {
            //label111.Visible = false;
            ////label112.Visible = false;
            uslovie = false;
            if (uslovieRepMac == false)
            {
                panel15.Visible = false;
                vibranMac = false;
                del.Invoke(0);
            }
           else if (uslovieRepMac == true)
            {
                panel15.Visible = false;
                vibranMac = false;
                button42.BackColor = Color.Gray;
                uslovieRepMac = false;
                tabControl1.SelectedIndex = 5;
            }
            ref Panel xPan = ref panel2;
            ref Label xText = ref label111;
            StaticPanel.panelNaMesto(false, xPan, xText, "Выберите станок");
        }

        private void dataGridView5_DoubleClick(object sender, EventArgs e)
        {
           
        }
        public void viborMacForRep ()
        {
            tabControl1.SelectedIndex = 3;
            panel2.Visible = true;
            panel15.Visible = true;
            vibranMac = true;
            
        }

        private void button42_Click(object sender, EventArgs e)
        {
            label111.Visible = true;
            uslovieRepMac = true;
            tabControl1.SelectedIndex = 3;
            panel2.Visible = true;
            panel15.Visible = true;
            uslovie = true;
            ref Panel xPan = ref panel2;
            ref Label xText = ref label111;
            StaticPanel.panelNaMesto(true, xPan, xText, "Выберите станок");
        }

        private void button26_Click(object sender, EventArgs e)
        {
            if (textBox14.Text == "Сотовый")
                textBox14.Text = "0";
            if (textBox13.Text == "Домашний")
                textBox13.Text = "0";
            person filtering = new person { FIO = textBox9.Text,  phoneSmart = Convert.ToInt32(textBox14.Text), phoneStac = Convert.ToInt32(textBox13.Text) };
            if (dateTimePicker4.Enabled == true)
                filtering.DateLastAutorization = dateTimePicker4.Value;
            DateTime min = new DateTime();
            if (dateTimePicker9.Enabled == true)
                min = dateTimePicker9.Value;
            DateTime max = new DateTime();
            if (dateTimePicker3.Enabled == true)
                max = dateTimePicker3.Value;
            DateTime dateAvtor = new DateTime();
            if (dateTimePicker11.Enabled == true)
                dateAvtor = dateTimePicker11.Value;
            DateTime dateAvtorMax = new DateTime();
            if (dateTimePicker10.Enabled == true)
                dateAvtorMax = dateTimePicker10.Value;
            string textForMethod = "DateAdd";
            switch (comboBox16.Text)
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
                case "Дата последнего входа":
                    textForMethod = "DateLastAutorization";
                    break;
            }
            InitializeMaster(textForMethod, comboBox15.Text, filtering, min, max, dateAvtor, dateAvtorMax, Convert.ToInt32(numericUpDown3.Value), Convert.ToInt32(numericUpDown1.Value));
        }
        bool uslovie = false;
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked == true)
            {
                dateTimePicker9.Enabled = true;
                dateTimePicker3.Enabled = true;
            }
            if (checkBox5.Checked == false)
            {
                dateTimePicker9.Enabled = false;
                dateTimePicker3.Enabled = false;
            }
        }

        private void checkBox10_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox10.Checked == true)
            {
                dateTimePicker10.Enabled = true;
                dateTimePicker11.Enabled = true;
            }
            if (checkBox10.Checked == false)
            {
                dateTimePicker10.Enabled = false;
                dateTimePicker11.Enabled = false;
            }
        }

        private void button56_Click(object sender, EventArgs e)
        {
            if (textBox17.Text == "Сотовый")
                textBox17.Text = "0";
            if (textBox16.Text == "Домашний")
                textBox16.Text = "0";
            person filtering = new person { FIO = textBox15.Text, phoneSmart = Convert.ToInt32(textBox17.Text), phoneStac = Convert.ToInt32(textBox16.Text) };
            if (dateTimePicker19.Enabled == true)
                filtering.DateLastAutorization = dateTimePicker19.Value;
            DateTime min = new DateTime();
            if (dateTimePicker20.Enabled == true)
                min = dateTimePicker20.Value;
            DateTime max = new DateTime();
            if (dateTimePicker18.Enabled == true)
                max = dateTimePicker18.Value;
            DateTime dateAvtor = new DateTime();
            if (dateTimePicker12.Enabled == true)
                dateAvtor = dateTimePicker12.Value;
            DateTime dateAvtorMax = new DateTime();
            if (dateTimePicker7.Enabled == true)
                dateAvtorMax = dateTimePicker7.Value;
            string textForMethod = "DateAdd";
            switch (comboBox14.Text)
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
                case "Дата последнего входа":
                    textForMethod = "DateLastAutorization";
                    break;
            }
            InitializeManger(textForMethod, comboBox13.Text, filtering, min, max, dateAvtor, dateAvtorMax, Convert.ToInt32(numericUpDown10.Value), Convert.ToInt32(numericUpDown4.Value));
        }

        private void button29_Click(object sender, EventArgs e)
        {
            AddUser form = new AddUser(1);
            form.ShowDialog();
            button26_Click(null,null);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            AddUser form = new AddUser(2);
            form.ShowDialog();
            button56_Click(null, null);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel18_Paint(object sender, PaintEventArgs e)
        {

        }

        private void X_Click(object sender, EventArgs e)
        {
            uslovieRepMac = false;
            button42.BackColor = Color.Gray;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            try
            {
                // if (autorization.Status != "Менеджер")
                //     throw new Exception();
                DialogResult result = MessageBox.Show(
          "Удалить ?",
          "Сообщение",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Information,
          MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    int id = InIsDatagrid(dataGridView5);
                    RepairsContext rep = new RepairsContext();
                    Repairs reps = rep.FindByIdRepairs(id, false);
                    bool uslovie = rep.DellRepairs(reps);
                    if (uslovie == false)
                    {
                        throw new Exception();
                    }
                    MessageBox.Show("Успешно");
                    button21_Click(null, null);
                }
                button21_Click(null, null);
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось удалить ремонт или вы не являетесь Менеджером");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ImyaFilter_Client.Text = "";
            CompanyFilter_Client.Text = "";
            PhoneSmartFilter_Client.Text = "Сотовый";
            PhoneStacFIlter_Client.Text = "Домашний";
            checkBox9.Checked = false;
            checkBox2.Checked = false;
            KollFilter_Client.Value = 15;
            strFilter_Client.Value = 1;
            comboBox3.SelectedIndex = 5;
            comboBox4.SelectedIndex = 1;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            checkBox3.Checked = false;
            checkBox8.Checked = false;
            numericUpDown5.Value = 15;
            numericUpDown8.Value = 1;
            textBox1.Text = "Клиент";
            textBox2.Text = "Менеджер";
            VibtanStan = false;
            comboBox8.SelectedIndex = 3;
            comboBox7.SelectedIndex = 1;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            checkBox11.Checked = false;
            checkBox14.Checked = false;
            checkBox15.Checked = false;
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            numericUpDown6.Value = 15;
            numericUpDown12.Value = 1;
            comboBox12.SelectedIndex = 1;
            comboBox11.SelectedIndex = 1;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                //if (autorization.Status != "Менеджер")
                 //   throw new Exception();
                DialogResult result = MessageBox.Show(
          "Если вы удалите данный станок, то удалятся и все его ремонты. Удалить ?",
          "Сообщение",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Information,
          MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    int id = InIsDatagrid(dataGridView8);
                    Stanok macCont = new Stanok();
                    bool itog = macCont.DellMachine(id);
                    if (itog == false)
                    {
                        throw new Exception();
                    }
                    MessageBox.Show("Успешно");
                    button11_Click(null, null);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось удалить станок или вы не являетесь менеджером");
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                //if (autorization.Status != "Менеджер")
                 //   throw new Exception();
                DialogResult result = MessageBox.Show(
          "Удалить ?",
          "Сообщение",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Information,
          MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    int id = InIsDatagrid(dataGridView4);
                    Uslugi uslugaCont = new Uslugi();
                    RepairsReferenceBook usluga = uslugaCont.FindByIdmac(id, false);
                    bool itog = uslugaCont.DellUslugi(usluga);
                    if (itog == false)
                    {
                        throw new Exception();
                    }
                    MessageBox.Show("Успешно");
                    button16_Click(null, null);
                }
                button16_Click(null, null);
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось удалить услугу или вы не являетесь менеджером");
            }
        }

        private void button28_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
          "Удалить?",
          "Сообщение",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Information,
          MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    int id = InIsDatagrid(dataGridView3);
                    Master del = new Master();
                    bool itog = del.DelMaster(id);
                    if (itog == false)
                        throw new Exception();
                    MessageBox.Show("Успешно");
                    button26_Click(null, null);
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось удалить мастера");
            }

        }

        private void label21_Click(object sender, EventArgs e)
        {
            Analiz_Client form = new Analiz_Client();
            form.ShowDialog();
        }

        private void label29_Click(object sender, EventArgs e)
        {
            Analiz_Machine form = new Analiz_Machine();
            form.ShowDialog();
        }

        private void label32_Click(object sender, EventArgs e)
        {
            Analiz_Repairs form = new Analiz_Repairs();
            form.ShowDialog();
        }

        private void button27_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void dataGridView3_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        public void SpravochStanUser (person user)
        {
            tabControl1.SelectedIndex = 2;
            button6_Click(null, null);
            button7_Click(null, null);
            textBoxMaster_MacRef.Text = user.FIO;
        }
        public void StanUser (person user)
        {
            button12_Click(null, null);
            tabControl1.SelectedIndex = 3;
            textBox2.Text = user.FIO;
            button11_Click(null, null);
        }
        public void UslugaUser (person user)
        {
            tabControl1.SelectedIndex = 4;
            button19_Click(null, null);
            textBox25.Text = user.FIO;
            button16_Click(null, null);
        }
        public void RepairsUser (person user)
        {
            tabControl1.SelectedIndex = 5;
            button22_Click(null, null);
            if (user.Status == "Менеджер")
                textBox6.Text = user.FIO;
            if (user.Status == "Мастер")
                textBox7.Text = user.FIO;
            button21_Click(null, null);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBoxCountry_Macref.Text = "";
            textBoxMark_MacRef.Text = "";
            textBoxName_MacRef.Text = "";
            textBoxMaster_MacRef.Text = "";
            numericUpDown2.Value = 15;
            numericUpDown9.Value = 1;
            comboBox6.SelectedIndex = 5;
            comboBox5.SelectedIndex = 1;
            button7_Click(null, null);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox11.Text = "";
            textBox12.Text = "";
            textBox25.Text = "";
            textBox10.Text = "";
            numericUpDown7.Value = 15;
            numericUpDown11.Value = 1;
            checkBox1.Checked = false;
            comboBox10.SelectedIndex = 3;
            comboBox9.SelectedIndex = 1;
            button16_Click(null, null);

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

        private void dataGridView6_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label60_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 db = new Model1();
                int id = autorization.ID;
                person pers = db.person
                    .Where(z => z.ID == autorization.ID).FirstOrDefault();
                KatochkaPolzovytelya form = new KatochkaPolzovytelya(pers);
                form.RegisterDelMacRef(new KatochkaPolzovytelya.MacRefDEL(SpravochStanUser));
                form.RegisterDelMac(new KatochkaPolzovytelya.MacDEL(StanUser));
                form.RegisterDelRep(new KatochkaPolzovytelya.RepDEL(RepairsUser));
                form.RegisterDelUsluga(new KatochkaPolzovytelya.UslugaDEL(UslugaUser));
                form.ShowDialog();
            }
            catch (Exception)
            {

            }
        }

        private void button32_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show(
          "Удалить?",
          "Сообщение",
          MessageBoxButtons.YesNo,
          MessageBoxIcon.Information,
          MessageBoxDefaultButton.Button1);
                if (result == DialogResult.Yes)
                {
                    int id = InIsDatagrid(dataGridView3);
                    Manager del = new Manager();
                    bool itog = del.DelManager(id);
                    if (itog == false)
                        throw new Exception();
                    MessageBox.Show("Успешно");
                    button56_Click(null, null);
                }
                button56_Click(null, null);
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось удалить Менеджера");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {      
            numericUpDown11.Value++;
            label22.Text = Convert.ToString(numericUpDown11.Value);
            button16_Click(null, null);
        }

        private void button47_Click(object sender, EventArgs e)
        {
            try
            {
                numericUpDown11.Value--;
                label22.Text = Convert.ToString(numericUpDown11.Value);
                button16_Click(null, null);
            }
            catch(Exception)
            {

            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                numericUpDown12.Value++;
                label28.Text = Convert.ToString(numericUpDown12.Value);
                button21_Click(null, null);
            }
            catch(Exception)
            {

            }
        }

        private void button48_Click(object sender, EventArgs e)
        {
            try
            {
                numericUpDown12.Value--;
                label28.Text = Convert.ToString(numericUpDown12.Value);
                button21_Click(null, null);
            }
            catch(Exception)
            {

            }
        }

        private void button30_Click_1(object sender, EventArgs e)
        {
            try
            {
                numericUpDown1.Value++;
                label85.Text = Convert.ToString(numericUpDown1.Value);
                button26_Click(null, null);
            }
            catch(Exception)
            {

            }
        }

        private void button53_Click(object sender, EventArgs e)
        {
            try
            {
                numericUpDown1.Value--;
                label85.Text = Convert.ToString(numericUpDown1.Value);
                button26_Click(null, null);
            }
            catch (Exception)
            {

            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            try
            {
                numericUpDown4.Value++;
                label37.Text = Convert.ToString(numericUpDown4.Value);
                button56_Click(null, null);
            }
            catch (Exception)
            {

            }
        }

        private void button55_Click(object sender, EventArgs e)
        {
            try
            {
                numericUpDown4.Value--;
                label37.Text = Convert.ToString(numericUpDown4.Value);
                button56_Click(null, null);
            }
            catch (Exception)
            {

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dateTimePicker5.Enabled = true;
                dateTimePicker6.Enabled = true;
            }
            if (checkBox1.Checked == false)
            {
                dateTimePicker5.Enabled = false;
                dateTimePicker6.Enabled = false;
            }
        }

        private void checkBox11_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox11.Checked == true)
            {
                dateTimePicker8.Enabled = true;
                dateTimePicker13.Enabled = true;
            }
            if (checkBox11.Checked == false)
            {
                dateTimePicker8.Enabled = false;
                dateTimePicker13.Enabled = false;
            }
        }

        private void checkBox14_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox14.Checked == true)
            {
                dateTimePicker14.Enabled = true;
                dateTimePicker15.Enabled = true;
            }
            if (checkBox14.Checked == false)
            {
                dateTimePicker14.Enabled = false;
                dateTimePicker15.Enabled = false;
            }
        }

        private void checkBox15_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox15.Checked == true)
            {
                dateTimePicker16.Enabled = true;
                dateTimePicker17.Enabled = true;
            }
            if (checkBox15.Checked == false)
            {
                dateTimePicker16.Enabled = false;
                dateTimePicker17.Enabled = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked == true)
            {
                dateTimePicker4.Enabled = true;
            }
            if (checkBox4.Checked == false)
            {
                dateTimePicker4.Enabled = false;
            }
        }

        private void checkBox12_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox12.Checked == true)
            {
                dateTimePicker20.Enabled = true;
                dateTimePicker18.Enabled = true;
            }
            if (checkBox12.Checked == false)
            {
                dateTimePicker20.Enabled = false;
                dateTimePicker18.Enabled = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked == true)
            {
                dateTimePicker7.Enabled = true;
                dateTimePicker12.Enabled = true;
            }
            if (checkBox6.Checked == false)
            {
                dateTimePicker7.Enabled = false;
                dateTimePicker12.Enabled = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = InIsDatagrid(dataGridView1);
            Client poisk = new Client();
            person client = poisk.FindByIdClient(id);
            Kartochka_Clienta form = new Kartochka_Clienta(client, autorization);
            form.RegisterDel(new Kartochka_Clienta.DelStan(RegisterClientForMac));
            form.RegisterDelRep(new Kartochka_Clienta.DelRep(RegisterClientForRep));
            form.ShowDialog();
            button4_Click(null, null);
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (VibtanStan == false)
            {
                int id = InIsDatagrid(dataGridView2);
                Stanki poisk = new Stanki();
                MachineReferenceBook mac = poisk.FindByIdStanok(id);
                Kartochka_MachineReferBook form = new Kartochka_MachineReferBook(mac, autorization);
                form.RegisterDel(new Kartochka_MachineReferBook.DelMac(RegisterMacRefForMac));
                form.ShowDialog();
                button7_Click(null, null);
            }
        }

        private void dataGridView8_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (vibranMac != true)
                {
                    int id = InIsDatagrid(dataGridView8);
                    Stanok stan = new Stanok();
                    Machine mac = stan.FindByIdmac(id, true);
                    Kartochka_Machine form = new Kartochka_Machine(mac, autorization);
                    form.RegisterDelegate(new Kartochka_Machine.AccountStateHandler(RegisterMacForRep));
                    form.ShowDialog();
                    button11_Click(null, null);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не робит форма");
            }
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id = InIsDatagrid(dataGridView4);
                RepairsReferenceBook usluga = new RepairsReferenceBook();
                Uslugi uslugaContex = new Uslugi();
                usluga = uslugaContex.FindByIdmac(id, true);
                Kartochka_Uslug uslug = new Kartochka_Uslug(autorization, usluga, autorization);
                uslug.ShowDialog();
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView5_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = InIsDatagrid(dataGridView5);
            Kartochka_Repairs form = new Kartochka_Repairs(id, autorization);
            form.RegisterDel(new Kartochka_Repairs.MacDel(viborMacForRep));
            del = form.RegisterMachine;
            form.ShowDialog();
        }

        private void dataGridView3_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (autorization.Status != "Админ")
                    throw new Exception();
                int id = InIsDatagrid(dataGridView3);
                Master mas = new Master();
                person pers = mas.FindByIdMaster(id);
                KatochkaPolzovytelya form = new KatochkaPolzovytelya(pers);
                form.RegisterDelMacRef(new KatochkaPolzovytelya.MacRefDEL(SpravochStanUser));
                form.RegisterDelMac(new KatochkaPolzovytelya.MacDEL(StanUser));
                form.RegisterDelRep(new KatochkaPolzovytelya.RepDEL(RepairsUser));
                form.RegisterDelUsluga(new KatochkaPolzovytelya.UslugaDEL(UslugaUser));
                form.ShowDialog();
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView6_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (autorization.Status != "Админ")
                    throw new Exception();
                int id = InIsDatagrid(dataGridView6);
                Manager mas = new Manager();
                person pers = mas.FindByIdManager(id);
                KatochkaPolzovytelya form = new KatochkaPolzovytelya(pers);
                form.RegisterDelMacRef(new KatochkaPolzovytelya.MacRefDEL(SpravochStanUser));
                form.RegisterDelMac(new KatochkaPolzovytelya.MacDEL(StanUser));
                form.RegisterDelRep(new KatochkaPolzovytelya.RepDEL(RepairsUser));
                form.RegisterDelUsluga(new KatochkaPolzovytelya.UslugaDEL(UslugaUser));
                form.ShowDialog();
            }
            catch (Exception)
            {

            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
