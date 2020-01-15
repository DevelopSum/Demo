using PENet;
using PEProtocol;
using System.Collections.Generic;


public class MsgPack {
    public ServerSession session;
    public GameMsg msg;
    public MsgPack(ServerSession session, GameMsg msg) {
        this.session = session;
        this.msg = msg;
    }

}

public class NetSvc
    {
        private static NetSvc instance = null;
        public static NetSvc Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new NetSvc();
                }
                return instance;
            }
        }

    /// <summary>
    /// 为了安全在新增的时候加入进程锁
    /// </summary>
    public static readonly string obj = "lock";
        /// <summary>
        /// 存储消息队列
        /// </summary>
        private Queue<MsgPack> msgPackQue=new Queue<MsgPack>();

    public void Init()
        {
        PESocket<ServerSession, GameMsg> server = new PESocket<ServerSession, GameMsg>();
        server.StartAsServer(SrvCfg.srvIP, SrvCfg.srvPort);

        PECommon.Log("NetSvc Init Done");
        }

    /// <summary>
    /// 接受消息包
    /// </summary>
    /// <param name="msg"> 消息 </param>
    public void AddMsgQue(ServerSession session , GameMsg msg) {
        lock(obj)
        {
            msgPackQue.Enqueue(new MsgPack(session,msg));
        }
    }

    public void Update() {
        //取出数据
        if (msgPackQue.Count>0)
        {
            PECommon.Log("PackCount : " + msgPackQue.Count);
            lock (obj)
            {
                MsgPack pack = msgPackQue.Dequeue();
                HadOutMsg(pack);
            }
        }
    }

    /// <summary>
    /// 对数据进行处理
    /// </summary>
    private void HadOutMsg(MsgPack pack) {
        switch ((CMD)pack.msg.cmd)
        {
            case CMD.None:
                break;
            case CMD.ReqLogin:
                LoginSys.Instance.ReqLogin(pack);
                break;
            case CMD.RspLogin:
                break;
            default:
                break;
        }
    }
}
