using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Demo
{
    partial class App
    {
        /// <summary>
        /// Abstract Factory 解决  系列对象   的需求变化
        /// </summary>
        public static void Main()
        {
            GameManager g = new GameManager(new ModernFacilitiesFactory());
            g.BuildGameFacilities();
            g.Run();
        }
    }


    partial class GameManager
    {
        FacilitiesFactory facilitiesFactory;
        /// <summary>
        /// 通过工厂实现不同风格游戏
        /// </summary>
        /// <param name="facilitiesFactory"></param>
        public GameManager(FacilitiesFactory facilitiesFactory)
        {
            this.facilitiesFactory = facilitiesFactory;
        }

        public void BuildGameFacilities()
        {
            Road road = facilitiesFactory.CreateRoad();
            Building building= facilitiesFactory.CreateBuilding();
        }
        public void Run()
        {
            //各种复杂业务
        }
    }
    #region 抽象
    abstract class FacilitiesFactory
    {
        public abstract Road CreateRoad();
        public abstract Building CreateBuilding();
        public abstract Tunnel CreateTunnel();
        public abstract Jungle CreateJungle();
    }

    /// <summary>
    /// 道路
    /// </summary>
    abstract class Road
    {

    }
    /// <summary>
    /// 房屋
    /// </summary>
    abstract class Building
    {

    }
    /// <summary>
    /// 地道
    /// </summary>
    abstract class Tunnel
    {

    }
    /// <summary>
    /// 丛林
    /// </summary>
    abstract class Jungle
    {

    }
    #endregion

    #region 现代风格实现
    class ModernFacilitiesFactory : FacilitiesFactory
    {
        public override ModernBuilding CreateBuilding()
        {
            return new ModernBuilding();
        }

        public override ModernJungle CreateJungle()
        {
            return new ModernJungle();
        }

        public override ModernRoad CreateRoad()
        {
            return new ModernRoad();
        }

        public override ModernTunnel CreateTunnel()
        {
            return new ModernTunnel();
        }
    }

    /// <summary>
    /// 道路
    /// </summary>
    class ModernRoad : Road
    {

    }
    /// <summary>
    /// 房屋
    /// </summary>
    class ModernBuilding : Building
    {

    }
    /// <summary>
    /// 地道
    /// </summary>
    class ModernTunnel : Tunnel
    {

    }
    /// <summary>
    /// 丛林
    /// </summary>
    class ModernJungle : Jungle
    {

    }
    #endregion


}
