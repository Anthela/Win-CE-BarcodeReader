using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using BarcodeReader.DataAccess.Models;
using BarcodeReader.DataAccess;

using BarcodeReaderDataAccess = BarcodeReader.DataAccess.DataAccess;

namespace BarcodeReader
{
    public partial class MainForm : Form
    {
        private List<Product> products;
        private readonly BarcodeReaderDataAccess dataAccess;

        public MainForm(BarcodeReaderDataAccess dataAccess)
        {
            InitializeComponent();

            this.dataAccess = dataAccess;
            products = dataAccess.ReadData().ToList();
        }

        private void OnItemNumberKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SetTextBoxTextsById((sender as TextBox).Text);
                this.BarcodeTextBox.SelectAll();
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
            {
                this.Close();
            }
        }

        private void SetTextBoxTextsById(string id)
        {
            Product product = dataAccess.GetProductById(id, products);

            if (product != null)
            {
                this.NameTextBox.Text = product.Name;
                this.PriceTextBox.Text = product.Price.ToString();
                this.VatTextBox.Text = product.Vat;
            }
            else
                MessageBox.Show("Nincs ilyen termék!", "Figyelem!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
        }
    }
}