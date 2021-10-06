using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 安检业务类
/// </summary>
public class Business : Object
{
    public string adminUserId; //负责的安检管理员Id
    public List<string> memberUsersId; //参与的安检员Id
    public List<string> tools; //安检需要工具


}
