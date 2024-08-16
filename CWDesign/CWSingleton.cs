using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWDesign
{
	public class CWSingleton
	{
		public int id { get; set; } = 333;

        public static CWSingleton Instance= new CWSingleton();
		private CWSingleton() { }
	}
}
