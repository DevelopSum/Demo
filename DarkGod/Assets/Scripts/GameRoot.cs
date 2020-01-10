/****************************************************
    文件：GameRoot.cs
	作者：Maven
    邮箱: maven_luo@outlook.com
    日期：2020/1/10 10:22:28
	功能：游戏启动入口
*****************************************************/

using UnityEngine;

public class GameRoot : MonoBehaviour 
{
    public static GameRoot Instance = null;

    public LoadingWind loadingWind;

    private void Start()
    {
        DontDestroyOnLoad(this);
        Instance = this;
        Debug.Log("Game Start...");
        Init();
    }

    private void Init()
    {
        //服务模块初始化
        ResSvc res = GetComponent<ResSvc>();
        res.InitSvc();
        AudioSvc audio = GetComponent<AudioSvc>();
        audio.InitSvc();

        //业务系统
        LoginSys login = GetComponent<LoginSys>();
        login.InitSys();

        //进入登陆场景并加载相应UI
        login.EnterLogin();
    }
}