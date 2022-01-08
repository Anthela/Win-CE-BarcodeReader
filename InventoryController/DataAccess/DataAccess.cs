﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using InventoryController.Data.Models;
using System.IO;

namespace InventoryController.DataAccess
{
    public class DataAccess
    {
        private readonly string path;

        public DataAccess(string path)
        {
            this.path = path;
        }

        public void SaveInventoryItem(InventoryItem inventoryItem)
        {
            using (StreamWriter writer = new StreamWriter(path, true, Encoding.UTF8))
            {
                var properties = inventoryItem.GetType().GetProperties().Select(prop =>
                    {
                        if (prop.PropertyType == typeof(DateTime))
                            return ((DateTime)prop.GetValue(inventoryItem, null)).ToString("yyyy.MM.dd HH:mm");

                        return prop.GetValue(inventoryItem, null).ToString();
                    }).ToArray();

                writer.WriteLine(string.Join(";", properties));
            }
        }
    }
}
