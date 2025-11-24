using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20251124_Inventory_Monitoring_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Inventory.GenerateInventory();
            Inventory.DisplaySummary();
            Console.ReadKey();
        }
    }
}
