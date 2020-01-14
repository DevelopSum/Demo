/****************************************************
    文件：AudioSvc.cs
	作者：Maven
    邮箱: maven_luo@outlook.com
    日期：2020/1/10 17:17:17
	功能：声音播放服务
*****************************************************/

using UnityEngine;

public class AudioSvc : MonoBehaviour
{
	public static AudioSvc Instance = null;

	/// <summary>
	/// 背景音效
	/// </summary>
	public AudioSource bgAudio;
	/// <summary>
	/// UI音效
	/// </summary>
	public AudioSource uiAudio;

	public void InitSvc()
	{
		Instance = this;
		Debug.Log("Init AudioSvc");
	}

	/// <summary>
	/// 背景音乐
	/// </summary>
	/// <param name="name">音乐名称</param>
	/// <param name="isLoop">是否循环</param>
	public void PlayBGMusic(string name, bool isLoop = true)
	{
		AudioClip audio =ResSvc.Instance.LoadAudio("ResAudio/" + name,true);
		if (bgAudio.clip == null || bgAudio.clip.name != audio.name)
		{
			bgAudio.clip = audio;
			bgAudio.loop = isLoop;
			bgAudio.Play();
		}
	}

	public void PlayUIAudio(string name)
	{
		AudioClip audio = ResSvc.Instance.LoadAudio("ResAudio/" + name, true);
		{
			uiAudio.clip = audio;
			uiAudio.Play();
		}
	}
}