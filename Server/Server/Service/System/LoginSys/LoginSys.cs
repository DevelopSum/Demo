using PEProtocol;


/// <summary>
/// 登录业务系统
/// </summary>
public class LoginSys
{
    private static LoginSys instance = null;
    public static LoginSys Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new LoginSys();
            }
            return instance;
        }
    }
    public CacheSvc cacheSvc = null;

    public void Init()
    {
        PECommon.Log("LoginSys Init Done.");
        cacheSvc = CacheSvc.Instance;
    }

    /// <summary>
    /// 业务处理
    /// </summary>
    /// <param name="msg"></param>
    public void ReqLogin(MsgPack pack)
    {
        ReqLogin data = pack.msg.reqLogin;

        //当前账号是否已经上线
        GameMsg msg = new GameMsg
        {
            cmd = (int)CMD.RspLogin
        };
        if (cacheSvc.IsAcctOnLine(data.acct))
        {
            //已上线 返回错误信息
            msg.err = (int)ErrorCode.AcctisOnline;
        }
        else
        {
            //未上线
            //账号是否存在
            PlayerData pd = cacheSvc.GetPlayerData(data.acct, data.pass);
            if (pd == null)
            {
                //存在密码错误
                msg.err = (int)ErrorCode.WrongPass;
            }
            else
            {
                msg.rspLogin = new RspLogin { playerData = pd };
            }
            //缓存账号数据
            cacheSvc.AcctOnline(data.acct, pack.session, pd);
        }
        //回应客户端
        pack.session.SendMsg(msg);
    }

    /// <summary>
    /// 重命名
    /// </summary>
    public void ReqRename(MsgPack pack)
    {

    }
}
