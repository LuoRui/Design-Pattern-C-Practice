using System;
namespace IteratorPattern
{
    /// <summary>
    /// 迭代器模式
    /// </summary>
    public class IteratorPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------IteratorPattern Practice:----------------------------");

            #region Step3 使用 NameRepository 来获取迭代器，并打印名字
            NameRepository nameRepository = new NameRepository();
            for (IIterator iterator = nameRepository.GetIterator(); iterator.HasNext();)
            {
                string name = iterator.Next().ToString();
                Console.WriteLine($"Name:{name}");
            }
            #endregion
        }
    }

    #region Step1 创建接口
    public interface IIterator
    {
        bool HasNext();
        Object Next();
    }

    public interface IContainer
    {
        IIterator GetIterator();
    }
    #endregion

    #region Step2 创建实现了接口的实体类
    public class NameRepository : IContainer
    {
        public string[] Names = { "Robert", "John", "Julie", "Lora" };

        public IIterator GetIterator()
        {
            return new StringArrayIterator(Names);
        }
    }

    public class StringArrayIterator : IIterator
    {
        String[] args;
        int index = 0;

        public StringArrayIterator(string[] args)
        {
            this.args = args;
        }

        public bool HasNext()
        {
            return index < args.Length;
        }

        public object Next()
        {
            if (HasNext())
            {
                return args[index++];
            }
            return null;
        }
    }
    #endregion
}
