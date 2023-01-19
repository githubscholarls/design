namespace Demo
{
    public class Singleton
    {
        private static volatile Singleton instance = null;
        private static object lockHelper = new object();
        private Singleton() { }
        public static Singleton Instance
        {
            get
            {
                if (instance is null)
                {
                    //解决多线程并发创建多个对象
                    lock (lockHelper)
                    {
                        //double check
                        if (instance is null)
                        {
                            instance = new Singleton();
                        }
                    }
                }
                return instance;
            }
        }
    }

    public class Singleton1
    {
        //public static readonly Singleton1 Instance = new();
        //private Singleton1() { }
        //or
        public static readonly Singleton1 Instance;
        /// <summary>
        /// 内联初始化，仅在静态字段初始化之后，在使用字段时才构造
        /// </summary>
        static Singleton1()
        {
            Instance= new Singleton1();
        }
        private Singleton1() { }
    }
}