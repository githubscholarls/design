using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace ActionDesignDemo
{
    /// <summary>
    /// 备忘录模式(不侵入原有类做一次备份)  或者序列化实现
    /// </summary>
    internal class Memento
    {
        Rectangle rectangle = new Rectangle(1, 1, 10, 20);
        public void Main()
        {
            var memento = rectangle.CreateMemento();

            //处理  改变rectangle

            //恢复上次状态
            rectangle.SetMemento(memento);
        }

    }
    #region 1.0
    public partial class Rectangle
    {
        public Rectangle(int x,int y,int width,int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
        public int x, y;
        public int width, height;
        public RectangleMemento CreateMemento()
        {
            RectangleMemento rectangleMemento = new RectangleMemento();
            rectangleMemento.SetState(this.x, this.y, this.width, this.height);
            return rectangleMemento;
        }
        public void SetMemento(RectangleMemento memento)
        {
            this.x = memento.x;
            this.y = memento.y;
            this.width = memento.width;
            this.height = memento.height;
        }
    }
    public class RectangleMemento
    {
        internal int x, y;
        internal int width, height;
        internal void SetState(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

    }
    #endregion

    #region 2.0(老版本序列化)

    /// <summary>
    /// 对象必须支持序列化
    /// </summary>
    [Serializable]
    partial class Rectangle
    {

        public GeneralMemento CreateMemento1()
        {
            GeneralMemento generalMemento = new();
            generalMemento.SetState(this);
            return generalMemento;
        }

        public void SetMemento1(GeneralMemento generalMemento)
        {
            Rectangle r =(Rectangle)generalMemento.GetState();
            this.x=r.x;
            this.y=r.y;
            this.width = r.width;
            this.height = r.height;
        }

    }

    public class GeneralMemento
    {
        MemoryStream saved = new MemoryStream();

        internal void SetState(object obj)
        {
            BinaryFormatter binary = new BinaryFormatter();
            binary.Serialize(saved, obj);
        }
        internal object GetState()
        {
            BinaryFormatter binary = new BinaryFormatter();
            saved.Seek(0, SeekOrigin.Begin);
            object obj = binary.Deserialize(saved);
            return obj;
        }
    }

    #endregion

}
