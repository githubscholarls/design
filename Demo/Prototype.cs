using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateDesignDemo
{
    internal class Prototype
    {
        NormalActor NormalActor;
        public void Run()
        {
            //通过原型创建对象
            NormalActor actor1 = NormalActor.Clone();
        }

    }

    public abstract class NormalActor
    {
        public abstract NormalActor Clone();
    }

    public class NormalActorA : NormalActor
    {
        double b;
        //引用类型  浅拷贝可能出现错误， 可以反序列化深拷贝一个新对象
        int[] intattr;
        public override NormalActor Clone()
        {
            return (NormalActor)MemberwiseClone();
        }
    }
}
