using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public static int timeUI;
    Text timerText;

    private void Awake()
    {
        timerText = GetComponent<Text>();
    }
    private void Start()
    {
        timeUI = 0;
    }

    void Update()
    {
        timerText.text = timeUI.ToString();
    }
}
