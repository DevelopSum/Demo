﻿using PEProtocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// 缓存层
/// </summary>
public class CacheSvc
{
    private static CacheSvc instance = null;
    public static CacheSvc Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CacheSvc();
            }
            return instance;
        }
    }

    private DBMgr dbMgr;

    /// <summary>
    /// 账号缓存
    /// </summary>
    private Dictionary<string, ServerSession> onLineAcctDic = new Dictionary<string, ServerSession>();
    private Dictionary<ServerSession, PlayerData> onLineSessionDic = new Dictionary<ServerSession, PlayerData>();

    public void Init()
    {
        dbMgr = DBMgr.Instance;
        PECommon.Log("CacheSvc Init Done.");
    }

    
    /// <summary>
    /// /是否上线
    /// </summary>
    /// <param name="acct"></param>
    /// <returns></returns>
    public bool IsAcctOnLine(string acct) {
        return onLineAcctDic.ContainsKey(acct);
    }

    /// <summary>
    /// 根据账号密码返回对应账号数据，密码错误返回null,账号不存在则默认创建新账号
    /// </summary>
    public PlayerData GetPlayerData(string acct, string pass) {
        return dbMgr.QueryPlayerData(acct, pass);
    }

    /// <summary>
    /// 账号上线，缓存数据
    /// </summary>
    public void AcctOnline(string acct, ServerSession session, PlayerData playerData) {
        onLineAcctDic.Add(acct, session);
        onLineSessionDic.Add(session, playerData);
    }

    /// <summary>
    /// 名字是否存在
    /// </summary>
    public bool IsNameExist(string name)
    {
        return dbMgr.QueryNameData(name);
    }

    /// <summary>
    /// 获取playerdata数据
    /// </summary>
    public PlayerData GetPlayerDataBySession(ServerSession session)
    {
        if (onLineSessionDic.TryGetValue(session, out PlayerData playerdata))
        {
            return playerdata;
        }
        else
        {
            return null;
        }
    }
}