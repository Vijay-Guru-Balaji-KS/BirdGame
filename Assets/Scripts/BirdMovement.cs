using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BirdMovement : MonoBehaviour
{
    public static BirdMovement instance;

    public Rigidbody2D bird;
    public float flapstrength = 10f;
    public LogicScript logic;
    public bool birdisalive = true;

    public Camera MainCamera;

    public GameObject pausescreen;

    //below line wrote
    LogicScript lscript;
    public HighScoreManager highscoreManager;

    SpellCooldown SpellCooldown;
    
    public Text mudscore;
    int hscore  = 0;

    public AudioSource audioPlayer;

    private void Awake()
    {
        //PlayerPrefs.DeleteAll();
        //PlayerPrefs.SetString("BloodyScore", "0");
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        lscript = logic.GetComponent<LogicScript>();
        highscoreManager = gameObject.GetComponent<HighScoreManager>();
        hscore = int.Parse(PlayerPrefs.GetString("BloodyScore"), 0);
        mudscore.text = PlayerPrefs.GetString("BloodyScore");
    }

    // Update is called once per frame
    void Update()
    {

        if ((Input.GetKeyDown(KeyCode.Escape)))
        {
            PauseGame();
        }
        if (Input.GetKeyDown(KeyCode.Space) && birdisalive==true)
        {
            bird.velocity = new Vector2(0,1) * flapstrength;
        }

        if(Input.GetKeyDown(KeyCode.E) && birdisalive==true)
        {
            logic.UseSpell();
        }

        if(Input.GetKeyDown(KeyCode.Q) && birdisalive==true)
        { 
            logic.UseBackSpell();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetString("BloodyScore", "0");
        }
    }

     public void dashForward()
    {
        bird.velocity = new Vector2(-1, 0) * 8f;
        Vector3 newpos = this.transform.position + new Vector3(-1, 0, 0) * 100f * Time.deltaTime;
        this.transform.position = new Vector2(-1, 0) + bird.velocity * Time.deltaTime;
        transform.position = newpos;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //below wriite
        //mudscore.text = "gut";


        /*finalscore = lscript.getScore();

        if (finalscore > lscript.highscore)
        {
            lscript.highscore = finalscore;
            PlayerPrefs.SetInt("HighScore", lscript.highscore);
        } */



        /*if(int.Parse(mudscore.text)<lscript.getScore())
        {
            mudscore.text = lscript.getScore().ToString();
        }
        
        PlayerPrefs.SetString("BloodyScore", mudscore.text); */

        //PlayerPrefs.SetString("BloodyScore", mudscore.text);
        if(collision.gameObject.tag == "coin")
        {
            audioPlayer.Play();
        }

        int score = lscript.getScore();

        if (hscore < score)
        {
            PlayerPrefs.SetString("BloodyScore",score.ToString()); 
            mudscore.text = PlayerPrefs.GetString("BloodyScore");
            PlayerPrefs.Save();
        }
         //mudscore.text = lscript.getScore().ToString();
         Debug.Log("Bird mov la Bloody Sore : " + PlayerPrefs.GetString("BloodyScore"));

        /*int mudScore = int.Parse(mudscore.text);

        // Check if the current score is higher than the mainPageScore
        if (logic!=null)
        {
            logic.setScore(mudScore); // Set the score in LogicScript
        }*/

        logic.gameover();
        birdisalive = false;
        DetachCamera();
    }

    public int deathscore()
    {
        return int.Parse(mudscore.text);
    }


     public void DetachCamera()
    {
        MainCamera.transform.parent = null;
    }


    public void PauseGame()
    {
        Time.timeScale = 0;
        pausescreen.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
        pausescreen.SetActive(false);
    }

    public void GotoHome()
    {
        SceneManager.LoadScene("FlappyBird");
    }
}
