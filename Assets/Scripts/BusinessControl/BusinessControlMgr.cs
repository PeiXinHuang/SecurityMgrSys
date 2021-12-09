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
        view.sysCheckPDFBtn.onClick.AddListener(() => view.ShowPDFView(data.currentSelectPdfName));
        view.sysDelBusinessBtn.onClick.AddListener(DeleteCurrentBusiness);
    }


    public void ResetPanel()
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
        ResetPanel();
    }
}
