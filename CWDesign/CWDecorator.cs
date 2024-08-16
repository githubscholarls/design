using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CWDesign.CWDecorator;

namespace CWDesign
{
	/// <summary>
	/// 一个对象持有一系列的装饰引用    非继承子类爆炸式的扩展功能
	/// </summary>
	public class CWDecorator
	{
		public static void Main()
		{
			Person person = new BlockPerson();
			Decorator per = new headdress(person);
			Decorator per2 = new necklace(per);
			per2.Print();
		}

		public abstract class Person
		{
			public abstract void Print();
		}

		public class BlockPerson : Person
		{
			public string name = "block";

			public override void Print()
			{
                Console.WriteLine("原生黑人");
            }
		}
		public abstract class Decorator:Person
		{
			private Person Person;
            protected Decorator(Person person)
            {
				this.Person = person;
            }
			public override void Print()
			{
				Person.Print();
            }
        }
		public class headdress : Decorator
		{
			public headdress(Person person) : base(person)
			{
			}

			public override void Print()
			{
				//模式主要部分
				base.Print();
				Console.WriteLine(" 添加头饰 ");
            }
		}

		public class necklace : Decorator
		{
			public necklace(Person person) : base(person)
			{
			}

			public override void Print()
			{
				base.Print();
				Console.WriteLine(" 添加项链 ");
			}
		}
	}
}
