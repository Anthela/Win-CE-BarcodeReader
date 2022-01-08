using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using InventoryController.Exceptions;

namespace InventoryController.Validators
{
    public class Validator
    {
        public bool ValidControlValues(ValidatorInput validatorInput)
        {
            if (!validatorInput.BarcodeTextValidatorInput.CurrentBarcode.Equals(validatorInput.BarcodeTextValidatorInput.BarcodeTextBoxText))
                throw new ManipulatedBarcodeException("A vonalkód megváltozott a beolvasás óta!\r\nMentés sikertelen!");
            
            if (validatorInput.StockTextValidatorInput.Unit.Name.Equals("db") && validatorInput.StockTextValidatorInput.StockText.Contains('.'))
                throw new InvalidUnitException("\"Darab\" mértékegység esetén a készlet csak egész szám lehet!");

            if (validatorInput.StockTextValidatorInput.StockValue == 0)
                throw new InvalidStockValueException("A készlet nem lehet 0!");

            return true;
        }
    }
}
