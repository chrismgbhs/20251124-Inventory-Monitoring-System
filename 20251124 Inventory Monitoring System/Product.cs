using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20251124_Inventory_Monitoring_System
{
    internal class Product
    {
        public string Name;
        public string Type;

        /// <summary>
        /// This constructor initializes a new instance of the Product class with the specified name.
        /// </summary>
        /// <param name="name"></param>
        public Product(string name, string type)
        {
            Name = name;
            Type = type;
        }
    }
}
