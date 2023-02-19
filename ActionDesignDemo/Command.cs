using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionDesignDemo
{
    /// <summary>
    /// 将某些对象的相似行为转为对象（DocumentCommand，类似Delegate）
    /// </summary>
    internal class Command
    {
        public static void Main()
        {
            //1.0
            var doc = new Document();
            doc.ShowDocument();
            var g = new Graphics();
            g.Show();

            //2.0
            ICommand doc1 = new Document1();
            doc1.Show();
            ICommand g1 = new Graphics1();
            g1.Show();

            List<ICommand> list=default;
            foreach (var item in list)
            {
                item.Show();
            }
            //3.0
            Stack<ICommand> commands= new Stack<ICommand>();
            commands.Push(new DocumentComand(new Document3()));
            commands.Push(new GraphicsCommand(new Graphics3()));
            foreach (var item in commands)
            {
                item.Show();
            }
        }
    }

    #region 初始版本
    public class Document
    {
        public void ShowDocument() { }
    }
    public class Graphics
    {
        public void Show() { }
    }
    #endregion

    #region 2.0
    public interface ICommand
    {
        public void Show();
        public void Undo();
        public void Redo();
    }

    public class Document1 : ICommand
    {
        public void Redo()
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
    public class Graphics1 : ICommand
    {
        public void Redo()
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    #region 3.0

    /// <summary>
    /// 具体化的命令对象
    /// </summary>
    public class DocumentComand: ICommand
    {
        private readonly Document3 document;

        public DocumentComand(Document3 document)
        {
            this.document = document;
        }
        public void Redo()
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
    public class GraphicsCommand : ICommand
    {
        private readonly Graphics3 graphics3;

        public GraphicsCommand(Graphics3 graphics3)
        {
            this.graphics3 = graphics3;
        }
        public void Redo()
        {
            throw new NotImplementedException();
        }
        public void Show()
        {
            throw new NotImplementedException();
        }
        public void Undo()
        {
            throw new NotImplementedException();
        }
    }


    public class Document3{}
    public class Graphics3 { }

    #endregion
}
