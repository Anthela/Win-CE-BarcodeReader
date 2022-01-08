using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace InventoryController.Exceptions
{
    public class InvalidStockValueException : Exception
    {
        public InvalidStockValueException(string errormessage) : base(errormessage) { }
    }
}
