using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControlMgr : MonoBehaviour
{
    private static UserControlMgr instance;
    public static UserControlMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (UserControlMgr)FindObjectOfType(typeof(UserControlMgr));
                if (instance == null)
                {
                    GameObject UserControlMgrObj = new GameObject("UserControlMgr");
                    instance = (UserControlMgr)UserControlMgrObj.AddComponent(typeof(UserControlMgr));

                }
                instance.InitUserControlMgr();
            }

            return instance;
        }

    }

    private UserControlView view;
    public UserControlData data;
    public void InitUserControlMgr()
    {
        view = (UserControlView)FindObjectOfType(typeof(UserControlView));
        data = new UserControlData();

        AddEventHander();
    }



    /// <summary>
    /// 添加事件处理
    /// </summary>
    private void AddEventHander()
    {
        view.searchBtn.onClick.AddListener(OnClickSearchBtn);
        view.resetBtn.onClick.AddListener(OnClickResetBtn);

        view.backBtn.onClick.AddListener(view.HideDetailContent);

        data.AddEventListener("SearchUsersEvent", UserControlMgr.Instance.ShowUsers);


        view.addUserBtn.onClick.AddListener(OnClickAddUserBtn);
        view.addResetBtn.onClick.AddListener(OnClickAddResetBtn);


        
    }

    public void OnClickResetBtn()
    {
        view.ResetSearch();
    }

    public void OnClickSearchBtn()
    {
        data.SetSearchId(view.idInput.text);
        data.SetSearchUserName(view.userNameInput.text);
        data.SetSearchSex(view.sexDropDown.value);
        data.SetSearchJob(view.jobDropDown.value);
        data.Search();
    }
    
    public void ShowUsers()
    {
        view.ClearScrollView();

        List<User> users = data.GetUsers();

       

        for(int i = 0; i< users.Count; i++)
        {
            User currentUser = users[i];
            view.AddItem(currentUser.userId, currentUser.userName, currentUser.userJob);
            
        }
    }

    public void OnClickAddUserBtn()
    {
        data.AddUser(view.addIdInput.text, view.addUserNameInput.text, view.addPhoneInput.text,
            view.addPasswordInput.text, view.addSexDropDown.value, view.addJobDropDown.value);
    }

    public void OnClickAddResetBtn()
    {
        view.ResetAdd();
    }
}

