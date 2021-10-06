using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���������࣬���ڹ�����������ݺ�UI���棬����
/// ����������ʾ
/// ���������ݣ���ǰ��¼���û����ݣ�
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


        data.AddEventListener("updateContent", UpdateContentPanel);

        //�󶨰�ť�¼�
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