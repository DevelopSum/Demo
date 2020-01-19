/****************************************************
    文件：PETools.cs
	作者：Maven
    邮箱: maven_luo@outlook.com
    日期：2020/1/13 18:17:3
	功能：工具类
*****************************************************/


public class PETools 
{
    public static int RDInt(int min, int max, System.Random rd = null)
    {
        if (rd == null)
        {
            rd = new System.Random();
        }
        int val = rd.Next(min, max + 1);
        return val;
    }
}