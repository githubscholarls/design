using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ActionDesignDemo
{
    /// <summary>
    /// 观察者（事件）设计模式
    /// </summary>
    internal class Observer
    {
    }
    #region 初始设计
    public class BankAccount
    {
        private Emailer emailer;
        private Mobiler mobiler;
        public void WithDraw(int money)
        {
            emailer.SendEmail("236350...qq.com");
            mobiler.SendMobiler("166386...");
        }
    }
    public class Emailer
    {
        public void SendEmail(string email)
        {
            ///....
        }
    }
    public class Mobiler
    {
        public void SendMobiler(string phone)
        {
            ///...
        }
    }
    #endregion

    #region 观察者1.0

    /// <summary>
    /// 当只有一个消息通知行为时候，且BankAccount1 内部稳定时候
    /// </summary>
    public interface IAccountObserver
    {
        public void UpdateMessage(UserAccountArgs args);
    }
    public class UserAccountArgs
    {
        public string email { get; set; }
        public string phone { get; set; }
    }

    public class BankAccount1
    {
        IEnumerable<IAccountObserver> accountObservers;
        public void WithDraw(UserAccountArgs args)
        {
            foreach (var item in accountObservers)
            {
                item.UpdateMessage(args);
            }
        }
    }
    public class Emailer1 : IAccountObserver
    {
        public void UpdateMessage(UserAccountArgs args)
        {
            //更新通知
            //args.email...
        }
    }
    public class Mobiler1 : IAccountObserver
    {
        public void UpdateMessage(UserAccountArgs args)
        {
            //更新通知
            //args.phone...
        }
    }

    #endregion

    #region 观察者2.0

    public abstract class Subject
    {
        protected List<IAccountObserver> accountObservers;
        protected virtual void Notify(UserAccountArgs args)
        {
            foreach (IAccountObserver observer in accountObservers)
            {
                observer.UpdateMessage(args);
            }
        }
        public void AddObserver(IAccountObserver observer)
        {
            accountObservers.Add(observer);
        }
        public void RemoveObserver(IAccountObserver observer)
        {
            accountObservers.Remove(observer);
        }
    }

    public class BankAccount2: Subject
    {
        public void WithDraw(UserAccountArgs args)
        {
            AddObserver(new Mobiler1());
            AddObserver(new Emailer1());
            this.Notify(args);
        }
    }

    #endregion

    #region 事件中的观察者（更加松耦合）

    public class App 
    {
        public static void Main()
        {
            BankAccountE bankAccountE = new BankAccountE();
            EmailerE emailerE = new EmailerE();
            bankAccountE.AccountChange += new AccountChangeEventHander(emailerE.Update);
            bankAccountE.WithDraw(123);
        }
    }

    public delegate void AccountChangeEventHander(object sender, UserAccountArgs args);
    public class BankAccountE
    {
        //内部就是观察者2.0的链表(遍历行为)和add以及remove
        public event AccountChangeEventHander AccountChange;
        public void WithDraw(int money)
        {
            UserAccountArgs args = new UserAccountArgs();
            this.OnAccountChange(args);
        }
        protected virtual void OnAccountChange(UserAccountArgs args)
        {
            if(AccountChange != null)
            {
                AccountChange(this,args);
            }
        }
    }

    public class EmailerE
    {
        public void Update(object sender, UserAccountArgs args)
        {
            //...
        }
    }

    #endregion
}
