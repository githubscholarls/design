using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ActionDesignDemo.Mediator
{
    /// <summary>
    /// 解耦系统内各个对象之间的关联关系（mediator随着越来越庞大，单个对象可能通知莫一部分对象，大量ifelse随着而来）
    /// </summary>
    public abstract class Mediator
    {
        List<Element> elements = new();
        public abstract void Modify(Element send,Object message);
        public virtual void AddElement(Element element)
        {
            elements.Add(element);
        }
    }
    public class ConocreteMediator : Mediator
    {

        private CutMenuItem1 CutMenuItem1;
        private TextArea1 textArea1;
        private ClipBoard1 clipBoard1;
        private ToolBarButton1 toolBarButton1;
        public override void Modify(Element sender,object message)
        {
            //假设文本右键菜单后都是自动的
            if(sender == CutMenuItem1)
            {
                textArea1.SelectedText();
            }else if(sender == textArea1)
            {
                //通知剪切板复制值
                clipBoard1.OnChange(message);
            }else if(sender == clipBoard1)
            {
                toolBarButton1.OnChange(message);
            }
        }
    }

    public class Client
    {
        public void Main()
        {

            ///由我统一管理
            var mediator = new ConocreteMediator();
            var CutMenuItem1 = new CutMenuItem1(mediator);
            var TextArea1 = new CutMenuItem1(mediator);
            var ClipBoard1 = new CutMenuItem1(mediator);
            var ToolBarButton1 = new CutMenuItem1(mediator);

            CutMenuItem1.Click();

        }
    }

    #region 初始版：模拟文本全选重新粘贴新内容
    class CutMenuItem
    {
        TextArea TextArea;
        ClipBoard ClipBoard;
        ToolBarButton toolBarButton;

        public void Click()
        {
            string text = TextArea.SelectText();
            ClipBoard.SetData(text);

        }
    }
    class TextArea 
    {
        public string SelectText()
        {
            return "上次复制的文本";
        }
    }
    class ClipBoard 
    {
        string data = string.Empty;
        public void SetData(string txt) { this.data= txt; }
    }
    class ToolBarButton { }
    #endregion
    #region 中介者

    public abstract class Element
    {
        public Mediator mediator;
        public Element(Mediator mediator)
        {
            this.mediator = mediator;
            this.mediator.AddElement(this);
        }
        public abstract void OnChange(object Message);
    }
    class CutMenuItem1: Element
    {
        private string cutText;
        public CutMenuItem1(Mediator mediator) : base(mediator)
        {
        }

        /// <summary>
        /// 点击右键
        /// </summary>
        public void Click()
        {
            cutText = "获取了文本";
            this.OnChange(cutText);
        }
        public override void OnChange(object message)
        {
            //剪切的文本内容
            mediator.Modify(this, message);
        }
    }
    class TextArea1:Element
    {
        private string text;
        public TextArea1(Mediator mediator) : base(mediator)
        {
            text = "";
            this.mediator = mediator;
        }
        public void SelectedText()
        {
            this.OnChange("我是选中的文本");
        }

        public override void OnChange(object message)
        {
            Console.WriteLine("已选择文本");
            mediator.Modify(this,text);
        }
    }
    class ClipBoard1 : Element
    {
        string data = string.Empty;

        public ClipBoard1(Mediator mediator) : base(mediator)
        {
        }

        public override void OnChange(object message)
        {
            mediator.Modify(this,message);
        }

        public void SetData(string txt) { this.data = txt; }
    }
    class ToolBarButton1 : Element
    {
        public ToolBarButton1(Mediator mediator) : base(mediator)
        {
        }

        public void EnablePaste()
        {
            this.OnChange("");
        }

        public override void OnChange(object message)
        {
            mediator.Modify(this,message);
        }
    }
    #endregion
}
