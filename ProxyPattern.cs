using System;
namespace ProxyPattern
{
    /// <summary>
    /// 代理模式
    /// </summary>
    public class ProxyPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------ProxyPattern Practice:----------------------------");

            #region Step3 当被请求时，使用 ProxyImage 来获取 RealImage 类的对象
            IImage image = new ProxyImage("test_imgae.png");
            image.Display();
            image.Display();
            #endregion
        }
    }

    #region Step1 创建一个接口
    public interface IImage
    {
        void Display();
    }
    #endregion

    #region Step2 创建实现接口的实体类
    public class RealImage : IImage
    {
        private string fileName;

        public RealImage(string fileName)
        {
            this.fileName = fileName;
            LoadFromDisk(fileName);
        }

        public void Display()
        {
            Console.WriteLine($"Displaying {fileName}");
        }

        private void LoadFromDisk(string fileName)
        {
            Console.WriteLine($"Loading {fileName}");
        }
    }

    public class ProxyImage : IImage
    {
        private RealImage realImage;
        private string fileName;

        public ProxyImage(string fileName)
        {
            this.fileName = fileName;
        }

        public void Display()
        {
            if (realImage == null)
            {
                realImage = new RealImage(fileName);
            }
            realImage.Display();
        }
    }
    #endregion
}
