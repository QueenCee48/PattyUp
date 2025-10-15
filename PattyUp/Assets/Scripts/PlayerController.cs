using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject[] hearts;
    Text timerText;
    Text scoreText;
    OrderController orderController;
    BurgerController burgerController;
    IngredientController ingredientController;
    Image gameOverPanel;
    Text gameOverText;
    Text playAgainText;
    Image startPanel;
    RawImage logo;
    Text playText;
    Text creditText;
    Text instructionTitle;
    Text instructionText;
    Text hintText;
    RawImage[] heartImages;
    AudioSource bgMusic;
    AudioSource timerAudio;
    AudioSource gameOverAudio;
    AudioSource scoreAudio;
    AudioSource loseLifeAudio;

    // BG Music by mk.matheusklein (Matheus) from Unity Asset Store
    // Timer Sound Effect by Dustyroom from Unity Asset Store
    // Game Over Sound Effect by Dustyroom from Unity Asset Store
    // Click Sound Effect by Dustyroom from Unity Asset Store
    // Point Sound Effect by Dustyroom from Unity Asset Store
    // Lose Life Sound Effect by MiraclEI from Pixabay
    // Wall & Table Textures by Yughues (formerly Nobiax) from Unity Asset Store
    // Parcel Box Asset by TP Studios from Unity Asset Store
    // Most Burger Assets by _TheCloudy__ from itch.io
    // Baloo2 Font by Ek Type from 1001 Fonts

    int heartsRemaining;
    public float timer;
    public int score;
    string[] order;
    string[] prepared;
    bool gameOver;
    bool instructionsShown;
    bool preparing;
    bool topBunPlaced;

    // Start is called before the first frame update
    void Start()
    {
        //hearts = GameObject.FindGameObjectsWithTag("Heart");
        heartImages = new RawImage[hearts.Length];
        timerText = GameObject.Find("TimerText").GetComponent<Text>();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        orderController = GameObject.Find("Canvas").GetComponent<OrderController>();
        burgerController = GameObject.Find("BurgerDisplay").GetComponent<BurgerController>();
        gameOverPanel = GameObject.Find("GameOverPanel").GetComponent<Image>();
        gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
        playAgainText = GameObject.Find("PlayAgainText").GetComponent<Text>();
        startPanel = GameObject.Find("StartPanel").GetComponent<Image>();
        logo = GameObject.Find("PattyUpLogo").GetComponent<RawImage>();
        playText = GameObject.Find("PlayText").GetComponent<Text>();
        creditText = GameObject.Find("CreditText").GetComponent<Text>();
        instructionTitle = GameObject.Find("InstructionTitle").GetComponent<Text>();
        instructionText = GameObject.Find("InstructionText").GetComponent<Text>();
        hintText = GameObject.Find("HintText").GetComponent<Text>();

        bgMusic = GetComponent<AudioSource>();
        timerAudio = GameObject.Find("TimerText").GetComponent<AudioSource>();
        gameOverAudio = GameObject.Find("GameOverScreen").GetComponent<AudioSource>();
        scoreAudio = GameObject.Find("ScoreText").GetComponent<AudioSource>();
        loseLifeAudio = GameObject.Find("Hearts").GetComponent<AudioSource>();

        for (int i = 0; i < hearts.Length; i++)
        {
            heartImages[i] = hearts[i].GetComponent<RawImage>();
        }

        startPanel.enabled = true;
        logo.enabled = true;
        playText.enabled = true;
        creditText.enabled = true;

        heartsRemaining = hearts.Length;
        timerText.text = "Timer: " + Mathf.CeilToInt(timer);
        gameOver = false;
        instructionsShown = false;
        Time.timeScale = 0;
        bgMusic.volume = 0.5f;
        bgMusic.Play();
        timerAudio.Stop();
        gameOverAudio.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.timeScale == 0 && !gameOver && !instructionsShown)
        {
            logo.enabled = false;
            playText.enabled = false;
            creditText.enabled = false;

            instructionTitle.enabled = true;
            instructionText.enabled = true;
            hintText.enabled = true;
            instructionsShown = true;
        }
        else if (Input.GetButtonDown("Fire1") && Time.timeScale == 0 && !gameOver && instructionsShown)
        {
            startPanel.enabled = false;
            instructionTitle.enabled = false;
            instructionText.enabled = false;
            hintText.enabled = false;
            instructionsShown = false;
            Time.timeScale = 1;
            bgMusic.volume = 0.25f;
        }
        else if (Input.GetButtonDown("Fire1") && Time.timeScale == 0 && gameOver)
        {
            SceneManager.LoadScene("Game");
        }

        timer -= Time.deltaTime;
        timerText.text = "Timer: " + Mathf.CeilToInt(timer);

        if (timer <= 10f && timer > 0f)
        {
            if (!timerAudio.isPlaying)
            {
                timerAudio.Play();
            }
        }
        else if (timer <= 0f && !gameOver)
        {
            timer = 0f;
            GameOver();
        }

        if (!gameOver)
        {
            order = orderController.GetOrder();
            prepared = burgerController.GetPrepared();
            preparing = burgerController.GetPreparing();

            if (topBunPlaced)
            {
                if (!preparing && prepared.SequenceEqual(order))
                {
                    scoreAudio.Play();

                    score++;
                    scoreText.text = "Score: " + score;

                    Reset();
                }
                else if (!preparing && !prepared.SequenceEqual(order))
                {
                    loseLifeAudio.Play();
                    
                    heartsRemaining--;
                    heartImages[heartsRemaining].enabled = false;

                    Reset();

                    if (heartsRemaining == 0)
                    {
                        GameOver();
                    }
                }
            }
        }
    }

    public bool GetGameOver()
    {
        return gameOver;
    }

    void GameOver()
    {
        gameOver = true;
        Time.timeScale = 0;
        gameOverPanel.enabled = true;
        gameOverText.enabled = true;
        playAgainText.enabled = true;
        bgMusic.Stop();
        timerAudio.Stop();
        gameOverAudio.Play();
    }

    void Reset()
    {
        burgerController.ClearPrepared();
        orderController.SetOrderCompleted(false);
        order = orderController.GetOrder();
        orderController.SetOrderText("");
        orderController.resetOrderNum();

        foreach (GameObject c in GameObject.FindGameObjectsWithTag("Clone"))
            Destroy(c);

        foreach (GameObject c in GameObject.FindGameObjectsWithTag("TopBunClone"))
            Destroy(c);
        
        // foreach (GameObject c in GameObject.FindGameObjectsWithTag("LastClone"))
        //     Destroy(c);

        topBunPlaced = false;
    }

    public void NotifyTopBunLanded()
    {
        topBunPlaced = true;
    }
}
