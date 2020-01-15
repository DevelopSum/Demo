/****************************************************
    文件：GameStart.cs
	作者：Maven
    邮箱: maven_luo@outlook.com
    日期：#CreateTime#
	功能：Nothing
*****************************************************/

using Assets.Scripts;
using Protocal;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    PENet.PESocket<ClientSeesion, NetMsg> client = null;
    private void Start()
    {
        //启动客户端
        client = new PENet.PESocket<ClientSeesion, NetMsg>();
        client.StartAsClient(IPCfg.srvIP, IPCfg.srvPort);

        client.SetLog(true, (string msg, int lv) =>
        {
            switch (lv)
            {
                case 0 :
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
    }

    private void Update()
    {
        //发送消息
        if (Input.GetKeyDown(KeyCode.Space))
        {
            client.session.SendMsg(new NetMsg
            {
                text = "hello"
            });
        }
    }
}