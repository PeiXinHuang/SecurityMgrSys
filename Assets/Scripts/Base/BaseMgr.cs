using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���������࣬���ڹ�����������ݺ�UI����
/// </summary>
public class BaseMgr : MonoBehaviour
{

    // ʵ�ֵ���ģʽ�������ݿ�
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
    /// ����¼�����
    /// </summary>
    private void AddEventHander()
    {


        data.AddEventListener("updateContentEvent", UpdateContentPanel);
        data.AddEventListener("updateContentEvent", UpdateListBtnViewStyle);

        //�󶨰�ť�¼�
        view.businessControlBtn.onClick.AddListener(()=>OnClickListBtn(BaseData.ContentType.BusinessControl));
        view.selfInfoBtn.onClick.AddListener(() => OnClickListBtn(BaseData.ContentType.SelfInfo));
        view.userControlBtn.onClick.AddListener(() => OnClickListBtn(BaseData.ContentType.UserControl));
        view.infoControlBtn.onClick.AddListener(() => OnClickListBtn(BaseData.ContentType.InfoControl));
        view.toolControlBtn.onClick.AddListener(() => OnClickListBtn(BaseData.ContentType.ToolControl));
    }

    public void UpdateUserPanel()
    {

        view.UpdateUserPanel(GameManager.Instance.GetCurrentUser());
    }
    public void UpdateListPanel()
    {

        view.UpdateListPanel(GameManager.Instance.GetCurrentUser());
    }
    public void UpdateContentPanel()
    {
        view.UpdateContentPanel(data.GetCurrentSelectContent());  
    }
    public void UpdateListBtnViewStyle()
    {
        view.UpdateListViewStyle(data.GetCurrentSelectContent());
    }



    private void OnClickListBtn(BaseData.ContentType contentType)
    {
        
        data.SetCurrentSelectContent(contentType);
    }



}