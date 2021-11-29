using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserControlMgr : MonoBehaviour
{
    #region 单例
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
    #endregion


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

        //查找
        view.searchBtn.onClick.AddListener(OnClickSearchBtn);
        data.AddEventListener("SearchUsersEvent", UserControlMgr.Instance.ShowSearchResult);


        view.addBtn.onClick.AddListener(OnClickAddUserBtn);
        view.motifyBtn.onClick.AddListener(OnClickModifyBtn);
        
        //view.AddEventListener("DeleteUserEvent",da)

    }

   
    public void OnClickSearchBtn()
    {
        data.SetSearchId(view.idInput.text);
        data.SetSearchUserName(view.userNameInput.text);
        data.SetSearchSex(view.sexDropDown.value);
        data.SetSearchJob(view.jobDropDown.value);
        data.Search();
    }
    
    public void ShowSearchResult()
    {
        view.ClearSearchResult();

        List<User> users = data.GetUsers();

        for(int i = 0; i< users.Count; i++)
        {
            User newUser = users[i];
            view.AddSearchResultItem(newUser);
        }
    }

    public void OnClickAddUserBtn()
    {
        data.AddUser(view.addIdInput.text, view.addUserNameInput.text, view.addPhoneInput.text,
            view.addPasswordInput.text, view.addSexDropDown.value, view.addJobDropDown.value);
    }

    public void OnClickModifyBtn()
    {
        data.ModifyUser(view.editIdInput.text, view.editNameInput.text, view.editPhoneInput.text,
            view.editPasswordInput.text, view.editSexDropdown.value, view.editJobDropdown.value);
    }

}

