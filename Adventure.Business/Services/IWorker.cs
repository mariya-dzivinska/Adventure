using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Business.Services
{
    public interface IWorker
    {
        void Work();
        void Eat();
        void Sleep();
    }

    public class Robot : IWorker
    {
        public void Work()
        {
            // Code for performing work
        }

        public void Eat()
        {
            throw new NotSupportedException();
        }

        public void Sleep()
        {
            throw new NotSupportedException();
        }
    }
}
