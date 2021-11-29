using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class UserControlView : MonoBehaviour
{



    [Header("查找操作相关")]
    public InputField idInput;
    public InputField userNameInput;
    public Dropdown sexDropDown;
    public Dropdown jobDropDown;
    public Button searchBtn;

    [Header("查找结果相关")]
    public RectTransform searchResultContent;
    public GameObject searchResultPrefab;
    public Dictionary<string, GameObject> searchResultDir = new Dictionary<string, GameObject>();


    [Header("编辑用户相关")]
    public InputField editIdInput;
    public InputField editNameInput;
    public InputField editPhoneInput;
    public InputField editPasswordInput;
    public Dropdown editSexDropdown;
    public Dropdown editJobDropdown;
    public Button motifyBtn;

    [Header("添加用户相关")]
    public InputField addIdInput;
    public InputField addUserNameInput;
    public InputField addPhoneInput;
    public InputField addPasswordInput;
    public Dropdown addSexDropDown;
    public Dropdown addJobDropDown;
    public Button addBtn;



   
    public void ResetSearchPanel()
    {
        idInput.text = "";
        userNameInput.text = "";
        sexDropDown.value = 0;
        jobDropDown.value = 0;
    }


    public void ClearSearchResult()
    {

        foreach (string key in searchResultDir.Keys)
        {
            DestroyImmediate(searchResultDir[key]);
         
        }
        searchResultDir.Clear();
    }

    public void AddSearchResultItem(User user)
    {

        GameObject item = Instantiate(searchResultPrefab, searchResultContent);

        Text idText = item.transform.GetChild(0).GetComponent<Text>();
        Text nameText = item.transform.GetChild(1).GetComponent<Text>();
        Text jobText = item.transform.GetChild(2).GetComponent<Text>();

        Button editBtn = item.transform.GetChild(3).GetComponent<Button>();
        Button deleteBtn = item.transform.GetChild(4).GetComponent<Button>();


        idText.text = user.userId;
        nameText.text = user.userName;
        jobText.text = user.JobToChinese(user.userJob);

        editBtn.onClick.AddListener(() => onClickEditBtn(user));
        deleteBtn.onClick.AddListener(() => onClickDelteBtn(user.userId));

        searchResultDir[user.userId] = item;

    }

    public void RemoveSearchResultItem(string userId)
    {
        GameObject obj = searchResultDir[userId];
        searchResultDir.Remove(userId);
        DestroyImmediate(obj);
    }



    public void onClickEditBtn(User user)
    {
        editIdInput.text = user.userId;
        editNameInput.text = user.userName;

        switch (user.sex)
        {
            case "男":
                editSexDropdown.value = 0;
                break;
            case "女":
                editSexDropdown.value = 1;
                break;
        }

        switch (user.userJob)
        {
            case User.UserJob.Member:
                editJobDropdown.value = 0;
                break;
            case User.UserJob.Admin:
                editJobDropdown.value = 1;
                break;
            case User.UserJob.SysAdmin:
                editJobDropdown.value = 2;
                break;
        }

        editPasswordInput.text = user.password;
        editPhoneInput.text = user.phone;

    }


   
    public void onClickDelteBtn(string id)
    {
        UserDatabaseMgr.Instance.DeleteUserData(id);
        RemoveSearchResultItem(id);
        MessageBoxMgr.Instance.ShowInfo("删除用户成功");
    }



    public void ResetAddPanel()
    {
        addIdInput.text = "";
        addUserNameInput.text = "";
        addSexDropDown.value = 0;
        addJobDropDown.value = 0;
        addPasswordInput.text = "";
        addPhoneInput.text = "";
    }
   


        
    
}
