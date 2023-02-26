using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionDesignDemo.ChinaOfResponsibility
{
    /// <summary>
    /// 责任链模式
    /// </summary>
    internal class ChinaOfResponsibility
    {
    }

    #region 初始
    public class Sender
    {
        public void Process()
        {
            Request request = new Request();
            ArrayList list =new ArrayList();
            list.Add(new AHandler());
            list.Add(new BHandler());
            foreach (BaseHandler item in list)
            {
                item.HandlerRequest(request);
            }
        }
    }
    public abstract class BaseHandler
    {
        public abstract bool CanHandler();
        public abstract void HandlerRequest(Request request);
    }
    public class AHandler : BaseHandler
    {
        public override bool CanHandler()
        {
            throw new NotImplementedException();
        }

        public override void HandlerRequest(Request request)
        {
            ///...
        }
    }
    public class BHandler : BaseHandler
    {
        public override bool CanHandler()
        {
            throw new NotImplementedException();
        }

        public override void HandlerRequest(Request request)
        {
            ///...
        }
    }
    public class Request { }
    #endregion

    #region 责任链1.0

    public abstract class BaseHandler1
    {
        public BaseHandler1(BaseHandler1 baseHandler1)
        {
            next= baseHandler1;
        }
        public abstract bool CanHandler();
        public virtual void HandlerRequest(Request1 request)
        {
            if (next != null)
            {
                next.HandlerRequest(request);
            }
        }
        private BaseHandler1 next;
        public BaseHandler1 Next { get { return next; } set { next = value; } }
    }

    public class Sender1
    {
        public void Process(BaseHandler1 baseHandler1)
        {
            Request1 request1 = new();
            baseHandler1.HandlerRequest(request1);
        }
    }

    public class App
    {
        public static void Main()
        {
            Sender1 sender1 = new Sender1();

            AHandler1 aHandler1 = new AHandler1(null);
            BHandler1 bHandler1 = new BHandler1(aHandler1);
            // bHandler   ->   aHandler  -> null

            sender1.Process(bHandler1);
        }
    }


    public class AHandler1 : BaseHandler1
    {
        public AHandler1(BaseHandler1 baseHandler1) : base(baseHandler1)
        {
        }

        public override bool CanHandler()
        {
            throw new NotImplementedException();
        }

        public override void HandlerRequest(Request1 request)
        {
            ///...
            if (this.CanHandler())
            {
                //...
            }
            else
            {
                base.HandlerRequest(request);
            }
        }
    }
    public class BHandler1 : BaseHandler1
    {
        public BHandler1(BaseHandler1 baseHandler1) : base(baseHandler1)
        {
        }

        public override bool CanHandler()
        {
            throw new NotImplementedException();
        }

        public override void HandlerRequest(Request1 request)
        {
            ///...
        }
    }
    public class Request1 { }


    #endregion




}
