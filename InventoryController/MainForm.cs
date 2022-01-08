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
using InventoryDataAccess = InventoryController.DataAccess.DataAccess;
using InventoryController.Exceptions;

namespace InventoryController
{
    public partial class MainForm : Form
    {
        private List<Product> products;
        private readonly BarcodeReaderDataAccess dataAccess;
        private readonly InventoryDataAccess inventoryDataAccess;
        private readonly Validator validator;
        private string currentBarcode;

        public MainForm(BarcodeReaderDataAccess dataAccess, InventoryDataAccess inventoryDataAccess, Validator validator)
        {
            InitializeComponent();

            this.dataAccess = dataAccess;
            this.inventoryDataAccess = inventoryDataAccess;
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
                SaveInventoryItem((TextBox)sender);
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
            currentBarcode = string.Empty;
        }

        private void OnUnitComboBoxKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
                SaveInventoryItem((ComboBox)sender);
            else if (e.KeyChar == Convert.ToChar(Keys.Escape))
                ResetFormControls();
        }

        private bool ValidDigitChar(char keyChar)
        {
            char[] dots = new char[] { '.', ',' };

            return Char.IsDigit(keyChar) || keyChar == Convert.ToChar(Keys.Back) || (dots.Contains(keyChar) && !this.StockTextBox.Text.Contains(keyChar));
        }

        private void SaveInventoryItem(Control control)
        {
            double stockValue = 0;
            string stockStr = this.StockTextBox.Text.Replace(',', '.');

            if (stockStr.Equals("."))
                stockValue = 0;
            else
                stockValue = Convert.ToDouble(stockStr);
            
            var validatorInput = new ValidatorInput()
            {
                BarcodeTextValidatorInput = new BarcodeTextValidatorInput()
                {
                    BarcodeTextBoxText = this.BarcodeTextBox.Text,
                    CurrentBarcode = currentBarcode
                },
                StockTextValidatorInput = new StockTextValidatorInput()
                {
                    StockText = stockStr,
                    StockValue = stockValue,
                    Unit = new Unit(this.UnitComboBox.Text)
                }
            };

            try
            {
                if (validator.ValidControlValues(validatorInput))
                {
                    InventoryItem inventoryItem = new InventoryItem(this.BarcodeTextBox.Text,
                                                                    this.NameTextBox.Text,
                                                                    Convert.ToInt32(this.PriceTextBox.Text),
                                                                    this.VatTextBox.Text,
                                                                    stockValue,
                                                                    this.UnitComboBox.Text);

                    inventoryDataAccess.SaveInventoryItem(inventoryItem);

                    ResetFormControls();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);
                if (ex is InvalidUnitException)
                {
                    if (control is ComboBox)
                    {
                        this.StockTextBox.Focus();
                        this.StockTextBox.SelectAll();
                    }
                    else
                        this.UnitComboBox.Focus();
                }
                else
                    ResetFormControls();
            }
        }
    }
}