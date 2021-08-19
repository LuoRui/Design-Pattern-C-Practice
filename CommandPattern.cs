using System;
using System.Collections.Generic;
namespace CommandPattern
{
    /// <summary>
    /// 命令模式
    /// </summary>
    public class CommandPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------CommandPattern Practice:----------------------------");

            #region Step5 使用 Broker 类来接受并执行命令
            Stock abcStock = new Stock();
            BuyStock buyStockOrder = new BuyStock(abcStock);
            SellStock sellStockOrder = new SellStock(abcStock);
            Broker broker = new Broker();
            broker.TakeOrder(buyStockOrder);
            broker.TakeOrder(sellStockOrder);
            broker.PlaceOrders();
            #endregion
        }
    }

    #region Step1 创建一个命令接口
    public interface IOrder
    {
        void Excute();
    }
    #endregion

    #region Step2 创建一个请求类
    public class Stock
    {
        private string name = "ABC";
        private int quantity = 10;

        public void Buy()
        {
            Console.WriteLine($"Stock [Name:{name},Quantity:{quantity}] bought");
        }

        public void Sell()
        {
            Console.WriteLine($"Stock [Name:{name},Quantity:{quantity}] sold");
        }
    }
    #endregion

    #region Step3 创建实现了 Order 接口的实体类
    public class BuyStock : IOrder
    {
        private Stock abcStock;

        public BuyStock(Stock stock)
        {
            abcStock = stock;
        }

        public void Excute()
        {
            abcStock.Buy();
        }
    }

    public class SellStock : IOrder
    {
        private Stock abcStock;

        public SellStock(Stock stock)
        {
            abcStock = stock;
        }

        public void Excute()
        {
            abcStock.Sell();
        }
    }
    #endregion

    #region Step4 创建命令调用类
    public class Broker
    {
        private List<IOrder> orderLis = new List<IOrder>();

        public void TakeOrder(IOrder order)
        {
            orderLis.Add(order);
        }

        public void PlaceOrders()
        {
            foreach (IOrder order in orderLis)
            {
                order.Excute();
            }
            orderLis.Clear();
        }
    }
    #endregion
}
