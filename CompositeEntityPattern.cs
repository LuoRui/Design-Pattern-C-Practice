using System;
namespace CompositeEntityPattern
{
    /// <summary>
    /// 组合实体模式
    /// </summary>
    public class CompositeEntityPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------CompositeEntityPattern Practice:----------------------------");

            #region Step5 使用Client来演示组合实体设计模式的用法
            Client client = new Client();
            client.SetData("StrayCat", "Blue");
            client.PrintData();
            client.SetData("Roger", "Red");
            client.PrintData();
            #endregion
        }
    }

    #region Step1 创建依赖对象
    public class DependentObject1
    {
        private string data;

        public void SetData(string data)
        {
            this.data = data;
        }

        public string GetData()
        {
            return data;
        }
    }

    public class DependentObject2
    {
        private string data;

        public void SetData(string data)
        {
            this.data = data;
        }

        public string GetData()
        {
            return data;
        }
    }
    #endregion

    #region Step2 创建粗粒度对象
    public class CoarseGrainedObject
    {
        DependentObject1 do1 = new DependentObject1();
        DependentObject2 do2 = new DependentObject2();

        public void SetData(string data1, string data2)
        {
            do1.SetData(data1);
            do2.SetData(data2);
        }

        public string[] GetData()
        {
            return new string[] { do1.GetData(), do2.GetData() };
        }
    }
    #endregion

    #region Step3 创建组合实体
    public class CompositeEntity
    {
        private CoarseGrainedObject cgo = new CoarseGrainedObject();

        public void SetData(string data1, string data2)
        {
            cgo.SetData(data1, data2);
        }

        public string[] GetData()
        {
            return cgo.GetData();
        }
    }
    #endregion

    #region Step4 创建使用组合实体的客户端类
    public class Client
    {
        private CompositeEntity compositeEntity = new CompositeEntity();

        public void PrintData()
        {
            for (int i = 0; i < compositeEntity.GetData().Length; i++)
            {
                Console.WriteLine($"Data:{compositeEntity.GetData()[i]}");
            }
        }

        public void SetData(string data1, string data2)
        {
            compositeEntity.SetData(data1, data2);
        }
    }
    #endregion
}
