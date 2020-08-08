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
    public partial class Add_Repairs : Form
    {
        public delegate void initializeMac();
        initializeMac delMac;
        Machine mac = new Machine();
        person pers = new person();

        List<RepairsReferenceBook> uslugi = new List<RepairsReferenceBook>();
        public void RegisterUslugi (List<RepairsReferenceBook> _uslugi)
        {
            uslugi = _uslugi;
            initilizeUslugi();
        }
        public void RegisterHandler(initializeMac del)
        {
            delMac = del;
        }
        public void RegisterMachine(int _id)
        {
            Stanok stan = new Stanok();
            mac = stan.FindByIdmac(_id, true);
            this.Visible = true;
            this.TopMost = true;
            initializeMachine(mac);
        }
        public void initilizeUslugi ()
        {
            dataGridView1.Rows.Clear();
            foreach(RepairsReferenceBook usluga in uslugi)
            {
                dataGridView1.Rows.Add(usluga.ServiceName, usluga.price);
            }
            Cena();
        }
        public Add_Repairs(int id, person autorization)
        {
            InitializeComponent();
            Stanok stan = new Stanok();
            mac = stan.FindByIdmac(id,true);
            initializeMachine(mac);
            initilizeUslugi();
            pers = autorization;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
         
        }
        public void InitializeUslugi(string sorting, string sortingA, RepairsReferenceBook filtering, DateTime maxDate, DateTime MinDate, int count, int page)
        {
           
        }

        public void initializeMachine (Machine machine)
        {
            try
            { 
                label10.Text = machine.MachineReferenceBook.Name;
                label11.Text = machine.MachineReferenceBook.Mark;
                label12.Text = Convert.ToString(machine.YerOfIssue.Date.Year);
                label13.Text = machine.person.Where(b => b.Status == "Клиент").FirstOrDefault().FIO;
            }
            catch(Exception)
            {
                
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        public delegate void ViborRepairs();
        ViborRepairs vib;
        public void RegisterRepaiersVibor (ViborRepairs _del)
        {
            vib = _del;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Repairs repairs = new Repairs();
                RepairsContext addRep = new RepairsContext();
                repairs.paid = Convert.ToInt32(textBox1.Text);
                repairs.price = Convert.ToInt32(textBox2.Text);
                repairs.AddDate = DateTime.Now;
                person client = mac.person.Where(m => m.Status == "Клиент").FirstOrDefault();
                repairs.IDMachine = mac.ID;
                if (repairs.price <= repairs.paid)
                {
                    repairs.oplata = true;
                }
                else
                {
                    repairs.oplata = false;
                }
                bool itog = addRep.addRepairs(repairs, pers,client,uslugi);
                if (itog == false)
                {
                    throw new Exception();
                }
                MessageBox.Show("Успешно");
                vib.Invoke();
                this.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось добавить ремонт");
            }

        }
        public void Cena()
        {
            float stoimost = 0;

            for (int m = 0; m < dataGridView1.RowCount; m++)
            {
                stoimost = stoimost + Convert.ToSingle(dataGridView1[1, m].Value);
            }
            label2.Text = Convert.ToString(stoimost);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            delMac.Invoke();
            this.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            viboruSLUG form = new viboruSLUG();
            form.RegisterList(uslugi);
            form.RegisterHandler(new viboruSLUG.initializeUslugi(RegisterUslugi));
            form.ShowDialog();
        }
    }
}
