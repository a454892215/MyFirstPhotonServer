using System.IO;
using ExitGames.Logging;
using ExitGames.Logging.Log4Net;
using log4net.Config;
using Photon.SocketServer;

namespace MyTestServer
{
    public class AppServer : ApplicationBase
    {
        static readonly ILogger Log = LogManager.GetCurrentClassLogger();

        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            var firstPeer = new FirstPeer(initRequest);
            Log.Info("======一个客户端连接过来了。。。。");
            return firstPeer;
        }

        protected override void Setup()
        {
            InitLog();
            Log.Info("======Log初始化完成！");
        }

        private void InitLog()
        {
            // 日志的初始化
            log4net.GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(
                Path.Combine(this.ApplicationRootPath, "bin_Win64"), "log");
            FileInfo configFileInfo = new FileInfo(Path.Combine(this.BinaryPath, "log4net.config"));
            if (configFileInfo.Exists)
            {
                LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance); //让photon知道使用的是Log4NetLog插件
                XmlConfigurator.ConfigureAndWatch(configFileInfo); //让log4net这个插件读取配置文件
            }
        }

        protected override void TearDown()
        {
            Log.Info("=======服务器应用关闭了");
        }
    }
}