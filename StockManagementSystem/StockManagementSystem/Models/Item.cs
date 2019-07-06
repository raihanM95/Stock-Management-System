using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Models
{
    public class Item
    {
        public int ID { get; set; }
        public string ItemName { get; set; }
        public int CategoryID { get; set; }
        public int CompanyID { get; set; }
        public int ReorderLevel { get; set; }
        public int AvailableQuantity { get; set; }

        // Items Summary
        public string Category { get; set; }
        public string Company { get; set; }
    }
}
