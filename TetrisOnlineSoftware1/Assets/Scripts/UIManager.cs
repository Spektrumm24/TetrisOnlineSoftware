using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    public GameObject loginUI;
    public GameObject RegisterUI;

    private void Awake()
    {
        if(instance = null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(this);
        }
    }
    public void LoginScreen()
    {
        loginUI.SetActive(true);
        RegisterUI.SetActive(false);
    }
    public void RegisterScreen()
    {
        loginUI.SetActive(false);
        RegisterUI.SetActive(true);
    }
}
