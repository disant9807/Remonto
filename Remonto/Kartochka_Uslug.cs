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
    public partial class Kartochka_Uslug : Form
    {
        person _manager = new person();
        RepairsReferenceBook _usluga = new RepairsReferenceBook();
        public Kartochka_Uslug(person manager, RepairsReferenceBook usluga, person autors)
        {
            try
            {
                InitializeComponent();
                skrytie(autors);
                _usluga = usluga;
                _manager = manager;
                textBoxFIO.Text = usluga.ServiceName;
                textBoxCompany.Text = usluga.DescriptionIOfService;
                label7.Text = Convert.ToString(usluga.AddDate);
                textBox1.Text = Convert.ToString(usluga.price);
                label9.Text = manager.FIO;
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось згрузить форму");
                this.Close();
            }
        }
        public void skrytie (person aut)
        {
            if (aut.Status != "Менеджер")
            {
                buttonSave.Enabled = false;
            }
            if (aut.Status == "Менеджер" || aut.Status == "Админ")
            {
                buttonSave.Enabled = true;
            }
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                _usluga.ServiceName = textBoxFIO.Text;
                _usluga.DescriptionIOfService = textBoxCompany.Text;
                _usluga.price = Convert.ToSingle(textBox1.Text);
                Uslugi usluga = new Uslugi();
                bool itog = usluga.SaveMachine(_usluga);
                if (itog == false)
                {
                    throw new Exception();
                }
                _usluga = usluga.FindByIdmac(_usluga.ID, true);
                MessageBox.Show("Успешно");
                this.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось сохранить услугу");
            }
        }

        private void EndFIO_Click(object sender, EventArgs e)
        {
            textBoxFIO.Text = _usluga.ServiceName;
        }

        private void EndCompany_Click(object sender, EventArgs e)
        {
            textBoxCompany.Text = _usluga.DescriptionIOfService;
        }

        private void label3_Click(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(_usluga.price);
        }
    }
}
