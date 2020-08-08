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
    public partial class AddUslugi : Form
    {
        person _manager;
        public AddUslugi(person manager)
        {
            InitializeComponent();
            _manager = manager;
        }

        private void AddUslugi_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                RepairsReferenceBook usluga = new RepairsReferenceBook();
                usluga.AddDate = DateTime.Now;
                usluga.DescriptionIOfService = textBox1.Text;
                usluga.price = Convert.ToSingle(textBox2.Text);
                usluga.ServiceName = Imya.Text;
                Uslugi addUsluga = new Uslugi();
                bool itog = addUsluga.addUslugi(usluga, _manager);
                if (itog == false)
                    throw new Exception();
                MessageBox.Show("Успех");
                textBox1.Text = "";
                textBox2.Text = "0";
                Imya.Text = "";
                this.Close();

            }
            catch(Exception)
            {
                MessageBox.Show("Услуга не добавлена !");
            }
        }
    }
}
