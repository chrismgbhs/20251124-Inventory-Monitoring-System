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

            for (int counter = 0; counter < Inventory.distinctProducts.Count; counter++)
            {
                Console.WriteLine($"{counter + 1}. {Inventory.distinctProducts[counter].Name}");
            }

            Console.WriteLine();

            while (productInput < 1 || productInput > Inventory.distinctProducts.Count)
            {
                Console.Write($"Select a product to update (1-{Inventory.distinctProducts.Count}): ");
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

            switch (quantityOption)
            {

                /// This case increases the quantity of a selected product by adding instances of that product to the inventory list.
                case 1:
                    int increaseAmount = 0;
                    Console.WriteLine();

                    Inventory.DisplayProductQuantity(Inventory.distinctProducts[productInput - 1], out currentQuantity);

                    while (increaseAmount <= 0)
                    {
                        Console.Write("Enter the amount to increase: ");
                        int.TryParse(Console.ReadLine(), out increaseAmount);
                    }

                    for (int counter = 0; counter < increaseAmount; counter++)
                    {
                        Inventory.products.Add(new Product(Inventory.distinctProducts[productInput-1].Name));
                    }
                    break;

                /// This case decreases the quantity of a selected product by removing instances of that product from the inventory list.
                case 2:
                    Console.WriteLine();
                    Inventory.DisplayProductQuantity(Inventory.distinctProducts[productInput - 1], out currentQuantity);

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
    }
}
