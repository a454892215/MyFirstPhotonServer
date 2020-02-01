using Photon.SocketServer;
using PhotonHostRuntimeInterfaces;

namespace MyTestServer
{
    public class FirstPeer : ClientPeer
    {
        public FirstPeer(InitRequest initRequest) : base(initRequest)
        {
            
        }

        protected override void OnOperationRequest(OperationRequest operationRequest, SendParameters sendParameters)
        {
            
        }

        protected override void OnDisconnect(DisconnectReason reasonCode, string reasonDetail)
        {
    
        }
    }
}