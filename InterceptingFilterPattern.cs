using System;
using System.Collections.Generic;
namespace InterceptingFilterPattern
{
    /// <summary>
    /// 拦截过滤器模式
    /// </summary>
    public class InterceptingFilterPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------InterceptingFilterPattern Practice:----------------------------");

            #region Step7 使用Client来演示拦截过滤器设计模式
            FilterManager filterManager = new FilterManager(new Target());
            filterManager.SetFilter(new AuthenticationFilter());
            filterManager.SetFilter(new DebugFilter());

            Client client = new Client();
            client.SetFilterManager(filterManager);
            client.SendRequest("HOME");
            #endregion
        }
    }

    #region Step1 创建过滤器接口
    public interface IFilter
    {
        void Execute(string request);
    }
    #endregion

    #region Step2 创建实体过滤器
    public class AuthenticationFilter : IFilter
    {
        public void Execute(string request)
        {
            Console.WriteLine($"Authenticating request:{request}");
        }
    }

    public class DebugFilter : IFilter
    {
        public void Execute(string request)
        {
            Console.WriteLine($"Request debug log:{request}");
        }
    }
    #endregion

    #region Step3 创建Target
    public class Target
    {
        public void Execute(string request)
        {
            Console.WriteLine($"Executing request:{request}");
        }
    }
    #endregion

    #region Step4 创建过滤器链
    public class FilterChain
    {
        private List<IFilter> filters = new List<IFilter>();
        private Target target;

        public void AddFilter(IFilter filter)
        {
            filters.Add(filter);
        }

        public void Execute(string request)
        {
            filters.ForEach(filter => filter.Execute(request));
            target.Execute(request);
        }

        public void SetTarget(Target target)
        {
            this.target = target;
        }
    }
    #endregion

    #region Step5 创建过滤管理器
    public class FilterManager
    {
        FilterChain filterChain;

        public FilterManager(Target target)
        {
            filterChain = new FilterChain();
            filterChain.SetTarget(target);
        }

        public void SetFilter(IFilter filter)
        {
            filterChain.AddFilter(filter);
        }

        public void FilterRequest(String request)
        {
            filterChain.Execute(request);
        }
    }
    #endregion

    #region Step6 创建客户端Client
    public class Client
    {
        FilterManager filterManager;

        public void SetFilterManager(FilterManager filterManager)
        {
            this.filterManager = filterManager;
        }

        public void SendRequest(string request)
        {
            filterManager.FilterRequest(request);
        }
    }
    #endregion
}
