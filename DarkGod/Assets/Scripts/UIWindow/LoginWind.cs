/****************************************************
    文件：LoginWind.cs
	作者：Maven
    邮箱: maven_luo@outlook.com
    日期：2020/1/10 12:28:47
	功能：登陆注册界面
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class LoginWind : WindowRoot
{
    public InputField iptAcct;
    public InputField iptPass;
    public Button btnEnter;
    public Button btnNotice;
    protected override void InitWnd()
    {
        base.InitWnd();
        Debug.Log("Init InitWnd...");
        //获取本地存储的账号密码
        if (PlayerPrefs.HasKey("Acct") && PlayerPrefs.HasKey("Pass"))
        {
            iptAcct.text = PlayerPrefs.GetString("Acct");
            iptPass.text = PlayerPrefs.GetString("Pass");
        }
        else
        {
            iptAcct.text = "";
            iptPass.text = "";
        }
    }

    /// <summary>
    /// 点击进入游戏
    /// </summary>
    public void ClickEnterBtn()
    {
        audioSvc.PlayUIAudio(Constants.UILoginBtn);

        string acct = iptAcct.text;
        string pass = iptPass.text;
        if (acct != "" && pass != "")
        {
            //更新本地存储的账号密码
            PlayerPrefs.SetString("Acct",acct);            
            PlayerPrefs.SetString("Pass",pass);            
        
            //TODO 发送网络消息，请求登陆
            
            //TO Remove
            LoginSys.Instance.RspLogin();
        }
        else
        {
            GameRoot.AddTips("账号密码为空");
        }
    }

    public void ClickNoticeBtn()
    {
        audioSvc.PlayUIAudio(Constants.UIClickBtn);
        
        GameRoot.AddTips("功能正在开发中....");
    }
}