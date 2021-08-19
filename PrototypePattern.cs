using System;
using System.Collections;
namespace PrototypePattern
{
    /// <summary>
    /// 原型模式
    /// </summary>
    public class PrototypePattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------PrototypePattern Practice:----------------------------");

            #region Step4 使用 ShapeCache 类来获取存储在 Hashtable 中的形状的克隆
            ShapeCache.LoadCache();
            Shape clonedShape1 = ShapeCache.GetShape("1");
            clonedShape1.Draw();
            Shape clonedShape2 = ShapeCache.GetShape("2");
            clonedShape2.Draw();
            Shape clonedShape3 = ShapeCache.GetShape("3");
            clonedShape3.Draw();
            #endregion
        }
    }

    #region Step1 创建一个实现了 Cloneable 接口的抽象类
    public abstract class Shape : ICloneable
    {
        private string id;
        protected string type;

        public abstract void Draw();

        public string getType()
        {
            return type;
        }

        public string getId()
        {
            return id;
        }

        public void setId(string id)
        {
            this.id = id;
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
    #endregion

    #region Step2 创建扩展了上面抽象类的实体类
    public class Rectangle : Shape
    {
        public Rectangle()
        {
            type = "Rectangle";
        }

        public override void Draw()
        {
            Console.WriteLine("Inside Rectangle.Draw() method.");
        }
    }

    public class Square : Shape
    {
        public Square()
        {
            type = "Square";
        }

        public override void Draw()
        {
            Console.WriteLine("Inside Square.Draw() method.");
        }
    }

    public class Circle : Shape
    {
        public Circle()
        {
            type = "Circle";
        }

        public override void Draw()
        {
            Console.WriteLine("Inside Circle.Draw() method.");
        }
    }
    #endregion

    #region Step3 创建一个类，从数据库获取实体类，并把它们存储在一个 Hashtable 中
    public class ShapeCache
    {
        private static Hashtable shapeMap = new Hashtable();

        public static Shape GetShape(string shapeId)
        {
            var cachedShape = shapeMap[shapeId];
            return (Shape)(cachedShape as Shape).Clone();
        }

        public static void LoadCache()
        {
            Circle circle = new Circle();
            circle.setId("1");
            shapeMap.Add(circle.getId(), circle);

            Square square = new Square();
            square.setId("2");
            shapeMap.Add(square.getId(), square);

            Rectangle rectangle = new Rectangle();
            rectangle.setId("3");
            shapeMap.Add(rectangle.getId(), rectangle);
        }
    }
    #endregion
}
