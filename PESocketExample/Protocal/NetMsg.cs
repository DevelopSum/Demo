using PENet;
using System;

namespace Protocal
{
    /// <summary>
    /// Serializable
    /// 序列化 
    /// 转换成二进制
    /// </summary>
    [Serializable]
    public class NetMsg : PEMsg
    {
        public string text;
    }

    /// <summary>
    /// 当前服务器IP PROT
    /// </summary>
    public class IPCfg
    {
        public const string srvIP = "127.0.0.1";
        public const int srvPort = 17666;
    }
}
