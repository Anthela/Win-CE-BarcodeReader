using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

using BarcodeReaderDataAccess = BarcodeReader.DataAccess.DataAccess;
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
            string path = @"\My Documents\database.csv";

            BarcodeReaderDataAccess dataAccess = new BarcodeReaderDataAccess(path);
            Validator validator = new Validator();

            Application.Run(new MainForm(dataAccess, validator));
        }
    }
}