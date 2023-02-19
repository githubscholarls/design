using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionDesignDemo
{
    /// <summary>
    /// 责任链模式
    /// 定义一个操作中的算法的骨架，而将一些步骤延迟到子类中
    /// </summary>
    internal class TemplateMethod
    {
        public static void Main()
        {
            VehicalTestFramework.DoTest(new HongqiCar());
        }
    }

    /// <summary>
    /// 框架开发者 - 先开发
    /// </summary>
    public abstract class Vehical
    {
        protected abstract void startup();
        protected abstract void run();
        protected abstract void turn(int degree);
        protected abstract void stop();
        public void Test(int degree)
        {
            startup();
            run();
            turn(degree);
            stop();
        }
    }
    public class VehicalTestFramework
    {
        public static void DoTest(Vehical vehical)
        {
            vehical.Test(1);
        }
    }
    /// <summary>
    /// 应用程序开发--晚开发
    /// </summary>
    public class HongqiCar : Vehical
    {
        protected override void run()
        {
            throw new NotImplementedException();
        }

        protected override void startup()
        {
            throw new NotImplementedException();
        }

        protected override void stop()
        {
            throw new NotImplementedException();
        }

        protected override void turn(int degree)
        {
            var k = new tesa();
            throw new NotImplementedException();
        }
    }

    public class tesa
    {
        public virtual void tsa() { }
    }
}
