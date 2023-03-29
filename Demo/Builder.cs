using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Demo.CreateDesignDemo
{

    partial class App
    {
        /// <summary>
        /// Builder模式解决  对象部分  的需求变化
        /// </summary>
        public static void MainA()
        {
            //固定的
            //House house = GameManager.CreateHouse(new RomanBuilder());
            //or
            string assemblyName = "";
            string builderName = "";
            Assembly assembly = Assembly.Load(assemblyName);
            Type type = assembly.GetType(builderName);
            Builder builder = (Builder)Activator.CreateInstance(type);
            House house = GameManager.CreateHouse(builder);
        }
    }

    /// <summary>
    /// 对象3   静态方法或者用指挥类
    /// </summary>
    partial class GameManager
    {
        public static House CreateHouse(Builder builder)
        {

            //各个部分剧烈变化，组合在一起的算法比较稳定
            builder.BuildDoor();
            builder.BuildWall();
            builder.BuildWindows();
            builder.BuildFloor();
            builder.BuildHouseCeiling();

            return builder.GetHouse();
        }
    }
    #region 实现

    class RomanBuilder : Builder
    {
        private static readonly House House = new RomanHouse();
        public override void BuildDoor()
        {
            throw new NotImplementedException();
        }

        public override void BuildFloor()
        {
            throw new NotImplementedException();
        }

        public override void BuildHouseCeiling()
        {
            throw new NotImplementedException();
        }

        public override void BuildWall()
        {
            throw new NotImplementedException();
        }

        public override void BuildWindows()
        {
            throw new NotImplementedException();
        }

        public override House GetHouse()
        {
            throw new NotImplementedException();
        }
    }

    class RomanHouse:House
    {
        public RomanDoor RomanDoor { get; set; }
        public RomanWall RomanWall { get; set; }
        public RomanWindows RomanWindows { get; set; }
        public RomanFloor RomanFloor { get; set; }
        public RomanHouseCeiling RomanHouseCeiling { get; set; }
        public RomanHouse()
        {

        }
    }
    class RomanDoor : Door { }
    class RomanWall : Wall { }
    class RomanWindows : Windows { }
    class RomanFloor : Floor { }
    class RomanHouseCeiling : HouseCeiling { }

    #endregion


    #region 接口
    /// <summary>
    /// 对象2
    /// </summary>
    abstract class Builder
    {
        public abstract void BuildDoor();
        public abstract void BuildWall();
        public abstract void BuildWindows();
        public abstract void BuildFloor();
        public abstract void BuildHouseCeiling();

        public abstract House GetHouse();
    }

    /// <summary>
    /// 对象1
    /// </summary>
    public abstract class House
    {
    }
    public abstract class Door { }
    public abstract class Wall { }
    public abstract class Windows { }
    public abstract class Floor { }
    public abstract class HouseCeiling { }
    #endregion


    #region 案例2

    #region 构建者约束   （对象1）
    public abstract class Builder2
    {
        public abstract Builder2 BuilderA();
        public abstract Builder2 BuilderB();
        public abstract Builder2 BuilderC();
        public abstract Object GetProduct();
    }
    #endregion
    #region 工人构建各个部分（对象2）
    public class Worker2 : Builder2
    {
        private string a = string.Empty;
        private string b = string.Empty;
        private string c = string.Empty;
        private object product = new {a="",b="",c="" };

        public override Builder2 BuilderA()
        {
            a = "a1";
            Console.WriteLine("build a");
            return this;
        }

        public override Builder2 BuilderB()
        {
            b = "b2";
            Console.WriteLine("build b");
            return this;
        }

        public override Builder2 BuilderC()
        {
            c = "c3";
            Console.WriteLine("build c");
            return this;
        }
        public override Object GetProduct()
        {
            return product;
        }
    }
    #endregion

    #region 客户端

    public class Client2
    {
        public static void Start()
        {
            //只有两个对象时候 客户端更灵活
            var wk = new Worker2().BuilderB().BuilderC().BuilderA().GetProduct();
        }

    }

    #endregion


    #endregion

}
