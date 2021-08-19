using System;
namespace NullObjectPattern
{
    /// <summary>
    /// 空对象模式
    /// </summary>
    public class NullObjectPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------NullObjectPattern Practice:----------------------------");

            #region Step4 使用CustomerFactory，基于客户传递的名字，来获取RealCustomer或NullCustomer对象
            AbstractCustomer Customer1 = CustomerFactory.GetCustomer("Julie");
            AbstractCustomer Customer2 = CustomerFactory.GetCustomer("Rob");
            AbstractCustomer Customer3 = CustomerFactory.GetCustomer("Joe");
            AbstractCustomer Customer4 = CustomerFactory.GetCustomer("Laora");

            Console.WriteLine("Customers");
            Console.WriteLine(Customer1.GetName());
            Console.WriteLine(Customer2.GetName());
            Console.WriteLine(Customer3.GetName());
            Console.WriteLine(Customer4.GetName());
            #endregion
        }
    }

    #region Step1 创建一个抽象类
    public abstract class AbstractCustomer
    {
        protected string Name;
        public abstract bool IsNull();
        public abstract string GetName();
    }
    #endregion

    #region Step2 创建扩展了上述类的实体类
    public class RealCustomer : AbstractCustomer
    {
        public RealCustomer(string name)
        {
            this.Name = name;
        }

        public override string GetName()
        {
            return Name;
        }

        public override bool IsNull()
        {
            return false;
        }
    }

    public class NullCustomer : AbstractCustomer
    {
        public override string GetName()
        {
            return "Not Available in Customer Database";
        }

        public override bool IsNull()
        {
            return true;
        }
    }
    #endregion

    #region Step3 创建CustomerFactory类
    public class CustomerFactory
    {
        public static readonly string[] names = { "Rob", "Joe", "Julie" };
        public static AbstractCustomer GetCustomer(string name)
        {
            for (int i = 0; i < names.Length; i++)
            {
                if (names[i].ToLower().Equals(name.ToLower()))
                {
                    return new RealCustomer(name);
                }
            }
            return new NullCustomer();
        }
    }
    #endregion
}
