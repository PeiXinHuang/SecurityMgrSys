using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseView : MonoBehaviour
{

    [Header("基础面板—用户面板")]
    public Text userNameText;

    [Header("基础面板—列表面板")]
    public Button selfInfoBtn; 
    public Button userControlBtn; 
    public Button businessControlBtn; 
    public Button infoControlBtn;
    public Button toolControlBtn;


    public Image selfInfoHighStyleImg;
    public Image userControlHighStyleImg;
    public Image businessControlHighStyleImg;
    public Image infoControlHighStyleImg;
    public Image toolControlHighStyleImg;

    [Header("详情面板")]
    public Image selfInfoContent;
    public Image userControlContent;
    public Image businessControlContent;
    public Image infoControlContent;

    


    // 刷新基础面板的用户面板视图
    public void UpdateUserPanel(User user)
    {

        if (user.isEmptyUser())
        {
            throw new System.Exception("Fail to set list's user Panel, bscause user is empty");
        }
        else
        {
            userNameText.text = user.userName;
        }
       
    }


    public void UpdateListViewStyle(BaseData.ContentType contentType)
    {
        selfInfoHighStyleImg.gameObject.SetActive(false);
        userControlHighStyleImg.gameObject.SetActive(false); 
        businessControlHighStyleImg.gameObject.SetActive(false); 
        infoControlHighStyleImg.gameObject.SetActive(false); 
        toolControlHighStyleImg.gameObject.SetActive(false);

        switch (contentType)
        {
            case BaseData.ContentType.SelfInfo:
                selfInfoHighStyleImg.gameObject.SetActive(true);
                break;
            case BaseData.ContentType.BusinessControl:
                businessControlHighStyleImg.gameObject.SetActive(true);
                break;
            case BaseData.ContentType.UserControl:
                userControlHighStyleImg.gameObject.SetActive(true);
                break;
            case BaseData.ContentType.InfoControl:
                infoControlHighStyleImg.gameObject.SetActive(true);
                break;
            case BaseData.ContentType.ToolControl:
                toolControlHighStyleImg.gameObject.SetActive(true);
                break;
            default:
                break;
        }
    }


    // 根据用户类型刷新基础面板的列表视图，安检员不显示用户管理，安检管理员和系统管理员显示全部
    public void UpdateListPanel(User user)
    {

        if (user.isEmptyUser())
        {
            throw new System.Exception("Fail to set list Panel, bscause user is empty");
        }
    
        if(user.userJob == User.UserJob.Member)
        {
            selfInfoBtn.gameObject.SetActive(true);
            userControlBtn.gameObject.SetActive(false);
            businessControlBtn.gameObject.SetActive(true);
            infoControlBtn.gameObject.SetActive(true);
            toolControlBtn.gameObject.SetActive(true);
        }
        else if (user.userJob == User.UserJob.Admin)
        {
            selfInfoBtn.gameObject.SetActive(true);
            userControlBtn.gameObject.SetActive(true);
            businessControlBtn.gameObject.SetActive(true);
            infoControlBtn.gameObject.SetActive(true);
            toolControlBtn.gameObject.SetActive(true);
        }
        else if (user.userJob == User.UserJob.SysAdmin)
        {
            selfInfoBtn.gameObject.SetActive(true);
            userControlBtn.gameObject.SetActive(true);
            businessControlBtn.gameObject.SetActive(true);
            infoControlBtn.gameObject.SetActive(true);
            toolControlBtn.gameObject.SetActive(true);
        }

    }

    /// <summary>
    /// 显示详情面板,将要显示的面板移到最前面
    /// </summary>
    /// <param name="contentType">详情面板类型</param>
    public void UpdateContentPanel(BaseData.ContentType contentType)
    {
        switch (contentType)
        {
            case BaseData.ContentType.SelfInfo:
                selfInfoContent.rectTransform.SetAsLastSibling();
                break;
            case BaseData.ContentType.BusinessControl:
                businessControlContent.rectTransform.SetAsLastSibling();
                break;
            case BaseData.ContentType.UserControl:
                userControlContent.rectTransform.SetAsLastSibling();
                break;
            case BaseData.ContentType.InfoControl:
                infoControlContent.rectTransform.SetAsLastSibling();
                break;
            default:
                break;
        }
    }

    
}
