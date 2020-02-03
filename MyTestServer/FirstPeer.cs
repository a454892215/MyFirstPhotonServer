using System;
using System.Collections.Generic;
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

            var dictionary = new Dictionary<byte, Object> {{1, "我是来自服务器的响应 i am response msg from server"}};
            //以响应的发送给客服端发送消息
            var response = new OperationResponse(1, dictionary);
            SendOperationResponse(response, sendParameters);

            //以事件的方式给客服端发送消息
            var dic2 = new Dictionary<byte, Object> {{1, "我是来自服务器的事件 i am event msg from server"}};
            var eventData = new EventData(1, dic2);
            SendEvent(eventData, sendParameters);
            LogUtil.I("===========服务端发送消息成功===========");
        }

        //客户端断开
        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
            LogUtil.I("客户端断开 reasonDetail：" + reasonDetail + "   reasonCode:" + reasonCode);
        }
    }
}