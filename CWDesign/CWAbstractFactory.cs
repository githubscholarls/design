using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace CWDesign
{
	/// <summary>
	/// 我不想改动工厂方法，那就延时到子类
	/// </summary>
	public class CWAbstractFactory
	{
		public static void Main()
		{
			//默认的食物做法
			CWAbstractFoodFactory factory1 = new CWFoodFactory();
			factory1.GetFishFood();
			factory1.GetChickenFood();
			//郑州的食物做法
			CWAbstractFoodFactory factory2 = new CWZhengzhouFoodFactory();
			factory2.GetFishFood();
			factory2.GetChickenFood();
		}

		public abstract class CWAbstractFoodFactory
		{
			public abstract CWFood? GetFishFood();
			public abstract CWFood? GetChickenFood();
		}
		public class CWFoodFactory : CWAbstractFoodFactory
		{
			public override CWFood? GetFishFood()
			{
				return new Fish();
			}
			public override CWFood? GetChickenFood()
			{
				return new Chicken();
			}
		}

		public abstract class CWFood{}

		public class Chicken : CWFood { }
		public class Fish : CWFood { }


		//如果想添加新的产品  但不想改变工厂类 (解决了简单工厂面对新增产品的痛处，遵守了开闭原则)

		public class CWZhengzhouFoodFactory : CWAbstractFoodFactory
		{
			public override CWFood? GetFishFood()
			{
				return new ZhengzhouFish();
			}
			public override CWFood? GetChickenFood()
			{
				return new ZhengzhouChicken();
			}
		}
		public class ZhengzhouChicken:CWFood { }
		public class ZhengzhouFish : CWFood { }
	}
}
