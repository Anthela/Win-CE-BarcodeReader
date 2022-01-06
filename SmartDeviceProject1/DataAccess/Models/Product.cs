using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace BarcodeReader.DataAccess.Models
{
    public class Product
    {
        public string BarCode { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Vat { get; set; }
    }
}
