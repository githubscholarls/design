using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructDesignDemo.flyweight
{
    internal class flyweight
    {
        // 用于享元模式(字符串底层用了，多个相同字符串，用到的地方存的就是引用(池化))
        //1.创建Dictionary Hashtable（两个对象hash值相同才视为相等）
        public static Hashtable Hashtable = new();
        //1.重写Font 类  Equals

        static void Main()
        {
            {
                var list = new List<MyFont>();
                for (int i = 0; i < 100000; i++)
                {
                    //当MyFont达到一定数量级后，Font就几中类型，消耗大量内存
                    list.Add(new MyFont() { k = i, Font = new Font() { name = "1", size = 1, Color = Color.Red } });
                    list.Add(new MyFont() { k = i, Font = new Font() { name = "2", size = 2, Color = Color.Black } });

                }
            }
            //flyweight模式
            {
                var list = new List<MyFont>();
                for (int i = 0; i < 100000; i++)
                {
                    //当MyFont达到一定数量级后，Font就几中类型，消耗大量内存
                    list.Add(new MyFont() { k = i, Font = new Font() { name = "1", size = 1, Color = Color.Red } });
                    list.Add(new MyFont() { k = i, Font = new Font() { name = "2", size = 2, Color = Color.Black } });

                    //这个地方Font可以复用
                    list.Add(new MyFont() { k = i, Font = new Font() { name = "1", size = 1, Color = Color.Red } });
                }
            }
        }
    }

    public class Font
    {
        public int size { get; set; }
        public string name { get; set; }
        public Color Color { get; set; }
        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            var o = (Font)obj;
            if (o.size == this.size && o.name == this.name && o.Color == this.Color)
                return true;
            return false;
        }
        public override int GetHashCode()
        {
            return size.GetHashCode() ^ name.GetHashCode() ^ Color.GetHashCode();
        }
    }

    public class MyFont
    {
        public int k { get; set; }
        private Font font;
        public Font Font { 
            get 
            {
                return font;
            }
            set 
            {
                
                if (flyweight.Hashtable.ContainsKey(value))
                    font = (Font)flyweight.Hashtable[value];
                else
                {
                    flyweight.Hashtable.Add(value, value);
                    font = value;
                }
            } 
        }

    }
    
}
