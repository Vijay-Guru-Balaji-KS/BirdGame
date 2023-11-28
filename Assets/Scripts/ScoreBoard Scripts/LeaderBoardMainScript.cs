using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LeaderBoardMainScript : MonoBehaviour
{
    public GameObject goback;

    public void gotohome()
    {
        SceneManager.LoadScene("FlappyBird");
    }
}
