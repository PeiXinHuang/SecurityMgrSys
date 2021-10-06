using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ������Ϣ������
/// </summary>
public class SelfInfoMgr : MonoBehaviour
{
    // ʵ�ֵ���ģʽ�������ݿ�
    private static SelfInfoMgr instance;
    public static SelfInfoMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (SelfInfoMgr)FindObjectOfType(typeof(SelfInfoMgr));
                if (instance == null)
                {
                    GameObject databaseMgrObj = new GameObject("SelfInfoMgr");
                    instance = (SelfInfoMgr)databaseMgrObj.AddComponent(typeof(SelfInfoMgr));

                }
                instance.InitSelfInfoMgr();
            }

            return instance;
        }

    }


    private SelfInfoView view;
    public SelfInfoData data;
    public void InitSelfInfoMgr()
    {

        view = (SelfInfoView)FindObjectOfType(typeof(SelfInfoView));
        data = new SelfInfoData();

        AddEventHander();
    }



    /// <summary>
    /// ����¼�����
    /// </summary>
    private void AddEventHander()
    {

        //�󶨰�ť�¼�
        view.loginBtn.onClick.AddListener(OnClickLogin);
        view.logoutBtn.onClick.AddListener(OnClickLogout);
        view.modifyBtn.onClick.AddListener(OnClickModify);

        //�û���¼��ע����ʱ��ˢ�»��������û�����ѡ���б�  
        data.AddEventListener("updateUserEvent", BaseMgr.Instance.UpdateListPanel);
        data.AddEventListener("updateUserEvent", BaseMgr.Instance.UpdateUserPanel);  

        //ˢ�¸�����Ϣ���
        data.AddEventListener("updateUserEvent", view.UpdateSelfInfoContent);
        data.AddEventListener("updateUserEvent", view.UpdateUserPanel);


    }


    private void OnClickLogin()
    {
        data.Login(view.idInput.text, view.passwordInput.text);
    }

    private void OnClickLogout()
    {
        data.Logout();
    }

    private void OnClickModify()
    {
        data.Modify(view.userNameModifyInput.text,view.passwordModifyInput.text,view.phoneModifyInput.text);
    }
}
