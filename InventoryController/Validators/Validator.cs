using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace InventoryController.Validators
{
    public class Validator
    {
        public string ValidControlValues(BarcodeTextValidatorInput barcodeTextValidatorInput, StockTextValidatorInput stockTextValidatorInput)
        {
            if (!barcodeTextValidatorInput.CurrentBarcode.Equals(barcodeTextValidatorInput.BarcodeTextBoxText))
                return "A vonalkód megváltozott a beolvasás óta!\r\nMentés sikertelen!";
            if (stockTextValidatorInput.Unit.Name.Equals("db") && (stockTextValidatorInput.StockText.Contains('.') || stockTextValidatorInput.StockText.Contains(',')))
                return "\"Darab\" mértékegység esetén a készlet csak egész szám lehet!";

            return null;
        }
    }
}
