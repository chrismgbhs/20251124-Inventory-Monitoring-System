using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20251124_Inventory_Monitoring_System
{
    internal class Inventory
    {
        public static List<Product> products = new List<Product>();
        public static List<Product> distinctProducts = new List<Product>();
        public static List<string> productTypes = new List<string>();

        /// <summary>
        /// Initial inventory with some products
        /// </summary>
        public static void GenerateInventory()
        {
            /// Populate the inventory with initial products
            products.Add(new Product("Magbuhos Personal Computer","IT Related"));
            products.Add(new Product("Magbuhos Smartphone Pro", "IT Related"));
            products.Add(new Product("Magbuhos Smartphone Pro", "IT Related"));
            products.Add(new Product("Magbuhos IC Recorder", "IT Related"));
            products.Add(new Product("Magbuhos IC Recorder", "IT Related"));
            products.Add(new Product("Magbuhos Angel Fish", "Fish Products"));
            products.Add(new Product("Magbuhos IC Recorder", "IT Related"));
            products.Add(new Product("Magbuhos Janitor Fish", "Fish Products"));
            products.Add(new Product("Magbuhos IC Recorder", "IT Related"));
            products.Add(new Product("Magbuhos IC Recorder", "IT Related"));
            products.Add(new Product("Magbuhos Smartphone Pro", "IT Related"));
            products.Add(new Product("Magbuhos Janitor Fish", "Fish Products"));
            products.Add(new Product("Magbuhos Smartphone Pro", "IT Related"));
            products.Add(new Product("Magbuhos Angel Fish", "Fish Products"));
            products.Add(new Product("Magbuhos Smartphone Pro", "IT Related"));
            products.Add(new Product("Magbuhos Personal Computer", "IT Related"));
            products.Add(new Product("Magbuhos Personal Computer", "IT Related")); 
            products.Add(new Product("Magbuhos Personal Computer", "IT Related"));
            products.Add(new Product("Magbuhos AI Microprocessor", "IT Related"));
            products.Add(new Product("Magbuhos Janitor Fish", "Fish Products"));
            products.Add(new Product("Magbuhos Angel Fish", "Fish Products"));
            products.Add(new Product("Magbuhos Goldfish", "Fish Products"));
            products.Add(new Product("Magbuhos Arwana", "Fish Products"));
        }

        /// <summary>
        /// This method displays a summary of the inventory, showing the quantity of each distinct product.
        /// </summary>
        public static void DisplaySummary()
        {
            bool doLoop = true;

            while (doLoop)
            {
                Console.Clear();

                /// Generate the list of distinct products
                RegenerateDistinctProducts();

                /// Classify each type of products
                RegenerateDistinctProductTypes();

                /// Display inventory summary by countring the quantity of each distinct product
                Console.WriteLine("SUMMARY");
                Console.WriteLine();

                foreach (string type in productTypes)
                {
                    Console.WriteLine(type);
                    
                    foreach (var distinctProduct in distinctProducts)
                    {
                        if (distinctProduct.Type == type) 
                        {
                            DisplayProductQuantity(distinctProduct, out int count);
                        }       
                    }
                    Console.WriteLine();
                }
                
                OtherModes(out doLoop);
            }
            
        }

        /// <summary>
        /// This method provides options for modifying the inventory, such as updating product quantities or exiting the program.
        /// </summary>
        /// <param name="doLoop"></param>
        public static void OtherModes(out bool doLoop)
        {
            int input = 0;
            doLoop = true;

            List<string> options = new List<string>()
            {
                "Update Quantity",
                "Add Product",
                "Delete Product",
                "Exit"
            };

            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            Console.WriteLine();

            while (input < 1 || input > 4)
            {
                Console.Write("Select an option: ");
                int.TryParse(Console.ReadLine(), out input);
            }

            switch (input)
            {
                case 1:
                    Modify_Inventory.UpdateQuantity();
                    break;
                case 2:
                    Modify_Inventory.AddProduct();
                    break;
                case 3:
                    Modify_Inventory.RemoveProduct();
                    break;
                case 4:
                    doLoop = false;
                    break;
            }

        }

        /// <summary>
        /// Thsi method counts and displays the quantity of a specific distinct product in the inventory.
        /// </summary>
        /// <param name="distinctProduct"></param>
        /// <param name="count"></param>
        public static void DisplayProductQuantity(Product distinctProduct, out int count)
        {
            count = 0;

            foreach (var p in products)
            {
                if (p.Name == distinctProduct.Name)
                {
                    count++;
                }
            }

            Console.WriteLine($"{distinctProduct.Name}:\t{count}");
        }

        public static void RegenerateDistinctProducts()
        {
            distinctProducts.Clear();
            /// Generate the list of distinct products by comparing each product name from the inventory
            foreach (var product in products)
            {
                bool found = false;

                foreach (var distinctProduct in distinctProducts)
                {
                    if (product.Name == distinctProduct.Name)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    distinctProducts.Add(product);
                }
            }
        }

        /// <summary>
        /// This method classifies the types of each products.
        /// </summary>
        public static void RegenerateDistinctProductTypes()
        {
            productTypes.Clear();

            foreach (var product in products)
            {
                bool typeFound = false;

                foreach (string type in productTypes)
                {
                    if (product.Type == type)
                    {
                        typeFound = true;
                        break;
                    }
                }

                if (!typeFound)
                {
                    productTypes.Add(product.Type);
                }
            }
        }

        /// <summary>
        /// This method prints products under a classified type.
        /// </summary>
        /// <param name="typeInput"></param>
        public static void PrintClassifiedProducts(int typeInput, out int startingPoint, out int lastPoint)
        {
            bool startingPointFound = false;
            startingPoint = -1;
            lastPoint = -1;

            for (int counter = 0; counter <distinctProducts.Count; counter++)
            {
                if (distinctProducts[counter].Type == productTypes[typeInput - 1])
                {
                    Console.WriteLine($"{counter + 1}. {distinctProducts[counter].Name}");

                    while (!startingPointFound) 
                    {
                        startingPoint = counter;
                        startingPointFound = true;
                    }
                    
                    lastPoint = counter;
                }
            }
        }

        /// <summary>
        /// This method prints each type of products.
        /// </summary>
        public static void PrintProductTypes()
        {
            for (int counter = 0; counter < productTypes.Count; counter++)
            {
                Console.WriteLine($"{counter + 1}: {productTypes[counter]}");
            }
        }
    }
}
