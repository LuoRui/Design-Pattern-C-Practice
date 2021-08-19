using System;
namespace FactoryPattern
{
    /// <summary>
    /// 工厂模式
    /// </summary>
    public class FactoryPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------FactoryPattern Practice:----------------------------");

            #region Step4 使用工厂，通过传递类型信息来获取实体类的对象
            ShapeFactory shapeFactory = new ShapeFactory();
            IShape shape1 = shapeFactory.GetShape("circle");
            shape1.Draw();
            IShape shape2 = shapeFactory.GetShape("square");
            shape2.Draw();
            IShape shape3 = shapeFactory.GetShape("rectangle");
            shape3.Draw();
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
            Console.WriteLine("Inside Rectangle.Draw() method.");
        }
    }

    public class Square : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Inside Square.Draw() method.");
        }
    }

    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Inside Circle.Draw() method.");
        }
    }
    #endregion

    #region Step3 创建一个工厂，生成基于给定信息的实体类的对象
    public class ShapeFactory
    {
        public IShape GetShape(string shapeType)
        {
            if (string.IsNullOrEmpty(shapeType))
            {
                return null;
            }
            else if (shapeType.ToLower().Equals("circle"))
            {
                return new Circle();
            }
            else if (shapeType.ToLower().Equals("square"))
            {
                return new Square();
            }
            else if (shapeType.ToLower().Equals("rectangle"))
            {
                return new Rectangle();
            }
            else
            {
                return null;
            }
        }
    }
    #endregion
}
