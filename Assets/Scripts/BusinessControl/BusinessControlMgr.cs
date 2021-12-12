using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessControlMgr : MonoBehaviour
{    
    // 实现单例模式
    private static BusinessControlMgr instance;
    public static BusinessControlMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (BusinessControlMgr)FindObjectOfType(typeof(BusinessControlMgr));
                if (instance == null)
                {
                    GameObject BusinessControlMgrObj = new GameObject("BusinessControlMgr");
                    instance = (BusinessControlMgr)BusinessControlMgrObj.AddComponent(typeof(BusinessControlMgr));

                }
                instance.InitBusinessControlMgr();
            }

            return instance;
        }

    }


    private BusinessControlView view;
    public BusinessControlData data;
    public void InitBusinessControlMgr()
    {

        view = (BusinessControlView)FindObjectOfType(typeof(BusinessControlView));
        data = new BusinessControlData();

        AddEventHander();
    }

    private void AddEventHander()
    {

        data.AddEventListener("updateBusinessState", view.UpdateAdminBusinessState);
        data.AddEventListener("updateCanAddMember", UpdateAddDropdownView);

        view.sysCheckPDFBtn.onClick.AddListener(() => view.ShowPDFView(data.currentSelectBusinessId,data.currentSelectPdfName));
        view.sysDelBusinessBtn.onClick.AddListener(DeleteCurrentBusiness);

        view.adminCheckPDFBtn.onClick.AddListener(() => view.ShowPDFView(data.currentSelectBusinessId, data.currentSelectPdfName));
        view.adminBackBtn.onClick.AddListener(data.BackCurrentSelectBusiness);
        view.adminFinishBtn.onClick.AddListener(data.FinishCurrentSelectBusiness);
        view.addDropdown.onValueChanged.AddListener(OnAddDropdownValueChanged);
        view.addBusinessButton.onClick.AddListener(OnClickAddBusinessBtn);


        view.memberCheckPDFBtn.onClick.AddListener(() => view.ShowPDFView(data.currentSelectBusinessId, data.currentSelectPdfName));
        view.memberSendBtn.onClick.AddListener(data.SendPdfFile);


        view.closePDFBtn.onClick.AddListener(view.ShowBusinessPanel);
    }


    public void ResetBusinessPanel()
    {
        data.currentSelectPdfName = string.Empty;
        data.currentSelectBusinessId = string.Empty;

        view.ShowBusinessPanel();

        // 根据用户状态显示对应的界面
        switch (GameManager.Instance.GetCurrentUser().userJob)
        {
            case User.UserJob.SysAdmin:
                view.ResetSysBusinessPanel();
                break;
            case User.UserJob.Member:
                view.ResetMemberBusinessPanel();
                break;
            case User.UserJob.Admin:
                view.ResetAdminBusinessPanel();
                view.ResetAddBusinessPanel();
                data.ClearAddMemberIds();
                break;
        }
    }


    public void SetCurrentBusiness(string id, string name)
    {
        data.currentSelectBusinessId = id;
        data.currentSelectPdfName = name;

       
    }

    public void DeleteCurrentBusiness()
    {
        data.DeleteCurrentSelectBusiness();
        ResetBusinessPanel();
    }

    /// <summary>
    /// 刷新下拉列表数据
    /// </summary>
    public void UpdateBusinessDropdown()
    {
        data.UpdateAllCanAddUsers();
    }

    public void UpdateAddDropdownView()
    {
        List<string> dropdownList = new List<string>();
        dropdownList.Add("None");
        dropdownList.Add("All");
        foreach (string key in data.memberUserDir.Keys)
        {
            dropdownList.Add(key + " " + data.memberUserDir[key]);
        }

        view.UpdateAddDropDown(dropdownList);

    }

    public void OnAddDropdownValueChanged(int value)
    {
        string dropdownText = view.addDropdown.options[value].text;

        string memberId = dropdownText.Split(' ')[0];


        data.UpdateAddMemberIds(memberId);
    }

    public void UpdateViewAddInput(string str)
    {
        view.addMemberInput.text = str;
    }

    public void OnClickAddBusinessBtn()
    {
        data.CreateBusiness(view.addTitleInput.text, view.addContentInput.text);
    }

  
}
