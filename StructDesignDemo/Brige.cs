using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StructDesignDemo
{

    //抽象依赖于细节不好，抽象A依赖于抽象B，但如果抽象B也不稳定呢？(用坦克游戏解释此模式)
    //意图：将抽象部分与实现部分分离，是他们都可以独立的变化（将一个事物中多个维度的变化分离）

    internal class Brige
    {
        public static void Main()
        {
            TankPlatformImplementation platform = new PCTankImplementation();

            //pc 端的T50坦克
            T50 t50 = new(platform);
        }
    }
    #region 抽象

    #endregion
    public abstract class Tank
    {
        //使用了组合的模式，把变化引了出去，此类仅写与坦克相关的部分
        protected TankPlatformImplementation tankImpl;

        /// <summary>
        /// 示范最初模式
        /// </summary>
        public Tank()
        {

        }
        /// <summary>
        /// 桥接模式
        /// </summary>
        /// <param name="tankImpl"></param>

        public Tank(TankPlatformImplementation tankImpl)
        {
            this.tankImpl = tankImpl;
        }
        public TankPlatformImplementation TankImpl { get { return this.tankImpl; } set { this.tankImpl = value; } }
        public abstract void Shot();
        public abstract void Run();
        public abstract void Trun();
    }
    public partial class T50 : Tank
    {
        //示范最初代码
        public T50() { }
        public override void Run()
        {
            throw new NotImplementedException();
        }

        //public override void Shot()
        //{
        //    throw new NotImplementedException();
        //}

        public override void Trun()
        {
            throw new NotImplementedException();
        }
    }
    public partial class T75 : Tank
    {
        public T75() { }
        public override void Run()
        {
            throw new NotImplementedException();
        }

        public override void Shot()
        {
            throw new NotImplementedException();
        }

        public override void Trun()
        {
            throw new NotImplementedException();
        }
    }
    public partial class T90 : Tank
    {
        //示范最初代码
        public T90() { }

        public override void Run()
        {
            throw new NotImplementedException();
        }

        public override void Shot()
        {
            throw new NotImplementedException();
        }

        public override void Trun()
        {
            throw new NotImplementedException();
        }
    }

    #region 最初实现(类层级过于复杂，重复代码很多，新平台也不好办)

    #region pc

    /// <summary>
    /// 三个类中都使用了PC中相同模块的代码
    /// </summary>
    public partial class PCT50 : T50 { }
    public partial class PCT75 : T75 { }
    public partial class PCT90 : T90 { }
    #endregion

    #region phone

    public partial class MobileT50 : T50 { }
    public partial class MobileT75 : T75 { }
    public partial class MobileT90 : T90 { }

    #endregion

    #endregion

    #region 桥接实现

    public abstract class TankPlatformImplementation
    {
        public abstract void MoveTankTo(Point to);
        public abstract void DrawTank();
        public abstract void DoShot();
    }
    public partial class T50 : Tank
    {
        public T50(TankPlatformImplementation tankImpl) : base(tankImpl)
        {

        }
        public override void Shot()
        {
            //不同型号使用了不通平台的代码，平台代码都在不同平台实现中
            tankImpl.DoShot();
            throw new NotImplementedException();
        }
    }
    public partial class T75 : Tank
    {
        public T75(TankPlatformImplementation tankImpl) : base(tankImpl)
        {

        }
    }
    public partial class T90 : Tank
    {
        public T90(TankPlatformImplementation tankImpl) : base(tankImpl)
        {

        }

    }
    
    

    /// <summary>
    /// 基本上都是pc相关代码
    /// </summary>
    public class PCTankImplementation : TankPlatformImplementation
    {
        public override void DoShot()
        {
            throw new NotImplementedException();
        }

        public override void DrawTank()
        {
            throw new NotImplementedException();
        }

        public override void MoveTankTo(Point to)
        {
            throw new NotImplementedException();
        }
    }

    #endregion
}
