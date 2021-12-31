using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
/// <summary>
/// 信息对象类
/// </summary>
[Serializable]
public class Tool
{
    public int tId; //工具编号
    public string tName; //工具名称
    public string tType; //工具类型
    public int tStatus; //工具状况
    public string uName; //借出人名字
    public string uId; //借出人id
    public string bDate; //借出时间
    public string rDate; //归还时间
}
