using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Demo
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
    abstract class Builder
    {
        public abstract void BuildDoor();
        public abstract void BuildWall();
        public abstract void BuildWindows();
        public abstract void BuildFloor();
        public abstract void BuildHouseCeiling();

        public abstract House GetHouse();
    }

    public abstract class House
    {
    }
    public abstract class Door { }
    public abstract class Wall { }
    public abstract class Windows { }
    public abstract class Floor { }
    public abstract class HouseCeiling { }
    #endregion


}
