using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.FactoryMethod
{
    public interface ILoggerProvider
    {
        public ILogger FactoryMethod();
    }
    public class ConsoleLoggerProvider : ILoggerProvider
    {
        public ILogger FactoryMethod()
        {
            return new ConsoleLogger();
        }
    }

    public class WebLoggerProvider : ILoggerProvider
    {
        public ILogger FactoryMethod()
        {
            return new WebLogger();
        }
    }

    public interface ILogger
    {}

    public class ConsoleLogger : ILogger
    {

    }

    public class WebLogger : ILogger
    {

    }
}

