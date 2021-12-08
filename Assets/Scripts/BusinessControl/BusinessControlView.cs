using Paroxe.PdfRenderer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BusinessControlView : MonoBehaviour
{
    [Header("����ҵ�����")]
    public Image businessPanel;

    [Header("ϵͳ����Ա����ҵ�����������")]
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


    [Header("�������Ա����ҵ�����������")]
    public Image adminBusinessPanel;


    [Header("����Ա����ҵ�����������")]
    public Image memberBusinessPanel;
    

    [Header("PDFԤ���������")]
    public Image pdfPanel;
    public PDFViewer pdfViewer;
    public Button closePDFBtn;



    public void ShowBusinessPanel()
    {
        businessPanel.transform.SetAsLastSibling();
    }

    public void ShowPDFView(string pdfName)
    {
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
            //ʵ����Prefab
        }

    }

    public void ShowSysBusinessContent(string title,string content, string name,string state)
    {

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
