using CreateDesignDemo.FactoryMethod.Infrastructure;
using System.Reflection;

namespace CreateDesignDemo.FactoryMethod
{
    public class FactoryMethod
    {
        public static void Main()
        {
            CarTestFramework carTest = new CarTestFramework();

            //reflection create model
            string assemblyName = "";
            string typeName = "";
            var assembly = Assembly.Load(assemblyName);
            var type = Type.GetType(typeName);
            AbstractCarFactory carFactory = (AbstractCarFactory)Activator.CreateInstance(type);

            carTest.BuildTestContext(carFactory);
        }
    }
    public class CarTestFramework
    {
        //通过参数传抽象car，但多个car呢
        public void BuildTestContext(/*Car car*/ AbstractCarFactory carFactory)
        {
            //可能不同车类型   改Car为抽象类
            //Car car = new();

            //还是依赖具体类
            //Car car = new MiniCar();

            //多个不同car， 使用工厂

            //car.Startup();

            var car1 = carFactory.CreateCar();
            var car2 = carFactory.CreateCar();
        }
    }


}
