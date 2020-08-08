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
    public partial class AddMacRef : Form
    {
        person master = new person();
        public AddMacRef(person _master)
        {
            InitializeComponent();
            master = _master;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Model1 db = new Model1();
                MachineReferenceBook machine = new MachineReferenceBook();
                Stanki stanok = new Stanki();
                machine.Country = Convert.ToString(Country.Text);
                machine.Name = Names.Text;
                machine.Mark = Mark.Text;
                machine.DateAdd = DateTime.Now;
                bool itog = stanok.addStanok(machine, master);
                if (itog == false)
                {
                    throw new Exception();
                }
                MessageBox.Show("Успешно");
                Country.Text = "";
                Names.Text = "";
                Mark.Text = "";
                this.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Не удалось добавить станок, пожалуйста поверьте заполненность полей");
            }
        }
    }
}
