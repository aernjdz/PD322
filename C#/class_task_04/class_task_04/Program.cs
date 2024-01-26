using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Xml.Serialization;

namespace class_task_04
{
    [Serializable]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
    [Serializable]
    public class SerializableStore
    {
        public List<Product> Products { get; set; } = new List<Product>();
    }
    [Serializable]
    public class Store
    {
        public Dictionary<int, Product> ProductsById { get; set; } = new Dictionary<int, Product>();
        public Dictionary<string, Product> ProductsByName { get; set; } = new Dictionary<string, Product>();
    }

    class Program
    {
        static void Main()
        {
          
            Store store = new Store();
            store.ProductsById.Add(1, new Product { Id = 1, Name = "Product1", Type = "Type1", Price = 10.99m, Quantity = 50 });
            store.ProductsByName.Add("Product2", new Product { Id = 2, Name = "Product2", Type = "Type2", Price = 20.49m, Quantity = 30 });

       
            string binaryFilePath = "storeBinary.dat";
            SaveToFileBinarySerialization(store, binaryFilePath);

            Store deserializedStoreBinary = LoadFromFileBinarySerialization(binaryFilePath);

            Console.WriteLine("Binary Deserialization Result:");
            DisplayStoreContents(deserializedStoreBinary);

          
            string jsonFilePath = "storeJson.json";
            SaveToFileJsonSerialization(store, jsonFilePath);

          
            Store deserializedStoreJson = LoadFromFileJsonSerialization(jsonFilePath);

         
            Console.WriteLine("\nJSON Deserialization Result:");
            DisplayStoreContents(deserializedStoreJson);


            string xmlFilePath = "storeXml.xml";
            SaveToFileXmlSerialization(store, xmlFilePath);

            Store deserializedStoreXml = LoadFromFileXmlSerialization(xmlFilePath);

            Console.WriteLine("\nXML Deserialization Result:");
            DisplayStoreContents(deserializedStoreXml);
        }

        static void DisplayStoreContents(Store store)
        {
            foreach (var product in store.ProductsById.Values)
            {
                Console.WriteLine($"Product ID: {product.Id}, Name: {product.Name}, Type: {product.Type}, Price: {product.Price}, Quantity: {product.Quantity}");
            }
        }

        static void SaveToFileBinarySerialization(Store store, string filePath)
        {
            byte[] binaryData = BinarySerialization.Serialize(store);
            File.WriteAllBytes(filePath, binaryData);
            Console.WriteLine($"Binary data saved to file: {filePath}");
        }

        static Store LoadFromFileBinarySerialization(string filePath)
        {
            byte[] binaryData = File.ReadAllBytes(filePath);
            return BinarySerialization.Deserialize<Store>(binaryData);
        }

        static void SaveToFileJsonSerialization(Store store, string filePath)
        {
            string jsonData = JsonSerialization.Serialize(store);
            File.WriteAllText(filePath, jsonData);
            Console.WriteLine($"JSON data saved to file: {filePath}");
        }

        static Store LoadFromFileJsonSerialization(string filePath)
        {
            string jsonData = File.ReadAllText(filePath);
            return JsonSerialization.Deserialize<Store>(jsonData);
        }


        static void SaveToFileXmlSerialization(Store store, string filePath)
        {
            var serializableStore = new SerializableStore
            {
                Products = store.ProductsById.Values.ToList()
            };

            XmlSerializer serializer = new XmlSerializer(typeof(SerializableStore));
            using (TextWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, serializableStore);
            }
            Console.WriteLine($"XML data saved to file: {filePath}");
        }

        static Store LoadFromFileXmlSerialization(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(SerializableStore));
            using (TextReader reader = new StreamReader(filePath))
            {
                var serializableStore = (SerializableStore)serializer.Deserialize(reader);
                var store = new Store();

                foreach (var product in serializableStore.Products)
                {
                    store.ProductsById.Add(product.Id, product);
                }

                return store;
            }
        }
    }


    public static class BinarySerialization
    {
        public static byte[] Serialize<T>(T obj)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, obj);
                return stream.ToArray();
            }
        }

        public static T Deserialize<T>(byte[] data)
        {
            using (var stream = new MemoryStream(data))
            {
                var formatter = new BinaryFormatter();
                return (T)formatter.Deserialize(stream);
            }
        }
    }


    public static class JsonSerialization
    {
        public static string Serialize<T>(T obj)
        {
            return JsonSerializer.Serialize(obj);
        }

        public static T Deserialize<T>(string json)
        {
            return JsonSerializer.Deserialize<T>(json);
        }
    }
}
