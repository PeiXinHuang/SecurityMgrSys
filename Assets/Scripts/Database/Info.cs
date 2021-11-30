using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 信息对象类
/// </summary>
public class Info : Object
{
    public string infoId; //信息编号
    public string sendId; //发送对象
    public string receiveId; //接收对象
    public string infoTitle; //信息标题
    public string infoContent; //信息内容

    public string GetSendName()
    {
        User user = UserDatabaseMgr.Instance.GetUserDataById(sendId);
        if (user.isEmptyUser())
            return "已注销";
        else
            return user.userName;
    }
    
    public string GetReceiveName()
    {
        User user = UserDatabaseMgr.Instance.GetUserDataById(receiveId);
        if (user.isEmptyUser())
            return "已注销";
        else
            return user.userName;
    }
}
