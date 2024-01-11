using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Adventure.FactoryMethod;
using FluentMigrator.Builder.Create.Index;

namespace Adventure
{
    public  interface IOrderService
    {
        bool GetLogger(ILoggerProvider loggerProvider);
    }

    public class OrderService : IOrderService
    {
        

        public bool GetLogger(ILoggerProvider loggerProvider)
        {
            if (loggerProvider != null)
            {
                 return true;    
            }
            return false;
        }
    }
}
