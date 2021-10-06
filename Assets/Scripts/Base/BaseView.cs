using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BaseView : MonoBehaviour
{

    [Header("������塪�û����")]
    public Text userNameText;

    [Header("������塪�б����")]
    public Button selfInfoBtn; 
    public Button userControlBtn; 
    public Button businessControlBtn; 
    public Button infoControlBtn;

    [Header("�������")]
    public Image selfInfoContent;
    public Image userControlContent;
    public Image businessControlContent;
    public Image infoControlContent;

    // ˢ�»��������û������ͼ
    public void UpdateUserPanel(User user)
    {

        if (user.isEmptyUser())
        {
            userNameText.text = "δ��¼";
        }
        else
        {
            userNameText.text = user.userName;
        }
       
    }



    // �����û�����ˢ�»��������б���ͼ������Ա����ʾ�û������������Ա��ϵͳ����Ա��ʾȫ��
    public void UpdateListPanel(User user)
    {

        //������û��ǿյģ���ʾ�˳���ֻ��ʾ������Ϣ
        if (user.isEmptyUser())
        {
            selfInfoBtn.gameObject.SetActive(true);
            userControlBtn.gameObject.SetActive(false);
            businessControlBtn.gameObject.SetActive(false);
            infoControlBtn.gameObject.SetActive(false);
            return;
        }
    
        if(user.userJob == User.UserJob.Member)
        {
            selfInfoBtn.gameObject.SetActive(true);
            userControlBtn.gameObject.SetActive(false);
            businessControlBtn.gameObject.SetActive(true);
            infoControlBtn.gameObject.SetActive(true);
        }
        else if (user.userJob == User.UserJob.Admin)
        {
            selfInfoBtn.gameObject.SetActive(true);
            userControlBtn.gameObject.SetActive(true);
            businessControlBtn.gameObject.SetActive(true);
            infoControlBtn.gameObject.SetActive(true);
        }
        else if (user.userJob == User.UserJob.SysAdmin)
        {
            selfInfoBtn.gameObject.SetActive(true);
            userControlBtn.gameObject.SetActive(true);
            businessControlBtn.gameObject.SetActive(true);
            infoControlBtn.gameObject.SetActive(true);
        }

    }

    /// <summary>
    /// ��ʾ�������,��Ҫ��ʾ������Ƶ���ǰ��
    /// </summary>
    /// <param name="contentType">�����������</param>
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
