using System;
namespace AbstractFactoryPattern
{
    /// <summary>
    /// 抽象工厂模式
    /// </summary>
    public class AbstractFactoryPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------AbstractFactoryPattern Practice:----------------------------");

            #region Step8 使用 FactoryProducer 来获取 AbstractFactory，通过传递类型信息来获取实体类的对象
            AbstractFactory shapeFactory = FactoryProducer.GetFactory("SHAPE");
            AbstractFactory colorFactory = FactoryProducer.GetFactory("COLOR");
            IShape shape1 = shapeFactory.GetShape("Circle");
            IColor color1 = colorFactory.GetColor("Red");
            shape1.Draw();
            color1.Fill();
            IShape shape2 = shapeFactory.GetShape("square");
            IColor color2 = colorFactory.GetColor("green");
            shape2.Draw();
            color2.Fill();
            IShape shape3 = shapeFactory.GetShape("rectangle");
            IColor color3 = colorFactory.GetColor("blue");
            shape3.Draw();
            color3.Fill();
            #endregion
        }
    }

    #region Step1 为形状创建一个接口
    public interface IShape
    {
        void Draw();
    }
    #endregion

    #region Step2 创建实现形状接口的实体类
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

    #region Step3 为颜色创建一个接口
    public interface IColor
    {
        void Fill();
    }
    #endregion

    #region Step4 创建实现颜色接口的实体类
    public class Red : IColor
    {
        public void Fill()
        {
            Console.WriteLine("Inside Red.Fill() method.");
        }
    }

    public class Green : IColor
    {
        public void Fill()
        {
            Console.WriteLine("Inside Green.Fill() method.");
        }
    }

    public class Blue : IColor
    {
        public void Fill()
        {
            Console.WriteLine("Inside Blue.Fill() method.");
        }
    }
    #endregion

    #region Step5 为 Color 和 Shape 对象创建抽象类来获取工厂
    public abstract class AbstractFactory
    {
        public abstract IShape GetShape(string shape);
        public abstract IColor GetColor(string color);
    }
    #endregion

    #region Step6 创建扩展了 AbstractFactory 的工厂类，基于给定的信息生成实体类的对象
    public class ShapeFactory : AbstractFactory
    {
        public override IColor GetColor(string color)
        {
            return null;
        }

        public override IShape GetShape(string shape)
        {
            if (string.IsNullOrEmpty(shape))
            {
                return null;
            }
            else if (shape.ToLower().Equals("circle"))
            {
                return new Circle();
            }
            else if (shape.ToLower().Equals("square"))
            {
                return new Square();
            }
            else if (shape.ToLower().Equals("rectangle"))
            {
                return new Rectangle();
            }
            else
            {
                return null;
            }
        }
    }

    public class ColorFactory : AbstractFactory
    {
        public override IColor GetColor(string color)
        {
            if (string.IsNullOrEmpty(color))
            {
                return null;
            }
            else if (color.ToLower().Equals("red"))
            {
                return new Red();
            }
            else if (color.ToLower().Equals("green"))
            {
                return new Green();
            }
            else if (color.ToLower().Equals("blue"))
            {
                return new Blue();
            }
            else
            {
                return null;
            }
        }

        public override IShape GetShape(string shape)
        {
            return null;
        }
    }
    #endregion

    #region Step7 创建一个工厂创造器/生成器类，通过传递形状或颜色信息来获取工厂
    public class FactoryProducer
    {
        public static AbstractFactory GetFactory(string chioce)
        {
            if (string.IsNullOrEmpty(chioce))
            {
                return null;
            }
            else if (chioce.Equals("SHAPE"))
            {
                return new ShapeFactory();
            }
            else if (chioce.Equals("COLOR"))
            {
                return new ColorFactory();
            }
            else
            {
                return null;
            }
        }
    }
    #endregion
}
