using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreManager : MonoBehaviour
{
    public Text MainMenuScore;

    void Start()
    {
        MainMenuScore.text = PlayerPrefs.GetString("BloodyScore");
        PlayerPrefs.SetString("LeaderScore", PlayerPrefs.GetString("BloodyScore"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
