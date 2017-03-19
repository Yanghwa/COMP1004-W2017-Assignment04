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
    public partial class OrderForm : Form
    {
        public ProductInfoForm previousForm;
        private DataGridViewSelectedRowCollection _selectedRowData;
        public OrderForm()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void BringDataFromProductInfoForm()
        {
            _selectedRowData = previousForm.SelectedRowData;
            PriceTextBox.Text = _selectedRowData[0].Cells[1].Value.ToString();
            ManufacturerTextBox.Text = _selectedRowData[0].Cells[2].Value.ToString();
            ModelTextBox.Text = _selectedRowData[0].Cells[3].Value.ToString();
            MemoryTextBox.Text = _selectedRowData[0].Cells[5].Value.ToString();
            LCDSizeTextBox.Text = _selectedRowData[0].Cells[7].Value.ToString();
            CPUBrandTextBox.Text = _selectedRowData[0].Cells[10].Value.ToString();
            CPUTypeTextBox.Text = _selectedRowData[0].Cells[11].Value.ToString();
            CPUSpeedTextBox.Text = _selectedRowData[0].Cells[12].Value.ToString();
            CPUNumberTextBox.Text = _selectedRowData[0].Cells[13].Value.ToString();
            ConditionTextBox.Text = _selectedRowData[0].Cells[14].Value.ToString();
            OSTextBox.Text = _selectedRowData[0].Cells[15].Value.ToString();
            PlatformTextBox.Text = _selectedRowData[0].Cells[16].Value.ToString();
            HDDTextBox.Text = _selectedRowData[0].Cells[17].Value.ToString();
            GPUTypeTextBox.Text = _selectedRowData[0].Cells[19].Value.ToString();
            WebCamTextBox.Text = _selectedRowData[0].Cells[30].Value.ToString();
            CalculateTotalPrice();
        }

        private void CalculateTotalPrice()
        {
            double price = double.Parse(_selectedRowData[0].Cells[1].Value.ToString());
            double salesTax = price * 0.13;
            double total = price + salesTax;
            SalesTaxTextBox.Text = salesTax.ToString();
            TotalTextBox.Text = total.ToString();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            previousForm.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your Selection-----------------\n" 
                + "Condition: " + ConditionTextBox.Text + "\n"
                + "Platform: " + PlatformTextBox.Text + "\n"
                + "Manufacturer: " + ManufacturerTextBox.Text + "\n"    
                + "Model: " + ModelTextBox.Text + "\n"
                + "LCD Size: " + LCDSizeTextBox.Text + "\n"
                + "Memory: " + MemoryTextBox.Text + "\n"
                + "CPU Brand: " + CPUBrandTextBox.Text + "\n"
                + "CPU Type: " + CPUTypeTextBox.Text + "\n"
                + "CPU Number: " + CPUNumberTextBox.Text + "\n"
                + "CPU Speed: " + CPUSpeedTextBox.Text + "\n"
                + "HDD: " + HDDTextBox.Text + "\n"
                + "GPU Type: " + GPUTypeTextBox.Text + "\n"
                + "WebCam: " + WebCamTextBox.Text + "\n"
                + "OS: " + OSTextBox.Text + "\n"
                + "Price: " + PriceTextBox.Text + "\n"
                + "SalesTax: " + SalesTaxTextBox.Text + "\n"
                + "Total Price: " + TotalTextBox.Text + "\n",
             "Selected Computer");
        }

        private void FinishButton_Click(object sender, EventArgs e)
        {
            DialogResult completeOrderResult = MessageBox.Show("Thank you so much for your order! \n\n Your order will be processed in 7-10 business days!",
             "Complete your order!", MessageBoxButtons.OK);
            if(completeOrderResult == DialogResult.OK)
            {
                Application.Exit();
            }


        }
    }
}
