using System;
using System.Collections.Generic;
namespace FlyweightPattern
{
    /// <summary>
    /// 享元模式
    /// </summary>
    public class FlyweightPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------FlyweightPattern Practice:----------------------------");

            #region Step4 使用对象工厂，通过传递颜色信息来获取实体类的对象            
            for (int i = 0; i < 20; i++)
            {
                Circle circle = (Circle)ShapeFactory.GetCircle(GetRandomColor());
                circle.SetX(GetRandomX());
                circle.SetY(GetRancomY());
                circle.SetRadius(100);
                circle.Draw();
            }
            #endregion
        }

        private static string[] colors = { "Red", "Green", "Blue", "White", "Black" };

        private static Random rd = new Random();

        private static string GetRandomColor()
        {
            return colors[rd.Next(0, colors.Length)];
        }

        private static int GetRandomX()
        {
            return rd.Next(1, 10) * 100;
        }

        private static int GetRancomY()
        {
            return rd.Next(1, 10) * 100;
        }
    }

    #region Step1 创建一个接口
    public interface IShape
    {
        void Draw();
    }
    #endregion

    #region Step2 创建实现接口的实体类
    public class Circle : IShape
    {
        private int x, y, radius;
        private string color;

        public Circle(string color)
        {
            this.color = color;
        }

        public void SetX(int x)
        {
            this.x = x;
        }

        public void SetY(int y)
        {
            this.y = y;
        }

        public void SetRadius(int radius)
        {
            this.radius = radius;
        }

        public void Draw()
        {
            Console.WriteLine($"Circle.Draw()[Color:{color},X:{x},Y:{y}],Radius:{radius}");
        }
    }
    #endregion

    #region Step3 创建一个工厂，生成基于给定信息的实体类的对象
    public class ShapeFactory
    {
        public static readonly Dictionary<string, Circle> CircleMap = new Dictionary<string, Circle>();
        public static IShape GetCircle(string color)
        {
            Circle circle;
            if (CircleMap.ContainsKey(color))
            {
                circle = CircleMap[color];
            }
            else
            {
                circle = new Circle(color);
                CircleMap.Add(color, circle);
                Console.WriteLine($"Creating circle of color:{color}");
            }
            return circle;
        }
    }
    #endregion
}
