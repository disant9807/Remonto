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
    public partial class AddClient : Form
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                person Person = new person();
                if (phone.Text != "Сотовый" && phone.Text != "")
                    Person.phoneSmart = Convert.ToInt32(phone.Text);
                if (phone2.Text != "Стационарный" && phone2.Text != "")
                    Person.phoneStac = Convert.ToInt32(phone2.Text);
                Person.FIO = Imya.Text;
                Person.CompanyName = Companyname.Text;
                Client clientAdd = new Client();
                bool itog = clientAdd.addClient(Person);
                if (itog == false)
                {
                    throw new Exception();
                }
                if (itog == true)
                {
                    MessageBox.Show("Успешно!");
                    phone.Text = "";
                    Imya.Text = "";
                    Companyname.Text = "";
                    this.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось добавить клиента, пожалуйста проверьте правильность заполнения форм((");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                phone.Enabled = true;
            else if (checkBox1.Checked == false)
                phone.Enabled = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
                phone2.Enabled = true;
            else if (checkBox2.Checked == false)
                phone2.Enabled = false;
        }

        private void phone_Click(object sender, EventArgs e)
        {
            if (phone.Text == "Сотовый")

                phone.Text = "";
            }

        private void phone2_Click(object sender, EventArgs e)
        {
            if (phone2.Text == "Стационарный")
            {
                phone2.Text = "";
            }
        }
    }
}

