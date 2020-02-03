
using Photon.SocketServer;

namespace MyTestServer
{
    public class AppServer : ApplicationBase
    {
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            var firstPeer = new FirstPeer(initRequest);
            LogUtil.I("==i====一个客户端连接过来了。。。。");
            return firstPeer;
        }

        protected override void Setup()
        {
            LogUtil.Init(this);
        }


        protected override void TearDown()
        {
            LogUtil.I("====i===服务器应用关闭了");
        }
    }
}