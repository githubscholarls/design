using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructDesignDemo
{


    /// <summary>
    /// 组合模式的适配器
    /// </summary>
    internal class Adapter : IStack//适配对象
    {
        ArrayList adaptee = new();//被适配的对象
        public object Peek()
        {
            return adaptee[adaptee.Count - 1];
        }

        public object Pop()
        {
            var model = adaptee[adaptee.Count - 1];
            adaptee.RemoveAt(adaptee.Count - 1);
            return model;
        }

        public void Push(object obj)
        {
            adaptee.Add(obj);
        }
    }

    /// <summary>
    /// 继承模式(类)的适配器（有点乱套了，违背了类单一职责的原则）
    /// </summary>
    internal class Adapter1 : ArrayList, IStack
    {
        public object Peek()
        {
            throw new NotImplementedException();
        }

        public object Pop()
        {
            throw new NotImplementedException();
        }

        public void Push(object obj)
        {
            throw new NotImplementedException();
        }
    }

    #region 接口
    interface IStack//客户期望的接口
    {
        void Push(object obj);
        object Pop();
        object Peek();
    }
    #endregion

    #region 实际应用例子

    /// <summary>
    /// 第三方类
    /// </summary>
    public class ExistingClass
    {
        public void SpecificRequest1() { }
        public void SpecificRequest2() { }
    }

    /// <summary>
    /// 我的系统
    /// </summary>
    class mySystem
    {
        public void Process(ITarget target)
        {
            //使用了三方类
            target.Request();
        }
    }

    /// <summary>
    /// 适配器使用第三方
    /// </summary>
    class Adapter3 : ITarget
    {
        ExistingClass adaptee;
        public void Request()
        {
            adaptee.SpecificRequest1();
            adaptee.SpecificRequest2();
        }
    }
    /// <summary>
    /// 我的系统新环境的接口
    /// </summary>
    interface ITarget
    {
        void Request();
    }


    #endregion
}
