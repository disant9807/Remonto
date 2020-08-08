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
    public partial class Kartochka_Machine : Form
    {
        Machine _machine = new Machine();
        public delegate void AccountStateHandler(Machine message);
        AccountStateHandler del;
        public void RegisterDelegate (AccountStateHandler _del)
        {
            del = _del;
        }
        public Kartochka_Machine(Machine machine, person autoriz)
        {
            try
            {
                InitializeComponent();
                skrytie(autoriz);
                InitializeMac(machine);
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось загрузить форму");
                this.Close();
            }
        }
        public void InitializeMac (Machine machine)
        {
            Stanok stan = new Stanok ();
            machine = stan.FindByIdmac(machine.ID, true);
            Name__.Text = machine.MachineReferenceBook.Name;
            Mark.Text = machine.MachineReferenceBook.Mark;
            Country.Text = machine.MachineReferenceBook.Country;
            label6.Text = Convert.ToString(machine.UploadDate);
            if (machine.person.Count != 0)
            {
                if (machine.person.Where(z => z.Status == "Клиент").FirstOrDefault() != null)
                label10.Text = machine.person.Where(z => z.Status == "Клиент").FirstOrDefault().FIO;
                if (machine.person.Where(m => m.Status == "Менеджер").FirstOrDefault() != null)
                label12.Text = machine.person.Where(m => m.Status == "Менеджер").FirstOrDefault().FIO;
            }
            string[] data = Convert.ToString(machine.YerOfIssue).Split('.');
            string[] data2 = data[2].Split(' ');
            textBox1.Text = data2[0];
            _machine = machine;
        }
        public void skrytie (person per)
        {
            if (per.Status != "Менеджер")
            {
                button1.Enabled = false;
                buttonSave.Enabled = false;
            }
            if (per.Status == "Менеджер" || per.Status == "Админ")
            {
                button1.Enabled = true;
                buttonSave.Enabled = true;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                Stanok stan = new Stanok();
                Machine mach = new Machine();
                mach = _machine;
                mach.YerOfIssue = new DateTime(Convert.ToInt32(textBox1.Text), 1, 1);
                bool itog = stan.SaveMachine(mach);
                if (itog == false)
                {
                    throw new Exception();
                }
                MessageBox.Show("Успешно");
                this.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось сохранить станок");
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {
            string[] data = Convert.ToString(_machine.YerOfIssue).Split('.');
            string[] data2 = data[2].Split(' ');
            textBox1.Text = data2[0];
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MacRefForMac form = new MacRefForMac(_machine.ID);
            form.ShowDialog();
            InitializeMac(_machine);

        }

        private void label9_Click(object sender, EventArgs e)
        {
            del.Invoke(_machine);
            this.Close();
        }
    }
}
