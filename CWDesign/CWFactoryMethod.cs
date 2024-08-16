using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWDesign
{
	/// <summary>
	/// 工厂方法模式每个具体工厂类只完成单个实例的创建,所以它具有很好的可扩展性
	/// </summary>
	public class CWFactoryMethod
	{
		public static void Main()
		{
			CWAbstractFoodFactory cWAbstractFoodFactory = new CWFishFoodFactory();
			//得到鱼工厂食物
			cWAbstractFoodFactory.GetFood();

			CWAbstractFoodFactory cWAbstractFoodFactory1 = new CWChickenFoodFactory();
			//得到鸡肉工厂食物
			cWAbstractFoodFactory1.GetFood();
		}

		public abstract class CWAbstractFoodFactory
		{
			public abstract CWFood? GetFood();
		}
		public class CWFishFoodFactory : CWAbstractFoodFactory
		{
			public override CWFood? GetFood()
			{
				return new Fish();
			}
		}

		public abstract class CWFood { }

		public class Chicken : CWFood { }
		public class Fish : CWFood { }



		public class CWChickenFoodFactory : CWAbstractFoodFactory
		{
			public override CWFood? GetFood()
			{
				return new Chicken();
			}
		}


	}
}
