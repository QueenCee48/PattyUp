using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject[] hearts;
    public Text timerText;
    public Text scoreText;
    public OrderController orderController;
    public BurgerController burgerController;
    public ScreenCtrlr screenCtrlr;

    RawImage[] heartImages;
    public AudioSource bgMusic;
    public AudioSource timerAudio;
    public AudioSource gameOverAudio;
    public AudioSource scoreAudio;
    public AudioSource loseLifeAudio;

    public string gameMode = null;

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
    public bool gameOver;
    bool preparing;
    bool topBunPlaced;

    // Start is called before the first frame update
    void Start()
    {
        heartImages = new RawImage[hearts.Length];
        bgMusic = GetComponent<AudioSource>();

        for (int i = 0; i < hearts.Length; i++)
        {
            heartImages[i] = hearts[i].GetComponent<RawImage>();
        }

        heartsRemaining = hearts.Length;
        timerText.text = "Timer: " + Mathf.CeilToInt(timer);
        gameOver = false;
        Time.timeScale = 0;
        bgMusic.volume = 0.5f;
        bgMusic.Play();
        timerAudio.Stop();
        gameOverAudio.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        handleTimer();

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
        screenCtrlr.TurnOnGameOverScreen();
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

        topBunPlaced = false;
    }

    public void NotifyTopBunLanded()
    {
        topBunPlaced = true;
    }

    void handleTimer()
    {
        if (gameMode == "classic") 
        {
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
        }
        else if (gameMode == "endless")
        {
            timer += Time.deltaTime;
            timerText.enabled = false;
        }
    }
}
