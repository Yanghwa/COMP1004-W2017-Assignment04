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
            
            try
            {
                ProductInfoForm product = new ProductInfoForm();
                string filename;
                DialogResult result;
                OpenProductFileDialog.Filter = "Text Files (*.txt)|*.txt|All files (*.*)|*.*";
                OpenProductFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                result = OpenProductFileDialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    filename = OpenProductFileDialog.FileName;
                    Stream objStreamDeSerialize = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                    product.SelectedRowData = (Product)objBinaryFormatter.Deserialize(objStreamDeSerialize);
                    product.SettingTextFromData();
                    //    MessageBox.Show("File Empty - No data to Read", "Error Reading File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    product.Show();
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
