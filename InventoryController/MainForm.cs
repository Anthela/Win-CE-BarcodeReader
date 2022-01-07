using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using InventoryController.Data.Models;
using BarcodeReader.DataAccess.Models;
using InventoryController.Validators;

using BarcodeReaderDataAccess = BarcodeReader.DataAccess.DataAccess;

namespace InventoryController
{
    public partial class MainForm : Form
    {
        private List<Product> products;
        private readonly BarcodeReaderDataAccess dataAccess;
        private readonly Validator validator;
        private string currentBarcode;

        public MainForm(BarcodeReaderDataAccess dataAccess, Validator validator)
        {
            InitializeComponent();

            this.dataAccess = dataAccess;
            this.validator = validator;
            products = dataAccess.ReadData().ToList();

            Unit[] units = new Unit[]{
                new Unit("db"),
                new Unit("kg")
            };

            this.UnitComboBox.DataSource = units;
            this.UnitComboBox.DisplayMember = "Name";
        }

        private bool SetTextBoxTextsById(string id)
        {
            bool productFound = false;
            Product product = dataAccess.GetProductById(id, products);

            if (product != null)
            {
                productFound = true;
                this.NameTextBox.Text = product.Name;
                this.PriceTextBox.Text = product.Price.ToString();
                this.VatTextBox.Text = product.Vat;
            }
            else
                MessageBox.Show("Nincs ilyen termék!", "Figyelem!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

            return productFound;
        }

        private void OnBarcodeTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                string barcode = (sender as TextBox).Text;
                if (SetTextBoxTextsById(barcode))
                {
                    this.StockTextBox.Focus();
                    this.StockTextBox.SelectAll();
                    currentBarcode = barcode;
                }
                else
                    ResetFormControls();
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
                this.Close();
        }

        private void OnStockTextBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                this.UnitComboBox.Focus();
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
                ResetFormControls();
            else if (!ValidDigitChar(e.KeyChar))
                e.Handled = true;
        }

        private void ResetFormControls()
        {
            this.BarcodeTextBox.Focus();
            this.BarcodeTextBox.SelectAll();
            this.NameTextBox.Text = string.Empty;
            this.PriceTextBox.Text = string.Empty;
            this.VatTextBox.Text = string.Empty;
            this.StockTextBox.Text = "0";
        }

        private void OnUnitComboBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                var barcodeTextValidatorInput = new BarcodeTextValidatorInput()
                {
                    BarcodeTextBoxText = this.BarcodeTextBox.Text,
                    CurrentBarcode = currentBarcode
                };

                var stockTextValidatorInput = new StockTextValidatorInput()
                {
                    StockText = this.StockTextBox.Text,
                    Unit = new Unit("db")
                };

                string errorMessage = validator.ValidControlValues(barcodeTextValidatorInput, stockTextValidatorInput); 
                if (!string.IsNullOrEmpty(errorMessage))
                    MessageBox.Show(errorMessage, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                else
                {
                    // nem számmal kezdődő készlet esetén 0 eléfűzése
                    // adatok összegyűjtése
                    // DataAccess segítségével fájlba írás
                }

                ResetFormControls();
            }
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
                ResetFormControls();
        }

        private bool ValidDigitChar(char keyChar)
        {
            char[] dots = new char[] { '.', ',' };

            return Char.IsDigit(keyChar) || keyChar == Convert.ToChar(Keys.Back) || (dots.Contains(keyChar) && !this.StockTextBox.Text.Contains(keyChar));
        }
    }
}