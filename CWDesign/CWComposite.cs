using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWDesign
{
	/// <summary>
	/// 对于包含的元素，有一些公用的方法，上层忽略他们的不同，同一处理
	/// </summary>
	public class CWComposite
	{
		public static void Main()
		{
			Learn learn = new School();
			learn.Add(new Class("1班"));
			learn.Add(new Class("2班"));
			learn.Process();

			Learn cla = new Class("独立班");
			//注意不能调用
			//cla.Add(new Class("25班"));
			cla.Process();

		}
		
		/// <summary>
		/// 学习
		/// </summary>
		public abstract class Learn
		{
			/// <summary>
			/// 语文
			/// </summary>
			public abstract void Chinese();
			/// <summary>
			/// 数学
			/// </summary>
			public abstract void Math();

			/// <summary>
			/// 不安全的组合模式（最小单位班级不能添加元素）
			/// </summary>
			/// <param name="learn"></param>
			public abstract void Add(Learn learn);
			public abstract void Process();

        }

		/// <summary>
		/// 最小单位班级
		/// </summary>
		public class Class : Learn
		{
			public string name = string.Empty;

			public Class(string name)
			{
				this.name = name;
			}

			public override void Add(Learn learn)
			{
				//不安全
				throw new NotImplementedException();
			}

			public override void Chinese()
			{
                Console.WriteLine($"{this.name}学习语文");
            }

			public override void Math()
			{
				Console.WriteLine($"{this.name}学习数学");
			}

			public override void Process()
			{
				this.Chinese();
				this.Math();
			}
		}

		public class School : Learn
		{
			private List<Learn> chidren = new List<Learn>();
			public override void Add(Learn learn)
			{
				chidren.Add(learn);
			}

			public override void Chinese()
			{
				Console.WriteLine("学校学习数学");
			}

			public override void Math()
			{
				Console.WriteLine("学校学习数学");
			}

			public override void Process()
			{
				if(chidren.Count > 0 )
				{
					foreach (var item in chidren)
					{
						item.Process();
					}
				}
				this.Chinese();
				this.Math();
			}
		}
	}
}
