using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {
    
    private int maxEnemiesToSpawn = 2;
    private bool gameOver;
    private static GameManager instance;
    public static GameManager Instance => instance;

    [SerializeField] private GameObject enemiePrefab;
    [SerializeField] private Player player;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private ScoreManager scoreManager;

    private const string HighScorePrefKey = "HighScore";
    private int highScore;
    public int HighScore => highScore;

    private void Start() {
        instance = this;
        StartCoroutine(spawnEnemies());

        highScore = PlayerPrefs.GetInt(HighScorePrefKey);
    }

    private void OnEnable() {
        player.health = 5;
        scoreManager.score = 0;
        scoreManager.updateScore(scoreManager.score);
        player.gameObject.SetActive(true);
    }

    public void Enable() {
        gameObject.SetActive(true);
    }
    private IEnumerator spawnEnemies() {
        var zombieToSpawn = Random.Range(1, maxEnemiesToSpawn);
        for (int i = 0; i < zombieToSpawn; i++) {
            Instantiate(enemiePrefab, new Vector3(7, -3, 0), Quaternion.identity);
        }
        yield return new WaitForSeconds(7f);
        yield return spawnEnemies();
    }

    public void GameOver() {
        gameObject.SetActive(false);
        gameOverMenu.SetActive(true);

        if (scoreManager.score > highScore) {
            highScore = scoreManager.score;
            PlayerPrefs.SetInt(HighScorePrefKey, highScore);
            Debug.Log(highScore);
        }
    }
}
