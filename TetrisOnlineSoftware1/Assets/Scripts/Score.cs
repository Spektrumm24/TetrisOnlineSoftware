using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;
    Text scoreText;

    private void Awake()
    {
        scoreText = GetComponent<Text>();
    }
    private void Start()
    {
        score = 0;
    }

    void Update()
    {
        scoreText.text = score.ToString();
    }
}