using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class BusinessControlData
{

    private event UnityAction<Business.State> UpdateBusinessState;
    private event UnityAction  UpdateCanAddMember;

    public void AddEventListener(string eventName, UnityAction<Business.State> function)
    {
        if (eventName == "updateBusinessState")
            UpdateBusinessState += function;
        else
            Debug.LogWarning("Event: " + eventName + " is not exit");
    }
    public void RemoveEventListener(string eventName, UnityAction<Business.State> function)
    {
        if (eventName == "updateBusinessState")
            UpdateBusinessState -= function;
        else
            Debug.LogWarning("Event: " + eventName + " is not exit");
    }

    public void AddEventListener(string eventName, UnityAction function)
    {
        if (eventName == "updateCanAddMember")
            UpdateCanAddMember += function;
        else
            Debug.LogWarning("Event: " + eventName + " is not exit");
    }
    public void RemoveEventListener(string eventName, UnityAction function)
    {
        if (eventName == "updateCanAddMember")
            UpdateCanAddMember -= function;
        else
            Debug.LogWarning("Event: " + eventName + " is not exit");
    }





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


    //驳回当前业务
    public void BackCurrentSelectBusiness()
    {

        if (string.IsNullOrEmpty(currentSelectBusinessId))
        {
            MessageBoxMgr.Instance.ShowWarnning("当前没有选中安检业务");
            return;
        }

        Business.State currentBusinessState = BusinessDatabaseMgr.Instance.GetBusinessStateById(currentSelectBusinessId);

        switch (currentBusinessState)
        {
            case Business.State.Doing:
                MessageBoxMgr.Instance.ShowWarnning("安检业务进行中，无法驳回");
                return;
            case Business.State.Check:
                break;
            case Business.State.Back:
                MessageBoxMgr.Instance.ShowWarnning("按检业务已驳回中，无法再次驳回");
                break;
            case Business.State.Finish:
                MessageBoxMgr.Instance.ShowWarnning("按检业务已完成，无法驳回");
                break;
            default:
                return;
        }

        BusinessDatabaseMgr.Instance.UpdateBusinessStateById(currentSelectBusinessId, Business.State.Back);
        MessageBoxMgr.Instance.ShowInfo("安检业务已驳回");

        if (UpdateBusinessState != null)
            UpdateBusinessState(Business.State.Back);
    }


    //驳回当前业务
    public void FinishCurrentSelectBusiness()
    {

        if (string.IsNullOrEmpty(currentSelectBusinessId))
        {
            MessageBoxMgr.Instance.ShowWarnning("当前没有选中安检业务");
            return;
        }

        Business.State currentBusinessState = BusinessDatabaseMgr.Instance.GetBusinessStateById(currentSelectBusinessId);

        switch (currentBusinessState)
        {
            case Business.State.Doing:
                MessageBoxMgr.Instance.ShowWarnning("安检业务进行中，无法通过");
                return;
            case Business.State.Check:

                break;
            case Business.State.Back:
                MessageBoxMgr.Instance.ShowWarnning("安检业务驳回中，无法通过");
                break;
            case Business.State.Finish:
                MessageBoxMgr.Instance.ShowWarnning("安检业务已完成，无法再次通过");
                break;
            default:
                return;
        }

        BusinessDatabaseMgr.Instance.UpdateBusinessStateById(currentSelectBusinessId, Business.State.Finish);
        MessageBoxMgr.Instance.ShowInfo("安检业务已通过");

        if (UpdateBusinessState != null)
            UpdateBusinessState(Business.State.Finish);
    }

    //发送用户
    public Dictionary<string, string> memberUserDir = new Dictionary<string, string>();
    public void UpdateAllCanAddUsers()
    {
        memberUserDir.Clear();
        User conditionUser = new User();
        conditionUser.userJob = User.UserJob.Member;
        List<User> users = UserDatabaseMgr.Instance.GetUsersData(conditionUser);
        foreach (User user in users)
        {

            memberUserDir.Add(user.userId, user.userName);
        }

        if (UpdateCanAddMember != null)
            UpdateCanAddMember();
    }

    //将要成员的安检成员
    List<string> addMemberIds = new List<string>();
    public void ClearAddMemberIds()
    {
        addMemberIds.Clear();
    }

    public void UpdateAddMemberIds(string memberId)
    {
        if (memberId == "None")
        {
            addMemberIds.Clear();
        }
        else if (memberId == "All")
        {
            addMemberIds.Clear();
            foreach (string item in memberUserDir.Keys)
            {
                addMemberIds.Add(item);
            }
        }
        else
        {

            bool canGet = memberUserDir.ContainsKey(memberId);
            if (canGet)
            {
                if (!addMemberIds.Contains(memberId))
                    addMemberIds.Add(memberId);
            }
            else
            {
                Debug.LogError("找不到安检员：" + memberId);
            }
        }

        string str = "";
        foreach (string item in addMemberIds)
        {
            str += string.Format("{0}({1}) / ", item, memberUserDir[item]);
        }


        BusinessControlMgr.Instance.UpdateViewAddInput(str);
    }

    //创建业务
    public void CreateBusiness(string title, string content)
    {
        if (string.IsNullOrEmpty(title))
        {
            MessageBoxMgr.Instance.ShowWarnning("业务标题不能为空");
            return;
        }

        if (string.IsNullOrEmpty(content))
        {
            MessageBoxMgr.Instance.ShowWarnning("业务内容不能为空");
            return;
        }

        if (addMemberIds.Count == 0)
        {
            MessageBoxMgr.Instance.ShowWarnning("安检员不能为空");
            return;
        }

        BusinessDatabaseMgr.Instance.CreateNewBusinesses(GameManager.Instance.GetCurrentUser().userId,
            addMemberIds, title, content);

        BusinessControlMgr.Instance.ResetBusinessPanel();
        MessageBoxMgr.Instance.ShowInfo("创建业务成功");
    }


    public void SendPdfFile()
    {
        if (string.IsNullOrEmpty(currentSelectBusinessId))
        {
            MessageBoxMgr.Instance.ShowWarnning("当前没有选中安检业务");
            return;
        }
        if (BusinessDatabaseMgr.Instance.GetBusinessStateById(currentSelectBusinessId) == Business.State.Check)
        {
            MessageBoxMgr.Instance.ShowWarnning("安检业务审核中，无法提交安检报表文件");
            return;
        }
        else if(BusinessDatabaseMgr.Instance.GetBusinessStateById(currentSelectBusinessId) == Business.State.Finish)
        {
            MessageBoxMgr.Instance.ShowWarnning("安检业务已完成，无法提交安检报表文件");
            return;
        }


        string path = EditorUtility.OpenFilePanel("上传安检报表文件", "", "pdf");
        if (path.Length != 0)
        {
            if (path.ToLower().EndsWith(".pdf"))
            {
                if(File.Exists(Application.streamingAssetsPath + "/" + currentSelectBusinessId + ".pdf"))
                {
                    File.Delete(Application.streamingAssetsPath + "/" + currentSelectBusinessId + ".pdf");
                }
                File.Copy(path, Application.streamingAssetsPath + "/" + currentSelectBusinessId + ".pdf");
                BusinessDatabaseMgr.Instance.UpdateBusinessStateById(currentSelectBusinessId, Business.State.Check);

                BusinessDatabaseMgr.Instance.UpdatePdfName(currentSelectBusinessId, currentSelectBusinessId + ".pdf");

            }
            else
            {
                MessageBoxMgr.Instance.ShowWarnning("请上传pdf文件");
            }


            BusinessControlMgr.Instance.ResetBusinessPanel();

            MessageBoxMgr.Instance.ShowInfo("安检报表文件上传成功");
        }
    }
}
