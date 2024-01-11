using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure
{
    public interface IAppLoggerCreator
    {
        IAppLogger FactoryMethod();
    }

    public class ConsoleAppLogger: IAppLoggerCreator
    {
        public IAppLogger FactoryMethod()
        {
            return new ConsoleLogger();
        }
    }

    public class FileAppLogger : IAppLoggerCreator
    {
        public IAppLogger FactoryMethod()
        {
            return new FileLogger();
        }
    }

    public interface IAppLogger
    {
        void Log(string message);
    }

    public class ConsoleLogger : IAppLogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    public class FileLogger : IAppLogger
    {
        public void Log(string message)
        {
            Console.WriteLine("to file" + message);
        }
    }
}
