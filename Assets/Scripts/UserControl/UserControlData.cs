using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UserControlData : Object
{
    private UnityAction SearchUsersEvent;
    private UnityAction AddUserEvent;
    public void AddEventListener(string eventName, UnityAction function)
    {
        if (eventName == "SearchUsersEvent")
            SearchUsersEvent += function;
        else
            Debug.LogWarning("Event: " + eventName + " is not exit");
    }
    public void RemoveEventListener(string eventName, UnityAction function)
    {
        if (eventName == "SearchUsersEvent")
            SearchUsersEvent -= function;
        else
            Debug.LogWarning("Event: " + eventName + " is not exit");
    }
    #region �����û����

    private string searchUserName = "";
    private string searchId = "";
    private string searchSex = "";
    private User.UserJob searchJob = User.UserJob.None;

    public void SetSearchUserName(string name)
    {
        this.searchUserName = name;
    }
    public void SetSearchId(string id)
    {
        this.searchId = id;
    }
    public void SetSearchSex(int sex)
    {

        switch (sex)
        {
            case 0: this.searchSex = ""; break;
            case 1: this.searchSex = "��"; break;
            case 2: this.searchSex = "Ů"; break;
        }
    }
    public void SetSearchJob(int job)
    {
       
        switch (job)
        {
            case 0: this.searchJob = User.UserJob.None;break;
            case 1: this.searchJob = User.UserJob.Member;break;
            case 2: this.searchJob = User.UserJob.Admin;break;
            case 3: this.searchJob = User.UserJob.SysAdmin;break;
        }
    }


    private List<User> users = new List<User>();

    public List<User> GetUsers()
    {
        return users;
    }

    

    public void Search()
    {
        users.Clear();
        User conditionUser = new User();
        conditionUser.userId = this.searchId;
        conditionUser.userName = this.searchUserName;
        conditionUser.sex = this.searchSex;
        conditionUser.userJob = this.searchJob;

        users = UserDatabaseMgr.Instance.GetUsersData(conditionUser);

        if (SearchUsersEvent != null)
            SearchUsersEvent();
    }
    #endregion

    #region ����û����
    public void AddUser(string userId, string userName,string phone,string password, int sexId,int jobId)
    {

        if (string.IsNullOrEmpty(userId))
        {
            Debug.Log("���������û��˺�");
            return;
        }

        if (string.IsNullOrEmpty(userName))
        {
            Debug.Log("���������û�����");
            return;
        }

        if (string.IsNullOrEmpty(password))
        {
            Debug.Log("���������û�����");
        }

        User addUser = new User();
        addUser.userId = userId;
        addUser.userName = userName;
        addUser.phone = phone;
        addUser.password = password;
        switch (sexId)
        {
            case 0: addUser.sex = "��";break;
            case 1: addUser.sex = "Ů";break;
        }
        switch (jobId)
        {
            case 0: addUser.userJob = User.UserJob.Member; break;
            case 1: addUser.userJob = User.UserJob.Admin; break;
            case 2: addUser.userJob = User.UserJob.SysAdmin; break;
          
        }

        UserDatabaseMgr.Instance.InsertUserData(addUser);
        
    }
    #endregion
}
