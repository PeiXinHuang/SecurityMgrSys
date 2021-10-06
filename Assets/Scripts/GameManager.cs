using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///  ��Ϸ������
/// </summary>
public class GameManager : MonoBehaviour
{
    
    void Start()
    {
        InitGame();
    }

    /// <summary>
    /// ��ʼ����Ϸ
    /// </summary>
    private void InitGame()
    {

        //������������
        BaseMgr baseMgr = BaseMgr.Instance; //��������������
        SelfInfoMgr selfInfoMgr = SelfInfoMgr.Instance; //������Ϣ����������

        //ˢ�»������
        BaseMgr.Instance.UpdateListPanel(SelfInfoMgr.Instance.data.GetCurrentUser());
        BaseMgr.Instance.UpdateUserPanel(SelfInfoMgr.Instance.data.GetCurrentUser());
        BaseMgr.Instance.UpdateContentPanel(BaseMgr.Instance.data.GetCurrentSelectContent());
    }


    //���Դ���
    private void TextCode()
    {
        //User user = new User();
        //user.InitUser("000001", "�û�A", "********", UserType.Member);

        //User user = new User();
        //user.InitUser("00002", "����", User.UserJob.Admin, "��", "12312212123", "888888");
        //UserDatabaseMgr.Instance.InsertUserData(user);
    }
}
