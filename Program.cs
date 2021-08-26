using System;

namespace DesignPattern
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            #region 创建型模式实践
            FactoryPattern.FactoryPattern.Practice();
            AbstractFactoryPattern.AbstractFactoryPattern.Practice();
            SingletonPattern.SingletonPattern.Practice();
            BuilderPattern.BuilderPattern.Practice();
            PrototypePattern.PrototypePattern.Practice();
            #endregion

            #region 结构型模式实践
            AdapterPattern.AdapterPattern.Practice();
            BridgePattern.BridgePattern.Practice();
            FilterPattern.FilterPattern.Practice();
            CompositePattern.CompositePattern.Practice();
            DecoratorPattern.DecoratorPattern.Practice();
            FacadePattern.FacadePattern.Practice();
            FlyweightPattern.FlyweightPattern.Practice();
            ProxyPattern.ProxyPattern.Practice();
            #endregion

            #region 行为型模式实践
            ChainOfResponsibilityPattern.ChainOfResponsibilityPattern.Practice();
            CommandPattern.CommandPattern.Practice();
            InterpreterPattern.InterpreterPattern.Practice();
            IteratorPattern.IteratorPattern.Practice();
            MediatorPattern.MediatorPattern.Practice();
            MementoPattern.MementoPattern.Practice();
            ObserverPattern.ObserverPattern.Practice();
            StatePattern.StatePattern.Practice();
            NullObjectPattern.NullObjectPattern.Practice();
            StrategyPattern.StrategyPattern.Practice();
            TemplatePattern.TemplatePattern.Practice();
            VisitorPattern.VisitorPattern.Practice();
            #endregion

            #region J2EE模式实践（C#实现）
            MVCPattern.MVCPattern.Practice();
            BusinessDelegatePattern.BusinessDelegatePattern.Practice();
            CompositeEntityPattern.CompositeEntityPattern.Practice();
            DataAccessObjectPattern.DataAccessObjectPattern.Practice();
            FrontControllerPattern.FrontControllerPattern.Practice();
            InterceptingFilterPattern.InterceptingFilterPattern.Practice();
            ServiceLocatorPattern.ServiceLocatorPattern.Practice();
            TransferObjectPattern.TransferObjectPattern.Practice();
            #endregion
        }
    }
}
