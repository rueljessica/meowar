using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class QuitGame : MonoBehaviour {
    public void quit() {
        Application.Quit();
    }

    public void play() {
        SceneManager.LoadScene(0);
    }
}
