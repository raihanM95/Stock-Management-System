using StockManagementSystem.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManagementSystem.BLL
{
    public class UserManager
    {
        UserRepository _userRepository;
        public UserManager()
        {
            _userRepository = new UserRepository();
        }

        public int LogIn(User user)
        {
            return _userRepository.LogIn(user);
        }
    }
}
