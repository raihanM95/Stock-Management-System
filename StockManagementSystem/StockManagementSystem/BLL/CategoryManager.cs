using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Models;
using StockManagementSystem.Repository;

namespace StockManagementSystem.BLL
{
    public class CategoryManager
    {
        CategoryRepository _categoryRepository;
        public CategoryManager()
        {
            _categoryRepository = new CategoryRepository();
        }

        public DataTable LoadCategoryDataGridView()
        {
            return _categoryRepository.LoadCategoryDataGridView();
        }

        public bool ValidationCheck(Category category)
        {
            return _categoryRepository.ValidationCheck(category);
        }

        public int InsertCategory(Category category)
        {
            return _categoryRepository.InsertCategory(category);
        }

        public int UpdateCategory(Category category)
        {
            return _categoryRepository.UpdateCategory(category);
        }
    }
}
