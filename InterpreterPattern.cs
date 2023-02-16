using System;
namespace InterpreterPattern
{
    /// <summary>
    /// 解释器模式
    /// </summary>
    public class InterpreterPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------InterpreterPattern Practice:----------------------------");

            #region Step3 使用 Expression 类来创建规则，并解析它们
            IExpression isMale = GetMaleExpression();
            IExpression isMarriedWoman = GetMarriedWomanExpression();
            Console.WriteLine($"John is male? {isMale.Interpret("John")}");
            Console.WriteLine($"Julie is a marride women? {isMarriedWoman.Interpret("Marride Julie")}");
            #endregion
        }

        public static IExpression GetMaleExpression()
        {
            IExpression robert = new TerminalExpression("Robert");
            IExpression john = new TerminalExpression("John");
            return new OrExtpression(robert, john);
        }

        public static IExpression GetMarriedWomanExpression()
        {
            IExpression julie = new TerminalExpression("Julie");
            IExpression married = new TerminalExpression("Marride");
            return new AndExpression(julie, married);
        }
    }

    #region Step1 创建一个表达式接口
    public interface IExpression
    {
        bool Interpret(string context);
    }
    #endregion

    #region Step2 创建实现了上述接口的实体类
    public class TerminalExpression : IExpression
    {
        private string data;
        public TerminalExpression(string data)
        {
            this.data = data;
        }

        public bool Interpret(string context)
        {
            if (context.Contains(data))
            {
                return true;
            }
            return false;
        }
    }

    public class OrExtpression : IExpression
    {
        private IExpression expr1 = null;
        private IExpression expr2 = null;

        public OrExtpression(IExpression expr1, IExpression expr2)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
        }

        public bool Interpret(string context)
        {
            return expr1.Interpret(context) || expr2.Interpret(context);
        }
    }

    public class AndExpression : IExpression
    {
        private IExpression expr1 = null;
        private IExpression expr2 = null;

        public AndExpression(IExpression expr1, IExpression expr2)
        {
            this.expr1 = expr1;
            this.expr2 = expr2;
        }

        public bool Interpret(string context)
        {
            return expr1.Interpret(context) && expr2.Interpret(context);
        }
    }
    #endregion
}
