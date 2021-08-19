using System;
namespace VisitorPattern
{
    /// <summary>
    /// 访问者模式
    /// </summary>
    public class VisitorPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------VisitorPattern Practice:----------------------------");

            #region Step5 使用ComputerDisplayVisitor来显示Computer的组成部分
            IComputerPart computer = new Computer();
            computer.Accept(new ComputerPartDisplayVisitor());
            #endregion
        }
    }

    #region Step1 定义一个表示元素的接口
    public interface IComputerPart
    {
        void Accept(IComputerPartVisitor computerPartVisitor);
    }
    #endregion

    #region Step2 创建扩展了上述类的实体类
    public class Keyboard : IComputerPart
    {
        public void Accept(IComputerPartVisitor computerPartVisitor)
        {
            computerPartVisitor.Visit(this);
        }
    }

    public class Monitor : IComputerPart
    {
        public void Accept(IComputerPartVisitor computerPartVisitor)
        {
            computerPartVisitor.Visit(this);
        }
    }

    public class Mouse : IComputerPart
    {
        public void Accept(IComputerPartVisitor computerPartVisitor)
        {
            computerPartVisitor.Visit(this);
        }
    }

    public class Computer : IComputerPart
    {
        IComputerPart[] parts;
        public Computer()
        {
            parts = new IComputerPart[] { new Keyboard(), new Monitor(), new Mouse() };
        }

        public void Accept(IComputerPartVisitor computerPartVisitor)
        {
            for (int i = 0; i < parts.Length; i++)
            {
                parts[i].Accept(computerPartVisitor);
            }
            computerPartVisitor.Visit(this);
        }
    }
    #endregion

    #region Step3 定义一个表示访问者的接口
    public interface IComputerPartVisitor
    {
        void Visit(Keyboard keyboard);
        void Visit(Monitor monitor);
        void Visit(Mouse mouse);
        void Visit(Computer computer);
    }
    #endregion

    #region Step4 创建扩展了上述类的实体访问者
    public class ComputerPartDisplayVisitor : IComputerPartVisitor
    {
        public void Visit(Keyboard keyboard)
        {
            Console.WriteLine("Displaying Keyboard.");
        }

        public void Visit(Monitor monitor)
        {
            Console.WriteLine("Displaying Monitor.");
        }

        public void Visit(Mouse mouse)
        {
            Console.WriteLine("Displaying Mouse.");
        }

        public void Visit(Computer computer)
        {
            Console.WriteLine("Displaying Computer.");
        }
    }
    #endregion
}
