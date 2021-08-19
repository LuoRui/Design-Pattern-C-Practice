using System;
using System.Collections.Generic;
namespace MementoPattern
{
    /// <summary>
    /// 备忘录模式
    /// </summary>
    public class MementoPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------MementoPattern Practice:----------------------------");

            #region Step4 使用CareTaker和Originator对象
            Originator originator = new Originator();
            CareTaker careTaker = new CareTaker();
            originator.SetState("State #1");
            originator.SetState("State #2");
            careTaker.Add(originator.SaveStateToMemento());
            originator.SetState("State #3");
            careTaker.Add(originator.SaveStateToMemento());
            originator.SetState("State #4");

            Console.WriteLine($"Current State:{originator.GetState()}");
            originator.GetStateFromMemento(careTaker.Get(0));
            Console.WriteLine($"First saved State:{originator.GetState()}");
            originator.GetStateFromMemento(careTaker.Get(1));
            Console.WriteLine($"Second saved State:{originator.GetState()}");
            #endregion
        }
    }

    #region Step1 创建Memento类
    public class Memento
    {
        private string state;

        public Memento(string state)
        {
            this.state = state;
        }

        public string GetState()
        {
            return state;
        }
    }
    #endregion

    #region Step2 创建Originator类
    public class Originator
    {
        private string state;

        public void SetState(string state)
        {
            this.state = state;
        }

        public string GetState()
        {
            return state;
        }

        public Memento SaveStateToMemento()
        {
            return new Memento(state);
        }

        public void GetStateFromMemento(Memento memento)
        {
            this.state = memento.GetState();
        }
    }
    #endregion

    #region Step3 创建CareTaker类
    public class CareTaker
    {
        private List<Memento> mementoList = new List<Memento>();

        public void Add(Memento memento)
        {
            mementoList.Add(memento);
        }

        public Memento Get(int index)
        {
            if (mementoList.Count > index)
            {
                return mementoList[index];
            }
            else
            {
                return null;
            }
        }
    }
    #endregion
}
