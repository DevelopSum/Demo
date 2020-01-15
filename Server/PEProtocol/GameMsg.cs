using PENet;
using System;

namespace PEProtocol
{
    /// <summary>
    /// 网络通信协议（客户端服务端共用）
    /// </summary>
    [Serializable]
    public class GameMsg : PEMsg
    {
        public ReqLogin reqLogin;
        public RspLogin rspLogin;
    }

    /// <summary>
    /// 发送请求登录的类
    /// </summary>
    [Serializable]
    public class ReqLogin
    {
        public string acct;
        public string pass;
    }

    [Serializable]
    public class RspLogin
    {
        public PlayerData playerData;
    }
    [Serializable]
    public class PlayerData {
        public int id;
        public string name;
        public int lv;
        public int exp;
        public int power;
        public int coin;
        public int diamond;
    }

    public enum ErrorCode { 
        /// <summary>
        /// 没有错误
        /// </summary>
        Node=0,
         /// <summary>
        /// 账号已上线
        /// </summary>
        AcctisOnline,
        /// <summary>
        /// 密码错误
        /// </summary>
        WrongPass,
    
    }

    public enum CMD
    {
        None = 0,
        //登陆相关
        ReqLogin = 101,
        RspLogin = 102,
    }

    public class SrvCfg
    {
        public const string srvIP = "127.0.0.1";
        public const int srvPort = 17666;
    }
}
