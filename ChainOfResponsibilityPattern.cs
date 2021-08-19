using System;
namespace ChainOfResponsibilityPattern
{
    /// <summary>
    /// 责任链模式
    /// </summary>
    public class ChainOfResponsibilityPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------ChainOfResponsibilityPattern Practice:----------------------------");

            #region Step3 创建不同类型的记录器。赋予它们不同的错误级别，并在每个记录器中设置下一个记录器。每个记录器中的下一个记录器代表的是链的一部分。
            AbstractLogger loggerChain = GetChainOfLoggers();
            loggerChain.LogMessage(AbstractLogger.INFO, "This is an infomation.");
            loggerChain.LogMessage(AbstractLogger.DEBUG, "This is a debug level infomation.");
            loggerChain.LogMessage(AbstractLogger.ERROR, "This is an error infomation.");
            #endregion
        }

        private static AbstractLogger GetChainOfLoggers()
        {
            AbstractLogger errorLogger = new ErrorLogger(AbstractLogger.ERROR);
            AbstractLogger fileLogger = new FileLogger(AbstractLogger.DEBUG);
            AbstractLogger infoLogger = new ConsoleLogger(AbstractLogger.INFO);

            errorLogger.SetNextLogger(fileLogger);
            fileLogger.SetNextLogger(infoLogger);

            return errorLogger;
        }
    }

    #region Step1 创建抽象的记录器类
    public abstract class AbstractLogger
    {
        public static int INFO = 1;
        public static int DEBUG = 2;
        public static int ERROR = 3;

        protected int level;
        protected AbstractLogger nextLogger;

        public void SetNextLogger(AbstractLogger nextLogger)
        {
            this.nextLogger = nextLogger;
        }

        public void LogMessage(int level, string message)
        {
            if (this.level <= level)
            {
                Write(message);
            }
            if (nextLogger != null)
            {
                nextLogger.LogMessage(level, message);
            }
        }

        protected abstract void Write(string message);
    }
    #endregion

    #region Step2 创建扩展了该记录器类的实体类
    public class ConsoleLogger : AbstractLogger
    {
        public ConsoleLogger(int level)
        {
            this.level = level;
        }

        protected override void Write(string message)
        {
            Console.WriteLine($"Standard Console Logger:{message}");
        }
    }

    public class ErrorLogger : AbstractLogger
    {
        public ErrorLogger(int level)
        {
            this.level = level;
        }

        protected override void Write(string message)
        {
            Console.WriteLine($"Error Console Logger:{message}");
        }
    }

    public class FileLogger : AbstractLogger
    {
        public FileLogger(int level)
        {
            this.level = level;
        }

        protected override void Write(string message)
        {
            Console.WriteLine($"File Console Logger:{message}");
        }
    }
    #endregion
}