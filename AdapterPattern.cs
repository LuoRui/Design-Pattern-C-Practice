using System;
namespace AdapterPattern
{
    /// <summary>
    /// 适配器模式
    /// </summary>
    public class AdapterPattern
    {
        public static void Practice()
        {
            Console.WriteLine("----------------------------AdapterPattern Practice:----------------------------");

            #region Step5 使用 AudioPlayer 来播放不同类型的音频格式
            AudioPlayer audioPlayer = new AudioPlayer();
            audioPlayer.Play("Mp4", "The lost of us.mp4");
            audioPlayer.Play("Mp3", "Watting for you.mp3");
            audioPlayer.Play("Avi", "Waht you want.avi");
            audioPlayer.Play("Vlc", "My hero,my god.vlc");
            #endregion
        }
    }

    #region Step1 为媒体播放器和更高级的媒体播放器创建接口
    public interface MediaPlayer
    {
        void Play(string audioType, string fileName);
    }

    public interface AdvancedMediaPlayer
    {
        void PlayVlc(string fileName);
        void PlayMp4(string fileName);
    }
    #endregion

    #region Step2 创建实现了 AdvancedMediaPlayer 接口的实体类
    public class VlcPlayer : AdvancedMediaPlayer
    {
        public void PlayMp4(string fileName)
        {
            //Do nothing
        }

        public void PlayVlc(string fileName)
        {
            Console.WriteLine($"Playing Vlc file,Name:{fileName}");
        }
    }

    public class Mp4Player : AdvancedMediaPlayer
    {
        public void PlayMp4(string fileName)
        {
            Console.WriteLine($"Playing Mp4 file,Name:{fileName}");
        }

        public void PlayVlc(string fileName)
        {
            //Do nothing
        }
    }
    #endregion

    #region Step3 创建实现了 MediaPlayer 接口的适配器类
    public class MediaAdapter : MediaPlayer
    {
        AdvancedMediaPlayer advanceMediaPlayer;

        public MediaAdapter(string audioType)
        {
            switch (audioType.ToLower())
            {
                case "vlc":
                    advanceMediaPlayer = new VlcPlayer();
                    break;
                case "mp4":
                    advanceMediaPlayer = new Mp4Player();
                    break;
            }
        }

        public void Play(string audioType, string fileName)
        {
            switch (audioType.ToLower())
            {
                case "vlc":
                    advanceMediaPlayer.PlayVlc(fileName);
                    break;
                case "mp4":
                    advanceMediaPlayer.PlayMp4(fileName);
                    break;
            }
        }
    }
    #endregion

    #region Step4 创建实现了 MediaPlayer 接口的实体类
    public class AudioPlayer : MediaPlayer
    {
        MediaAdapter mediaAdapter;

        public void Play(string audioType, string fileName)
        {
            switch (audioType.ToLower())
            {
                case "mp3":
                    {
                        Console.WriteLine($"Playing Mp3 file,Name:{fileName}");
                    }
                    break;
                case "mp4":
                case "vlc":
                    {
                        mediaAdapter = new MediaAdapter(audioType);
                        mediaAdapter.Play(audioType, fileName);
                    }
                    break;
                default:
                    {
                        Console.WriteLine($"Invalid media.{audioType} format not supported.");
                    }
                    break;
            }
        }
    }
    #endregion
}
