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
    public partial class ProductInfoForm : Form
    {
        private IFormatter objBinaryFormatter = new BinaryFormatter();
        public SelectForm previousForm;
        private Product _selectedRowData;
        
        public Product SelectedRowData
        {
            get
            {
                return _selectedRowData;
            }
            set
            {
                this._selectedRowData = value;
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
            if (previousForm != null)
            {
                previousForm.Show();
            } 
            else
            {
                this.Close();
                StartForm start = new StartForm();
                start.Show();
            }
                
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void SettingTextFromData()
        {
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

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result;
            string filename;
            SaveProductFileDialog.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";
            SaveProductFileDialog.FileName = "Product.txt";
            SaveProductFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
            result = SaveProductFileDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                filename = SaveProductFileDialog.FileName;
                try
                {
                    Stream objStream = new FileStream(filename, FileMode.Create,FileAccess.ReadWrite,FileShare.None);
                    objBinaryFormatter.Serialize(objStream, _selectedRowData);
                    objStream.Close();
                    MessageBox.Show("File Written Successfully", "File Status", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                    MessageBox.Show("Error Writting File", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
            
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string filename;
                DialogResult result;
                OpenProductFileDialog.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";
                OpenProductFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                result = OpenProductFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    filename = OpenProductFileDialog.FileName;
                    Stream objStreamDeSerialize = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                    _selectedRowData = (Product)objBinaryFormatter.Deserialize(objStreamDeSerialize);
                    SettingTextFromData();
                    //    MessageBox.Show("File Empty - No data to Read", "Error Reading File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                    //this._reader.Close();   //flushes the buffer and read the files
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                MessageBox.Show("Error Reading File", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
