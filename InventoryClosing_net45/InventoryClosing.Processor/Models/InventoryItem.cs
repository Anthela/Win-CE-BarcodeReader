using System;

namespace InventoryClosing.Processor.Models
{
    public class InventoryItem
    {
        public string Barcode { get; set; }
        public string Name { get; set; }
        public int UnitPrice { get; set; }
        public string Vat { get; set; }
        public double Stock { get; set; }
        public string Unit { get; set; }
        public int Sum { get; set; }
        public DateTime Recorded { get; set; }
    }
}
