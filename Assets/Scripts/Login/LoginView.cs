using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoginView : MonoBehaviour
{
    
    public Image loginContent;
    public InputField userIdInput;
    public InputField passwordInput;
    public Button loginBtn;
    public Button exitBtn;

    public void ShowLoginPanel()
    {
        loginContent.rectTransform.SetAsLastSibling();
    }

    public void HideLoginPanel()
    {
        loginContent.rectTransform.SetAsFirstSibling();
    }

    


}
