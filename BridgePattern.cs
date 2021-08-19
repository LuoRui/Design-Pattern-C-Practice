using System;
namespace BridgePattern
{
    /// <summary>
    /// 桥接模式
    /// </summary>
    public class BridgePattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------BridgePattern Practice:----------------------------");

            #region Step5 使用 Shape 和 DrawAPI 类画出不同颜色的圆
            Shape redCricle = new Circle(100, 100, 10, new RedCricle());
            Shape greenCricle = new Circle(100, 100, 10, new GreenCricle());
            redCricle.Draw();
            greenCricle.Draw();
            #endregion
        }
    }

    #region Step1 创建桥接实现接口
    public interface IDrawAPI
    {
        void DrawCircle(int radius, int x, int y);
    }
    #endregion

    #region Step2 创建实现了 DrawAPI 接口的实体桥接实现类
    public class RedCricle : IDrawAPI
    {
        public void DrawCircle(int radius, int x, int y)
        {
            Console.WriteLine($"Drawing circle color:red,radius:{radius},x:{x},y:{y}");
        }
    }

    public class GreenCricle : IDrawAPI
    {
        public void DrawCircle(int radius, int x, int y)
        {
            Console.WriteLine($"Drawing circle color:green,radius:{radius},x:{x},y:{y}");
        }
    }
    #endregion

    #region Step3 使用 DrawAPI 接口创建抽象类 Shape
    public abstract class Shape
    {
        protected IDrawAPI drawAPI;
        protected Shape(IDrawAPI drawAPI)
        {
            this.drawAPI = drawAPI;
        }

        public abstract void Draw();
    }
    #endregion

    #region Step4 创建实现了 Shape 抽象类的实体类
    public class Circle : Shape
    {
        private int x, y, radius;

        public Circle(int x, int y, int radius, IDrawAPI drawAPI) : base(drawAPI)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        public override void Draw()
        {
            drawAPI.DrawCircle(radius, x, y);
        }
    }
    #endregion
}
