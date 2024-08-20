using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWDesign
{
    public class CWProxy
    {
        public static void Main()
        {
            Github git = new Windows();
            Console.WriteLine(git.GetGitHub());

            Github github = new Ladder();
            Console.WriteLine(github.GetGitHub());
        }

        public interface Github 
        {
            public string GetGitHub();
        }

        public class Windows: Github
        {
            public string GetGitHub()
            {
                return "本机不能访问git";
            }
            public void OpenRepository()
            {
                GetGitHub();
                Console.WriteLine("开始学习");
            }
        }


        /// <summary>
        /// 真实主题角色
        /// </summary>
        public class ClashVerge:Github
        {
            public string GetGitHub()
            {
                Console.WriteLine("成功访问");
                return "github.com 200";
            }
        }

        /// <summary>
        /// 代理角色  梯子
        /// </summary>
        public class Ladder : Github
        {
            private ClashVerge ClashVerge = new ClashVerge();
            public string GetGitHub()
            {
                Init();
                var res = ClashVerge.GetGitHub();
                Log();
                return res;
            }

            public void VersionUpdate()
            {

            }

            public void Init()
            {
                Console.WriteLine("配置节点");
            }
            public void Log()
            {
                Console.WriteLine("加个日志 ....");
            }
        }
    }
}
