using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CreateDesignDemo
{
    public class Prototype
    {
        public void Run()
        {
            var ormalActor = new NormalActorA();

            //两个引用类型字段
            ormalActor.intAttr2 = new List<int> { 1, 2, 3 };
            ormalActor.testCopyB = new Numb2(888);

            var actor1 = ormalActor.Clone();

            ormalActor.ToString();
            actor1.ToString();


            //（深拷贝）
            ormalActor.c = "d";
            ormalActor.testCopy = new Numb(2);
            ormalActor.intAttr2 = new List<int> { 1, 2, 3, 4 };

            //浅拷贝
            ormalActor.intAttr.Add(2);
            ormalActor.testCopyB.Number = 999;

            Console.WriteLine("changed");

            ormalActor.ToString();
            actor1.ToString();

            
        }

    }


    public class NormalActorA
    {
        public double b;
        public List<int> intAttr= new List<int> {1};
        public List<int> intAttr2;
        public string c = "c";
        /// <summary>
        /// 引用类型
        /// </summary>
        public Numb testCopy=new Numb(1);
        //引用类型  浅拷贝可能出现错误， 可以反序列化深拷贝一个新对象
        public Numb2 testCopyB;

        public NormalActorA Clone()
        {
            return (NormalActorA)this.MemberwiseClone();
        }
        public void ToString()
        {
            Console.WriteLine(c+"   len1:"+intAttr.Count+"    len2:"+intAttr2.Count +"    Numb:"+testCopy.Number+"    Numb2:"+testCopyB.Number);
        }
    }

    public class Numb
    {
        public int Number;
        public Numb(int number)
        {
            Number = number;
        }
    }

    public class Numb2
    {
        public int Number;

        public Numb2(int number)
        {
            Number = number;
        }
    }
}
