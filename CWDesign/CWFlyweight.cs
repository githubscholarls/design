using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWDesign
{
    /// <summary>
    /// 如果需要大量的对象，但他们的几个别参数不同，放到类实例外面，在方法调用时传递进来，这样共享的方式大幅度减少单个实例的数目
    /// </summary>
    public class CWFlyweight
    {
        public static void Main()
        {
            List<SiteTempalteBase> list = new();
            for (int i = 0; i < 100; ++i)
            {
                var siteA = FlyFactory.GetSiteTemplate("A");
                Console.WriteLine($"当前{i}的站点与之前所有站点引用{(list.All(l => object.ReferenceEquals(l, siteA)) ? "相同" : "不同")}");
                list.Add(siteA);
                siteA.PrintSite(new UserInfo() { Name = $"张{i}" });
            }
        }



        public abstract class SiteTempalteBase
        {
            /// <summary>
            /// 支持三种模板  A  B  C
            /// </summary>
            protected string TemplateName = "A";
            public virtual void Index()
            {
                Console.WriteLine("网站首页");
            }
            public void Login()
            {
                Console.WriteLine("登录功能");
            }
            public abstract void PrintSite(UserInfo userInfo);
        }
        public class SiteTemplate : SiteTempalteBase
        {
            public SiteTemplate(string TemplateName)
            {
                this.TemplateName = TemplateName;
            }
            public override void PrintSite(UserInfo userInfo)
            {
                Console.WriteLine($"当前客户{userInfo.Name},{userInfo.Email}的网站");
            }
        }
        public class UserInfo
        {
            public string Name;
            public string Email;
        }
        public class FlyFactory
        {
            public static Hashtable siteTemplates = new Hashtable();


            public static SiteTempalteBase GetSiteTemplate(string Name)
            {
                if (!siteTemplates.ContainsKey(Name))
                {
                    var addTemplate = new SiteTemplate(Name);
                    siteTemplates.Add(Name, addTemplate);
                }
                return siteTemplates[Name] as SiteTempalteBase;
            }

        }

    }
}
