using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Finish : MonoBehaviour {

    private AudioSource finishSound;
    [SerializeField] private AudioSource bgSound;
    private bool levelCompleted = false;

    [SerializeField] private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start() {
        finishSound = GetComponent<AudioSource>();
    }


    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.name == "Player" && !levelCompleted) {
            finishSound.Play();
            bgSound.Stop();
            Debug.Log("Next level");
            levelCompleted = true;
            Invoke("nextLevel", 2f);
        }
    }

    private void nextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
