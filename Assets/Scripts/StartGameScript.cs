using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;

public class StartGameScript : MonoBehaviour
{

    public static StartGameScript gamescript;


    public GameObject playscreen;
    public GameObject LeaderBoardScreen;
    

    public GameObject NamePanel;

    LogicScript lscript;
    public LogicScript logic;

    public GameObject InstructPanel;

    
    
    //below write


    public Text mainPageScore;

    /*[SerializeField]
    private Text inputScore;
    [SerializeField]
    private Text inputName;*/

    public Text testText;

    public InputField NameTextBox;


    public string testreturntext()
    {
        return testText.text;
    }

    private void Awake()
    {
        PlayerPrefs.SetString("FinalS","0");
    }

    /*public GameObject ForLBoard;
    GameObject LeaderBoardManager;

    //For leaderboard reference from the mainscreen
   /* public Text LName;
    public Text LScore;**/

    //start method wriiten
    private void Start()
    {
        if(logic!=null)
        {
            int temp = logic.getScore();
            mainPageScore.text = temp.ToString();
        }


        /*LeaderBoardManager = GameObject.FindGameObjectWithTag("LBoard");
        ForLBoard = LeaderBoardManager;*/
        testText.text = "Ready Player 1";
        PlayerPrefs.SetString("PlayerName", testText.text);
    }

    
   /* public void JustDoIt()
    {
        leaderBoard.SetLeaderboardEntry(LName.text,int.Parse(LScore.text));
    }*/

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetString("BloodyScore", "0");
        }
    }

    private void LateUpdate()
    {
        if (logic!=null && logic.getScore() > int.Parse(PlayerPrefs.GetString("FinalS")))
        {
            int temp = logic.getScore();
            mainPageScore.text = temp.ToString();
            PlayerPrefs.Save();
        }
    }

    /*public UnityEvent<string, int> submitScoreEvent;
    public void SubmitScore()
    {
        submitScoreEvent.Invoke(inputName.text, int.Parse(inputScore.text));
    }*/

    
    public void startgame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void scoreboard()
    {
        SceneManager.LoadScene("LeaderBoardScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void closeNamePopUp()
    {
       NamePanel.SetActive(false);
    }


    public void NameChange()
    {
        //PlayerPrefs.SetString("PlayerName", testText.ToString());
        Debug.Log("PlayerName : " + PlayerPrefs.GetString("PlayerName"));
        NamePanel.gameObject.SetActive(true);
    }

    public void SubmittingNameButton()
    {
        PlayerPrefs.SetString("PlayerName", NameTextBox.text);
        NamePanel.SetActive(false);
    }


    public void openInstrcPanel()
    {
        InstructPanel.SetActive(true);
    }
    public void CloseInstrucPane()
    {
        InstructPanel.SetActive(false);
    }
}
