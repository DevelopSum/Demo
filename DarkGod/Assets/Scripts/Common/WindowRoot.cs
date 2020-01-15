/****************************************************
    文件：WindowRoot.cs
	作者：Maven
    邮箱: maven_luo@outlook.com
    日期：#CreateTime#
	功能：UI界面基类
*****************************************************/

using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class WindowRoot : MonoBehaviour 
{
    protected ResSvc resSvc = null;
    protected AudioSvc audioSvc = null;
    protected NetSvc netSvc = null;
    
    /// <summary>
    /// 窗口是否激活
    /// </summary>
    public void SetWndState(bool isActive = true) 
    {
        if (gameObject.activeInHierarchy != isActive)
        {
            SetActive(gameObject,isActive);
        }
        if (isActive)
        {
            InitWnd();
        }
        else
        {
            ClearWnd();
        }
    }


    protected virtual void InitWnd()
    {
        resSvc = ResSvc.Instance;
        audioSvc = AudioSvc.Instance;
        netSvc = NetSvc.Instance;
    }

    protected virtual void ClearWnd()
    {
        resSvc = null;
        audioSvc = null;
        netSvc = null;   
    }

    #region Tool Functtions

    /// <summary>
    /// 对物体的激活
    /// </summary>
    /// <param name="go">物体</param>
    /// <param name="isActive">默认激活状态</param>
    protected void SetActive(GameObject go,bool isActive = true)
    {
        go.SetActive(isActive);   
    }

    protected void SetActive(Transform trans, bool state = true)
    {
        trans.gameObject.SetActive(state);
    }

    protected void SetActive(RectTransform rectTrans, bool state = true)
    {
        rectTrans.gameObject.SetActive(state);
    }

    protected void SetActive(Image img, bool state = true)
    {
        img.transform.gameObject.SetActive(state);
    }

    protected void SetActive(Text txt, bool state = true)
    {
        txt.transform.gameObject.SetActive(state);
    } 

    /// <summary>
        /// 设置文字显示
        /// </summary>
        /// <param name="text">文字组件</param>
        /// <param name="context">需要显示的内容</param>
        protected void SetText(Text txt, string context = "")
        {
            txt.text = context;
        }
    
        protected void SetText(Transform trans, int num = 0)
        {
            SetText(trans.GetComponent<Text>(), num);
        }
    
        protected void SetText(Transform trans, string context = "")
        {
            SetText(trans.GetComponent<Text>(), context);
        }
    
        protected void SetText(Text txt, int num = 0)
        {
            SetText(txt, num.ToString());
        } 

    #endregion
}