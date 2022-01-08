using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

using BarcodeReaderDataAccess = BarcodeReader.DataAccess.DataAccess;
using InventoryDataAccess = InventoryController.DataAccess.DataAccess;
using InventoryController.Validators;

namespace InventoryController
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            //string path = @"\Program Files\BarcodeReader\Data\jutaxls_211229061136.csv";
            //string inventoryPath = @"\Program Files\InventoryController\Leltar.csv";
            string path = @"\My Documents\database.csv";
            string inventoryPath = @"\My Documents\Leltar.csv";

            BarcodeReaderDataAccess dataAccess = new BarcodeReaderDataAccess(path);
            InventoryDataAccess inventoryDataAccess = new InventoryDataAccess(inventoryPath);
            Validator validator = new Validator();

            Application.Run(new MainForm(dataAccess, inventoryDataAccess, validator));
        }
    }
}