/****************************************************
    文件：NetSvc.cs
	作者：Maven
    邮箱: maven_luo@outlook.com
    日期：2020/1/15 12:1:2
	功能：网络服务
*****************************************************/

using PENet;
using PEProtocol;
using UnityEngine;

public class NetSvc : MonoBehaviour 
{
	public static NetSvc Instance = null;

	PESocket<ClientSession, GameMsg> client = null;

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

        Debug.Log("Init NetSvc");
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

    private void Update()
    {
      
    }
}