using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Business.Services
{
    public interface IRouteStrategy
    {
        public void CalculateRoute();
    }

    public class PublicTransportStrategy : IRouteStrategy
    {
        public void CalculateRoute()
        {
            Console.WriteLine("PublicTransport");
        }
    }

    public class CarStrategy : IRouteStrategy
    {
        public void CalculateRoute()
        {
            Console.WriteLine("Car");
        }
    }

    public class AirStrategy : IRouteStrategy
    {
        public void CalculateRoute()
        {
            Console.WriteLine("Air");
        }
    }

    public class Customer
    {
        public IRouteStrategy _routeStrategy;

        public Customer()
        {
        }

        public void SetRouteStrategy(IRouteStrategy routeStrategy)
        {
            _routeStrategy = routeStrategy;
        }
    }
}
