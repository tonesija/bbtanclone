using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    private GameObject buttonSound;
    private void Start(){
        buttonSound = GameObject.Find("ButtonSound");
        DontDestroyOnLoad(buttonSound);
    }

    public void LoadGameScene() {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("GameScene");
    }

    public void LoadAboutUsScene() {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("AboutScene");
    }

    public void LoadMainMenuScene() {
        GameObject.Find("ButtonSound").GetComponent<AudioSource>().Play();
        SceneManager.LoadScene("MenuScene");
    }

}
