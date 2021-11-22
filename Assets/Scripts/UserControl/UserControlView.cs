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
    public Button resetBtn;
    public Button searchBtn;

    [Header("查找结果相关")]
    public RectTransform scrollViewContent;
    public GameObject scrollViewItemPrefab;

    [Header("添加用户相关")]
    public InputField addIdInput;
    public InputField addUserNameInput;
    public InputField addPhoneInput;
    public InputField addPasswordInput;
    public Dropdown addSexDropDown;
    public Dropdown addJobDropDown;
    public Button addResetBtn;
    public Button addUserBtn;


    [Header("用户详情相关")]
    public Transform detailContent;
    public Button backBtn;
    public InputField detailIdInput;
    public InputField detailNameInput;
    public InputField detailPhoneInput;
    public InputField detailPasswordInput;
    public Dropdown detailSexDropdown;
    public Dropdown detailJobDropdown;
    public Button detailMotifyBtn;
    public Button detailDeleteBtn;
   
    public void ResetSearch()
    {
        idInput.text = "";
        userNameInput.text = "";
        sexDropDown.value = 0;
        jobDropDown.value = 0;
    }

    public void AddItem(string id,string name,User.UserJob job)
    {
       
        GameObject item = Instantiate(scrollViewItemPrefab, scrollViewContent);

        Text idText = item.transform.GetChild(0).GetChild(0).GetComponent<Text>();
        Text nameText = item.transform.GetChild(1).GetChild(0).GetComponent<Text>();
        Text jobText = item.transform.GetChild(2).GetChild(0).GetComponent<Text>();

        Button detailBtn = item.transform.GetChild(3).GetComponent<Button>();


        idText.text = id;
        nameText.text = name;
        switch (job)
        {
            case User.UserJob.None: jobText.text = "无";break;
            case User.UserJob.Admin: jobText.text = "安检管理员";break;
            case User.UserJob.Member: jobText.text = "安检员";break;
            case User.UserJob.SysAdmin: jobText.text = "系统管理员";break;
        }


        detailBtn.onClick.AddListener(() => onClickDetailBtn(id));

    }

    public void ClearScrollView()
    {
        for(int i = 0;i< scrollViewContent.childCount; i++)
        {
            GameObject.Destroy(scrollViewContent.GetChild(i).gameObject);
        }
        
    }

    public void onClickDetailBtn(string userId)
    {
        Debug.Log("显示详情");
        SetDetailContent(userId);
        ShowDetailContent();
    }

    public void ShowDetailContent()
    {
        detailContent.SetAsLastSibling();
    }

    public void HideDetailContent()
    {
        ClearScrollView();
        detailContent.SetAsFirstSibling();
    }

    public void SetDetailContent(string userId)
    {
        User user = UserDatabaseMgr.Instance.GetUserDataById(userId);
        detailIdInput.text = user.userId;
        detailNameInput.text = user.userName;
        detailPhoneInput.text = user.phone;
        detailPasswordInput.text = user.password;
        switch (user.sex)
        {
            case "男": detailJobDropdown.value = 0;break;
            case "女": detailJobDropdown.value = 1;break;
        }
        switch (user.userJob)
        {
            case User.UserJob.Member: detailJobDropdown.value = 0; break;
            case User.UserJob.Admin: detailJobDropdown.value = 1; break;
            case User.UserJob.SysAdmin: detailJobDropdown.value = 2; break;
        }

    }

    public void ResetAdd()
    {
        addIdInput.text = "";
        addUserNameInput.text = "";
        addPasswordInput.text = "";
        addPhoneInput.text = "";
        addSexDropDown.value = 0;
        addJobDropDown.value = 0;
    }
    
    
        
    
}
