/****************************************************
    文件：WindowRoot.cs
	作者：Maven
    邮箱: maven_luo@outlook.com
    日期：#CreateTime#
	功能：UI界面基类
*****************************************************/

using UnityEngine;

public class WindowRoot : MonoBehaviour 
{
    /// <summary>
    /// 窗口是否激活
    /// </summary>
    public void SetWndState(bool isActive = true) 
    {
        if (gameObject.activeInHierarchy != isActive)
        {
            gameObject.SetActive(isActive);
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
        
    }

    protected virtual void ClearWnd()
    {
    }
}