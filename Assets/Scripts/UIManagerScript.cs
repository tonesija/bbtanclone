using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManagerScript : MonoBehaviour
{
    public bool gameEnded;

    public GameObject GameOverUI;
    public GameObject ScoreUI;

    private GameObject player;

    private void Start(){
        gameEnded = false;
        GameOverUI.SetActive(false);
        ScoreUI.SetActive(true);
        player = GameObject.Find("Player");
    }

    private void Update() {
        int score = player.GetComponent<ShooterScript>().getScore();
        ScoreUI.GetComponentInChildren<TextMeshProUGUI>().SetText(score.ToString());

        if(gameEnded){
            player.GetComponent<ShooterScript>().setState(5);
            
            int highScore = PlayerPrefs.GetInt("HighScore", 0);
            if(score > highScore){
                highScore = score;
                PlayerPrefs.SetInt("HighScore", highScore);
            }

            GameOverUI.transform.Find("ScoreText").GetComponent<TextMeshProUGUI>().SetText("Score: " + score.ToString());
            GameOverUI.transform.Find("HighScoreText").GetComponent<TextMeshProUGUI>().SetText("High Score: " + highScore.ToString());

            GameOverUI.SetActive(true);
        }
    }
}
