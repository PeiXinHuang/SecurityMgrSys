using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class BusinessControlData
{

    private event UnityAction<Business.State> UpdateBusinessState;
    private event UnityAction UpdateCanAddMember;

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
        if (string.IsNullOrEmpty(currentSelectBusinessId))
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
        else if (BusinessDatabaseMgr.Instance.GetBusinessStateById(currentSelectBusinessId) == Business.State.Finish)
        {
            MessageBoxMgr.Instance.ShowWarnning("安检业务已完成，无法提交安检报表文件");
            return;
        }


        //string path = EditorUtility.OpenFilePanel("上传安检报表文件", "", "pdf");

        string path = OpenDialog.OpenFileDialog(OpenDialog.FileType.None);
        if (path.Length != 0)
        {
            if (path.ToLower().EndsWith(".pdf"))
            {
                if (File.Exists(Application.streamingAssetsPath + "/" + currentSelectBusinessId + ".pdf"))
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



    class OpenDialog
    {

        public enum FileType
        {
            None,
            Text,
            Texture,
            Video,
            Music,
        }
        /// <summary>
        /// 打开一个窗口选择一个文件
        /// </summary>
        /// <param name="fileType">需要选择的文件类型</param>
        /// <param name="openPath">设置打开的默认路径</param>
        /// <returns>返回选择文件的路径</returns>
        public static string OpenFileDialog(FileType fileType, string openPath = null)
        {
            OpenFileName ofn = new OpenFileName();
            ofn.structSize = Marshal.SizeOf(ofn);
            string fliter = string.Empty;
            switch (fileType)
            {
                case FileType.None:
                    fliter = "All Files(*.*)\0*.*\0\0";
                    break;
                case FileType.Text:
                    fliter = "Text Files(*文本文件)\0*.txt\0";
                    break;
                case FileType.Texture:
                    fliter = "Texure Files(*图片文件)\0*.png;*.jpg\0";
                    break;
                case FileType.Video:
                    fliter = "Video Files(*视频文件)\0*.mp4;*.mov\0";
                    break;
                case FileType.Music:
                    fliter = "Music Files(*音频文件)\0*.wav;*.mp3\0";
                    break;
            }
            ofn.filter = fliter;//设置需要选择的类型
            ofn.file = new string(new char[256]);
            ofn.maxFile = ofn.file.Length;
            ofn.fileTitle = new string(new char[64]);
            ofn.maxFileTitle = ofn.fileTitle.Length;
            if (string.IsNullOrEmpty(openPath))
                ofn.initialDir = System.Environment.CurrentDirectory; //打开的默认路径自行更改
            else
                ofn.initialDir = openPath;
            ofn.title = "选择文件";//标题 自定义 自行更改
                               //0x00000200  设置用户可以选择多个文件 不使用 暂时没找到解析多个文件路径的解决方法
                               //具体含义查看给到的参考文献链接
            ofn.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000008;
            if (OpenDialog.GetOFN(ofn))
            {
                Debug.Log(ofn.file);
                return ofn.file;
            }
            return "";
        }


        //链接指定系统函数       打开文件对话框
        [DllImport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
        public static extern bool GetOpenFileName([In, Out] OpenFileName ofn);
        public static bool GetOFN([In, Out] OpenFileName ofn)
        {
            return GetOpenFileName(ofn);
        }
        //链接指定系统函数        另存为对话框
        [DllImport("Comdlg32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
        public static extern bool GetSaveFileName([In, Out] OpenFileName ofn);
        public static bool GetSFN([In, Out] OpenFileName ofn)
        {
            return GetSaveFileName(ofn);
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class OpenFileName
        {
            public int structSize = 0;
            public IntPtr dlgOwner = IntPtr.Zero;
            public IntPtr instance = IntPtr.Zero;
            public String filter = null;
            public String customFilter = null;
            public int maxCustFilter = 0;
            public int filterIndex = 0;
            public String file = null;
            public int maxFile = 0;
            public String fileTitle = null;
            public int maxFileTitle = 0;
            public String initialDir = null;
            public String title = null;
            public int flags = 0;
            public short fileOffset = 0;
            public short fileExtension = 0;
            public String defExt = null;
            public IntPtr custData = IntPtr.Zero;
            public IntPtr hook = IntPtr.Zero;
            public String templateName = null;
            public IntPtr reservedPtr = IntPtr.Zero;
            public int reservedInt = 0;
            public int flagsEx = 0;
        }
    }
}