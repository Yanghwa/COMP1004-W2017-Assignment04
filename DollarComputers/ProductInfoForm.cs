using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DollarComputers
{
    public partial class ProductInfoForm : Form
    {
        public SelectForm previousForm;
        public ProductInfoForm()
        {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            OrderForm order = new OrderForm();
            this.Hide();
            order.Show();
        }

        private void SelectAnotherProductButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            previousForm.Show();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
