using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolControlMgr : MonoBehaviour
{
  public int nowIndex;

  #region 单例
  private static ToolControlMgr instance;
  public static ToolControlMgr Instance
  {
    get
    {
      if (instance == null)
      {
        instance = (ToolControlMgr)FindObjectOfType(typeof(ToolControlMgr));
        if (instance == null)
        {
          GameObject ToolControlMgrObj = new GameObject("ToolControlMgr");
          instance = (ToolControlMgr)ToolControlMgrObj.AddComponent(typeof(ToolControlMgr));

        }
        instance.InitToolControlMgr();
      }

      return instance;
    }

  }
  #endregion


  private ToolControlView view;
  public ToolControlData data;

  public void InitToolControlMgr()
  {
    view = (ToolControlView)FindObjectOfType(typeof(ToolControlView));
    data = new ToolControlData();

    AddEventHander();
  }



  /// <summary>
  /// 添加事件处理
  /// </summary>
  private void AddEventHander()
  {
    //获取数据库数据
    view.BtnOpenToolPage.onClick.AddListener(OpenToolPage);
    view.BtnTId.onClick.AddListener(delegate { ChangeToolPageData("tId", 1); });
    view.BtnTType.onClick.AddListener(delegate { ChangeToolPageData("tType", 2); });
    view.BtnTName.onClick.AddListener(delegate { ChangeToolPageData("tName", 3); });
    view.BtnTStatus.onClick.AddListener(delegate { ChangeToolPageData("tStatus", 4); });
    view.BtnBTime.onClick.AddListener(delegate { ChangeToolPageData("bDate", 5); });
    view.BtnRTime.onClick.AddListener(delegate { ChangeToolPageData("rDate", 6); });
    view.BtnUId.onClick.AddListener(delegate { ChangeToolPageData("uId", 7); });
    view.BtnUName.onClick.AddListener(delegate { ChangeToolPageData("uName", 8); });

    //借出等
    view.BtnBorrow.onClick.AddListener(BorrowTool);
    view.BtnReturn.onClick.AddListener(ReturnTool);
    view.BtnAdd.onClick.AddListener(OpenAddPanel);
    view.BtnLost.onClick.AddListener(LostTool);

    //添加工具相关
    view.AddConfirm.onClick.AddListener(AddTool);
    view.AddCancel.onClick.AddListener(CloseAddPanel);
  }

  // 打开工具页时调用
  void OpenToolPage()
  {
    CloseAddPanel();
    ChangeToolPageData("tId", 0); 
    string jobStr = GameManager.Instance.GetCurrentUser().JobToString(GameManager.Instance.GetCurrentUser().userJob);
    Debug.Log(jobStr);
    if (jobStr == "Member")
    {
      data.userJob = 0;
    }
    else if (jobStr == "Admin")
    {
      data.userJob = 1;
    }
    else
    {
      data.userJob = 2;
    }
    if (data.userJob == 0)
    {
      view.BtnAdd.gameObject.SetActive(false);
      view.BtnLost.gameObject.SetActive(false);
    }
  }


  // 改变面板数据
  void ChangeToolPageData(string type, int index)
  {
    data.type = type;
    data.ifAsc = true;
    // 第二次点击
    if (index == data.btnIndex && index != 0)
    {
      data.ifAsc = false;
      data.btnIndex = 0;
    }
    else
    {
      data.btnIndex = index;
    }
    RefreshPage();
  }

  void RefreshPage()
  {
    data.GetAllToolsData(data.type, data.ifAsc);
    view.ShowToolsData(data.tools, data.userJob);
  }


  // 获取选中项
  public void GetSelected(int tId)
  {
    data.lastSelectedToolId = data.selectedToolId;
    // 对比新旧id
    if (tId == data.lastSelectedToolId)
    {
      view.ChangeToolItem(tId, false);
      data.selectedToolId = 0;
      data.lastSelectedToolId = 0;
    }
    else
    {
      view.ChangeToolItem(data.lastSelectedToolId, false);
      view.ChangeToolItem(tId, true);
      data.selectedToolId = tId;
    }
    // nowIndex = data.selectedToolId;
  }

  // 借出工具
  void BorrowTool()
  {
    if (data.selectedToolId != 0)
    {
      // 查询工具是否已被借出
      if (ToolsDatabaseMgr.Instance.CheckToolStatus(data.selectedToolId) == 0)
      {
        ToolsDatabaseMgr.Instance.BorrowTool(
          GameManager.Instance.GetCurrentUser().userId,
          GameManager.Instance.GetCurrentUser().userName,
          data.selectedToolId
        );
      }
      RefreshPage();
    }
  }

  // 归还工具
  void ReturnTool()
  {
    if (data.selectedToolId != 0)
    {
      if (ToolsDatabaseMgr.Instance.CheckToolStatus(data.selectedToolId) == 1)
      {
        ToolsDatabaseMgr.Instance.ReturnTool(data.selectedToolId);
      }
      RefreshPage();
    }
  }

  // 打开添加工具面板
  void OpenAddPanel()
  {
    view.SetAddPanel(true);
  }
  void CloseAddPanel()
  {
    view.SetAddPanel(false);
  }

  void AddTool()
  {
    if (!string.IsNullOrEmpty(view.AddTName.text) && !string.IsNullOrEmpty(view.AddTType.text))
    {
      ToolsDatabaseMgr.Instance.AddTool(view.AddTName.text, view.AddTType.text);
      RefreshPage();
    }
  }

  void LostTool()
  {
    if (data.selectedToolId != 0)
    {
      ToolsDatabaseMgr.Instance.LostTool(data.selectedToolId);
    }
    RefreshPage();
  }
}