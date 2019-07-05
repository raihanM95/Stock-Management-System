using StockManagementSystem.Repository;
using StockManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.BLL
{
    public class ItemManager
    {
        ItemRepository _itemRepository;
        public ItemManager()
        {
            _itemRepository = new ItemRepository();
        }

        public DataTable LoadCategory()
        {
            return _itemRepository.LoadCategory();
        }

        public DataTable LoadCompany()
        {
            return _itemRepository.LoadCompany();
        }

        public int ItemInsert(Item item)
        {
            return _itemRepository.ItemInsert(item);
        }

        public bool IsDuplicate(Item item)
        {
            return _itemRepository.IsDuplicate(item);
        }

        public DataTable Search(Item item)
        {
            return _itemRepository.Search(item);
        }
    }
}
