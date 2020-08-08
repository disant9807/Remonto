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
    public partial class Kartochka_Clienta : Form
    {
        person Client = new person();
        bool VibtanStan = false;
        int IdVibranStan = 0;
        public delegate void DelStan (person client);
        DelStan del;
        public delegate void DelRep(person client);
        DelRep delRep;
        public void RegisterDel(DelStan _del)
        {
            del = _del;
        }
        public void RegisterDelRep (DelRep _del)
        {
            delRep = _del;
        }
        public Kartochka_Clienta(person _Client, person autoriza)
        {
            try
            {
                InitializeComponent();
                skrytie(autoriza);
                Client = _Client;
                InitializeClient();
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось загрузить форму");
                this.Close();
            }
        }
        public void skrytie(person aut)
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
        public void InitializeClient()
        {
            textBoxFIO.Text = Client.FIO;
            textBoxCompany.Text = Client.CompanyName;
            textBoxPhone.Text = Convert.ToString(Client.phoneSmart);
            textBoxPhoneDom.Text = Convert.ToString(Client.phoneStac);
            LabelDateAdd.Text = Convert.ToString(Client.DateAdd);

        }
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                Client.FIO = textBoxFIO.Text;
                Client.CompanyName = textBoxCompany.Text;
                Client.phoneSmart = Convert.ToInt32(textBoxPhone.Text);
                Client.phoneStac = Convert.ToInt32(textBoxPhoneDom.Text);
                Client client = new Client();
                bool itog = client.SaveClient(Client);
                if (itog == false)
                {
                    throw new Exception();
                }
                MessageBox.Show("Успешно");
                this.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось изменить клиента");
            }
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            textBoxFIO.Text = Client.FIO;
        }

        private void EndCompany_Click(object sender, EventArgs e)
        {
            textBoxCompany.Text = Client.CompanyName;
        }

        private void EndPhoneSmart_Click(object sender, EventArgs e)
        {
            textBoxPhone.Text = Convert.ToString(Client.phoneSmart);
        }

        private void EndPhoneStac_Click(object sender, EventArgs e)
        {
            textBoxPhoneDom.Text = Convert.ToString(Client.phoneStac);
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }
        public void InitializeMac(string sorting, string sortingA, Machine filtering, DateTime MinData, DateTime MaxData, DateTime MinYear, DateTime MaxYear, int count, int page)
        {
            
        }

        private void label9_Click(object sender, EventArgs e)
        {
            del.Invoke(Client);
            this.Close();
        }

        private void label10_Click(object sender, EventArgs e)
        {
            delRep.Invoke(Client);
            this.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
