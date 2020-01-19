/****************************************************
    文件：NetSvc.cs
	作者：Maven
    邮箱: maven_luo@outlook.com
    日期：2020/1/15 12:1:2
	功能：网络服务
*****************************************************/

using PENet;
using PEProtocol;
using System.Collections.Generic;
using UnityEngine;

public class NetSvc : MonoBehaviour 
{
	public static NetSvc Instance = null;

    private static readonly string obj = "lock";
	PESocket<ClientSession, GameMsg> client = null;
    private Queue<GameMsg> msgQue = new Queue<GameMsg>();
	public void InitSvc()
	{
		Instance = this;

        client = new PESocket<ClientSession, GameMsg>();
        client.SetLog(true, (string msg, int lv) =>
        {
            switch (lv)
            {
                case 0:
                    msg = "log" + msg;
                    Debug.Log(msg);
                    break;
                case 1:
                    msg = "war" + msg;
                    Debug.LogWarning(msg);
                    break;
                case 2:
                    msg = "err" + msg;
                    Debug.LogError(msg);
                    break;
                case 3:
                    msg = "info" + msg;
                    Debug.Log(msg);
                    break;
            }
        });
        client.StartAsClient(SrvCfg.srvIP, SrvCfg.srvPort);
        PECommon.Log("Init NetSvc...");
    }

    /// <summary>
    /// 发送消息
    /// </summary>
    /// <param name="msg"> 消息 </param>
    public void SendMsg(GameMsg msg) {
        if (client.session != null)
        {
            client.session.SendMsg(msg);
        }
        else
        {
            GameRoot.AddTips("服务器未连接");
            InitSvc();
        }
    }

    public void AddNetPkg(GameMsg msg)
    {
        lock (obj)
        {
            msgQue.Enqueue(msg);
        }
    }

    private void Update()
    {
        if (msgQue.Count > 0)
        {
            lock (obj)
            {
                GameMsg msg = msgQue.Dequeue();
                ProcessMsg(msg);
            }
        }
    }

    private void ProcessMsg(GameMsg msg)
    {
        if (msg.err != (int)ErrorCode.Node)
        {
            switch ((ErrorCode)msg.err)
            {
                //case ErrorCode.Node:
                //    break;
                case ErrorCode.AcctisOnline:
                    GameRoot.AddTips("当前账号已上线");
                    break;
                case ErrorCode.WrongPass:
                    GameRoot.AddTips("密码错误");
                    break;
            }
            return;
        }
        switch ((CMD)msg.cmd)
        {
            //case CMD.None:
            //    break;
            //case CMD.ReqLogin:
            //    break;
            case CMD.RspLogin:
                LoginSys.Instance.RspLogin(msg);
                break;
        }
    }
}