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
        private Product _selectedRowData;
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
            PriceTextBox.Text = "$" + string.Format("{0:#,##0.00}", _selectedRowData.cost);
            ManufacturerTextBox.Text = _selectedRowData.manufacturer.ToString();
            ModelTextBox.Text = _selectedRowData.model.ToString();
            MemoryTextBox.Text = _selectedRowData.RAM_size.ToString();
            LCDSizeTextBox.Text = _selectedRowData.screensize.ToString();
            CPUBrandTextBox.Text = _selectedRowData.CPU_brand.ToString();
            CPUTypeTextBox.Text = _selectedRowData.CPU_type.ToString();
            CPUSpeedTextBox.Text = _selectedRowData.CPU_speed.ToString();
            CPUNumberTextBox.Text = _selectedRowData.CPU_number.ToString();
            ConditionTextBox.Text = _selectedRowData.condition.ToString();
            OSTextBox.Text = _selectedRowData.OS.ToString();
            PlatformTextBox.Text = _selectedRowData.platform.ToString();
            HDDTextBox.Text = _selectedRowData.HDD_size.ToString();
            GPUTypeTextBox.Text = _selectedRowData.GPU_Type.ToString();
            WebCamTextBox.Text = _selectedRowData.webcam.ToString();
            CalculateTotalPrice();
        }

        private void CalculateTotalPrice()
        {
            decimal price = (decimal)_selectedRowData.cost;
            decimal salesTax = price * (decimal)0.13;
            decimal total = price + salesTax;
            SalesTaxTextBox.Text = "$" + string.Format("{0:#,##0.00}", salesTax);
            TotalTextBox.Text = "$" + string.Format("{0:#,##0.00}", total);
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
            /*MessageBox.Show("Your Selection-----------------\n" 
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
             "Selected Computer");*/
            MessageBox.Show("Your Selection is being printed now.\n Thank you for using.");

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
        public void SettingPictureOnPlatform()
        {
            switch(_selectedRowData.platform)
            {
                case "Laptop":
                    ComputerPictureBox.Image = Properties.Resources.laptop;
                    break;
                case "Desktop PC":
                    ComputerPictureBox.Image = Properties.Resources.desktop;
                    break;
                default:
                    ComputerPictureBox.Image = Properties.Resources.defaultComputer;
                    break;
            }
        }
    }
}
