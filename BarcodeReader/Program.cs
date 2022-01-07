using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

using BarcodeReaderDataAccess = BarcodeReader.DataAccess.DataAccess;

namespace BarcodeReader
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

            Application.Run(new MainForm(dataAccess));
        }
    }
}