using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 基础管理类，用于管理基本的数据和UI界面，包括
/// 基础面板的显示
/// 基本的数据（当前登录的用户数据）
/// </summary>
public class BaseMgr : MonoBehaviour
{

    // 实现单例模式访问数据库
    private static BaseMgr instance;
    public static BaseMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (BaseMgr)FindObjectOfType(typeof(BaseMgr));
                if (instance == null)
                {
                    GameObject databaseMgrObj = new GameObject("BaseMgr");
                    instance = (BaseMgr)databaseMgrObj.AddComponent(typeof(BaseMgr));
                   
                }
                instance.InitBaseMgr();
            }
        
            return instance;
        }

    }


    private BaseView view;
    public BaseData data;
    public void InitBaseMgr()
    {

        view = (BaseView)FindObjectOfType(typeof(BaseView));
        data = new BaseData();

        AddEventHander();
    }



    /// <summary>
    /// 添加事件处理
    /// </summary>


    private void AddEventHander()
    {


        data.AddEventListener("updateContent", UpdateContentPanel);

        //绑定按钮事件
        view.businessControlBtn.onClick.AddListener(() => OnClickListBtn(BaseData.ContentType.BusinessControl));
        view.selfInfoBtn.onClick.AddListener(() => OnClickListBtn(BaseData.ContentType.SelfInfo));
        view.userControlBtn.onClick.AddListener(() => OnClickListBtn(BaseData.ContentType.UserControl));
        view.infoControlBtn.onClick.AddListener(() => OnClickListBtn(BaseData.ContentType.InfoControl));
    }

    public void UpdateUserPanel(User user)
    {
        
        view.UpdateUserPanel(user);
    }
    public void UpdateListPanel(User user)
    {
        view.UpdateListPanel(user);
    }
    public void UpdateContentPanel(BaseData.ContentType contentType)
    {
        view.UpdateContentPanel(contentType);
    }

    private void OnClickListBtn(BaseData.ContentType contentType)
    {
        data.SetCurrentSelectContent(contentType);
    }



}