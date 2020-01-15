using PENet;
using Protocal;
using UnityEngine;

namespace Assets.Scripts
{
    public class ClientSeesion : PENet.PESession<NetMsg>
    {
        protected override void OnConnected()
        {
            Debug.Log("Server Connect");
        }

        protected override void OnReciveMsg(NetMsg msg)
        {
            Debug.Log("Server Rsp" + msg.text);
        }

        protected override void OnDisConnected()
        {
            Debug.Log("Server DisConnect");
        }
    }
}
