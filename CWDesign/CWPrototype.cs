using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWDesign
{
	/// <summary>
	/// 只创建一个类实例对象，如果后面需要更多这样的实例，可以通过对原来对象拷贝一份来完成创建
	/// </summary>
	public class CWPrototype
	{
		public static void Main()
		{
			ObjectA a = new ObjectA();
			ObjectA? aClone = a.Clone() as ObjectA;
			ObjectA? aDeepClone = a.DeepClone() as ObjectA;
			{
				Console.WriteLine($"a：{Newtonsoft.Json.JsonConvert.SerializeObject(a)}");
				Console.WriteLine($"aClone：{Newtonsoft.Json.JsonConvert.SerializeObject(aClone)}");
				a.x = 4;
				a.y.Add(1);
				a.z = "zzzzxxx";
				a.g.Add("ww");
				Console.WriteLine($"a：{Newtonsoft.Json.JsonConvert.SerializeObject(a)}");
				Console.WriteLine($"aClone：{Newtonsoft.Json.JsonConvert.SerializeObject(aClone)}");
			}

			{
				Console.WriteLine($"a：{Newtonsoft.Json.JsonConvert.SerializeObject(a)}");
				Console.WriteLine($"aDeepClone：{Newtonsoft.Json.JsonConvert.SerializeObject(aDeepClone)}");
				a.x = 4;
				a.y.Add(1);
				a.z += "xxx";
				Console.WriteLine($"a：{Newtonsoft.Json.JsonConvert.SerializeObject(a)}");
				Console.WriteLine($"aDeepClone：{Newtonsoft.Json.JsonConvert.SerializeObject(aDeepClone)}");
			}
		}
		

		public class ObjectA
		{
			/// <summary>
			/// 值类型
			/// </summary>
			public int x = 3;
			/// <summary>
			/// 引用类型
			/// </summary>
			public List<int> y = new List<int>() { 2,3,4};
			/// <summary>
			/// 字符串的不可变性
			/// </summary>
			public string z = "zzzz";
			/// <summary>
			/// 引用类型
			/// </summary>
			public List<object> g = new List<object>() { 1, "a", "f" };

			public object Clone()
			{
				//注意浅拷贝
				return this.MemberwiseClone();
			}

			public object? DeepClone()
			{
				return Newtonsoft.Json.JsonConvert.DeserializeObject<ObjectA>(Newtonsoft.Json.JsonConvert.SerializeObject(this)??"");
			}
		}

	}
}
