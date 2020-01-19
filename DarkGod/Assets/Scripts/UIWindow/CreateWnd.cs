/****************************************************
    文件：CreateWnd.cs
	作者：Maven
    邮箱: maven_luo@outlook.com
    日期：2020/1/13 15:22:21
	功能：角色创建页面
*****************************************************/

using PEProtocol;
using UnityEngine;
using UnityEngine.UI;

public class CreateWnd : WindowRoot
{
	public InputField iptName;
	protected override void InitWnd()
	{
		base.InitWnd();
		
		//显示一个随机名字
		iptName.text = resSvc.GetRDNameData(false);
	}

	public void ClickRandBtn()
	{
		audioSvc.PlayUIAudio(Constants.UIClickBtn);
		
		string rdName = resSvc.GetRDNameData();
		iptName.text = rdName;
	}

	public void ClickEnterBtn()
	{
		if (iptName.text != "")
		{
			//发送名字到服务器，登录主城
			GameMsg msg = new GameMsg
			{
				cmd=(int)CMD.ReqRename,
				reqRename=new ReqRename
				{
					name=iptName.text
				}
			};
			netSvc.SendMsg(msg);
		}
		else
		{
			GameRoot.AddTips("当前名称不符合规范");
		}
	}
	
}