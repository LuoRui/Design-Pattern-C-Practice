using System;
using System.Collections.Generic;
namespace ServiceLocatorPattern
{
    /// <summary>
    /// 服务定位器模式
    /// </summary>
    public class ServiceLocatorPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------ServiceLocatorPattern Practice:----------------------------");

            #region Step6 使用ServiceLocator来演示服务定位器设计模式
            IService service = ServiceLocator.GetService("service1");
            service.Execute();
            service = ServiceLocator.GetService("service2");
            service.Execute();
            service = ServiceLocator.GetService("service1");
            service.Execute();
            service = ServiceLocator.GetService("service2");
            service.Execute();
            #endregion
        }
    }

    #region Step1 创建服务接口
    public interface IService
    {
        string GetName();
        void Execute();
    }
    #endregion

    #region Step2 创建实体服务
    public class Service1 : IService
    {
        public void Execute()
        {
            Console.WriteLine("Execute Service1");
        }

        public string GetName()
        {
            return "Service1";
        }
    }

    public class Service2 : IService
    {
        public void Execute()
        {
            Console.WriteLine("Execute Service2");
        }

        public string GetName()
        {
            return "Service2";
        }
    }
    #endregion

    #region Step3 为JNDI查询创建InitialContext
    public class InitialContext
    {
        public object Lookup(string jndiName)
        {
            if (jndiName.ToUpper().Equals("SERVICE1"))
            {
                Console.WriteLine("Looking up and createing a new service1 object");
                return new Service1();
            }
            else if (jndiName.ToUpper().Equals("SERVICE2"))
            {
                Console.WriteLine("Looking up and createing a new service2 object");
                return new Service2();
            }
            return null;
        }
    }
    #endregion

    #region Step4 创建缓存Cache
    public class Cache
    {
        private List<IService> services;

        public Cache()
        {
            services = new List<IService>();
        }

        public IService GetService(string serviceName)
        {
            foreach (IService service in services)
            {
                if (service.GetName().ToUpper().Equals(serviceName.ToUpper()))
                {
                    Console.WriteLine($"Returning cached {serviceName} object");
                    return service;
                }
            }
            return null;
        }

        public void AddService(IService newService)
        {
            if (!services.Contains(newService))
            {
                services.Add(newService);
            }
        }
    }
    #endregion

    #region Step5 创建服务定位器
    public class ServiceLocator
    {
        private static Cache cache = new Cache();

        public static IService GetService(string jndiName)
        {
            IService service = cache.GetService(jndiName);
            if (service != null)
            {
                return service;
            }

            InitialContext context = new InitialContext();
            IService service1 = (IService)context.Lookup(jndiName);
            cache.AddService(service1);
            return service1;
        }
    }
    #endregion
}
