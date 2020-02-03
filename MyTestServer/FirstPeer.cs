using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;

namespace MyTestServer
{
    public class FirstPeer : ClientPeer
    {
        public FirstPeer(InitRequest initRequest) : base(initRequest)
        {
        }

        //接收到客户端请求
        protected override void OnOperationRequest(OperationRequest request, SendParameters sendParameters)
        {
            var obj = request.Parameters[3];
            LogUtil.I("接收到客户端的请求：" + obj + "  OperationCode:" + request.OperationCode);
        }

        //客户端断开
        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
            LogUtil.I("客户端断开 reasonDetail：" + reasonDetail + "   reasonCode:" + reasonCode);
        }
    }
}