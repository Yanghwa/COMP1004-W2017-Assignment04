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
        private DataGridViewRow _selectedRowData;
        public DataGridViewRow SelectedRowData
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
            ProductIDTextBox.Text = _selectedRowData.Cells[0].Value.ToString();
            CostTextBox.Text = _selectedRowData.Cells[1].Value.ToString();
            ManufacturerTextBox.Text = _selectedRowData.Cells[2].Value.ToString();
            ModelTextBox.Text = _selectedRowData.Cells[3].Value.ToString();
            MemoryTextBox.Text = _selectedRowData.Cells[5].Value.ToString();
            LCDSizeTextBox.Text = _selectedRowData.Cells[7].Value.ToString();
            CPUBrandTextBox.Text = _selectedRowData.Cells[10].Value.ToString();
            CPUTypeTextBox.Text = _selectedRowData.Cells[11].Value.ToString();
            CPUSpeedTextBox.Text = _selectedRowData.Cells[12].Value.ToString();
            CPUNumberTextBox.Text = _selectedRowData.Cells[13].Value.ToString();
            ConditionTextBox.Text = _selectedRowData.Cells[14].Value.ToString();
            OSTextBox.Text = _selectedRowData.Cells[15].Value.ToString();
            PlatformTextBox.Text = _selectedRowData.Cells[16].Value.ToString();
            HDDTextBox.Text = _selectedRowData.Cells[17].Value.ToString();
            GPUTypeTextBox.Text = _selectedRowData.Cells[19].Value.ToString();
            WebCamTextBox.Text = _selectedRowData.Cells[30].Value.ToString();
        }
    }
}
