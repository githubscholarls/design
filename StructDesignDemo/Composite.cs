using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StructDesignDemo
{
    /// <summary>
    /// 客户代码过度依赖对象容器复杂的内部实现结构，对象容器内部实现结构（而非抽象接口）的变化将引起客户代码的频繁变化，带来了代码的维护性，扩展性等弊端
    /// </summary>
    internal class Composite
    {
    }
    public interface IBox
    {
        void process();
        void Add(IBox box);
        void Remove(IBox box);

        //微软实现,从而去掉Add Remove
        IList Boxes { get; set; }
    }
    //客户代码
    public partial class App
    {
        static void Main()
        {
            //初始代码
            {
                IBox box = default;// = Factory.GetBox();
                if (box is ContainerBox)
                {
                    box.process();
                    ArrayList list = ((ContainerBox)box).getBoxes();
                    //...复杂处理
                }
                else if (box is SingleBox)
                {
                    box.process();
                }
            }
            //composite模式
            {
                IBox box = default;// = Factory.GetBox();
                box.process();
            }


        }
    }
    public class SingleBox : IBox
    {
        public IList Boxes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }


        //为了让客户操作container，但不让访问single（抛异常）虽然single不应该有（违背了单一职责），但这是必须付出的代价
        public void Add(IBox box)
        {
            throw new NotSupportedException();
        }

        public void process() { }

        public void Remove(IBox box)
        {
            throw new NotSupportedException();
        }
    }
    public partial class ContainerBox : IBox
    {

        //public void process() { }
        public ArrayList getBoxes() => new ArrayList();//易变元素，导致客户代码易变
    }
    public partial class ContainerBox : IBox
    {
        //套娃
        ArrayList list = new();
        //IBox 没有这个，客户没法添加容器
        public void Add(IBox box)
        {
            list.Add(box);
        }
        public void Remove(IBox box)
        {
            list.Remove(box);
        }
        public IList Boxes { get ; set ; }
        public void process()
        {
            //process self

            //process list
            if (list != null)
            {
                foreach (IBox box in list)
                {
                    box.process();
                }
            }
            //微软实现
            if (Boxes is not null)
            {
                foreach (IBox item in Boxes)
                {
                    item.process();
                }
            }
        }
    }

}
