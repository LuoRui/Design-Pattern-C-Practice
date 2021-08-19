using System;
namespace StatePattern
{
    /// <summary>
    /// 状态模式
    /// </summary>
    public class StatePattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------StatePattern Practice:----------------------------");

            #region Step4 使用Context来查看当状态State改变时的行为变化
            Context context = new Context();

            StartState startState = new StartState();
            startState.DoAction(context);
            Console.WriteLine(context.GetState().ToString());

            StopState stopState = new StopState();
            stopState.DoAction(context);
            Console.WriteLine(context.GetState().ToString());
            #endregion
        }
    }

    #region Step1 创建一个接口
    public interface IState
    {
        void DoAction(Context context);
    }
    #endregion

    #region Step2 创建实现接口的实体类
    public class StartState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("Player is in start state.");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Start State";
        }
    }

    public class StopState : IState
    {
        public void DoAction(Context context)
        {
            Console.WriteLine("Player is in stop state.");
            context.SetState(this);
        }

        public override string ToString()
        {
            return "Stop State";
        }
    }
    #endregion

    #region Step3 创建Context类
    public class Context
    {
        private IState state;
        public Context()
        {
            state = null;
        }

        public void SetState(IState state)
        {
            this.state = state;
        }

        public IState GetState()
        {
            return state;
        }
    }
    #endregion
}
