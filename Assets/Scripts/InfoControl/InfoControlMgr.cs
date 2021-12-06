using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoControlMgr : MonoBehaviour
{
    private static InfoControlMgr instance;
    public static InfoControlMgr Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (InfoControlMgr)FindObjectOfType(typeof(InfoControlMgr));
                if (instance == null)
                {
                    GameObject InfoContriolMgrObj = new GameObject("InfoControlMgr");
                    instance = (InfoControlMgr)InfoContriolMgrObj.AddComponent(typeof(InfoControlMgr));

                }
                instance.InitInfoContriolMgr();
            }

            return instance;
        }

    }

    private InfoControlView view;
    public InfoControlData data;
    public void InitInfoContriolMgr()
    {

        view = (InfoControlView)FindObjectOfType(typeof(InfoControlView));
        data = new InfoControlData();

        AddEventHander();
    }

    private void AddEventHander()
    {
        view.sendButton.onClick.AddListener(onClickSendButton);
        view.sendDropdown.onValueChanged.AddListener(OnSendDropdownValueChanged);

        //发送完信息，重置发送消息窗口
        data.AddEventListener("sendInfoEvent", view.ResetSendPanel);
        data.AddEventListener("updateCanSendUsers", UpdateViewSendDropdown);


    }

    private void onClickSendButton()
    {
        data.SendInfo(view.sendTitleInput.text,view.sendContentInput.text);
    }

    public void ResetPanel()
    {
        view.ResetSendPanel();
        view.ResetReceivePanel();
        view.ResetHistroyPanel();
    }

    /// <summary>
    /// 刷新下拉列表数据
    /// </summary>
    public void UpdateSendUserDropdown()
    {
        data.UpdateAllCanReceiveUsers();
    }

    /// <summary>
    /// 刷新下拉列表视图
    /// </summary>
    public void UpdateViewSendDropdown()
    {
        List<string> dropdownList = new List<string>();
        dropdownList.Add("None");
        dropdownList.Add("All");

        foreach (string key in data.receiveUserDir.Keys)
        {
            dropdownList.Add(key + " " + data.receiveUserDir[key]);
        }

        view.UpdateSendDropDown(dropdownList);
    }

    private void OnSendDropdownValueChanged(int value)
    {
        string dropdownText = view.sendDropdown.options[value].text;
       
        string sendId = dropdownText.Split(' ')[0];


        data.UpdateReceiveIds(sendId);
    }

    public void UpdateViewSendInput(string str)
    {
        view.sendUserInput.text = str;
    }
}
