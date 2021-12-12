using Paroxe.PdfRenderer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusinessControlView : MonoBehaviour
{
    [Header("安检业务相关")]
    public Image businessPanel;





  
    

    [Header("PDF预览界面相关")]
    public Image pdfPanel;
    public PDFViewer pdfViewer;
    public Button closePDFBtn;



    public void ShowBusinessPanel()
    {
        businessPanel.transform.SetAsLastSibling();
    }

    public void ShowPDFView(string businessId, string pdfName)
    {
        if(string.IsNullOrEmpty(businessId))
        {
            MessageBoxMgr.Instance.ShowWarnning("当前没有选中安检业务");
            return;
        }
        else if (string.IsNullOrEmpty(pdfName))
        {
            MessageBoxMgr.Instance.ShowWarnning("当前安检业务没有报告可查看");
            return;
        }

        pdfPanel.transform.SetAsLastSibling();
        pdfViewer.FileName = pdfName;
    }

    public void ResetBusinessControlPanel()
    {

        ShowBusinessPanel();
    }

    #region 系统管理员业务管理界面

    [Header("系统管理员安检业务管理界面相关")]
    public Image sysBusinessPanel;
    public RectTransform sysScrollTran;
    public GameObject sysItemPrefab;
    public Text sysTitle;
    public Text sysContent;
    public Text sysName;
    public Text sysName2;
    public Text sysState;
    public Image sysSpace;
    public Button sysCheckPDFBtn;
    public Button sysDelBusinessBtn;
    public void ResetSysBusinessPanel()
    {
        sysBusinessPanel.transform.SetAsLastSibling();

        sysContent.text = "";
        sysTitle.text = "";
        sysState.text = "";
        sysName.text = "";
        sysName2.text = "";
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
            string adminUserId = business.adminUserId;
            string pdfName = business.pdfName;
            Business.State state = business.state;

            string memberName = UserDatabaseMgr.Instance.GetUserDataById(memberUserId).userName;
            string adminName = UserDatabaseMgr.Instance.GetUserDataById(adminUserId).userName;

            if (string.IsNullOrEmpty(memberName))
                memberName = "已注销";

            if (string.IsNullOrEmpty(adminName))
                adminName = "已注销";

            newItem.transform.GetChild(0).GetComponent<Text>().text = string.Format("{0}({1})",title, memberName);
            Button clickBtn = newItem.GetComponent<Button>();
            clickBtn.onClick.AddListener(() => ShowSysBusinessContent(id,title,content, memberName, adminName, pdfName,state));
        }

    }

    public void ShowSysBusinessContent(string id, string title,string content, string name, string name2,string pdfName, Business.State state)
    {
        sysTitle.text = title;
        sysContent.text = content;
        sysName.text = "安检员：" + name;
        sysName2.text = "安检管理员：" + name2;
        sysSpace.gameObject.SetActive(true);
        sysState.text = "状态：" + Business.GetStateName(state);
        BusinessControlMgr.Instance.SetCurrentBusiness(id,pdfName);
        
     
    }
    #endregion


    #region 安检管理员业务管理界面

    [Header("安检管理员安检业务管理界面相关")]
    public Image adminBusinessPanel;
   

    public RectTransform adminScrollTran;
    public GameObject adminItemPrefab;
    public Text adminTitle;
    public Text adminContent;
    public Text adminName;
    public Text adminName2;
    public Text adminState;
    public Image adminSpace;
    public Button adminCheckPDFBtn;
    public Button adminBackBtn;
    public Button adminFinishBtn;

    public void ResetAdminBusinessPanel()
    {
        adminBusinessPanel.transform.SetAsLastSibling();
    

        adminContent.text = "";
        adminTitle.text = "";
        adminState.text = "";
        adminName.text = "";
        adminName2.text = "";
        adminSpace.gameObject.SetActive(false);
        int childCount = adminScrollTran.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(adminScrollTran.GetChild(i).gameObject);
        }
        List<Business> businesses = BusinessDatabaseMgr.Instance.GetBusinessesByAdminId(GameManager.Instance.GetCurrentUser().userId);

        foreach (Business business in businesses)
        {
            //实例化Prefab
            GameObject newItem = Instantiate(adminItemPrefab, adminScrollTran);
            string id = business.id;
            string title = business.title;
            string content = business.content;
            string memberUserId = business.memberUserId;
            string adminUserId = business.adminUserId;
            string pdfName = business.pdfName;
            Business.State state = business.state;

            string memberName = UserDatabaseMgr.Instance.GetUserDataById(memberUserId).userName;
            string adminName = UserDatabaseMgr.Instance.GetUserDataById(adminUserId).userName;


            if (string.IsNullOrEmpty(memberName))
                memberName = "已注销";
            if (string.IsNullOrEmpty(adminName))
                adminName = "已注销";
            newItem.transform.GetChild(0).GetComponent<Text>().text = string.Format("{0}({1})", title, memberName);
            Button clickBtn = newItem.GetComponent<Button>();
            clickBtn.onClick.AddListener(() => ShowAdminBusinessContent(id, title, content, memberName, adminName, pdfName, state));
        }

    }

    private void ShowAdminBusinessContent(string id, string title, string content, string name, string name2, string pdfName, Business.State state)
    {
        adminTitle.text = title;
        adminContent.text = content;
        adminName.text = "安检员：" + name;
        adminName2.text = "安检管理员：" + name2;
        adminSpace.gameObject.SetActive(true);
        adminState.text = "状态：" + Business.GetStateName(state);
        BusinessControlMgr.Instance.SetCurrentBusiness(id, pdfName);

    }

    public void UpdateAdminBusinessState(Business.State state)
    {
        adminState.text = "状态：" + Business.GetStateName(state);
    }



    public InputField addTitleInput;
    public InputField addContentInput;
    public InputField addMemberInput;
    public Dropdown addDropdown;
    public Button addBusinessButton;

    public void ResetAddBusinessPanel()
    {
        addTitleInput.text = "";
        addContentInput.text = "";
        addMemberInput.text = "";

        addDropdown.value = 0;
    }


    public void UpdateAddDropDown(List<string> list)
    {
        addDropdown.ClearOptions();
        addDropdown.AddOptions(list);
    }

    public void UpdateAddMemberInput(string str)
    {
        addMemberInput.text = str;
    }

    #endregion

    #region 安检员业务管理界面
    [Header("安检员安检业务管理界面相关")]
    public Image memberBusinessPanel;
    public RectTransform memberScrollTran;
    public GameObject memberItemPrefab;
    public Text memberTitle;
    public Text memberContent;
    public Text memberName;
    public Text memberName2;
    public Text memberState;
    public Image memberSpace;
    public Button memberCheckPDFBtn;
    public Button memberSendBtn;
    public void ResetMemberBusinessPanel()
    {
        memberBusinessPanel.transform.SetAsLastSibling();

        memberContent.text = "";
        memberTitle.text = "";
        memberState.text = "";
        memberName.text = "";
        memberName2.text = "";
        memberSpace.gameObject.SetActive(false);
        int childCount = memberScrollTran.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(memberScrollTran.GetChild(i).gameObject);
        }
        List<Business> businesses = BusinessDatabaseMgr.Instance.GetBusinessesByMemberId(GameManager.Instance.GetCurrentUser().userId);

        foreach (Business business in businesses)
        {
            //实例化Prefab
            GameObject newItem = Instantiate(memberItemPrefab, memberScrollTran);
            string id = business.id;
            string title = business.title;
            string content = business.content;
            string memberUserId = business.memberUserId;
            string adminUserId = business.adminUserId;
            string pdfName = business.pdfName;
            Business.State state = business.state;

            string memberName = UserDatabaseMgr.Instance.GetUserDataById(memberUserId).userName;
            string adminName = UserDatabaseMgr.Instance.GetUserDataById(adminUserId).userName;

            if (string.IsNullOrEmpty(memberName))
                memberName = "已注销";

            if (string.IsNullOrEmpty(adminName))
                adminName = "已注销";

            newItem.transform.GetChild(0).GetComponent<Text>().text = string.Format("{0}({1})", title, memberName);
            Button clickBtn = newItem.GetComponent<Button>();
            clickBtn.onClick.AddListener(() => ShowMemberBusinessContent(id, title, content, memberName, adminName, pdfName, state));
        }

    }

    public void ShowMemberBusinessContent(string id, string title, string content, string name, string name2, string pdfName, Business.State state)
    {
        memberTitle.text = title;
        memberContent.text = content;
        memberName.text = "安检员：" + name;
        memberName2.text = "安检管理员：" + name2;
        memberSpace.gameObject.SetActive(true);
        memberState.text = "状态：" + Business.GetStateName(state);
        BusinessControlMgr.Instance.SetCurrentBusiness(id, pdfName);


    }

    #endregion


}
