using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CWDesign
{
    public class CWFacade
    {
        /// <summary>
        /// 客户端不再引用每一个对象
        /// </summary>
        public static void Main()
        {
            RegistrationFacadeBase registrationFacade = new RegistrationFacade();
            registrationFacade.RegisterCourse("体育", "张三");
        }

        public abstract class RegistrationFacadeBase 
        {
            public abstract bool RegisterCourse(string courseName, string student);
        }

        public class RegistrationFacade: RegistrationFacadeBase
        {

            public RegisterCourse registerCourse = new RegisterCourse();
            public NotifyStudent notifyStudent = new NotifyStudent();

            public override bool RegisterCourse(string course,string student)
            {
                if (!registerCourse.CheckAvailable(course))
                {
                    notifyStudent.NotifyContent(student, "选课失败");
                    return false;
                }
                notifyStudent.NotifyContent(student, "恭喜选课成功");
                return true;
            }

        }

        public class RegisterCourse
        {
            public bool CheckAvailable(string courseName)
            {
                return true;
            }
        }
        public class NotifyStudent
        {
            public void NotifyContent(string student,string content)
            {
                Console.WriteLine(student+content);
            }
        }

    }
}
