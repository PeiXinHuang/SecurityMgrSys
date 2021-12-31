using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ToolControlData : Object
{

  public List<Tool> tools;

  public int btnIndex = 0;//当前按钮序号
  public int selectedToolId = 0;// 选中的工具id
  public int selectedToolStatus = 0;// 选中工具的状态
  public int lastSelectedToolId = 0;// 上一个被选中的工具id
  public bool ifAsc = true;// 当前数据排列数据
  public string type = "tId";// 数据按那种类型排列

  public int userJob = 0;// 用户的工种 0为安检员 1为安检管理员 2为系统管理员


  // 获取所有工具数据
  public void GetAllToolsData(string type,bool order)
  {
    tools = ToolsDatabaseMgr.Instance.GetToolData(type,order);
  }
}