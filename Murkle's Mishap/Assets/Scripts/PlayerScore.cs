using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private float timeLeft = 120;//time Left acts as extra points for players who finish the game faster
    public Text HScore;
    public int Score = 0;
    public GameObject playerScoreUI;
    public GameObject finalScoreUI;
    public GameObject HighScoreUI;
    public GameObject EndLevelUI;

    //Audio
    public AudioSource CoinSound;

    void Start()
    {
        HScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }

    void Update()
    {
        timeLeft -= Time.deltaTime;
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score:" + (int)Score);
    }
    void OnTriggerEnter2D (Collider2D trig)
    {
        if (trig.gameObject.name == "EndLevel")
        {
            CountScore();
            EndGame();
            Time.timeScale = 0f;
        }
        if (trig.gameObject.tag == "coin")
        {
            Score += 10;
            CoinSound.Play();
            Destroy(trig.gameObject);
        }
    }


    void CountScore()
    {
        Debug.Log("Score is: " + Score);
        Score = Score + 1000;
        Score = Score + (int)(timeLeft * 10);
        finalScoreUI.gameObject.GetComponent<Text>().text = ("Score:" + (int)Score);
        if (Score > PlayerPrefs.GetInt("HighScore", 0))
        {
            PlayerPrefs.SetInt("HighScore", Score);
        }
    }
    void EndGame()
    {
        EndLevelUI.SetActive(true);
    }

}