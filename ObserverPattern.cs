using System;
using System.Collections.Generic;
namespace ObserverPattern
{
    /// <summary>
    /// 观察者模式
    /// </summary>
    public class ObserverPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------ObserverPattern Practice:----------------------------");

            #region Step4 使用Subject和实体观察者对象
            Subject subject = new Subject();
            new HexaObserver(subject);
            new OctalObserver(subject);
            new BinaryObserver(subject);
            Console.WriteLine($"First state change : 15");
            subject.SetState(15);
            Console.WriteLine($"Second state change: 10");
            subject.SetState(10);
            #endregion
        }
    }

    #region Step1 创建Subject类
    public class Subject
    {
        private List<Observer> observers = new List<Observer>();
        private int state;

        public int GetState()
        {
            return state;
        }

        public void SetState(int state)
        {
            this.state = state;
            NotifyAllObservers();
        }

        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }

        public void NotifyAllObservers()
        {
            foreach (var observer in observers)
            {
                observer.Update();
            }
        }
    }
    #endregion

    #region Step2 创建ObServer类
    public abstract class Observer
    {
        protected Subject subject;
        public abstract void Update();
    }
    #endregion

    #region Step3 创建实体观察者类
    public class BinaryObserver : Observer
    {
        public BinaryObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.Attach(this);
        }

        public override void Update()
        {
            Console.WriteLine($"Binary String:{subject.GetState()}");//TODO Convert To Binary
        }
    }

    public class OctalObserver : Observer
    {
        public OctalObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.Attach(this);
        }

        public override void Update()
        {
            Console.WriteLine($"Octal String:{subject.GetState()}");//TODO Convert To Octal
        }
    }

    public class HexaObserver : Observer
    {
        public HexaObserver(Subject subject)
        {
            this.subject = subject;
            this.subject.Attach(this);
        }

        public override void Update()
        {
            Console.WriteLine($"Hex String:{subject.GetState()}");//TODO Convert To Hex
        }
    }
    #endregion
}
