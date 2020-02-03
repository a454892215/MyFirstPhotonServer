using System;
using System.IO;
using ExitGames.Logging;
using ExitGames.Logging.Log4Net;
using log4net.Config;
using Photon.SocketServer;

namespace MyTestServer
{
    public static class LogUtil
    {
        static readonly ILogger Log = LogManager.GetCurrentClassLogger();

        public static void Init(ApplicationBase app)
        {
            // 日志的初始化
            log4net.GlobalContext.Properties["Photon:ApplicationLogPath"] = Path.Combine(
                Path.Combine(app.ApplicationRootPath, "bin_Win64"), "log");
            FileInfo configFileInfo = new FileInfo(Path.Combine(app.BinaryPath, "log4net.config"));
            if (configFileInfo.Exists)
            {
                LogManager.SetLoggerFactory(Log4NetLoggerFactory.Instance); //让photon知道使用的是Log4NetLog插件
                XmlConfigurator.ConfigureAndWatch(configFileInfo); //让log4net这个插件读取配置文件
            }
            I("===i===Log初始化完成！");
        }

        public static void D(Object obj)
        {
            Log.Debug(obj);
        }

        public static void I(Object obj)
        {
            Log.Info(obj);
        }

        public static void E(Object obj)
        {
            Log.Error(obj);
        }
    }
}