using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class GameOverMenu : MonoBehaviour {

    private LTDescr restartAnimation;
    public TMPro.TextMeshProUGUI highScore;
    [SerializeField] private GameObject gameOverMenu;

    private void OnEnable() {
        highScore.text = $"High Score: {GameManager.Instance.HighScore}";

        var rectTransform = GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(0, rectTransform.rect.height);

        rectTransform.LeanMoveY(0, 1f).setEaseInOutElastic().delay = 0.5f;

        if(restartAnimation == null) {
            restartAnimation = GetComponentInChildren<TMPro.TextMeshProUGUI>().gameObject.LeanScale(new Vector3(1.2f, 1.2f), 0.3f).setLoopPingPong();
        }
        restartAnimation.resume();
    }

    public void restart() {
        gameOverMenu.gameObject.SetActive(false);
        restartAnimation.pause();
        GameManager.Instance.Enable();
    }

    public void quit() {
        Application.Quit();
    }
}
