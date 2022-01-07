using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using InventoryController.Data.Models;

namespace InventoryController.Validators
{
    public struct StockTextValidatorInput
    {
        public string StockText { get; set; }
        public Unit Unit { get; set; }
    }
}
