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


        data.AddEventListener("sendEventEvent", view.ResetSendPanel);
        data.AddEventListener("updateCanSendUsers", view.UpdateSendDropDown);
    }

    private void onClickSendButton()
    {
        data.SendInfo(view.sendTitleInput.text,view.sendContentInput.text);
    }

    public void ResetPanel()
    {
        view.ResetSendPanel();
    }

    public void UpdateSendUserDropdown()
    {
        data.UpdateAllCanSendUsers();
    }

    public void UpdateViewSendDropdown()
    {
        
    }
}
