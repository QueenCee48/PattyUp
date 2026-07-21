using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenCtrlr : MonoBehaviour
{
    PlayerController playerController;
    
    public Image gameOverPanel;
    public Text gameOverText;
    public Text yourScoreText;
    public Text replayBtnText;
    public Image replayBtnImg;
    public Text changeModeBtnText;
    public Image changeModeBtnImg;
    public Image startPanel;
    public RawImage logo;
    public Text playBtnText;
    public Image playBtnImg;
    public Text creditText;
    public Text instructionTitle;
    public Text instructionText;
    public Text hintText;

    public Image classicBtnImg;
    public Text classicBtnTxt;
    public Image endlessBtnImg;
    public Text endlessBtnTxt;

    bool startScreenOn;
    bool instructionScreenOn;
    bool gameOverScreenOn;
    
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("FoodBoard").GetComponent<PlayerController>();
        
        instructionScreenOn = false;
        gameOverScreenOn = false;

        TurnOnStartScreen();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayButton()
    {
        TurnOffStartScreen();
        TurnOnInstructionScreen();
    }

    public void SetClassicMode()
    {
        playerController.gameMode = "classic";
        playerController.timer = 60f;
        TurnOffInstructionScreen();
    }

    public void SetEndlessMode()
    {
        playerController.gameMode = "endless";
        playerController.timer = 0f;
        TurnOffInstructionScreen();
    }

    public void TurnOnStartScreen()
    {
        logo.enabled = true;
        playBtnText.enabled = true;
        playBtnImg.enabled = true;
        creditText.enabled = true;
        startPanel.enabled = true;
        startScreenOn = true;
        Time.timeScale = 0;

        instructionScreenOn = false;
        gameOverScreenOn = false;
    }

    public void TurnOffStartScreen()
    {
        logo.enabled = false;
        playBtnText.enabled = false;
        playBtnImg.enabled = false;
        creditText.enabled = false;
        startPanel.enabled = false;
        startScreenOn = false;
    }

    public void TurnOnInstructionScreen()
    {
        instructionTitle.enabled = true;
        instructionText.enabled = true;
        hintText.enabled = true;
        instructionScreenOn = true;
        startPanel.enabled = true;

        classicBtnImg.enabled = true;
        classicBtnTxt.enabled = true;
        endlessBtnImg.enabled = true;
        endlessBtnTxt.enabled = true;
        Time.timeScale = 0;

        gameOverScreenOn = false;
        startScreenOn = false;
    }

    public void TurnOffInstructionScreen()
    {
        instructionTitle.enabled = false;
        instructionText.enabled = false;
        hintText.enabled = false;
        instructionScreenOn = false;
        startPanel.enabled = false;

        classicBtnImg.enabled = false;
        classicBtnTxt.enabled = false;
        endlessBtnImg.enabled = false;
        endlessBtnTxt.enabled = false;

        Time.timeScale = 1;
        playerController.bgMusic.volume = 0.25f;
    }

    public void TurnOnGameOverScreen()
    {
        gameOverPanel.enabled = true;
        gameOverText.enabled = true;
        yourScoreText.enabled = true;
        yourScoreText.text = "Your Score: " + playerController.score;
        replayBtnText.enabled = true;
        replayBtnImg.enabled = true;
        changeModeBtnText.enabled = true;
        changeModeBtnImg.enabled = true;
        gameOverScreenOn = true;
        Time.timeScale = 0;

        instructionScreenOn = false;
        startScreenOn = false;
    }

    public void TurnOffGameOverScreen()
    {
        gameOverPanel.enabled = false;
        gameOverText.enabled = false;
        yourScoreText.enabled = false;
        yourScoreText.text = "";
        replayBtnText.enabled = false;
        replayBtnImg.enabled = false;
        changeModeBtnText.enabled = false;
        changeModeBtnImg.enabled = false;
        gameOverScreenOn = false;
        // SceneManager.LoadScene("Game");
    }

    public void ReplayButton()
    {
        TurnOffGameOverScreen();

        playerController.RestartGame();
    }

    public void ChangeMode()
    {
        TurnOffGameOverScreen();

        playerController.RestartGame();

        TurnOnInstructionScreen();
    }
}
