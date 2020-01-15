/****************************************************
    文件：SystemRoot.cs
	作者：Maven
    邮箱: maven_luo@outlook.com
    日期：2020/1/13 10:39:9
	功能：业务系统基类
*****************************************************/

using UnityEngine;

public class SystemRoot : MonoBehaviour
{
	protected ResSvc resSvc;
	protected AudioSvc audioSvc;
	protected NetSvc netSvc;

	public virtual void InitSys()
	{
		Debug.Log("Init SystemRoot...");
		resSvc = ResSvc.Instance;
		audioSvc = AudioSvc.Instance;
		netSvc = NetSvc.Instance;
	}
}