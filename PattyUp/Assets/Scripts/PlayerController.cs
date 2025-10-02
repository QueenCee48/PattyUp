using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    GameObject[] hearts;
    Text timerText;
    Text scoreText;
    OrderController orderController;
    BurgerController burgerController;
    Image panelImage;
    Text gameOverText;
    Text playAgainText;

    int heartsRemaining;
    public float timer;
    public int score;
    string[] order;
    string[] prepared;
    bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        hearts = GameObject.FindGameObjectsWithTag("Heart");
        timerText = GameObject.Find("TimerText").GetComponent<Text>();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        orderController = GameObject.Find("Canvas").GetComponent<OrderController>();
        burgerController = GameObject.Find("BurgerDisplay").GetComponent<BurgerController>();
        panelImage = GameObject.Find("Panel").GetComponent<Image>();
        gameOverText = GameObject.Find("GameOverText").GetComponent<Text>();
        playAgainText = GameObject.Find("PlayAgainText").GetComponent<Text>();

        heartsRemaining = hearts.Length;
        order = orderController.GetOrder();
        prepared = burgerController.GetPrepared();
        timerText.text = "Timer: " + Mathf.CeilToInt(timer);
        gameOver = false;
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.timeScale == 0 && !gameOver)
        {
            Time.timeScale = 1;
        }
        else if (Input.GetButtonDown("Fire1") && Time.timeScale == 0 && gameOver)
        {
            SceneManager.LoadScene("Game");
        }
        
        timer -= Time.deltaTime;
        timerText.text = "Timer: " + Mathf.CeilToInt(timer);

        if (timer <= 0f)
        {
            timer = 0f;
            gameOver = true;
            Time.timeScale = 0;
            panelImage.enabled = true;
            gameOverText.enabled = true;
            playAgainText.enabled = true;
        }
    }
}
