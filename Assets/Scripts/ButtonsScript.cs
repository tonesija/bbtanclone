using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsScript : MonoBehaviour
{
    
    public void LoadGameScene() {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadAboutUsScene() {
        SceneManager.LoadScene("AboutScene");
    }

    public void LoadMainMenuScene() {
        SceneManager.LoadScene("MenuScene");
    }

}
