using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToBoard : MonoBehaviour
{
    public void GoToLeaderboard()
    {
        SceneManager.LoadScene(3);
    }
}
