using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Repository;
using StockManagementSystem.Models;

namespace StockManagementSystem.BLL
{
    class SearchAndViewManager
    {
        SearchAndViewRepository _searchAndViewRepository = new SearchAndViewRepository();
        
        public DataTable LoadCompany()
        {
            return _searchAndViewRepository.LoadCompany();
        }
        public DataTable LoadCategory()
        {
            return _searchAndViewRepository.LoadCategory();
        }
        public DataTable Search(SearchAndViewModel searchAndViewModel)
        {
            return _searchAndViewRepository.Search(searchAndViewModel);
        }
    }
}
