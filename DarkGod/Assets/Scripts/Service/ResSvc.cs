/****************************************************
    文件：ResSvc.cs
	作者：Maven
    邮箱: maven_luo@outlook.com
    日期：2020/1/10 10:36:14
	功能：资源加载服务
*****************************************************/

using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Xml;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class ResSvc : MonoBehaviour 
{
    public static ResSvc Instance = null;

    public void InitSvc() 
    {
        Instance = this;
        InitRDNameCfg();
        
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

    #region InitCfgs(读取xml)
    /// <summary>
    /// 存储姓 男人名字 女人名字    
    /// </summary>
    private List<string> surnameLst = new List<string>();
    private List<string> manLst = new List<string>();
    private List<string> womanLst = new List<string>();
    
    private void InitRDNameCfg() {
        TextAsset xml = Resources.Load<TextAsset>(PathDefine.RDNameCfg);
        if (!xml) {
            Debug.LogError("xml file:" + PathDefine.RDNameCfg + " not exist");
        }
        else {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml.text);

            XmlNodeList nodLst = doc.SelectSingleNode("root").ChildNodes;

            for (int i = 0; i < nodLst.Count; i++) {
                XmlElement ele = nodLst[i] as XmlElement;

                if (ele.GetAttributeNode("ID") == null) {
                    continue;
                }
                int ID = Convert.ToInt32(ele.GetAttributeNode("ID").InnerText);
                foreach (XmlElement e in nodLst[i].ChildNodes) {
                    switch (e.Name) {
                        case "surname":
                            surnameLst.Add(e.InnerText);
                            break;
                        case "man":
                            manLst.Add(e.InnerText);
                            break;
                        case "woman":
                            womanLst.Add(e.InnerText);
                            break;
                    }
                }

            }

        }

    }

    public string GetRDNameData(bool man = true)
    {
        Random rd = new Random();
        string rdName = surnameLst[PETools.RDInt(0, surnameLst.Count - 1)];

        if (man)
        {
            rdName += manLst[PETools.RDInt(0, manLst.Count - 1)];
        }
        else
        {
            rdName += womanLst[PETools.RDInt(0, womanLst.Count - 1)];
        }
        return rdName;     
    }
    #endregion
    
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