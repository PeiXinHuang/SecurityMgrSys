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
            MessageBoxMgr.Instance.ShowWarnning("当前没有选中安检业务");
            return;
        }

        BusinessDatabaseMgr.Instance.DeleteBusinessById(currentSelectBusinessId);

        MessageBoxMgr.Instance.ShowInfo("删除业务成功");
    }
}
