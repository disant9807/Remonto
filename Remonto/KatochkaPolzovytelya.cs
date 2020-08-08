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
    public partial class KatochkaPolzovytelya : Form
    {
        person master = new person();
        public KatochkaPolzovytelya( person user)
        {
            InitializeComponent();
            initializeUser(user);
        }
        public delegate void MacDEL(person user);
        MacDEL delMAC;
        public void RegisterDelMac (MacDEL _del)
        {
            delMAC = _del;
        }
        public delegate void MacRefDEL(person user);
        MacRefDEL delMacRef;
        public void RegisterDelMacRef (MacRefDEL _del)
        {
            delMacRef = _del;
        }
        public delegate void RepDEL(person user);
        RepDEL delREP;
        public void RegisterDelRep(RepDEL _del)
        {
            delREP = _del;
        }
        public delegate void UslugaDEL(person user);
        UslugaDEL delUsl;
        public void RegisterDelUsluga (UslugaDEL _del)
        {
            delUsl = _del;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                person Client = new person();
                Client = master;
                Client.FIO = textBoxFIO.Text;
                Client.phoneSmart = Convert.ToInt32(textBoxPhone.Text);
                Client.phoneStac = Convert.ToInt32(textBoxPhoneDom.Text);
                Client.AccesCode = textBox1.Text;
                Manager client = new Manager();
                bool itog = client.SaveManager(Client);
                if (itog == false)
                {
                    throw new Exception();
                }
                MessageBox.Show("Успешно");
                master = Client;
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Не удалось изменить клиента");
            }
        }
        public void initializeUser( person Client)
        {
            textBoxFIO.Text = Client.FIO;
            textBoxPhone.Text = Convert.ToString(Client.phoneSmart);
            textBoxPhoneDom.Text = Convert.ToString(Client.phoneStac);
            LabelDateAdd.Text = Convert.ToString(Client.DateAdd);
            textBox1.Text = Client.AccesCode;
            master = Client;
        }

        private void EndFIO_Click(object sender, EventArgs e)
        {
            textBoxFIO.Text = master.FIO;
        }

        private void EndPhoneSmart_Click(object sender, EventArgs e)
        {
            textBoxPhone.Text = Convert.ToString(master.phoneSmart);
        }

        private void EndPhoneStac_Click(object sender, EventArgs e)
        {
            textBoxPhoneDom.Text = Convert.ToString(master.phoneStac);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            textBox1.Text = master.AccesCode;
        }

        private void label9_Click(object sender, EventArgs e)
        {
            delMAC.Invoke(master);
        }

        private void label10_Click(object sender, EventArgs e)
        {
            delREP.Invoke(master);
        }

        private void label4_Click(object sender, EventArgs e)
        {
            delMacRef.Invoke(master);
        }

        private void label7_Click(object sender, EventArgs e)
        {
            delUsl.Invoke(master);
        }
    }
}
