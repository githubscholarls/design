using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ActionDesignDemo.Interpreter
{
    internal class Interpreter
    {
        public void Main()
        {
            string roman = "五十一万八千六百五十二";
            Context context = new Context(roman);
            ArrayList tree = new ArrayList();
            tree.Add(new GePression());
            tree.Add(new ShiPression());
            tree.Add(new BaiPression());
            tree.Add(new QianPression());
            tree.Add(new WanPression());
            foreach (Expression exp in tree)
            {
                exp.Interpreter(context);
            }

        }
    }

    public class Context
    {
        public Context(string statement)
        {
            this.statement = statement;
        }
        public string statement { get; set; }
        public int data { get; set; }
    }

    public abstract class Expression
    {
        protected Dictionary<string, int> table = new();
        public Expression()
        {
            table.Add("一", 1);
            table.Add("二", 2);
            table.Add("三", 3);
            table.Add("四", 4);
            table.Add("五", 5);
            table.Add("六", 6);
            table.Add("七", 7);
            table.Add("八", 8);
            table.Add("九", 9);
        }
        public virtual void Interpreter(Context context)
        {
            if (context.statement.Length == 0)
                return;
            foreach (var key in table.Keys)
            {
                int value = table[key];
                if (context.statement.EndsWith(key + GetPostfix()))
                {
                    context.data += value * this.Multiplier();
                    context.statement = context.statement.Substring(0, context.statement.Length - this.GetLength());
                }
            }
        }
        protected abstract string GetPostfix();
        protected abstract int Multiplier();
        protected virtual int GetLength()
        {
            return this.GetPostfix().Length + 1;
        }

    }
    public class GePression : Expression
    {
        protected override string GetPostfix()
        {
            return "";
        }

        protected override int Multiplier()
        {
            return 1;
        }
    }
    public class ShiPression : Expression
    {
        protected override string GetPostfix()
        {
            return "十";
        }

        protected override int Multiplier()
        {
            return 10;
        }
    }
    public class BaiPression : Expression
    {
        protected override string GetPostfix()
        {
            return "百";
        }

        protected override int Multiplier()
        {
            return 100;
        }
    }
    public class QianPression : Expression
    {
        protected override string GetPostfix()
        {
            return "千";
        }

        protected override int Multiplier()
        {
            return 1000;
        }
    }
    public class WanPression : Expression
    {
        protected override string GetPostfix()
        {
            return "万";
        }
        protected override int Multiplier()
        {
            return 10000;
        }
        public override void Interpreter(Context context)
        {
            //五十一万
            if (context.statement.Length == 0)
                return;
            ArrayList tree = new();
            tree.Add(new GePression());
            tree.Add(new ShiPression());
            tree.Add(new BaiPression());
            tree.Add(new QianPression());
            foreach (var key in table.Keys)
            {
                if (context.statement.EndsWith(this.GetPostfix()))
                {
                    //8652
                    int temp = context.data;
                    context.data = 0;
                    //五十一
                    context.statement = context.statement.Substring(0, context.statement.Length - 1);
                    foreach (Expression exp in tree)
                    {
                        exp.Interpreter(context);
                    }
                    context.data = temp + this.Multiplier() * context.data;
                }
            }
        }
    }
}
