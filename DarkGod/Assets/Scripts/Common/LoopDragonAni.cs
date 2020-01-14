/****************************************************
    文件：LoopDragonAni.cs
	作者：Maven
    邮箱: maven_luo@outlook.com
    日期：2020/1/13 11:5:26
	功能：飞龙循环动画
*****************************************************/

using System;
using UnityEngine;

public class LoopDragonAni : MonoBehaviour
{
	private Animation ani;

	private void Awake()
	{
		ani = transform.GetComponent<Animation>();
	}

	private void Start()
	{
		if (ani)
		{
			InvokeRepeating("PlayDragonAni",0,20);
		}
	}

	private void PlayDragonAni()
	{
		if (ani)
		{
			ani.Play();
		}
	}
}