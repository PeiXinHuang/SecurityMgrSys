using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InfoControlData : Object
{

    private event UnityAction SendInfoEvent;
    private event UnityAction UpdateCanReceiveUsers;

    public void AddEventListener(string eventName, UnityAction function)
    {
        if (eventName == "sendInfoEvent")
            SendInfoEvent += function;
        else if (eventName == "updateCanSendUsers")
            UpdateCanReceiveUsers += function;
        else
            Debug.LogWarning("Event: " + eventName + " is not exit");
    }
    public void RemoveEventListener(string eventName, UnityAction function)
    {
        if (eventName == "sendInfoEvent")
            SendInfoEvent -= function;
        else if (eventName == "updateCanSendUsers")
            UpdateCanReceiveUsers -= function;
        else
            Debug.LogWarning("Event: " + eventName + " is not exit");
    }


    #region ������Ϣ���
    //�����û�
    public Dictionary<string, string> receiveUserDir = new Dictionary<string, string>();

    public void SendInfo(string sendTitle, string sendContent)
    {
        if (string.IsNullOrEmpty(sendTitle))
        {
            MessageBoxMgr.Instance.ShowWarnning("��Ϣ���ⲻ��Ϊ��");
            return;
        }

        if (string.IsNullOrEmpty(sendContent))
        {
            MessageBoxMgr.Instance.ShowWarnning("��Ϣ���ݲ���Ϊ��");
            return;
        }

      
        if (receiveIds.Count == 0)
        {
            MessageBoxMgr.Instance.ShowWarnning("�ռ��˲���Ϊ��");
            return;
        }

       

        InfoDatabaseMgr.Instance.CreateNewInfos(GameManager.Instance.GetCurrentUser().userId,
            receiveIds, sendTitle, sendContent);

        if (SendInfoEvent != null)
            SendInfoEvent();

        MessageBoxMgr.Instance.ShowInfo("������Ϣ�ɹ�");
    }

    

    public void UpdateAllCanReceiveUsers()
    {
        receiveUserDir.Clear();
        List<User> users = UserDatabaseMgr.Instance.GetUsersData(new User());
        foreach (User user in users)
        {
            if(user.userId != GameManager.Instance.GetCurrentUser().userId) //���ܷ�����Ϣ���Լ�
                receiveUserDir.Add(user.userId, user.userName);
        }

        if (UpdateCanReceiveUsers != null)
            UpdateCanReceiveUsers();
    }


   


    List<string> receiveIds = new List<string>();
    public void ClearReceiveIds()
    {
        receiveIds.Clear();
    }
    public void UpdateReceiveIds(string receiveId)
    {
   
        if (receiveId == "None")
        {
            receiveIds.Clear();
        }
        else if (receiveId == "All")
        {
            receiveIds.Clear();
            foreach (string item in receiveUserDir.Keys)
            {
                receiveIds.Add(item);
            }
        }
        else
        {
        
            bool canGet = receiveUserDir.ContainsKey(receiveId);
            if (canGet)
            {
                if (!receiveIds.Contains(receiveId))
                    receiveIds.Add(receiveId);
            }
            else
            {
                Debug.LogError("�Ҳ��������û���" + receiveId);
            }
        }

        string receiveStr = "";
        foreach (string item in receiveIds)
        {
            receiveStr += string.Format("{0}({1}) / ", item, receiveUserDir[item]);
        }


        InfoControlMgr.Instance.UpdateViewSendInput(receiveStr);
    }
    #endregion
}
