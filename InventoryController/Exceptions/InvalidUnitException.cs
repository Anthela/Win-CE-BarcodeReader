using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace InventoryController.Exceptions
{
    public class InvalidUnitException : Exception
    {
        public InvalidUnitException(string errorMessage) : base(errorMessage) { }
    }
}
