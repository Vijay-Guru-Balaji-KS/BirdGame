using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    /*[SerializeField]
    private Text inputscore;
    [SerializeField]
    public Text inputName;


    /*private void Awake()
    {
        inputscore.text = PlayerPrefs.GetString("BloodyScore").ToString();
        inputName.text = PlayerPrefs.GetString("PlayerName").ToString();
        Debug.Log("Score manager la Bloody: " + PlayerPrefs.GetString("BloodyScore") + " Name : " + PlayerPrefs.GetString("PlayerName"));
    }*/

    public UnityEvent<string, int> submitScoreEvent;

    public  void SubmitScore()
    {
        //Debug.Log("Score manager la Bloody: " + PlayerPrefs.GetString("BloodyScore") + " Name : " + PlayerPrefs.GetString("PlayerName"));
        string PlayerName = PlayerPrefs.GetString("PlayerName");
        int score = int.Parse(PlayerPrefs.GetString("LeaderScore"));
        //Debug.Log("Score manager la Bloody: " + PlayerPrefs.GetString("BloodyScore") + " Name : " + PlayerPrefs.GetString("PlayerName") + " Leader Score : " + PlayerPrefs.GetString("LeaderScore"));
        Debug.Log("Score manager la Bloody: " + PlayerPrefs.GetString("BloodyScore") + " Name : " + PlayerPrefs.GetString("PlayerName") + " Leader Score : " + score);
        submitScoreEvent.Invoke(PlayerName,8);
    }

    /*private void LateUpdate()
    {
        PlayerPrefs.DeleteKey("PlayerName");
        PlayerPrefs.DeleteKey("LeaderScore");
    }*/
}
