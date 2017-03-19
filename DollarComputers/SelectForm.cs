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
    
    public partial class SelectForm : Form
    {
        private DataGridViewSelectedRowCollection _selectedRow;
        ComputersContext ComputerDB = new ComputersContext();
        public SelectForm()
        {
            InitializeComponent();
        }

        private void SelectForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dollarComputersDataSet.products' table. You can move, or remove it, as needed.
            //this.productsTableAdapter.Fill(this.dollarComputersDataSet.products);
            //select all the products in the products table of Computer DB
            ComputersDataGridView.ClearSelection();
            try
            {
                
                var ComputersList = (from product in ComputerDB.products
                                     select product).ToList();
                var SingleComputer = (from product in ComputerDB.products
                                      select product).FirstOrDefault();
                ComputersDataGridView.DataSource = ComputersList;
                
                //foreach (var product in ComputersList)
                //{
                //    Console.WriteLine(product.model);
                // }
                //var SingleComputer = (from product in ComputerDB.products
                //                      where product.OS == "OSX"
                //                      select product).FirstOrDefault();
                //Console.WriteLine(SingleComputer.model);
            } 
            catch ( Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            ComputersDataGridView.ClearSelection();
            ComputersDataGridView.CurrentRow.Selected = false;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            ProductInfoForm productInfo = new ProductInfoForm();
            this.Hide();
            productInfo.previousForm = this;
            productInfo.Show();
        }
        
        private void ComputersDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in ComputersDataGridView.SelectedRows)
            {
                string manufacturer = row.Cells[2].Value.ToString();
                string model = row.Cells[3].Value.ToString();
                string cost = row.Cells[1].Value.ToString();
                YourSelectionTextBox.Text = manufacturer + ", " + model + ", $" + cost;
            }
            _selectedRow = ComputersDataGridView.SelectedRows;
            NextButton.Enabled = true;
            Console.WriteLine(_selectedRow[0].Cells[0].Value.ToString());
        }
    }
}
