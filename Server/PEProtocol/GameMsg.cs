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

        public ReqRename reqRename;
        public RspRename rspRename;
    }

    #region 登录相关
    /// <summary>
    /// 发送请求登录类
    /// </summary>
    [Serializable]
    public class ReqLogin
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string acct;
        /// <summary>
        /// 密码
        /// </summary>
        public string pass;
    }

    /// <summary>
    /// 请求登录类
    /// </summary>
    [Serializable]
    public class RspLogin
    {
        /// <summary>
        /// 玩家数据
        /// </summary>
        public PlayerData playerData;
    }

    /// <summary>
    /// 玩家数据
    /// </summary>
    [Serializable]
    public class PlayerData
    {
        public int id;
        public string name;
        public int lv;
        public int exp;
        public int power;
        public int coin;
        public int diamond;
    }

    /// <summary>
    /// 重命名
    /// </summary>
    [Serializable]
    public class ReqRename
    {
        public string name;
    }
    /// <summary>
    /// 如果名字可用在发送给客户端
    /// </summary>
    public class RspRename { 
        public string name;
    }

    #endregion

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
        /// <summary>
        /// 名字已经存在
        /// </summary>
        NameIsExist,
    }

    public enum CMD
    {
        None = 0,
        //登陆相关
        ReqLogin = 101,
        RspLogin = 102,

        ReqRename = 103,
        RspRename = 104,
    }

    /// <summary>
    /// 服务器IP及端口
    /// </summary>
    public class SrvCfg
    {
        public const string srvIP = "127.0.0.1";
        public const int srvPort = 17666;
    }
}
