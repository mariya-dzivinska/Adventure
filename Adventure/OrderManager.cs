using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessServices;

namespace Adventure
{
    public interface IOrderManager
    {
        void Return();
    }

    public  class OrderManager : IOrderManager
    {
        private readonly IManager1 _manager1;

        public OrderManager(IManager1 manager)
        {
            _manager1 = manager;
        }


        public void Return()
        {
        }
    }
}
