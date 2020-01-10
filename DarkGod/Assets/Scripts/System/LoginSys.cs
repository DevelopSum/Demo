/****************************************************
    文件：LoginSys.cs
	作者：Maven
    邮箱: maven_luo@outlook.com
    日期：2020/1/10 10:35:41
	功能：登录注册业务系统
*****************************************************/

using UnityEngine;

public class LoginSys : MonoBehaviour 
{
    public void InitSys()
    {
        Debug.Log("Init LoginSys ...");
    }

    /// <summary>
    /// 进入登陆场景
    /// </summary>
    public void EnterLogin() 
    {
        GameRoot.Instance.loadingWind.gameObject.SetActive(true);
        GameRoot.Instance.loadingWind.InitWnd();
        //TODO
        //异步加载登陆场景
        ResSvc.Instance.AsyncLoadScene(Constants.SceneLogin);

        //显示加载进度
        //加载完成后在打开注册登陆界面
    }
}