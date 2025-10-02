using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    int heartsRemaining;
    public float timer;
    public int score;
    string[] order;
    string[] prepared;
    bool gameOver;
    bool instructionsShown;
    bool preparing;

    // Start is called before the first frame update
    void Start()
    {
        hearts = GameObject.FindGameObjectsWithTag("Heart");
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

        startPanel.enabled = true;
        logo.enabled = true;
        playText.enabled = true;
        creditText.enabled = true;

        heartsRemaining = hearts.Length;
        // order = orderController.GetOrder();
        // prepared = burgerController.GetPrepared();
        // preparing = burgerController.GetPreparing();
        timerText.text = "Timer: " + Mathf.CeilToInt(timer);
        gameOver = false;
        instructionsShown = false;
        Time.timeScale = 0;
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
            gameOverPanel.enabled = true;
            gameOverText.enabled = true;
            playAgainText.enabled = true;
        }

        if (!gameOver)
        {
            order = orderController.GetOrder();
            prepared = burgerController.GetPrepared();
            preparing = burgerController.GetPreparing();

            if (!preparing && prepared.SequenceEqual(order))
            {
                score++;
                scoreText.text = "Score: " + score;

                burgerController.ClearPrepared();
                orderController.setOrderCompleted(false);
                order = orderController.GetOrder();
            }
        }
    }

    public bool GetGameOver()
    {
        return gameOver;
    }
}
