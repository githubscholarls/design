using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructDesignDemo.Decorator
{
    //坦克游戏问题：不同坦克添加不同功能，若每一个不同型号坦克继承不同功能类，子类付子类，子类何其多（编译时便确定了类功能）最好动态设置功能
    

    public abstract class Tank
    {
        public abstract void Shot();
        public abstract void Run();
    }
    public interface IA
    {
        void ShotA();
        void RunA();
    }
    #region 最初设计
    public class T50 : Tank, IA
    {
        public override void Run()
        {
            this.RunA();//扩展功能
            throw new NotImplementedException();
        }

        public void RunA()
        {
            throw new NotImplementedException();
        }

        public override void Shot()
        {
            this.ShotA();
            throw new NotImplementedException();
        }

        public void ShotA()
        {
            throw new NotImplementedException();
        }
    }
    public class T75 : Tank
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        public override void Shot()
        {
            throw new NotImplementedException();
        }
    }
    public class T90 : Tank
    {
        public override void Run()
        {
            throw new NotImplementedException();
        }

        public override void Shot()
        {
            throw new NotImplementedException();
        }
    }


    #endregion

    #region Decorator模式

    public abstract class Decorator : Tank
    {
        private Tank _tank;
        public Decorator(Tank tank)
        {
            _tank = tank;
        }
    
        public override void Shot()
        {
            _tank.Shot();
        }
        public override void Run()
        {
            _tank.Run();
        }

    }


    public class DecoratorA : Decorator
    {
        public DecoratorA(Tank tank) : base(tank)
        {
        }

        public override void Run()
        {
            base.Run();
        }

        public override void Shot()
        {
            //红外扩展
            Console.WriteLine("红外扩展");
            base.Shot();
        }
    }
    public class DecoratorB : Decorator
    {
        public DecoratorB(Tank tank) : base(tank)
        {
        }

        public override void Run()
        {
            base.Run();
        }

        public override void Shot()
        {
            //卫星定位扩展
            Console.WriteLine("卫星定位");
            base.Shot();
        }
    }

    public class T50New:Tank
    {
        public override void Shot()
        {
            Console.WriteLine("T50New 自身功能");
        }
        public override void Run()
        {
        }
    }

    public class App
    {
        public static void Main()
        {
            Tank tank = new T50New();
            //添加不同的功能只用添加一个功能类，随用虽取
            Tank da = new DecoratorA(tank);
            Tank db = new DecoratorB(da);
            db.Shot();
        }
    }
    #endregion
}
