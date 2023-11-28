using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Dan.Main;
using UnityEngine.UI;

//public key : e3734a50f9a3e351e97ae875b006e3d087613dc7ec21175dd413f1abe3cd137d
//secret key : 9466c18ca34ec6ebc3ac4bed9dd29abf9e6407e5eb02359f37d6889fac68e74b121e0d6612d3b09fd5765b3fe3694cc6b3f465b3c44ebd522fcd0bd185247eb7fa29ed5599db44f3f94c057f2f0ea876a4503e3cce8e547768bfd94a566354a993ea9f9be5a0a5e2037ae578ba8dd921645dfb6ab7d1a332dc6766479fd23909

public class Leaderboard : MonoBehaviour
{
    [SerializeField]
    private List<Text> Naam;
    [SerializeField]
    private List<Text> points;

    public Text test;
    public Text ScoreTest;

    //private string publicLeaderKey = "d70af7311ab68da21f1ad826d9add18bc4f951069ff3318b5bd954428a89705c";
    private string publicLeaderKey = "e3734a50f9a3e351e97ae875b006e3d087613dc7ec21175dd413f1abe3cd137d";

    private void Start()
    {
        getLeaderBoard();
        
    }

    private void Awake()
    {
        test.text = PlayerPrefs.GetString("PlayerName");
        ScoreTest.text = PlayerPrefs.GetString("LeaderScore");

        Debug.Log("LeaderBoard la Bloody: " + PlayerPrefs.GetString("BloodyScore") + " Name : " + PlayerPrefs.GetString("PlayerName")+" Leader Score : "+PlayerPrefs.GetString("LeaderScore"));
    }
    public void getLeaderBoard()
    {
        
        LeaderboardCreator.GetLeaderboard(publicLeaderKey, (msg) =>
        {
            int loolen = (msg.Length < Naam.Count) ? msg.Length : Naam.Count;
            for (int i = 0; i < loolen; i++)
            {
                Naam[i].text = msg[i].Username;
               points[i].text = msg[i].Score.ToString();
            }
        });
    }

   public void SetLeaderBoardEntry(string username,int score)
    {
        LeaderboardCreator.UploadNewEntry(publicLeaderKey, username, score, ((msg) =>
        {
            getLeaderBoard();
        }));
    }

    /*private void LateUpdate()
    {
        test.text=null; ScoreTest.text=null;
    }*/

    /*private void LateUpdate()
    {
        PlayerPrefs.DeleteKey("PlayerName");
        PlayerPrefs.DeleteKey("LeaderScore");
    }*/
}
