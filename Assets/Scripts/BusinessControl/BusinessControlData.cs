using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BusinessControlData
{
    public string currentSelectBusinessId = string.Empty;
    public string currentSelectPdfName = string.Empty;

    public void DeleteCurrentSelectBusiness()
    {
        if(string.IsNullOrEmpty(currentSelectBusinessId))
        {
            MessageBoxMgr.Instance.ShowWarnning("��ǰû��ѡ�а���ҵ��");
            return;
        }

        BusinessDatabaseMgr.Instance.DeleteBusinessById(currentSelectBusinessId);

        MessageBoxMgr.Instance.ShowInfo("ɾ��ҵ��ɹ�");
    }
}
