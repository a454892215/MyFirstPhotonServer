using Photon.SocketServer;

namespace MyTestServer
{
    public class AppServer : ApplicationBase
    {
        protected override PeerBase CreatePeer(InitRequest initRequest)
        {
            var firstPeer = new FirstPeer(initRequest);
            return firstPeer;
        }

        protected override void Setup()
        {
          
        }

        protected override void TearDown()
        {
           
        }
    }
}