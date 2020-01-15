using PENet;
using PEProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 网络会话链接
/// </summary>
    public class ServerSession : PESession<GameMsg>
    {
    protected override void OnConnected()
    {
        PETool.LogMsg("Client Connect");
        SendMsg(new GameMsg
        {
            text="Welcom to Connect"
        });
    }

    protected override void OnReciveMsg(GameMsg msg)
    {
        PETool.LogMsg("Client Req : " + msg.text);
        SendMsg(new GameMsg
        {
            text = "SrvRsp : " + msg.text
        });
    }

    protected override void OnDisConnected()
    {
        PETool.LogMsg("Client DisConnect");
    }

}
