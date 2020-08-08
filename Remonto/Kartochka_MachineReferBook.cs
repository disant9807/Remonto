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
    public partial class Kartochka_MachineReferBook : Form
    {
        MachineReferenceBook stanok = new MachineReferenceBook();
        person master = new person();
        public delegate void DelMac(MachineReferenceBook mac);
        DelMac del;
        public void RegisterDel(DelMac _del)
        {
            del = _del;
        }
        public Kartochka_MachineReferBook(MachineReferenceBook _stanok, person autors)
        {
            try
            {
                InitializeComponent();
                skrytie(autors);
                stanok = _stanok;
                textBoxName.Text = stanok.Name;
                textBoxMark.Text = stanok.Mark;
                comboBoxCountry.Text = stanok.Country;
                foreach (person _master in stanok.person)
                    master = _master;
                labelMaster.Text = master.FIO;

            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось загрузить форму");
                this.Close();
            }
        }
        public void skrytie (person aut)
        {
            if (aut.Status != "Мастер")
            {
                buttonSave.Enabled = false;
            }
            if (aut.Status == "Мастер" || aut.Status == "Админ")
            {
                buttonSave.Enabled = true;
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                stanok.Name = textBoxName.Text;
                stanok.Mark = textBoxMark.Text;
                stanok.Country = Convert.ToString(comboBoxCountry.Text);
                Stanki stan = new Stanki();
                bool itog = stan.SaveStanok(stanok);
                if (itog == false)
                    throw new Exception();
                MessageBox.Show("Успешно!");
                this.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось изменить клиента");
            }
        }

        private void EndName_Click(object sender, EventArgs e)
        {
            textBoxName.Text = stanok.Name;
        }

        private void EndMark_Click(object sender, EventArgs e)
        {
            textBoxMark.Text = stanok.Mark;
        }

        private void EndCountry_Click(object sender, EventArgs e)
        {
            comboBoxCountry.Text = stanok.Country;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            del.Invoke(stanok);
            this.Close();
        }
    }
}
