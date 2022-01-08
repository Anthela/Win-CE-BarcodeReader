using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace InventoryController.Data.Models
{
    public class InventoryItem
    {
        public string Barcode { get; private set; }
        public string Name { get; private set; }
        public int UnitPrice { get; private set; }
        public string Vat { get; private set; }
        public double Stock { get; private set; }
        public string Unit { get; private set; }
        public int Sum { get; private set; }
        public DateTime Now { get; private set; }

        public InventoryItem(string barCode, string name, int unitPrice, string vat, double stock, string unit)
        {
            Barcode = barCode;
            Name = name;
            UnitPrice = unitPrice;
            Vat = vat;
            Stock = stock;
            Unit = unit;
            Sum = Convert.ToInt32(Math.Ceiling(UnitPrice * Stock));
            Now = DateTime.Now;
        }
    }
}
