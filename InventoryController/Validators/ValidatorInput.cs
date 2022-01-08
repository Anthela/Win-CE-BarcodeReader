using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace InventoryController.Validators
{
    public struct ValidatorInput
    {
        public BarcodeTextValidatorInput BarcodeTextValidatorInput { get; set; }
        public StockTextValidatorInput StockTextValidatorInput { get; set; }
    }
}
