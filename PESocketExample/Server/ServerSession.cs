using PENet;
using Protocal;

public class ServerSession : PESession<NetMsg>
{

    /// <summary>
    /// 建立连接
    /// </summary>
    protected override void OnConnected()
    {
        PETool.LogMsg("Client Connect");
        SendMsg(new NetMsg
        {
            text = "Client Connect"
        });
    }

    /// <summary>
    /// 收到数据
    /// </summary>
    /// <param name="msg"></param>
    protected override void OnReciveMsg(NetMsg msg)
    {
        PETool.LogMsg("Client Req" + msg.text);
        SendMsg(new NetMsg
        {
            text = "SrvRsp" + " : " + msg.text
        }); 
    }

    /// <summary>
    /// 断开连接
    /// </summary>
    protected override void OnDisConnected()
    {
        PETool.LogMsg("Client DisConnect");
    }
}
