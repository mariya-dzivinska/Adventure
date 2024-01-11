using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Business.Services
{
    public class DataAccess
    {
        public void SaveData(string data)
        {
            // Code to save data to a specific database
        }
    }

    public class UserService
    {
        private readonly DataAccess _dataAccess;

        public UserService()
        {
            _dataAccess = new DataAccess();
        }

        public void CreateUser(string username, string password)
        {
            // Code to create a user

            _dataAccess.SaveData("User created: " + username);
        }
    }

}
