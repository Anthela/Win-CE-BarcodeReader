using InventoryClosing.Processor.Models;

namespace InventoryClosing.Processor
{
    public class Processor
    {
        private string path;
        private IEnumerable<InventoryItem> inventoryItems;

        public Processor(string path)
        {
            this.path = path;
            inventoryItems = GetInventoryItems();
        }

        private IEnumerable<InventoryItem> GetInventoryItems()
        {
            List<InventoryItem> inventoryItems = new();
            var lines = File.ReadAllLines(path).Select(line => line.Split(';'));

            foreach (var line in lines)
            {
                var inventoryItem = new InventoryItem();
                var properties = inventoryItem.GetType().GetProperties();

                for (int i = 0; i < properties.Length; i++)
                {
                    var property = properties[i];
                    var currentProp = inventoryItem.GetType().GetProperty(properties[i].Name);

                    if (currentProp!.PropertyType == typeof(int))
                        currentProp.SetValue(inventoryItem, Convert.ToInt32(line[i]));
                    else if (currentProp!.PropertyType == typeof(double))
                        currentProp.SetValue(inventoryItem, Convert.ToDouble(line[i]));
                    else if (currentProp!.PropertyType == typeof(DateTime))
                        currentProp.SetValue(inventoryItem, Convert.ToDateTime(line[i]));
                    else
                        currentProp.SetValue(inventoryItem, line[i]);
                }

                inventoryItems.Add(inventoryItem);
            }

            return inventoryItems;
        }

        public void Process()
        {
            var vatGroups = inventoryItems.GroupBy(group => group.Vat).ToList();

            foreach (var group in vatGroups)
            {
                string filePath = Path.Combine(Path.GetDirectoryName(path)!, $"Leltar_{group.Key.Replace("%", string.Empty)}.csv");
                File.Delete(filePath);

                foreach (var inventoryItem in group)
                {
                    var properties = inventoryItem.GetType().GetProperties().Select(prop =>
                    {
                        if (prop.PropertyType == typeof(DateTime))
                            return $"{(DateTime)prop.GetValue(inventoryItem)!:yyyy.MM.dd HH:mm}{Environment.NewLine}";

                        return prop.GetValue(inventoryItem)!.ToString();
                    });

                    File.AppendAllText(filePath, string.Join(';', properties));
                }
            }

        }
    }
}