using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionDesignDemo
{

    /// <summary>
    /// 访问者模式
    /// </summary>
    public class Visitor
    {
        ShapeVisitor visitor;
        public Visitor(ShapeVisitor visitor)
        {
            this.visitor = visitor;
        }
        public void Process()
        {
            Shape shape = new Rectanglee();
            shape.Accept(visitor);
        }
    }

    public abstract class Shape
    {
        public abstract void Draw();
        /// <summary>
        /// 未来可能引入的操作
        /// </summary>
        /// <param name="visitor"></param>
        public abstract void Accept(ShapeVisitor visitor);

    }
    /// <summary>
    /// 帮助解决可能变化的操作类(当shape子类新增时候，这个接口就被破坏，此模式弊端)
    /// </summary>
    public abstract class ShapeVisitor
    {
        public abstract void Visit(Rectanglee visitor);
        public abstract void Visit(Circlee visitor);
    }
    /// <summary>
    /// 具体解决变化的实现类
    /// </summary>
    public class MyVisitor : ShapeVisitor
    {
        public override void Visit(Rectanglee rectanglee)
        {
            Console.WriteLine("Rectanglee 2");
        }
        public override void Visit(Circlee circlee)
        {
            Console.WriteLine("Circlee 2");
        }
    }
    //or
    //public class YourVisitor

    public class Rectanglee : Shape
    {
        public override void Draw(){}

        public override void Accept(ShapeVisitor visitor)
        {
            Console.WriteLine("Rectanglee 1");
            visitor.Visit(this);
        }
    }
    public class Circlee : Shape
    {
        public override void Draw() { }
        public override void Accept(ShapeVisitor visitor)
        {
            Console.WriteLine("Circlee 1");
            visitor.Visit(this);
        }
    }
}
