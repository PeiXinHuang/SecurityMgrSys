using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ToolControlView : MonoBehaviour
{
  [Header("打开工具的按钮")]
  public Button BtnOpenToolPage;

  [Header("表与表组件")]
  public GameObject table;
  public GameObject toolTableItem;

  [Header("种类查询相关")]

  public Button BtnTId;
  public Button BtnTName;
  public Button BtnTType;
  public Button BtnTStatus;
  public Button BtnBTime;
  public Button BtnRTime;
  public Button BtnUName;
  public Button BtnUId;

  [Header("新增，借出，归还，报失")]

  public Button BtnAdd;
  public Button BtnBorrow;
  public Button BtnReturn;
  public Button BtnLost;

  [Header("新增相关")]

  public GameObject AddPanel;
  public Button AddConfirm;
  public Button AddCancel;

  public Text AddTName;
  public Text AddTType;



  public void ShowToolsData(List<Tool> Tools,int userJob)
  { // 去掉旧数据
    for (int i = 1; i < table.transform.childCount; i++)
    {
      Destroy(table.transform.GetChild(i).gameObject);
    }


    // 展示新数据
    for (int i = 0; i < Tools.Count; i++)
    {
      Tool newTool = Tools[i];
      GameObject item = GameObject.Instantiate(toolTableItem, table.transform.position, table.transform.rotation) as GameObject;
      item.name = newTool.tId + "";
      item.transform.SetParent(table.transform);
      item.transform.localScale = Vector3.one;
      //设置预设实例中的各个子物体的文本内容
      string[] strArr = new string[8];
      strArr[0] = newTool.tId + "";
      strArr[1] = newTool.tName;
      strArr[2] = newTool.tType;
      if (newTool.tStatus == 0)
      {
        strArr[3] = "未借出";
      }
      else if (newTool.tStatus == 1)
      {
        strArr[3] = "已借出";
      }
      else
      {
        strArr[3] = "丢失";
      }
      strArr[4] = newTool.bDate;
      strArr[5] = newTool.rDate;
      if(userJob>0){

        string str = "";
        if (!string.IsNullOrEmpty(newTool.uId))
        {
            for (int k = 0; k < 5 - newTool.uId.Length; k++)
            {
                str += "0";
            }
        }
        str += newTool.uId;
        strArr[6] = str;
        strArr[7] = newTool.uName;
      }
      item.GetComponent<ChangeInfo>().ChangeText(strArr);
    }
  }


  // 改变工具的选中状态
  public void ChangeToolItem(int id, bool ifSelect)
  {
    for (int i = 1; i < table.transform.childCount; i++)
    {
      if (table.transform.GetChild(i).name == (id + ""))
      {
        table.transform.GetChild(i).GetComponent<ChangeInfo>().Selected(ifSelect);
      }
    }
  }

  // 改变添加面板状态
  public void SetAddPanel(bool ifActive){
    AddPanel.gameObject.SetActive(ifActive);
  }

  
}

