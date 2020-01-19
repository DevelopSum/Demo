using PENet;

/// <summary>
/// 日志类型
/// </summary>
public enum LogType
{
    /// <summary>
    /// 日志
    /// </summary>
    Log = 0,
    /// <summary>
    /// 警告
    /// </summary>
    Warn = 1,
    /// <summary>
    /// 错误
    /// </summary>
    Error = 2,
    /// <summary>
    /// 通知
    /// </summary>
    Info = 3
}

/// <summary>
/// 客户端服务端共用工具类
/// Log日志
/// </summary>
public class PECommon
{
    public static void Log(string msg = "", LogType tp = LogType.Log)
    {
        LogLevel lv = (LogLevel)tp;
        PETool.LogMsg(msg, lv);
    }
}

