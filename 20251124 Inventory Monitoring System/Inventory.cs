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

        /// <summary>
        /// Initial inventory with some products
        /// </summary>
        public static void GenerateInventory()
        {
            /// Populate the inventory with initial products
            products.Add(new Product("Magbuhos Personal Computer"));
            products.Add(new Product("Magbuhos Smartphone Pro"));
            products.Add(new Product("Magbuhos Smartphone Pro"));
            products.Add(new Product("Magbuhos IC Recorder"));
            products.Add(new Product("Magbuhos IC Recorder"));
            products.Add(new Product("Magbuhos IC Recorder"));
            products.Add(new Product("Magbuhos IC Recorder"));
            products.Add(new Product("Magbuhos IC Recorder"));
            products.Add(new Product("Magbuhos Smartphone Pro"));
            products.Add(new Product("Magbuhos Smartphone Pro"));
            products.Add(new Product("Magbuhos Smartphone Pro"));
            products.Add(new Product("Magbuhos Personal Computer"));
            products.Add(new Product("Magbuhos Personal Computer")); 
            products.Add(new Product("Magbuhos Personal Computer"));
            products.Add(new Product("Magbuhos AI Microprocessor"));

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
        /// This method displays a summary of the inventory, showing the quantity of each distinct product.
        /// </summary>
        public static void DisplaySummary()
        {
            bool doLoop = true;

            while (doLoop)
            {
                Console.Clear();
                /// Display inventory summary by countring the quantity of each distinct product
                Console.WriteLine("SUMMARY");
                Console.WriteLine();

                foreach (var distinctProduct in distinctProducts)
                {
                    DisplayProductQuantity(distinctProduct, out int count);
                }

                Console.WriteLine();
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
                //"Add Product", // Not required
                //"Remove Product", // Not required
                "Exit"
            };

            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }

            Console.WriteLine();

            while (input < 1 || input > 3)
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
    }
}
