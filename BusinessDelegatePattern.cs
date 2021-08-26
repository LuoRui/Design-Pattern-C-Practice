using System;
namespace BusinessDelegatePattern
{
    /// <summary>
    /// 业务代表模式
    /// </summary>
    public class BusinessDelegatePattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------BusinessDelegatePattern Practice:----------------------------");

            #region Step6 使用BusinessDelegate和Client类来演示业务代表模式
            BusinessDelegate businessDelegate = new BusinessDelegate();
            businessDelegate.SetServiceType("EJB");

            Client client = new Client(businessDelegate);
            client.DoTask();

            businessDelegate.SetServiceType("JMS");
            client.DoTask();
            #endregion
        }
    }

    #region Step1 创建BusinessService接口
    public interface IBusinessService
    {
        void DoProcessing();
    }
    #endregion

    #region Step2 创建实体服务类
    public class EJBService : IBusinessService
    {
        public void DoProcessing()
        {
            Console.WriteLine("Processing task by invoking EJB Service");
        }
    }

    public class JMSService : IBusinessService
    {
        public void DoProcessing()
        {
            Console.WriteLine("Processing task by invoking JMS Service");
        }
    }
    #endregion

    #region Step3 创建业务查询服务
    public class BusinessLookUp
    {
        public IBusinessService GetBusinessService(string serviceType)
        {
            if (serviceType.Equals("EJB"))
            {
                return new EJBService();
            }
            else
            {
                return new JMSService();
            }
        }
    }
    #endregion

    #region Step4 创建业务代表
    public class BusinessDelegate
    {
        private BusinessLookUp lookUpService = new BusinessLookUp();
        private IBusinessService businessService;
        private string serviceType;

        public void SetServiceType(string serviceType)
        {
            this.serviceType = serviceType;
        }

        public void DoTask()
        {
            businessService = lookUpService.GetBusinessService(serviceType);
            businessService.DoProcessing();
        }
    }
    #endregion

    #region Step5 创建客户端
    public class Client
    {
        BusinessDelegate businessDelegate;
        public Client(BusinessDelegate businessDelegate)
        {
            this.businessDelegate = businessDelegate;
        }

        public void DoTask()
        {
            businessDelegate.DoTask();
        }
    }
    #endregion
}
