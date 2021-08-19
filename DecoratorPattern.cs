using System;
namespace DecoratorPattern
{
    /// <summary>
    /// 装饰器模式
    /// </summary>
    public class DecoratorPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------DecoratorPattern Practice:----------------------------");

            #region Step5 使用 RedShapeDecorator 来装饰 Shape 对象
            IShape circle = new Circle();
            ShapeDecorater redCircle = new RedShapeDecorater(new Circle());
            ShapeDecorater redRectangle = new RedShapeDecorater(new Rectangle());
            circle.Draw();
            Console.WriteLine(string.Empty);
            redCircle.Draw();
            Console.WriteLine(string.Empty);
            redRectangle.Draw();
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
            Console.WriteLine("Draw Shape Rectangle.");
        }
    }

    public class Circle : IShape
    {
        public void Draw()
        {
            Console.WriteLine("Draw Shape Circle.");
        }
    }
    #endregion

    #region Step3 创建实现了 Shape 接口的抽象装饰类
    public abstract class ShapeDecorater : IShape
    {
        protected IShape decoratedShape;

        public ShapeDecorater(IShape shape)
        {
            decoratedShape = shape;
        }

        public virtual void Draw()
        {
            decoratedShape.Draw();
        }
    }
    #endregion

    #region Step4 创建扩展了 ShapeDecorator 类的实体装饰类
    public class RedShapeDecorater : ShapeDecorater
    {
        public RedShapeDecorater(IShape shape) : base(shape) { }

        public override void Draw()
        {
            base.Draw();
            SetRedBorder(decoratedShape);
        }

        private void SetRedBorder(IShape shape)
        {
            Console.WriteLine("Set Shape Border Color:Red");
        }
    }
    #endregion
}
