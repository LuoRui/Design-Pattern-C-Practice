using System;
namespace FrontControllerPattern
{
    /// <summary>
    /// 前端控制器模式
    /// </summary>
    public class FrontControllerPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------FrontControllerPattern Practice:----------------------------");

            #region Step4 使用FrontController来演示前端控制器设计模式
            FrontController frontController = new FrontController();
            frontController.DispatchRequest("Home");
            frontController.DispatchRequest("Student");
            #endregion
        }
    }

    #region Step1 创建视图
    public class HomeView
    {
        public void Show()
        {
            Console.WriteLine("Displaying Home Page");
        }
    }

    public class StudentView
    {
        public void Show()
        {
            Console.WriteLine("Displaying Student Page");
        }
    }
    #endregion

    #region Step2 创建调度器Dispatcher
    public class Dispatcher
    {
        private StudentView studentView;
        private HomeView homeView;

        public Dispatcher()
        {
            studentView = new StudentView();
            homeView = new HomeView();
        }

        public void Dispatch(string request)
        {
            if (request.ToUpper().Equals("STUDENT"))
            {
                studentView.Show();
            }
            else
            {
                homeView.Show();
            }
        }
    }
    #endregion

    #region Step3 创建前端控制器FrontController
    public class FrontController
    {
        private Dispatcher dispatcher;

        public FrontController()
        {
            dispatcher = new Dispatcher();
        }

        private bool IsAuthenticUser()
        {
            Console.WriteLine("User is authenticated success");
            return true;
        }

        private void TrackRequest(string request)
        {
            Console.WriteLine($"Page requested:{request}");
        }

        public void DispatchRequest(string request)
        {
            TrackRequest(request);
            if (IsAuthenticUser())
            {
                dispatcher.Dispatch(request);
            }
        }
    }
    #endregion
}
