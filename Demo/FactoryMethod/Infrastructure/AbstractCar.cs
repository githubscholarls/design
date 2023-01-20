using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDesignDemo.FactoryMethod.Infrastructure
{
    public abstract class AbstractCar
    {
        //一些配件

        //一些动作

        public abstract void Startup();
        public abstract void Stop();
        public abstract void Run();
        public abstract void Turn(Direction direction);


    }
    public class Direction
    {
    }
}
