namespace BusinessServices
{
    public interface IManager1
    {
        void Put();
    }

    public class Manager1 : IManager1
    {
        public Manager1(IManager2 manager2)
        {
            _manager2 = manager2;
        }

        private readonly IManager2 _manager2;

        public void Put()
        {
            _manager2.Put();
        }
    }

    public interface IManager2
    {
        public void Put()
        {}
    }

    public class Manager2 : IManager2
    {
        public void Put()
        {

        }
    }
}