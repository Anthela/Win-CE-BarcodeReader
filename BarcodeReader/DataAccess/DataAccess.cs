using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using BarcodeReader.DataAccess.Models;
using System.IO;

namespace BarcodeReader.DataAccess
{
    public class DataAccess
    {
        private string filePath;

        public DataAccess(string filePath)
        {
            this.filePath = filePath;
        }

        public IEnumerable<Product> ReadData()
        {
            List<Product> products = new List<Product>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (reader.Peek() >= 0)
                {
                    string[] data = reader.ReadLine().Split('\t');
                    Product productToAdd = new Product();

                    if (data.Length >= 1)
                        productToAdd.Name = data.First();

                    if (data.Length >= 2)
                        productToAdd.BarCode = data[1];

                    if (data.Length >= 3)
                        productToAdd.Price = Convert.ToInt32(data[2].Replace(" ", "").Replace(" ", ""));

                    if (data.Length >= 4)
                        productToAdd.Vat = data[3];

                    products.Add(productToAdd);
                }
            }

            return products;
        }

        public Product GetProductById(string id, IEnumerable<Product> products)
        {
            IEnumerable<Product> productList = products.Where(prod => prod.BarCode.Equals(id));

            if (productList.Any())
                return productList.First();

            return null;
        }
    }
}
