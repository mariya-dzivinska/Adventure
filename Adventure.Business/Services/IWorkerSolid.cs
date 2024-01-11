using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Business.Services
{
    public interface IWorkerSolid
    {
        void Work();
    }

    public interface IEater
    {
        void Eat();
    }

    public interface ISleeper
    {
        void Sleep();
    }

    public class Human : IWorkerSolid, IEater, ISleeper
    {
        public void Work()
        {
            // Code for performing work
        }

        public void Eat()
        {
            // Code for eating
        }

        public void Sleep()
        {
            // Code for sleeping
        }
    }

    public class RobotSolid : IWorkerSolid
    {
        public void Work()
        {
            // Code for performing work
        }
    }
}
