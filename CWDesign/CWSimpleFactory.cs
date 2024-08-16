using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWDesign
{
	public class CWSimpleFactory
	{
		/// <summary>
		/// 弊端 ：新增食物  必须改这个简单工厂方法
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public static CWFood? GetFood(string name)
		{
			if (name.ToLower() == "fish")
			{
				return new Fish();
			}else if(name.ToLower() == "chicken")
			{
				return new Chicken();
			}
			return null;
		}

		public static void Main()
		{
			var f = GetFood("fish");
			f?.Print();
			var c = GetFood("chicken");
			c?.Print();
		}
	}

	public abstract class CWFood
	{
		public abstract void Print() ;
	}
	public class Chicken : CWFood
	{
		public override void Print()
		{
            Console.WriteLine("我是鸡肉");
        }
	}
	public class Fish : CWFood
	{
		public override void Print()
		{
            Console.WriteLine("我是鱼肉");
        }
	}
}
