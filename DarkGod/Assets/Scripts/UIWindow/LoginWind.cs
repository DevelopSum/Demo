/****************************************************
    文件：LoginWind.cs
	作者：Maven
    邮箱: maven_luo@outlook.com
    日期：2020/1/10 12:28:47
	功能：登陆注册界面
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class LoginWind : MonoBehaviour 
{
    public InputField iptAcct;
    public InputField iptPass;
    public Button btnEnter;
    public Button btnNotice;
    public void InitWnd()
    { 
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
    //TODO更新本地存储的账号密码
}