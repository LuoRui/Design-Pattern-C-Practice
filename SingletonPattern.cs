using System;
namespace SingletonPattern
{
    /// <summary>
    /// 单例模式
    /// </summary>
    public class SingletonPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------SingletonPattern Practice:----------------------------");

            #region Step2 从Singleton类获取类的唯一对象
            SingleObject.Instance().ShowMessage();
            SingleObject2.Instance().ShowMessage();
            #endregion
        }
    }

    #region Step1 创建 Singleton 类
    public class SingleObject
    {
        private static SingleObject instance = new SingleObject();
        public static SingleObject Instance()
        {
            return instance;
        }

        private SingleObject() { }

        public void ShowMessage()
        {
            Console.WriteLine("I am the only one instance of SingleObject!");
        }
    }

    public class SingleObject2
    {
        private static class SingletonHolder
        {
            public static readonly SingleObject2 Instance = new SingleObject2();
        }

        public static SingleObject2 Instance()
        {
            return SingletonHolder.Instance;
        }

        private SingleObject2() { }

        public void ShowMessage()
        {
            Console.WriteLine("I am the only one instance of SingleObject2!");
        }
    }
    #endregion
}
