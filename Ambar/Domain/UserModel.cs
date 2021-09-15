using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ambar.Model.DAO;

namespace Ambar.Domain
{
    public class UserModel
    {
        private UserDAO userDAO = new UserDAO();

        public bool Login(string username, string password)
        {
            return userDAO.Login(username, password); 
        }

    }
}
