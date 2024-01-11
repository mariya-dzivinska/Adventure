using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public interface IOrderCreator
    {
        public IOrder Create();
    }

    public class ServiceOrderCreator : IOrderCreator
    {
        public IOrder Create()
        {
            return new ServiceOrder();
        }
    }

    public class FoodOrderCreator : IOrderCreator
    {
        public IOrder Create()
        {
            return new FoodOrder();
        }
    }

    public interface IOrder
    {
        public string Name { get; set; }
    }

    public class FoodOrder : IOrder
    {
        public string Name { get; set; } = "Food";
    }

    public class ServiceOrder : IOrder
    {
        public string Name { get; set; } = "Service";
    }
}
