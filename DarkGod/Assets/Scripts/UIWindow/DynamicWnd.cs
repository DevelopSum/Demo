/****************************************************
    文件：DynamicWnd.cs
	作者：Maven
    邮箱: maven_luo@outlook.com
    日期：2020/1/13 11:15:6
	功能：动态UI元素界面
*****************************************************/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class DynamicWnd : WindowRoot
{
	/// <summary>
	/// 动态UI提示动画
	/// </summary>
	public Animation tipsAni;
	/// <summary>
	/// 动态UI显示字体
	/// </summary>
	public Text txtTips;

	/// <summary>
	/// 当前是否有提示文本正在播放
	/// </summary>
	private bool isTipsShow = false;
	/// <summary>
	/// 用于将提示文本存储
	/// </summary>
	private Queue<string> tipsQue = new Queue<string>();

	protected override void InitWnd()
	{
		base.InitWnd();

		SetActive(txtTips,false);
	}

	/// <summary>
	/// 将提示文本加入队列
	/// </summary>
	/// <param name="tips"> 提示文本 </param>
	public void AddTips(string tips)
	{
		lock (tipsQue)
		{
			tipsQue.Enqueue(tips);
		}
	}

	private void Update()
	{
		if (tipsQue.Count > 0 && isTipsShow == false)
		{
			lock (tipsQue)
			{
				string tips = tipsQue.Dequeue();
				isTipsShow = true;
				SetTips(tips);
			}
		}
	}

	/// <summary>
	/// 设置提示文本
	/// </summary>
	/// <param name="tips"></param>
	private void SetTips(string tips)
	{
		SetActive(txtTips);
		SetText(txtTips,tips);

		AnimationClip clip = tipsAni.GetClip("TipsShowAni");
		tipsAni.Play();
		
		//延时关闭激活状态
		StartCoroutine(AniPlayDone(clip.length, () => { SetActive(txtTips, false);
			isTipsShow = false;
		}));
	}

	/// <summary>
	/// 字体帧动画控制
	/// </summary>
	private IEnumerator AniPlayDone(float sec, Action cb)
	{
		yield return new WaitForSeconds(sec);
		if (cb != null)
		{
			cb();
		}
	}
}