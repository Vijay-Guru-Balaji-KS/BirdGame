
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LogicScript : MonoBehaviour
{
    public int playerscore = 0;
    public Text scoretext;
    public GameObject gameoverscreen;


    public Text highScoreText;

    public int highscore = 0;

    public Text MainScore;

    

    //StartGameScript sgsscript;
    HighScoreManager highscoreManager;
    BirdMovement birdMovement;

    [Header("UI items for forward dash")]
    [Tooltip("Tooltip example")]
    [SerializeField]
    private Image imageCooldown;
    [SerializeField]
    private TMP_Text textCooldown;
    [SerializeField]
    private Image imageEdge;
    //variable for looking after the cooldown
    private bool isCoolDown = false;
    private float cooldownTime = 10.0f;
    private float cooldownTimer = 0.0f;
    public Rigidbody2D pakshibody;
    [Header("UI items for Backward dash")]
    [Tooltip("Tooltip example")]
    [SerializeField]
    private Image imageCooldown1;
    [SerializeField]
    private TMP_Text textCooldown1;
    [SerializeField]
    private Image imageEdge1;
    //variable for looking after the cooldown
    private bool isCoolDown1 = false;
    private float cooldownTime1 = 10.0f;
    private float cooldownTimer1 = 0.0f;
    int forwardcount,backwardcount;

    private AudioSource audioSource;

    private void Start()
    {
        textCooldown.gameObject.SetActive(false);
        imageEdge.gameObject.SetActive(false);
        imageCooldown.fillAmount = 0.0f;

        //sgsscript = GetComponent<StartGameScript>();
        textCooldown1.gameObject.SetActive(false);
        imageEdge1.gameObject.SetActive(false);
        imageCooldown1.fillAmount = 0.0f;


        highscoreManager = gameObject.GetComponent<HighScoreManager>();

        forwardcount = 0;
        backwardcount = 0;

        audioSource = FindObjectOfType<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            UseSpell();
        }

        if (isCoolDown)
        {
            ApplyCooldown();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            UseBackSpell();
        }

        if (isCoolDown1)
        {
            ApplyBackCooldown();
        }
    }

    [ContextMenu ("Increase Score")]
    public void addscore(int scoretoadd)
    {

        playerscore = playerscore + scoretoadd;
        scoretext.text = playerscore.ToString();
    }

    public void restartgame()
    {
        SceneManager.LoadScene("FlappyBird");
    }

    public void gameover()
    {
        gameoverscreen.SetActive(true);
    }

    public int ScoreObtain()
    {
        highScoreText.text = scoretext.text;
        return int.Parse(highScoreText.text);
    }


    public int getScore()
    {
        int temp = int.Parse(scoretext.text);
        PlayerPrefs.SetString("playingscore", temp.ToString());
        PlayerPrefs.Save();
        return temp;
    }

    public void setScore(int newScore)
    {
        playerscore = newScore;
        scoretext.text = playerscore.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameover();
    }

    void ApplyCooldown()
    {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer < 0.0f)
        {
            
            isCoolDown = false;
            textCooldown.gameObject.SetActive(false);
            imageEdge.gameObject.SetActive(false);
            imageCooldown.fillAmount = 0.0f;

            forwardcount= 0;
            
        }
        else
        {
            if(forwardcount == 4)
            {
                textCooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
                imageCooldown.fillAmount = cooldownTimer / cooldownTime;

                imageEdge.transform.localEulerAngles = new Vector3(0, 0, 360.0f * (cooldownTimer / cooldownTime));

                return;
            }
            else
            {
                pakshibody.velocity = new Vector2(1, 0) * 6f;
                Vector3 newpos = this.transform.position + new Vector3(1, 0, 0) * 100f * Time.deltaTime;
                transform.position = newpos;
                forwardcount += 1;
            }
        }

    }

    public bool UseSpell()
    {
        if (isCoolDown)
        {
            return false;
        }
        else
        {
            isCoolDown = true;
            textCooldown.gameObject.SetActive(true);
            cooldownTimer = cooldownTime;
            textCooldown.text = Mathf.RoundToInt(cooldownTimer).ToString();
            imageCooldown.fillAmount = 1.0f;

            imageEdge.gameObject.SetActive(true);
            return true;
        }
    }



    void ApplyBackCooldown()
    {
        cooldownTimer1 -= Time.deltaTime;
        if (cooldownTimer1 < 0.0f)
        {

            isCoolDown1 = false;
            textCooldown1.gameObject.SetActive(false);
            imageEdge1.gameObject.SetActive(false);
            imageCooldown1.fillAmount = 0.0f;

            backwardcount = 0;

        }
        else
        {
            if (backwardcount == 5)
            {
                textCooldown1.text = Mathf.RoundToInt(cooldownTimer1).ToString();
                imageCooldown1.fillAmount = cooldownTimer1 / cooldownTime1;

                imageEdge1.transform.localEulerAngles = new Vector3(0, 0, 360.0f * (cooldownTimer1 / cooldownTime1));

                return;
            }
            else
            {
                pakshibody.velocity = new Vector3(-1, 0, 0) * 6f;
                Vector3 newpos1 = this.transform.position + new Vector3(-1, 0, 0) * 100f * Time.deltaTime;
                transform.position = newpos1;

                backwardcount += 1;
            }

        }
    }

    public bool UseBackSpell()
    {
        if (isCoolDown1)
        {
            return false;
        }
        else
        {
            isCoolDown1 = true;
            textCooldown1.gameObject.SetActive(true);
            cooldownTimer1 = cooldownTime1;
            textCooldown1.text = Mathf.RoundToInt(cooldownTimer1).ToString();
            imageCooldown1.fillAmount = 1.0f;

            imageEdge1.gameObject.SetActive(true);
            return true;
        }
    }

}
