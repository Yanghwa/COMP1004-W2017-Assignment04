using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;

namespace DollarComputers
{
    public partial class StartForm : Form
    {
        private IFormatter objBinaryFormatter = new BinaryFormatter();
        private Product _product;
        public StartForm()
        {
            InitializeComponent();
            this._product = new Product();
        }

        private void StartNewOrderButton_Click(object sender, EventArgs e)
        {
            SelectForm select = new SelectForm();
            this.Hide();
            select.Show();

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoadSavedOrderButton_Click(object sender, EventArgs e)
        {
            ProductInfoForm product = new ProductInfoForm();
            product.Show();
            product.previousForm = new SelectForm();
            this.Hide();
            product.ClickOpenToolStripMenuItem(sender, e);
        }

    }
}
