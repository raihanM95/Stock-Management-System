using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using StockManagementSystem.Properties;
using StockManagementSystem.Repository;
using StockManagementSystem.Models;


namespace StockManagementSystem.BLL
{
    class CompanyManager
    {
        CompanyRepository _companyRepository;
        public CompanyManager()
        {
            _companyRepository = new CompanyRepository();
        }

        public DataTable LoadCompanyDataGridView()
        {
            return _companyRepository.LoadCompanyDataGridView();
        }

        public bool ValidationCheck(Company company)
        {
            return _companyRepository.ValidationCheck(company);
        }

        public int InsertCompany(Company company)
        {
            return _companyRepository.InsertCompany(company);
        }

        public int UpdateCompany(Company company)
        {
            return _companyRepository.UpdateCompany(company);
        }
    }
}
