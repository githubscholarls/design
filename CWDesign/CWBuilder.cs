using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWDesign
{
	/// <summary>
	/// 整体的算法比较稳定，但每个步骤千变万化适用
	/// </summary>
	public class CWBuilder
	{
		public static void Main()
		{
			CWHouseBuilder builder = new MyHouseBuilder();
			builder.BuilderWall();
			builder.BuilderDoor();
			builder.BuilderWindow();
			var myHouse = builder.GetHouse();
		}

		public abstract class CWHouseBuilder
		{
			protected CWHouse House;

			public abstract CWHouseBuilder BuilderWindow();
			public abstract CWHouseBuilder BuilderDoor();
			public abstract CWHouseBuilder BuilderWall();

			public CWHouse GetHouse() {  return House; }
		}

		public abstract class CWHouse
		{
			public CWDoor CWDoor;
			public CWWall CWWall;
			public CWWindows CWWindows;
		}
		public abstract class CWDoor { }
		public abstract class CWWall { }
		public abstract class CWWindows { }
	

		class RomanDoor : CWDoor { }
		class RomanWall : CWWall { }
		class RomanWindows : CWWindows { }

		public class MyHouseBuilder : CWHouseBuilder
		{
			public override CWHouseBuilder BuilderDoor()
			{
				House.CWDoor = new RomanDoor();
				return this;
			}

			public override CWHouseBuilder BuilderWall()
			{
				House.CWWall = new RomanWall();
				return this;
			}

			public override CWHouseBuilder BuilderWindow()
			{
				House.CWWindows = new RomanWindows();
				return this;
			}
		}
	}
}
