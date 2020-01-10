/****************************************************
    文件：LoadingWind.cs
	作者：Maven
    邮箱: maven_luo@outlook.com
    日期：2020/1/10 11:45:57
	功能：加载进度界面
*****************************************************/

using UnityEngine;
using UnityEngine.UI;

public class LoadingWind : MonoBehaviour 
{
    /// <summary>
    /// 提示文本
    /// </summary>
    public Text txtTips;

    /// <summary>
    /// 进度条前景
    /// </summary>
    public Image imgFG;

    /// <summary>
    /// 字体上特效
    /// </summary>
    public Image imgPoint;

    /// <summary>
    /// 进度文本
    /// </summary>
    public Text txtPrg;

    /// <summary>
    /// 进度条加载进度
    /// </summary>
    private float fgWidth;

    /// <summary>
    /// 初始化窗口
    /// </summary>
    public void InitWnd() 
    {
        fgWidth = imgFG.GetComponent<RectTransform>().sizeDelta.x;

        txtTips.text = "这是一条游戏Tips";
        txtPrg.text = "0%";
        imgFG.fillAmount = 0;imgPoint.transform.localPosition = new Vector3(-545f, 0, 0);
    }

    public void SetProgress(float prg)
    {
        txtPrg.text = (int)(prg * 100) + "%";
        imgFG.fillAmount = prg;

        float posX = prg * fgWidth - 545;
        imgPoint.GetComponent<RectTransform>().anchoredPosition = new Vector2(posX, 0);
    }
}