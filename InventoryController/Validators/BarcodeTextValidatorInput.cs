using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace InventoryController.Validators
{
    public struct BarcodeTextValidatorInput
    {
        public string BarcodeTextBoxText { get; set; }
        public string CurrentBarcode { get; set; }
    }
}
