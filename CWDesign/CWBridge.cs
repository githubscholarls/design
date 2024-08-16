using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWDesign
{
	/// <summary>
	/// 对于一类型的变化可以抽象化，但是两个方向上同时变化就很麻烦了，用一个方向上的抽象持有另一个方向上的抽象，即可解决
	/// </summary>
	public class CWBridge
	{
		public static void Main()
		{
			Company inter = new InterCompany();
			inter.Create();
			inter.MainDepartment = new DeveDepartment();
			inter.MainDepartment.Test();
			inter.Listed();

			Company sale = new SaleCompany();
			sale.Create();
			sale.MainDepartment = new ProdDepartment();
			sale.MainDepartment.Test();
			sale.Listed();
		}

		public abstract class Company
		{
			public Department MainDepartment { get; set; }
			public abstract void Create();
			public abstract void Listed();
		}
		
		public abstract class Department
		{
			public abstract void Test();
		}


		public class SaleCompany : Company
		{
			public override void Create()
			{
				Console.WriteLine("白酒公司创立");
			}

			public override void Listed()
			{
				Console.WriteLine("白酒公司上市");
			}
		}

		public class InterCompany : Company
		{
			public override void Create()
			{
				Console.WriteLine("互联网公司创立");
			}

			public override void Listed()
			{
				Console.WriteLine("互联网公司上市");
			}
		}


		public class DeveDepartment : Department
		{
			public override void Test()
			{
                Console.WriteLine("研发部门开会");
            }
		}
		public class ProdDepartment : Department
		{
			public override void Test()
			{
				Console.WriteLine("产品部门开会");
			}
		}

	}
}
