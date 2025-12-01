using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20251124_Inventory_Monitoring_System
{
    internal class Modify_Inventory
    {
        /// <summary>
        /// This method allows the user to update the quantity of a selected product in the inventory.
        /// </summary>
        public static void UpdateQuantity()
        {
            Console.Clear();
            int productInput = 0;
            int quantityOption = 0;
            int currentQuantity = 0;
            int typeInput = 0;
            int startingPoint;
            int lastPoint;

            Inventory.PrintProductTypes();

            while (typeInput == 0)
            {
                Console.Write("Please enter product type: ");
                int.TryParse(Console.ReadLine(), out typeInput);
            }

            Console.Clear();
            
            Inventory.PrintClassifiedProducts(typeInput, out startingPoint, out lastPoint);

            Console.WriteLine();

            while (productInput < startingPoint + 1 || productInput > lastPoint + 1 || Inventory.distinctProducts[productInput - 1].Type != Inventory.productTypes[typeInput - 1])
            {
                productInput = 0;
               
                Console.Write($"Select a product to update ({startingPoint+1}-{lastPoint+1}): ");
                int.TryParse(Console.ReadLine(), out productInput);
            }

            Console.WriteLine();

            Console.WriteLine("PLEASE SELECT ");
            Console.WriteLine("1. Increase Quantity");
            Console.WriteLine("2. Decrease Quantity");

            while (quantityOption < 1 || quantityOption > 2)
            {
                Console.Write("Select an option (1-2): ");
                int.TryParse(Console.ReadLine(), out quantityOption);
            }

            Inventory.DisplayProductQuantity(Inventory.distinctProducts[productInput - 1], out currentQuantity);

            switch (quantityOption)
            {

                /// This case increases the quantity of a selected product by adding instances of that product to the inventory list.
                case 1:
                    int increaseAmount = 0;
                    Console.WriteLine();

                    while (increaseAmount <= 0)
                    {
                        Console.Write("Enter the amount to increase: ");
                        int.TryParse(Console.ReadLine(), out increaseAmount);
                    }

                    for (int counter = 0; counter < increaseAmount; counter++)
                    {
                        Inventory.products.Add(new Product(Inventory.distinctProducts[productInput-1].Name, Inventory.distinctProducts[productInput - 1].Type));
                    }
                    break;

                /// This case decreases the quantity of a selected product by removing instances of that product from the inventory list.
                case 2:
                    Console.WriteLine();

                    bool loopYes = true;

                    while (loopYes)
                    {
                        int decreaseAmount = 0;

                        while (decreaseAmount <= 0)
                        {
                            Console.Write("Enter the amount to decrease: ");
                            int.TryParse(Console.ReadLine(), out decreaseAmount);
                        }

                        if (decreaseAmount > currentQuantity)
                        {
                            Console.WriteLine("Error: Decrease amount exceeds current quantity.");
                        }

                        else
                        {
                            for (int counter = 0; counter < decreaseAmount; counter++)
                            {
                                foreach (var p in Inventory.products)
                                {
                                    if (p.Name == Inventory.distinctProducts[productInput - 1].Name)
                                    {
                                        Inventory.products.Remove(p);
                                        loopYes = false;
                                        break;
                                    }
                                }   
                            }
                        }
                    }

                break;
            }
        }
        /// <summary>
        /// This method allows the user to add a new product to the inventory.
        /// </summary>
        public static void AddProduct()
        {
            int quantity = 0;
            string productName = "";
            string productType = "";
            bool typeFound = false;

            Console.Clear();    

            while (productName == "")
            {
                Console.Write("Enter the name of the new product: ");
                productName = Console.ReadLine();
            }

            while (productType == "")
            {
                Console.Write("Enter the type of the new product: ");
                productType = Console.ReadLine();

                foreach (var product in Inventory.products)
                {
                    if (productName == product.Name && productType != product.Type)
                    {
                        Console.WriteLine("Product already found at a different product type.");
                        productType = "";
                    }
                }
            }

            while (quantity <= 0)
            {
                Console.Write("Enter the quantity of the new product: ");
                int.TryParse(Console.ReadLine(), out quantity);
            }

            for (int counter = 0; counter < quantity; counter++)
            {
                Inventory.products.Add(new Product(productName,productType));
            }
        }
        /// <summary>
        /// This method allows the user to remove a product from the inventory.
        /// </summary>
        public static void RemoveProduct()
        {
            bool productFound = false;
            string productName = "";
            int productInput = 0;
            int typeInput = 0;
            int startingPoint;
            int lastPoint;
            Console.Clear();

            Inventory.PrintProductTypes();

            while (typeInput == 0)
            {
                Console.Write("Please enter product type: ");
                int.TryParse(Console.ReadLine(), out typeInput);
            }

            Console.Clear();

            Inventory.PrintClassifiedProducts(typeInput, out startingPoint, out lastPoint);

            Console.WriteLine();

            while (productInput < startingPoint+1 || productInput > lastPoint+1 || Inventory.distinctProducts[productInput-1].Type != Inventory.productTypes[typeInput-1])
            {
                productInput = 0;

                Console.Write($"Select a product to remove ({startingPoint+1}-{lastPoint+1}): ");
                int.TryParse(Console.ReadLine(), out productInput);
            }

            productName = Inventory.distinctProducts[productInput-1].Name;

            foreach (var product in Inventory.products)
            {
                if (product.Name == productName)
                {
                    Inventory.products.Remove(product);
                    productFound = true;
                    break;
                }
            }

            if (!productFound)
            {
                Console.WriteLine("Product not found in inventory.");
            }

            else
            {
                Console.WriteLine("Product deleted successfully.");
            }

                Console.WriteLine("Please press any key to continue...");
            Console.ReadKey();
        }
    }
}
