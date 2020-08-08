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
    public partial class AddUser : Form
    {
        
        public AddUser(int i)
        {
            InitializeComponent();
           if (i == 1)
            {
                radioButton1.Checked = true;
            }
            if (i == 2)
            {
                radioButton2.Checked = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Master master = new Master();
                Manager manager = new Manager();
                person user = new person();
                if (Imya.Text != "")
                    user.FIO = Imya.Text;
                if (phone.Text != "Сотовый" && phone.Text != "" && phone.Enabled == true)
                    user.phoneSmart = Convert.ToInt32(phone.Text);
                if (phone2.Text != "Стационарный" && phone2.Text != "" && phone2.Enabled == true)
                    user.phoneStac = Convert.ToInt32(phone2.Text);
                if (user.phoneSmart == 0 && user.phoneStac == 0)
                    throw new Exception();
                if (textBoxPass.Text != "" || textBoxPass.Text != null)
                    user.AccesCode = textBoxPass.Text;
                else if (textBoxPass.Text == "" || textBoxPass.Text == null)
                    throw new Exception();
                bool itog = false;
                if (radioButton1.Checked)
                {
                    person poisk = master.GetListMaster(null, null, user, DateTime.MinValue, DateTime.MaxValue, DateTime.MinValue, DateTime.MaxValue, 10, 1).FirstOrDefault();
                    try
                    {
                        if (poisk.FIO != "" && poisk.FIO != null)
                        {
                            MessageBox.Show("Данный номер телефона уже зарегестрирован");
                    
                        }
                    }
                    catch (Exception)
                    {
                        itog = master.addMaster(user);
                    }
                }
                else if (radioButton2.Checked)
                {
                    person poisk = manager.GetListManager(null, null, user, DateTime.MinValue, DateTime.MaxValue, DateTime.MinValue, DateTime.MaxValue, 10, 1).FirstOrDefault();
                    try
                    {
                        if (poisk.FIO != "" && poisk.FIO != null)
                        {
                            MessageBox.Show("Данный номер телефона уже зарегестрирован");
                            
                        }
                    }
                    catch (Exception)
                    {
                        itog = manager.addManager(user);
                    }
                }
                if (itog == false)
                    throw new Exception();
                MessageBox.Show("Успешно");
                this.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось провести регистрацию, пожалуйста проверьте правильность введенных данных ");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                phone.Enabled = true;
            }
            else if (checkBox1.Checked == false)
                phone.Enabled = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                phone2.Enabled = true;
            }
            else if (checkBox2.Checked == false)
                phone2.Enabled = false;
        }

        private void phone_MouseLeave(object sender, EventArgs e)
        {
            if (phone.Text == "")
                phone.Text = "Сотовый";
        }

        private void phone2_MouseLeave(object sender, EventArgs e)
        {
            if (phone2.Text == "")
                phone2.Text = "Стационарный";
        }

        private void phone_Click(object sender, EventArgs e)
        {
            if (phone.Text == "Сотовый")
                phone.Text = "";
        }

        private void phone2_Click(object sender, EventArgs e)
        {
            if (phone2.Text == "Стационарный")
                phone2.Text = "";
        }
    }
}
