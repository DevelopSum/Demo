/****************************************************
    文件：LoginSys.cs
	作者：Maven
    邮箱: maven_luo@outlook.com
    日期：2020/1/10 10:35:41
	功能：登录注册业务系统
*****************************************************/

using UnityEngine;

public class LoginSys : SystemRoot
{
    public static LoginSys Instance = null;

    public LoginWind loginWnd;
    public CreateWnd createWnd;

    public override void InitSys()
    {
        base.InitSys();
        Instance = this;
        Debug.Log("Init LoginSys ...");
    }

    /// <summary>
    /// 进入登陆场景
    /// </summary>
    public void EnterLogin()
    {
        //异步加载登陆场景
        //显示加载进度
        resSvc.AsyncLoadScene(Constants.SceneLogin, () => {
            //打开LoginWndPanel            //加载完成后在打开注册登陆界面
            loginWnd.SetWndState();
            audioSvc.PlayBGMusic(Constants.BGLogin);
        });
    }

    /// <summary>
    /// 模拟接受网络请求，登录成功
    /// </summary>
    public void RspLogin() {
        GameRoot.AddTips("登录成功");

        //打开角色创建界面
        createWnd.SetWndState();
        //关闭登录界面
        loginWnd.SetWndState(false);
    }
    
}