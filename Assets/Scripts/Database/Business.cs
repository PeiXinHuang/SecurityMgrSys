using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 安检业务类
/// </summary>
public class Business : Object
{
    public enum State
    {
        Doing, //正在进行
        Check, //审批中
        Back, //驳回
        Finish //完成
    }

    public string id; //安检业务编号
    public string adminUserId; //负责的安检管理员Id
    public string memberUserId; //参与的安检员Id
    public string tools; //安检需要工具
    public string title; //业务标题
    public string content; //安检内容
    public string pdfName; //提交的PDF
    public State state; //当前状态

}
