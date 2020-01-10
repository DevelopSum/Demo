/****************************************************
    文件：ResSvc.cs
	作者：Maven
    邮箱: maven_luo@outlook.com
    日期：2020/1/10 10:36:14
	功能：资源加载服务
*****************************************************/

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResSvc : MonoBehaviour 
{
    public static ResSvc Instance = null;

    public void InitSvc() 
    {
        Instance = this;
        Debug.Log("Init ResSvc...");
    }

    /// <summary>
    /// 更新回调
    /// </summary>
    private Action prgCB = null;

    public void AsyncLoadScene(string sceneName,Action loaded) 
    {
        GameRoot.Instance.loadingWind.SetWndState();

        AsyncOperation sceneAsync =  SceneManager.LoadSceneAsync(sceneName);
        prgCB = () =>
        {
            float val = sceneAsync.progress;
            GameRoot.Instance.loadingWind.SetProgress(val);
            if (val == 1)
            {
                if (loaded != null)
                {
                    loaded();
                }
                prgCB = null;
                sceneAsync = null;
                GameRoot.Instance.loadingWind.SetWndState(false);
            }
        };
    }    

    private void Update()
    {
        if (prgCB != null)
        {
            prgCB();
        }
    }

    /// <summary>
    /// 用来存储声音
    /// </summary>
    private Dictionary<string, AudioClip> adDic = new Dictionary<string, AudioClip>();
    
    public AudioClip LoadAudio(string path, bool cache = false)
    {
        AudioClip au = null;
        if (!adDic.TryGetValue(path,out au))
        {
            au = Resources.Load<AudioClip>(path);
            if (cache)
            {
                adDic.Add(path,au);
            }
        }
        return au;
    }
}