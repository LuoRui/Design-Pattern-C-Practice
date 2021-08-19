using System;
namespace FacadePattern
{
    /// <summary>
    /// 外观模式
    /// </summary>
    public class FacadePattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------FacadePattern Practice:----------------------------");

            #region Step4 使用外观类画出各种类型的形状
            ShapeMaker shapeMaker = new ShapeMaker();
            shapeMaker.DrawRectangle();
            shapeMaker.DrawSquare();
            shapeMaker.DrawCircle();
            #endregion
        }
    }

    #region Step1 创建一个接口
    public interface IShape
    {
        void Draw();
    }
    #endregion

    #region Step2 创建实现接口的实体类
    public class Rectangle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Rectangle.Draw()");
        }
    }

    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Square.Draw()");
        }
    }

    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Circle.Draw()");
        }
    }
    #endregion

    #region Step3 创建一个外观类
    public class ShapeMaker
    {
        private IShape rectangle;
        private IShape square;
        private IShape circle;

        public ShapeMaker()
        {
            rectangle = new Rectangle();
            square = new Square();
            circle = new Circle();
        }

        public void DrawRectangle()
        {
            rectangle.Draw();
        }

        public void DrawSquare()
        {
            square.Draw();
        }

        public void DrawCircle()
        {
            circle.Draw();
        }
    }
    #endregion
}
