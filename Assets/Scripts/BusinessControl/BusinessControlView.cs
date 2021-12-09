using Paroxe.PdfRenderer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusinessControlView : MonoBehaviour
{
    [Header("安检业务相关")]
    public Image businessPanel;

    [Header("系统管理员安检业务管理界面相关")]
    public Image sysBusinessPanel;
    public RectTransform sysScrollTran;
    public GameObject sysItemPrefab;
    public Text sysTitle;
    public Text sysContent;
    public Text sysName;
    public Text sysState;
    public Image sysSpace;
    public Button sysCheckPDFBtn;
    public Button sysDelBusinessBtn;


    [Header("安检管理员安检业务管理界面相关")]
    public Image adminBusinessPanel;


    [Header("安检员安检业务管理界面相关")]
    public Image memberBusinessPanel;
    

    [Header("PDF预览界面相关")]
    public Image pdfPanel;
    public PDFViewer pdfViewer;
    public Button closePDFBtn;



    public void ShowBusinessPanel()
    {
        businessPanel.transform.SetAsLastSibling();
    }

    public void ShowPDFView(string pdfName)
    {
        if(string.IsNullOrEmpty(pdfName))
        {
            MessageBoxMgr.Instance.ShowWarnning("当前没有选中安检业务");
            return;
        }

        pdfPanel.transform.SetAsLastSibling();
        pdfViewer.FileName = pdfName;
    }

    public void ResetBusinessControlPanel()
    {

        ShowBusinessPanel();
    }

    public void ResetSysBusinessPanel()
    {
        sysBusinessPanel.transform.SetAsLastSibling();

        sysContent.text = "";
        sysTitle.text = "";
        sysState.text = "";
        sysName.text = "";
        sysSpace.gameObject.SetActive(false);
        int childCount = sysScrollTran.childCount;
        for(int i= childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(sysScrollTran.GetChild(i).gameObject);
        }
        List<Business> businesses = BusinessDatabaseMgr.Instance.GetAllBusinesses();

        foreach (Business business in businesses)
        {
            //实例化Prefab
            GameObject newItem = Instantiate(sysItemPrefab, sysScrollTran);
            string id = business.id;
            string title = business.title;
            string content = business.content;
            string memberUserId = business.memberUserId;
            string pdfName = business.pdfName;
            Business.State state = business.state;

            string memberName = UserDatabaseMgr.Instance.GetUserDataById(memberUserId).userName;

            if (string.IsNullOrEmpty(memberName))
                memberName = "已注销";
            newItem.transform.GetChild(0).GetComponent<Text>().text = string.Format("{0}({1})",title, memberName);
            Button clickBtn = newItem.GetComponent<Button>();
            clickBtn.onClick.AddListener(() => ShowSysBusinessContent(id,title,content, memberName, pdfName));
        }

    }

    public void ShowSysBusinessContent(string id, string title,string content, string name,string pdfName)
    {
        sysTitle.text = title;
        sysContent.text = content;
        sysName.text = name;

        BusinessControlMgr.Instance.SetCurrentBusiness(id,pdfName);
     
    }



    public void ResetAdminBusinessPanel()
    {
        adminBusinessPanel.transform.SetAsLastSibling();
    }

    public void ResetMemberBusinessPanel()
    {
        memberBusinessPanel.transform.SetAsLastSibling();
    }


    


}
