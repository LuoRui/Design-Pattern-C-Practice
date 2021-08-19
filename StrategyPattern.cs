using System;
namespace StrategyPattern
{
    /// <summary>
    /// 策略模式
    /// </summary>
    public class StrategyPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------StrategyPattern Practice:----------------------------");

            #region Step4 使用Context来查看当它改变策略Strategy时的行为变化
            Context context = new Context(new OperationAdd());
            Console.WriteLine($"10+5={context.ExecteStrategy(10, 5)}");

            context = new Context(new OperationSubtract());
            Console.WriteLine($"10-5={context.ExecteStrategy(10, 5)}");

            context = new Context(new OperationMultiply());
            Console.WriteLine($"10*5={context.ExecteStrategy(10, 5)}");
            #endregion
        }
    }

    #region Step1 创建一个接口
    public interface Strategy
    {
        int DoOperation(int num1, int num2);
    }
    #endregion

    #region Step2 创建实现接口的实体类
    public class OperationAdd : Strategy
    {
        public int DoOperation(int num1, int num2)
        {
            return num1 + num2;
        }
    }

    public class OperationSubtract : Strategy
    {
        public int DoOperation(int num1, int num2)
        {
            return num1 - num2;
        }
    }

    public class OperationMultiply : Strategy
    {
        public int DoOperation(int num1, int num2)
        {
            return num1 * num2;
        }
    }
    #endregion

    #region Step3 创建Context类
    public class Context
    {
        private Strategy strategy;
        public Context(Strategy strategy)
        {
            this.strategy = strategy;
        }
        public int ExecteStrategy(int num1, int num2)
        {
            return strategy.DoOperation(num1, num2);
        }
    }
    #endregion
}
