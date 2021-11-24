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
        view.saveBtn.onClick.AddListener(OnClickSave);


        //ˢ�¸�����Ϣ���
        data.AddEventListener("updateUserEvent", SelfInfoMgr.Instance.UpdateContent);


    }

    private void OnClickSave()
    {
        //data.Modify(view.userNameModifyInput.text,view.passwordModifyInput.text,view.phoneModifyInput.text);
    }


    public void UpdateContent()
    {
        view.UpdateContent(GameManager.Instance.GetCurrentUser());
    }
}
