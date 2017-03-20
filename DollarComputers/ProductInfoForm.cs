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
        private product _selectedRowData;
        public product SelectedRowData
        {
            get
            {
                return _selectedRowData;
            }
        }
        public ProductInfoForm()
        {
            InitializeComponent();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            OrderForm order = new OrderForm();
            this.Hide();
            order.previousForm = this;
            order.BringDataFromProductInfoForm();
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

        public void BringDataFromSelectForm()
        {
            _selectedRowData = previousForm.SelectedRow;
            ProductIDTextBox.Text = _selectedRowData.productID.ToString();
            CostTextBox.Text = _selectedRowData.cost.ToString();
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
        }
    }
}
