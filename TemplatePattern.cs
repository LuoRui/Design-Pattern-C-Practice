using System;
namespace TemplatePattern
{
    /// <summary>
    /// 模板模式
    /// </summary>
    public class TemplatePattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------TemplatePattern Practice:----------------------------");

            #region Step3 使用Game的模版方法Play()来演示游戏的定义方式
            Game game = new Cricket();
            game.Play();
            game = new Football();
            game.Play();
            #endregion
        }
    }

    #region Step1 创建一个抽象类，设置模版方法Play
    public abstract class Game
    {
        protected abstract void Initialize();
        protected abstract void StartPlay();
        protected abstract void EndPlay();

        public void Play()
        {
            Initialize();
            StartPlay();
            EndPlay();
        }
    }
    #endregion

    #region Step2 创建扩展了上述类的实体类
    public class Cricket : Game
    {
        protected override void EndPlay()
        {
            Console.WriteLine("Cricket Game Finished!");
        }

        protected override void Initialize()
        {
            Console.WriteLine("Cricket Game Initialize!");
        }

        protected override void StartPlay()
        {
            Console.WriteLine("Cricket Game Started.");
        }
    }

    public class Football : Game
    {
        protected override void EndPlay()
        {
            Console.WriteLine("Football Game Finished!");
        }

        protected override void Initialize()
        {
            Console.WriteLine("Football Game Initialize!");
        }

        protected override void StartPlay()
        {
            Console.WriteLine("Football Game Started.");
        }
    }
    #endregion
}
