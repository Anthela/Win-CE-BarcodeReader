using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace InventoryController.DataAccess.Models
{
    public class Unit
    {
        public string Name { get; private set; }

        public Unit(string name)
        {
            Name = name;
        }
    }
}
