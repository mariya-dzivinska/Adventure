using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Business.Services
{
    public interface IDataAccess
    {
        void SaveData(string data);
    }

    public class DataAccessSolid : IDataAccess
    {
        public void SaveData(string data)
        {
            // Code to save data to a specific database
        }
    }

    public class UserServiceSolid
    {
        private readonly IDataAccess _dataAccess;

        public UserServiceSolid(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public void CreateUser(string username, string password)
        {
            // Code to create a user

            _dataAccess.SaveData("User created: " + username);
        }
    }
}
