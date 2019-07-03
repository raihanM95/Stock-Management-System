using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.Models
{
    public class Stock
    {
        public int ID { get; set; }
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }

        public string ItemName { get; set; }
        public string Company { get; set; }
    }
}
