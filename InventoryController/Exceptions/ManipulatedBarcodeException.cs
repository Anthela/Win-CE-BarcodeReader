using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace InventoryController.Exceptions
{
    public class ManipulatedBarcodeException : Exception
    {
        public ManipulatedBarcodeException(string errorMessage) : base(errorMessage) { }
    }
}
