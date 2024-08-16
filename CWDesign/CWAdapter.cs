using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWDesign
{
	/// <summary>
	/// 把一个类的接口变换成客户端所期待的另一种接口，从而使原本接口不匹配而无法一起工作的两个类能够在一起工作
	/// </summary>
	public class CWAdapter
	{
		public static void Main()
		{
			IThreeHole threehole = new ThreeHole();
			threehole.Request();
            Console.WriteLine("--------------------");
			IThreeHole adapter = new PowerAdapter();
			adapter.Request();
		}

		/// <summary>
		/// 现有的接口 不能工作
		/// </summary>
		public interface IThreeHole
		{
			void Request();
		}

		public class ThreeHole : IThreeHole
		{
			public void Request()
			{
				Console.WriteLine("我是三个孔的插头 有点问题");
			}
		}

		/// <summary>
		/// 两个孔的插头 可以工作 （新的接口被引入）
		/// </summary>
		public abstract class TwoHole
		{
			public void SpecificRequest()
			{
				Console.WriteLine("我是两个孔的插头 可以使用");
			}
		}
		/// <summary>
		/// 按照现有IThreeHole的客户端客户端流程   实现了可以工作的目的
		/// </summary>
		public class PowerAdapter : TwoHole, IThreeHole
		{
			/// <summary>
			/// 实现三个孔插头接口方法
			/// </summary>
			public void Request()
			{
				// 调用两个孔插头方法
				this.SpecificRequest();
			}
		}
	}

}
