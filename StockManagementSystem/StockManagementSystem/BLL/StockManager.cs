using StockManagementSystem.Models;
using StockManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.BLL
{
    public class StockManager
    {
        StockRepository _stockRepository;
        public StockManager()
        {
            _stockRepository = new StockRepository();
        }

        public DataTable LoadCompany()
        {
            return _stockRepository.LoadCompany();
        }

        public DataTable LoadCategory()
        {
            return _stockRepository.LoadCategory();
        }

        public DataTable LoadItem(int companyId, int categoryId)
        {
            return _stockRepository.LoadItem(companyId, categoryId);
        }

        public string LoadReorder(Stock stock)
        {
            return _stockRepository.LoadReorder(stock);
        }

        public string LoadQuantity(Stock stock)
        {
            return _stockRepository.LoadQuantity(stock);
        }

        public int LoadItemID(Stock stock)
        {
            return _stockRepository.LoadItemID(stock);
        }

        public int StockIn(Stock stock)
        {
            return _stockRepository.StockIn(stock);
        }

        public int UpdateStock(Stock stock)
        {
            return _stockRepository.UpdateStock(stock);
        }

        public int InsertAvailableQuantity(Item item)
        {
            return _stockRepository.InsertAvailableQuantity(item);
        }

        public DataTable DisplayStock(Stock stock)
        {
            return _stockRepository.DisplayStock(stock);
        }

        public DataTable GetQuantity(Item item)
        {
            return _stockRepository.GetQuantity(item);
        }

        public int StockOut(Stock stock)
        {
            return _stockRepository.StockOut(stock);
	    }

        public DataTable ViewReport(string fromDate, string toDate, string status)
        {
            return _stockRepository.ViewReport(fromDate, toDate, status);
        }
    }
}
