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
    public partial class Kartochka_Repairs : Form
    {
        Repairs _repairs = new Repairs();
        person autorization = new person();
        
        public Kartochka_Repairs(int id, person _autorization)
        {
            try
            {
                InitializeComponent();
                skrytie(_autorization);
                RepairsContext repairCont = new RepairsContext();
                Repairs repairs = repairCont.FindByIdRepairs(id, true);
                initializeRep(repairs);
                _repairs = repairs;
                autorization = _autorization;
                button16_Click_1(null, null);
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось загрузить станок");
                this.Close();
            }
        }
        
        public void skrytie (person autoris)
        {
            if (autoris.Status == "Менеджер")
            {
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                button2.Enabled = false;
                button3.Enabled = false;
                button1.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                button6.Enabled = true;
            }
            else if (autoris.Status == "Мастер")
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button1.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                button6.Enabled = false;
            }
            else if (autoris.Status == "Админ")
            {
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button2.Enabled = true;
                button3.Enabled = true;
                button1.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                button6.Enabled = true;
            }
        }
        public delegate void MacDel ();
        MacDel del;
        public void RegisterDel(MacDel _del)
        {
            del = _del;
        }
        public void RegisterMachine (int id)
        {
            try
            {
                if (id != 0)
                {
                    this.Visible = true;
                    _repairs.IDMachine = id;
                    Machine stan = new Machine();
                    Stanok posikStan = new Stanok();
                    stan = posikStan.FindByIdmac(id, false);
                    Stanki poisk = new Stanki();
                    MachineReferenceBook machine = poisk.FindByIdStanok(stan.MachineId);
                    label2.Text = "Марка: " + machine.Mark + "; Название: " + machine.Name + "; Год выпуска: " + stan.YerOfIssue;
                }
            }
            catch (Exception)
            {

            }
        }        
        public void initializeRep(Repairs repairs)
        {
            try
            {           
            if (repairs.Machine != null)
            {
                    int id = repairs.Machine.MachineId;
                    Stanki poisk = new Stanki();
                    MachineReferenceBook machine = poisk.FindByIdStanok(id);
                    label2.Text = "Марка: " + machine.Mark + "; Название: " + machine.Name + "; Год выпуска: " + repairs.Machine.YerOfIssue;
            }
                textBox3.Text = Convert.ToString(repairs.price);
                textBox4.Text = Convert.ToString(repairs.paid);
                if (repairs.AddDate != DateTime.MinValue)
                    label10.Text = Convert.ToString(repairs.AddDate);
                if (repairs.StartDate != DateTime.MinValue)
                    dateTimePicker1.Value = repairs.StartDate;
                if (repairs.EndDate != DateTime.MinValue)
                    dateTimePicker2.Value = repairs.EndDate;
                if (repairs.person.Where(m => m.Status == "Клиент").FirstOrDefault() != null)
                    label20.Text = repairs.person.Where(m => m.Status == "Клиент").FirstOrDefault().FIO;
                if (repairs.person.Where(m => m.Status == "Мастер").FirstOrDefault() != null)
                    foreach (person master in repairs.person.Where(m => m.Status == "Мастер"))
                    {
                        label15.Text = label15.Text + master.FIO + ";";
                    }
                if (repairs.person.Where(m => m.Status == "Менеджер").FirstOrDefault() != null)
                    label16.Text = repairs.person.Where(m => m.Status == "Менеджер").FirstOrDefault().FIO;
                if (repairs.CharacterOfFailure != null)
                    textBox1.Text = repairs.CharacterOfFailure;
                if (repairs.AdditionalInformation != null)
                    textBox2.Text = repairs.AdditionalInformation;
                checkBox2.Checked = repairs.oplata;
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось загрузить ремонт");
            }
        }
        public void InitializeUslugi(List <RepairsReferenceBook> uslu)
        {
            _repairs.RepairsReferenceBook.Clear();
            _repairs.RepairsReferenceBook = uslu;
            button16_Click_1(null, null);
        }
        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Repairs repairs = new Repairs();
                repairs.ID = _repairs.ID;
                if (textBox3.Text != "")
                    repairs.price = Convert.ToInt32(textBox3.Text);
                if (textBox4.Text != "")
                    repairs.paid = Convert.ToInt32(textBox4.Text);
                repairs.StartDate = dateTimePicker1.Value;
                repairs.person = _repairs.person;
                repairs.EndDate = dateTimePicker2.Value;
                repairs.oplata = checkBox2.Checked;
                if (textBox1.Text != "")
                    repairs.CharacterOfFailure = textBox1.Text;
                if (textBox2.Text != "")
                    repairs.AdditionalInformation = textBox2.Text;
                repairs.RepairsReferenceBook = _repairs.RepairsReferenceBook;
                RepairsContext rep = new RepairsContext();
                bool itog = rep.SaveRepairs(repairs);
                if(itog == false)
                {
                    throw new Exception();
                }
                MessageBox.Show("Сохранено");
                this.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось сохранить");
            }



        }

        private void button16_Click_1(object sender, EventArgs e)
        {
            try
            {
                RepairsReferenceBook usluga = new RepairsReferenceBook();
                 //if (textBox11.Text != "")
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

                dataGridView4.Rows.Clear();
                Uslugi uslugaAdd = new Uslugi();
                List<RepairsReferenceBook> listRepa = new List<RepairsReferenceBook>();
                listRepa = _repairs.RepairsReferenceBook
                .Where(m => m.ServiceName.StartsWith(usluga.ServiceName) || usluga.ServiceName == "")
                .Where(m => m.DescriptionIOfService.StartsWith(usluga.DescriptionIOfService) || usluga.DescriptionIOfService == "")
                .Where(m => m.price == usluga.price || usluga.price == 0)
                .Where(z => z.AddDate <= MaxDate || MaxDate == DateTime.MinValue)
                .Where(z => z.AddDate >= MinDAte || MinDAte == DateTime.MinValue)
                .OrderByDescending(i => i.AddDate)
                .Skip((count * (page - 1)))
                .Take(count)
                .ToList();
                foreach (RepairsReferenceBook rep in listRepa)
                {
                    dataGridView4.Rows.Add(rep.ID, rep.ServiceName, rep.DescriptionIOfService, rep.AddDate, rep.price);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось загрузить услуги");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel13.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            viboruSLUG form = new viboruSLUG();
            form.RegisterList(_repairs.RepairsReferenceBook.ToList());
            form.RegisterHandler(new viboruSLUG.initializeUslugi(InitializeUslugi));
            form.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            del.Invoke();
            this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (autorization.Status == "Мастер")
                {
                    bool itog = true;
                    foreach (person pers in _repairs.person)
                    {
                        if (pers.ID == autorization.ID)
                            itog = false;
                    }
                    if (itog == true)
                        _repairs.person.Add(autorization);
                    RepairsContext repairs = new RepairsContext();
                    bool itog2 = repairs.SaveRepairs(_repairs);
                    if (itog2 == false)
                    {
                        throw new Exception();
                    }
                    MessageBox.Show("Успешно");
                    initializeRep(_repairs);
                }
                else if (autorization.Status != "Мастер")
                {
                    throw new Exception();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось взять станок");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (person master in _repairs.person.Where(m => m.Status == "Мастер"))
                {
                    if (master.ID == autorization.ID)
                    {
                        _repairs.person.Remove(master);
                    }
                    
                }
                button5_Click(null, null);
            }
            catch(Exception)
            {

            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(textBox4.Text) >= (Convert.ToInt32(textBox3.Text)))
                {
                    checkBox2.Checked = true;
                }
                else if (Convert.ToInt32(textBox4.Text) < (Convert.ToInt32(textBox3.Text)))
                {
                    checkBox2.Checked = false;
                }
            }
            catch(Exception)
            {
                
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(textBox4.Text) >= (Convert.ToInt32(textBox3.Text)))
                {
                    checkBox2.Checked = true;
                }
                else if (Convert.ToInt32(textBox4.Text) < (Convert.ToInt32(textBox3.Text)))
                {
                    checkBox2.Checked = false;
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
