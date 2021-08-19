using System;
namespace MediatorPattern
{
    /// <summary>
    /// 中介者模式
    /// </summary>
    public class MediatorPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------MediatorPattern Practice:----------------------------");

            #region Step3 使用 User 对象来显示他们之间的通信
            User robert = new User("Robert");
            User john = new User("John");
            robert.SendMessage("Hi!John!");
            john.SendMessage("Hello!Robert!");
            #endregion
        }
    }

    #region Step1 创建中介类
    public class ChatRoom
    {
        public static void ShowMessage(User user, string message)
        {
            Console.WriteLine($"{DateTime.Now.ToString()} [{user.GetName()}]:{message}");
        }
    }
    #endregion

    #region Step2 创建 user 类
    public class User
    {
        private string name;

        public User(string name)
        {
            this.name = name;
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SendMessage(string message)
        {
            ChatRoom.ShowMessage(this, message);
        }
    }
    #endregion
}
