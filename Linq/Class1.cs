using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Linq
{
    public class Class1
    {
        public static void Main()
        {
            var arr = new List<int>() { 0,1,2,3,4};
            var arr1 = new List<int>() { 0, 1, 2, 3, 4 };

            var arr3 = from a in arr
                       from a1 in arr1
                       select a + a1;//每一个a 与 a1所有记录操作
            {
                var arr4 = from a in arr1
                           where IsEven(a)
                           select a;
            }
            {
                var arr5 = from a in arr1
                           let n = a % 2
                           where n == 0
                           select a;//0  2  4
            }
            {
                var arr6 = from a in arr1
                           where a > 0 && a < 4
                           group a by a % 2;
                //组1：{1 3}  组2：{2}

                foreach (var group in arr6)
                {
                    foreach (var item in group)
                    {
                        Console.WriteLine(item);
                        //1 3 
                        //2
                    }
                }
            }
            {
                var arr7 = from a in arr1
                           where a>0&&a<=3
                           group a by a % 2 into g//临时标识符，存储数据  组1：1 3  组2：2
                           from g2 in g
                           select g2;//
                foreach (var item in arr7)
                {
                    Console.WriteLine(item);//1  3  2
                }
            }
            {
                var query = from a in arr
                            where a > 1
                            join b in arr1 on a equals b
                            select a;
                foreach (var item in query)
                {
                    //2 3 4
                }
            }

            Console.ReadKey();

        }

        public static bool IsEven(int n) => n % 2 == 0;
    }
}